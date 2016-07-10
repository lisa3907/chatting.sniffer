using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using Quiksoft.EasyMail.Parse;

using OdinSoft.LIB.Configuration;
using OdinSoft.LIB.Data;
using OdinSoft.LIB.Data.Collection;
using OdinSoft.UIC.Win.Control.Library;

using Sniffer.Proxy.CPacket;
using Sniffer.Proxy.Mail;

namespace Sniffer.Client.Viewer.MailView
{
    public partial class MailReader : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        public MailReader(GridView p_gridView)
        {
            InitializeComponent();

            this.wbMail.AllowWebBrowserDrop = false;
            this.m_gridView = p_gridView;
            //this.lbAttaches.SetSystemImageList(false);
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Private properties
        //-------------------------------------------------------------------------------------------------------------//
        private GridView m_gridView = null;

        private DataHelper m_dataHelper = null;
        private DataHelper g_dataHelper
        {
            get
            {
                if (m_dataHelper == null)
                    m_dataHelper = new DataHelper(MKindOfDatabase.MSSQL);

                return m_dataHelper;
            }
        }

        private DeltaHelper m_deltaHelper = null;
        private DeltaHelper g_deltaHelper
        {
            get
            {
                if (m_deltaHelper == null)
                    m_deltaHelper = new DeltaHelper(MKindOfDatabase.MSSQL);

                return m_deltaHelper;
            }
        }

        private DatParameters m_dbps = null;
        private DatParameters g_dbps
        {
            get
            {
                if (m_dbps == null)
                    m_dbps = new DatParameters();
                return m_dbps;
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private void MailReader_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);

            this.wbMail.AllowWebBrowserDrop = false;
            this.wbMail.IsWebBrowserContextMenuEnabled = false;
            this.wbMail.WebBrowserShortcutsEnabled = false;
            this.wbMail.ObjectForScripting = this;
            this.wbMail.ScriptErrorsSuppressed = true;
        }

        private void MailReader_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
        }

        private void MailReader_Activated(object sender, EventArgs e)
        {
            this.BodyBrowsing(NavigatorButtonType.Custom);
        }

        //-------------------------------------------------------------------------------------------------------------//
        //
        //-------------------------------------------------------------------------------------------------------------//
        private byte[] m_content = null;
        private int m_seqno = -1;

        private byte[] ReadContent(int p_seqno)
        {
            byte[] _result = null;

            try
            {
                var _sqlstr = ""
                        + "SELECT   content"
                        + " FROM    TB_iEIP_MONITOR_SMTP"
                        + " WHERE   seqno=@seqno";

                g_dbps.Clear();
                g_dbps.Add("@seqno", SqlDbType.Decimal, p_seqno);

                DataSet _ds = g_dataHelper.SelectDataSet(CPACKET_STRING.g_connString, _sqlstr, g_dbps);
                if (_ds.Tables[0].Rows.Count > 0)
                    _result = (byte[]) _ds.Tables[0].Rows[0][0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
            }

            return _result;
        }

        private void BodyBrowsing(NavigatorButtonType p_type)
        {
            if (p_type != NavigatorButtonType.Custom)
                m_gridView.GridControl.EmbeddedNavigator.NavigatableControl.DoAction(p_type);

            int _position = m_gridView.GridControl.EmbeddedNavigator.NavigatableControl.Position;
            int _norecords = m_gridView.GridControl.EmbeddedNavigator.NavigatableControl.RecordCount - 1;

            this.bbFirst.Enabled = true;
            this.bbPrev.Enabled = true;
            this.bbLast.Enabled = true;
            this.bbNext.Enabled = true;

            if (_position >= _norecords)
            {
                this.bbLast.Enabled = false;
                this.bbNext.Enabled = false;
            }

            if (_position <= 0)
            {
                this.bbFirst.Enabled = false;
                this.bbPrev.Enabled = false;
            }

            if (this.MailViewing.IsBusy == false)
            {
                RESULT_STRUC _struc = new RESULT_STRUC();
                _struc._position = _position;
                _struc._norecords = _norecords;
                this.MailViewing.RunWorkerAsync(_struc);
            }
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Mail Viewer
        //-------------------------------------------------------------------------------------------------------------//
        private class RESULT_STRUC
        {
            public smtparse _parse;
            public EmailMessage _emsg;
            public string _document;
            public int _position = 0;
            public int _norecords = 0;
        };

        private void MailViewing_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker _worker = sender as BackgroundWorker;

            e.Result = null;
            e.Cancel = false;

            try
            {
                while (true)
                {
                    double _percent = 0.0;
                    _worker.ReportProgress((int)_percent);
                    if (_worker.CancellationPending)
                    {
                        e.Cancel = true;
                        break;
                    }

                    RESULT_STRUC _rstruc = (RESULT_STRUC)e.Argument;

                    DataRow _dr = m_gridView.GetDataRow(_rstruc._position);
                    if (_dr != null)
                    {
                        _percent += 10.0;
                        _worker.ReportProgress((int)_percent);
                        if (_worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        int _seqno = Convert.ToInt32(_dr["seqno"]);
                        if (m_seqno != _seqno)
                        {
                            this.m_content = this.ReadContent(_seqno);
                            m_seqno = _seqno;
                        }

                        _percent += 10.0;
                        _worker.ReportProgress((int)_percent);
                        if (_worker.CancellationPending)
                        {
                            e.Cancel = true;
                            break;
                        }

                        if (this.m_content != null)
                        {
                            _rstruc._parse = new smtparse(this.m_content);
                            _rstruc._emsg = new EmailMessage(new MemoryStream(this.m_content));

                            BodyPart _part = _rstruc._emsg.BodyParts.GetBodyPart(BodyPartFormat.HTML);
                            if (_part == null)
                                _part = _rstruc._emsg.BodyParts.GetBodyPart(BodyPartFormat.Text);
                            if (_part == null)
                                _part = _rstruc._emsg.BodyParts.GetBodyPart(BodyPartFormat.Unknown);

                            if (_part != null)
                            {
                                string _bodytext = _part.BodyText;
                                string _filepath = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);

                                foreach (EmailMessagePart _mp in _rstruc._emsg.EmailMessageParts)
                                {
                                    string _filename = null;

                                    if (String.IsNullOrEmpty(_mp.ContentID) == false)
                                    {
                                        _filename = Path.Combine(
                                            _filepath,
                                            _mp.ContentID.Trim("<>".ToCharArray())
                                        );

                                        _bodytext = _bodytext.Replace("cid:" + _mp.ContentID.Trim("<>".ToCharArray()), _filename);

                                        using (FileStream _fs = new FileStream(_filename, FileMode.Create, FileAccess.ReadWrite))
                                        {
                                            _mp.DecodePart(_fs);
                                            _fs.Close();
                                        }
                                    }
                                }

                                _rstruc._document = _bodytext;
                            }
                            else
                            {
                                _rstruc._document = String.Empty;
                            }

                            _percent = 100.0;
                            _worker.ReportProgress((int)_percent);
                            if (_worker.CancellationPending)
                            {
                                e.Cancel = true;
                                break;
                            }

                            e.Result = _rstruc;
                        }
                        else
                        {
                            m_seqno = -1;
                        }
                    }

                    break;
                }
            }
            catch (Exception ex)
            {
                e.Result = "Raise error while read data from database.\r\n" + ex.Message;
                e.Cancel = true;
            }
        }

        private void MailViewing_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.sbProgress.EditValue = e.ProgressPercentage;

            if (e.ProgressPercentage < 100)
                this.sbText.Caption = e.ProgressPercentage + "% Completed";
            else
                this.sbText.Caption = "Binding....";
        }

        private void MailViewing_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    this.sbText.Caption = "Status: Cancelled";
                }
                else
                {
                    RESULT_STRUC _rstruc = (RESULT_STRUC)e.Result;

                    this.lbTitle.Text = _rstruc._parse["subject"];
                    this.lbFrom.Text = _rstruc._parse["from"];
                    this.lbTo.Text = _rstruc._parse["to"];
                    this.lbCc.Text = _rstruc._parse["cc"];
                    this.lbBcc.Text = _rstruc._parse["bcc"];

                    this.lbAttaches.Items.Clear();
                    foreach (Attachment _at in _rstruc._emsg.Attachments)
                    {
                        string _attname = _at.EmailMessagePart.Filename.Trim();
                        if (String.IsNullOrEmpty(_attname) == false)
                            this.lbAttaches.ItemAdd(_attname);
                    }

                    if (this.lbAttaches.Items.Count < 1)
                        this.pnAttaches.Visible = false;
                    else
                        this.pnAttaches.Visible = true;

                    if (String.IsNullOrEmpty(this.lbTitle.Text) == true)
                        this.lbTitle.Text = _rstruc._emsg.Subject;
                    if (String.IsNullOrEmpty(this.lbFrom.Text) == true)
                        this.lbFrom.Text = _rstruc._emsg.From.ToString();
                    if (String.IsNullOrEmpty(this.lbTo.Text) == true)
                        this.lbTo.Text = _rstruc._emsg.To.ToString();
                    if (String.IsNullOrEmpty(this.lbCc.Text) == true)
                        this.lbCc.Text = _rstruc._emsg.CC.ToString();
                    if (String.IsNullOrEmpty(this.lbBcc.Text) == true)
                        this.lbBcc.Text = _rstruc._emsg.BCC.ToString();

                    if (_rstruc._emsg.Date != null)
                        this.lbSent.Text = _rstruc._emsg.Date.Date.ToString("yyyy-MM-dd tt hh:mm:ss");

                    sbPosition.Caption = String.Format("record {0} of {1}", _rstruc._position + 1, _rstruc._norecords + 1);

                    this.wbMail.DocumentText = _rstruc._document;
                    this.sbText.Caption = "Status: Completed";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                this.sbProgress.EditValue = 0;
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private void wbMail_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.sbProgress.EditValue = 0;
        }

        private void wbMail_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            double _percentage = 0;
            if (e.MaximumProgress > 0 && e.CurrentProgress > 0)
            {
                _percentage = (double) e.CurrentProgress / (double) e.MaximumProgress;
            }
            else
            {
                _percentage = Convert.ToDouble(this.sbProgress.EditValue);
                if (_percentage < 0 || _percentage > 100 || _percentage == Double.NaN)
                    _percentage = 0;
                _percentage += 10;
            }

            this.sbProgress.EditValue = _percentage;
        }

        private void wbMail_StatusTextChanged(object sender, EventArgs e)
        {
            this.sbText.Caption = (sender as WebBrowser).StatusText;
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private void bbFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_gridView != null)
            {
                this.BodyBrowsing(NavigatorButtonType.First);
            }
        }

        private void bbLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_gridView != null)
            {
                this.BodyBrowsing(NavigatorButtonType.Last);
            }
        }

        private void bbPrev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_gridView != null)
            {
                this.BodyBrowsing(NavigatorButtonType.Prev);
            }
        }

        private void bbNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_gridView != null)
            {
                this.BodyBrowsing(NavigatorButtonType.Next);
            }
        }

        private void bbDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (m_gridView != null)
            {
                if (m_gridView.SelectedRowsCount > 0)
                {
                    int _position = m_gridView.GridControl.EmbeddedNavigator.NavigatableControl.Position;

                    m_gridView.GridControl.EmbeddedNavigator.NavigatableControl.DoAction(NavigatorButtonType.Remove);
                    m_gridView.SelectRow(_position);

                    this.BodyBrowsing(NavigatorButtonType.Custom);
                }
            }
        }

        private void tsOpenFile_Click(object sender, EventArgs e)
        {

        }

        private void tsSaveFile_Click(object sender, EventArgs e)
        {
            if (this.lbAttaches.SelectedIndices.Count > 0)
            {
                string _filename = Convert.ToString(this.lbAttaches.SelectedValue);

                SaveFileDialog _saveDlg = new SaveFileDialog()
                {
                    Title = "Save as attache file",
                    FileName = _filename
                };
                _saveDlg.ShowDialog();

                if (String.IsNullOrEmpty(_saveDlg.FileName) == false)
                {
                    int _position = m_gridView.GridControl.EmbeddedNavigator.NavigatableControl.Position;
                    DataRow _dr = m_gridView.GetDataRow(_position);
                    if (_dr != null)
                    {
                        int _seqno = Convert.ToInt32(_dr["seqno"]);
                        if (m_seqno != _seqno)
                        {
                            this.m_content = this.ReadContent(_seqno);
                            m_seqno = _seqno;
                        }

                        EmailMessage _emsg = new EmailMessage(new MemoryStream(this.m_content));
                        
                        using (FileStream _fs = new FileStream(_saveDlg.FileName, FileMode.Create, FileAccess.ReadWrite))
                        {
                            foreach (Attachment _at in _emsg.Attachments)
                            {
                                string _attname = _at.EmailMessagePart.Filename.Trim();
                                if (_attname == _filename)
                                    _at.EmailMessagePart.DecodePart(_fs);
                            }

                            _fs.Close();
                        }
                    }
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
    }
}