using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;

using Quiksoft.EasyMail.Parse;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;

using OdinSoft.LIB.Configuration;
using OdinSoft.LIB.Data;
using OdinSoft.LIB.Data.Collection;
using OdinSoft.UIC.Win.Control.Library;

using Sniffer.Proxy.CPacket;
using Sniffer.Proxy.Mail;

namespace Sniffer.Client.Viewer.MailView
{
    public partial class MailViewer : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------//
        // Creator
        //-------------------------------------------------------------------------------------------------------------//
        public MailViewer()
        {
            InitializeComponent();

            this.dtpFrDate.DateTime = DateTime.Now;
            this.dtpToDate.DateTime = DateTime.Now;

            this.wbMail.AllowWebBrowserDrop = false;

            this.EndBind();
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Private properties
        //-------------------------------------------------------------------------------------------------------------//
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
        
        //-------------------------------------------------------------------------------------------------------------//
        // Private Functions
        //-------------------------------------------------------------------------------------------------------------//
        private void BeginBind()
        {
            this.Cursor = Cursors.WaitCursor;

            this.bbRefresh.Enabled = false;
            this.bbCancel.Enabled = true;
            this.bbDelete.Enabled = false;
            this.bbSave.Enabled = false;

            this.bbReset.Enabled = false;
            this.bbOpen.Enabled = false;
            this.bbView.Enabled = false;

            this.bbClean.Enabled = false;
            this.bbSpam.Enabled = false;

            this.lboxMail.Enabled = false;
            this.fgMail.Enabled = false;
        }

        private void EndBind()
        {
            this.bbRefresh.Enabled = true;
            this.bbCancel.Enabled = false;
            this.bbDelete.Enabled = true;

            this.CheckChanges();

            this.bbReset.Enabled = true;
            this.bbOpen.Enabled = true;
            this.bbView.Enabled = true;

            this.bbClean.Enabled = true;
            this.bbSpam.Enabled = true;

            this.lboxMail.Enabled = true;
            this.fgMail.Enabled = true;

            this.Cursor = Cursors.Default;
        }

        private bool CheckChanges()
        {
            bool _enabled = false;

            if (this.fgMail.DataSource != null)
            {
                DataSet _ds = (this.fgMail.DataSource as DataView).Table.DataSet;
                if (_ds.HasChanges() == true)
                    _enabled = true;
            }

            this.bbSave.Enabled = _enabled;

            return _enabled;
        }

        private void SaveChanges()
        {
            if (this.CheckChanges() == true)
            {
                DialogResult _dr = MessageBox.Show(
                    "변경된 자료가 있습니다. 저장 하시겠습니까?", "SaveDialog", MessageBoxButtons.OKCancel
                    );
                if (_dr == DialogResult.OK)
                    this.SaveDataSet();
            }
        }

        private void SaveDataSet()
        {
            DataSet _ds = (this.fgMail.DataSource as DataView).Table.DataSet;

            DataSet _deltaset = _ds.GetChanges();
            this.g_deltaHelper.UpdateDeltaSet(CPACKET_STRING.g_connString, _deltaset);
            _ds.AcceptChanges();
        }

        private DataSet RefreshDataSet()
        {
            var _result = new DataSet();

            try
            {
                var _sqlstr = ""
                    + "SELECT   seqno, sender, sendipadrs, sendport, receivers, recvipadrs, attach, title, sentime, protocol, "
                    + "         command, response, validation, completed, timeout, "
                    + "         REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') as domain "
                    + "  FROM   TB_iEIP_MONITOR_SMTP"
                    + "  WHERE  CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) "
                    + "    AND  CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) ";

                if (this.cbSpamView.Checked == false)
                    _sqlstr += ""
                    + "    AND  ( "
                    + "             REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') in "
                    + "	            ( "
                    + "		            SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM "
                    + "		            WHERE typeofsender='D' AND inclusion='V' "
                    + "	            ) "
                    + "	        OR  sender in "
                    + "	            ( "
                    + "		            SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM "
                    + "		            WHERE typeofsender='M' AND inclusion='V' "
                    + "	            ) "
                    + "         ) ";

                _sqlstr += ""
                    + "  ORDER  BY seqno DESC";

                g_dbps.Clear();

                g_dbps.Add("@frtime", SqlDbType.DateTime, dtpFrDate.DateTime);
                g_dbps.Add("@totime", SqlDbType.DateTime, dtpToDate.DateTime);

                DataTable _dt = g_dataHelper.SelectDataSet(CPACKET_STRING.g_connString, _sqlstr, g_dbps).Tables[0];
                _dt.TableName = "TB_iEIP_MONITOR_SMTP";
                _result.Merge(_dt);

                _sqlstr = ""
                    + "SELECT * FROM "
                    + " ( "
                    + "     SELECT   REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') as domain "
                    + "       FROM   TB_iEIP_MONITOR_SMTP"
                    + "      WHERE   CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) "
                    + "        AND   CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) ";

                if (this.cbSpamView.Checked == false)
                    _sqlstr += ""
                    + "    AND  ( "
                    + "             REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') in "
                    + "	            ( "
                    + "		            SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM "
                    + "		            WHERE typeofsender='D' AND inclusion='V' "
                    + "	            ) "
                    + "	        OR  sender in "
                    + "	            ( "
                    + "		            SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM "
                    + "		            WHERE typeofsender='M' AND inclusion='V' "
                    + "	            ) "
                    + "         ) ";
                    
                _sqlstr += ""
                    + " ) x "
                    + "GROUP BY domain ";

                _dt = g_dataHelper.SelectDataSet(CPACKET_STRING.g_connString, _sqlstr, g_dbps).Tables[0];
                _dt.TableName = "SENDER";
                _result.Merge(_dt);
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

        private int RemoveByMailAddress(string[] p_mails)
        {
            int _result = -1;

            try
            {
                this.BeginBind();

                var _sqlstr = ""
                        + "DELETE TB_iEIP_MONITOR_SMTP"
                        + " WHERE CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) "
                        + "   AND CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) ";

                _sqlstr += "   AND (";
                for (int i = p_mails.Length - 1 ; i >= 0 ; i--)
                {
                    _sqlstr += "sender = '" + p_mails[i] + "'";
                    if (i > 0)
                        _sqlstr += " OR ";
                }
                _sqlstr += ")";

                g_dbps.Clear();

                g_dbps.Add("@frtime", SqlDbType.DateTime, dtpFrDate.DateTime);
                g_dbps.Add("@totime", SqlDbType.DateTime, dtpToDate.DateTime);

                _result = g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                this.EndBind();
            }

            return _result;
        }

        private int InsertSpam(string[] p_mails, string p_type, string p_inclusion)
        {
            int _result = 0;

            try
            {
                this.BeginBind();

                var _sqlstr = ""
                        + "IF EXISTS (SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM WHERE sender=@sender) "
	                    + "     DELETE TB_iEIP_MONITOR_SMTP_SPAM WHERE sender=@sender "
                        + Environment.NewLine
                        + "INSERT INTO TB_iEIP_MONITOR_SMTP_SPAM "
                        + "(sender, typeofsender, inclusion) VALUES (@sender, @typeofsender, @inclusion) ";

                foreach (string _mail in p_mails)
                {
                    g_dbps.Clear();

                    g_dbps.Add("@sender", SqlDbType.NVarChar, _mail);
                    g_dbps.Add("@typeofsender", SqlDbType.NVarChar, p_type);
                    g_dbps.Add("@inclusion", SqlDbType.NVarChar, p_inclusion);

                    _result += g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                this.EndBind();
            }

            return _result;
        }

        private int RemoveByMailDomain(string[] p_domains)
        {
            int _result = -1;

            try
            {
                this.BeginBind();

                var _sqlstr = ""
                        + "DELETE TB_iEIP_MONITOR_SMTP"
                        + " WHERE CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) "
                        + "   AND CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) ";

                _sqlstr += "   AND (";
                for (int i = p_domains.Length - 1 ; i >= 0 ; i--)
                {
                    _sqlstr += "REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') = '" + p_domains[i] + "'";
                    if (i > 0)
                        _sqlstr += " OR ";
                }
                _sqlstr += ")";

                g_dbps.Clear();

                g_dbps.Add("@frtime", SqlDbType.DateTime, dtpFrDate.DateTime);
                g_dbps.Add("@totime", SqlDbType.DateTime, dtpToDate.DateTime);

                _result = g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                this.EndBind();
            }

            return _result;
        }

        private int CleanSpamMail()
        {
            int _result = -1;

            try
            {
                this.BeginBind();

                var _sqlstr = ""
                        + "DELETE TB_iEIP_MONITOR_SMTP "
                        + " WHERE CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) "
                        + "   AND CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) "
                        + "   AND "
                        + "     ( "
                        + "         ISNULL(sender,'')='' OR content is null OR response != '250' "
                        + "         OR "
                        + "         ( "
                        + "             sender in "
                        + "             ( "
                        + "                 SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM "
                        + "                  WHERE typeofsender='M' AND inclusion='S' "
                        + "             ) "
                        + "         ) "
                        + "         OR "
                        + "         ( "
                        + "             REPLACE(SUBSTRING(sender, CHARINDEX('@', sender)+1, 128), '>', '') not in "
                        + "             ( "
                        + "                 SELECT sender FROM TB_iEIP_MONITOR_SMTP_SPAM "
                        + "                  WHERE typeofsender='D' AND inclusion='V' "
                        + "             ) "
                        + "         ) "
                        + "     )";

                g_dbps.Clear();

                g_dbps.Add("@frtime", SqlDbType.DateTime, dtpFrDate.DateTime);
                g_dbps.Add("@totime", SqlDbType.DateTime, dtpToDate.DateTime);

                _result = g_dataHelper.ExecuteText(CPACKET_STRING.g_connString, _sqlstr, g_dbps);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                this.EndBind();
            }

            return _result;
        }
        
        //-------------------------------------------------------------------------------------------------------------//
        //
        //-------------------------------------------------------------------------------------------------------------//
        private void DomainMailFilterAndSelect(string p_filter)
        {
            if (String.IsNullOrEmpty(p_filter) == false)
                (this.fgMail.DataSource as DataView).RowFilter = "domain = '" + p_filter + "'";
            else
                (this.fgMail.DataSource as DataView).RowFilter = "";

            foreach (int _row in this.fgMailView.GetSelectedRows())
                this.fgMailView.UnselectRow(_row);

            if (this.fgMailView.RowCount > 0)
            {
                this.fgMailView.GridControl.EmbeddedNavigator.NavigatableControl.DoAction(NavigatorButtonType.First);
                this.fgMailView.SelectRow(0);
                this.BodyBrowsing(this.fgMailView);
            }
        }

        private void BodyBrowsing(object sender)
        {
            GridView _gridView = (GridView)sender;
            if (_gridView.GetSelectedRows().Length > 0)
            {
                int _position = _gridView.GridControl.EmbeddedNavigator.NavigatableControl.Position;
                if (this.MailViewing.IsBusy == false)
                    this.MailViewing.RunWorkerAsync(_position);
            }
        }

        private void ContentView(object sender)
        {
            GridView _gridView = (GridView) sender;

            if (_gridView.GetSelectedRows().Length > 0)
            {
                DataRow _dr = _gridView.GetDataRow(_gridView.GridControl.EmbeddedNavigator.NavigatableControl.Position);
                if (_dr != null)
                {
                    int _seqno = Convert.ToInt32(_dr["seqno"]);
                    if (this.m_seqno != _seqno)
                    {
                        this.m_content = this.ReadContent(_seqno);
                        this.m_seqno = _seqno;
                    }

                    if (this.m_content != null)
                    {
                        MailContent _mail = new MailContent(this.m_content);
                        _mail.Owner = this;
                        _mail.ShowInTaskbar = false;
                        _mail.ShowDialog();
                    }
                    else
                        this.m_seqno = -1;
                }
            }
        }

        private void ContentRead(object sender)
        {
            GridView _gridView = (GridView) sender;

            if (_gridView.GetSelectedRows().Length > 0)
            {
                DataRow _dr = _gridView.GetDataRow(_gridView.GridControl.EmbeddedNavigator.NavigatableControl.Position);
                if (_dr != null)
                {
                    MailReader _mail = new MailReader(_gridView);
                    _mail.Owner = this;
                    _mail.ShowInTaskbar = false;
                    _mail.ShowDialog();
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Event Process
        //-------------------------------------------------------------------------------------------------------------//
        private void MailViewer_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);

            this.wbMail.AllowWebBrowserDrop = false;
            this.wbMail.IsWebBrowserContextMenuEnabled = false;
            this.wbMail.WebBrowserShortcutsEnabled = false;
            this.wbMail.ObjectForScripting = this;
            this.wbMail.ScriptErrorsSuppressed = true;

            this.bbRefresh_ItemClick(null, null);

            //this.lbAttaches.SetSystemImageList(false);
        }

        private void MailViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
            this.SaveChanges();
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Running Worker and I am waiting .....
        //-------------------------------------------------------------------------------------------------------------//
        DataSet MailGridSet = null;

        private void MailRefresh_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker _worker = sender as BackgroundWorker;
            e.Cancel = false;

            try
            {
                while (true)
                {
                    double _percent = 0.0;
                    _worker.ReportProgress((int) _percent);

                    if (_worker.CancellationPending)
                    {
                        e.Result = null;
                        e.Cancel = true;
                        break;
                    }

                    MailGridSet = this.RefreshDataSet();

                    _percent = 90.0;
                    _worker.ReportProgress((int) _percent);

                    if (_worker.CancellationPending)
                    {
                        e.Result = null;
                        e.Cancel = true;
                        break;
                    }

                    break;
                }

                if (e.Cancel == false)
                {
                    e.Result = null;
                }
            }
            catch (Exception ex)
            {
                e.Result = "Raise error while read data from database.\r\n" + ex.Message;
                e.Cancel = true;
            }
        }

        private void MailRefresh_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.sbProgress.EditValue = e.ProgressPercentage;

            if (e.ProgressPercentage < 100)
                this.sbText.Caption = e.ProgressPercentage + "% Completed";
            else
                this.sbText.Caption = "Binding....";
        }

        private void MailRefresh_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    this.sbText.Caption = "Status: Cancelled";
                    if (e.Result != null)
                    {
                        MessageBox.Show((string) e.Result);
                    }
                }
                else
                {
                    //------------------------------------------------------------------------------------------------------//
                    // Bindings
                    //------------------------------------------------------------------------------------------------------//
                    this.fgMail.DataSource = MailGridSet.Tables["TB_iEIP_MONITOR_SMTP"].DefaultView;
                    //this.fgMail.DataMember = "TB_iEIP_MONITOR_SMTP";

                    this.lboxMail.SelectedIndexChanged -= new EventHandler(lboxMail_SelectedIndexChanged);
                    MailGridSet.Tables["SENDER"].DefaultView.Sort = "domain";
                    foreach (DataRowView _dr in MailGridSet.Tables["SENDER"].DefaultView)
                        this.lboxMail.Items.Add(_dr["domain"]);
                    this.lboxMail.SelectedIndexChanged += new EventHandler(lboxMail_SelectedIndexChanged);

                    string _selval = String.Empty;
                    if (this.cbListBoxUse.Checked == true)
                        _selval = Convert.ToString(this.lboxMail.SelectedValue);
                    this.DomainMailFilterAndSelect(_selval);

                    this.fgMailView.BestFitColumns();
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
                this.EndBind();
                this.ActiveControl = this.fgMail;
            }
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Mail Viewer
        //-------------------------------------------------------------------------------------------------------------//
        private struct RESULT_STRUC
        {
            public smtparse _parse;
            public EmailMessage _emsg;
            public string _document;
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

                    int _position = (int)e.Argument;
                    DataRow _dr = this.fgMailView.GetDataRow(_position);
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
                        if (this.m_seqno != _seqno)
                        {
                            this.m_content = this.ReadContent(_seqno);
                            this.m_seqno = _seqno;
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
                            RESULT_STRUC _rstruc = new RESULT_STRUC();

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
                            this.m_seqno = -1;
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

                    this.wbMail.DocumentText = _rstruc._document;

                    this.CheckChanges();
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
        
        //-------------------------------------------------------------------------------------------------------------//
        //
        //-------------------------------------------------------------------------------------------------------------//
        private byte[] m_content = null;
        private int m_seqno = -1;

        private void bbSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.fgMail.DataSource != null)
            {
                (e.Item as BarLargeButtonItem).Enabled = false;
                this.SaveDataSet();
                (e.Item as BarLargeButtonItem).Enabled = true;

                this.CheckChanges();
            }
        }

        private void bbRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.lboxMail.Items.Clear();

            if (this.MailRefresh.IsBusy == false)
            {
                this.SaveChanges();

                this.BeginBind();
                this.MailRefresh.RunWorkerAsync();
            }
        }

        private void bbCancel_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.MailRefresh.CancelAsync();
        }

        private void bbReset_ItemClick(object sender, ItemClickEventArgs e)
        {
            LayoutHelper.RemoveFormLayout(this);
            (e.Item as BarLargeButtonItem).Enabled = false;
        }

        private void bbOpen_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ContentRead(this.fgMailView);
        }

        private void bbView_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ContentView(this.fgMailView);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            //Debug.WriteLine("gridView1_DoubleClick");
            this.ContentRead(sender);
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //Debug.WriteLine("gridView1_FocusedRowChanged");
            this.BodyBrowsing(sender);
        }

        private void gridView1_GotFocus(object sender, EventArgs e)
        {
            //Debug.WriteLine("gridView1_GotFocus");
            this.BodyBrowsing(sender);
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            //Debug.WriteLine("gridView1_Click");
            this.BodyBrowsing(sender);
        }

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

        private void fgMail_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            //Debug.WriteLine("fgMail_EmbeddedNavigator_ButtonClick");
            if (e.Button.ImageIndex == 10) // CancelDelete
            {
                if (this.fgMail.DataSource != null)
                {
                    DataSet _ds = (this.fgMail.DataSource as DataView).Table.DataSet;
                    _ds.RejectChanges();
                }
            }
        }

        private void fgMail_ProcessGridKey(object sender, KeyEventArgs e)
        {
            //Debug.WriteLine("fgMail_ProcessGridKey");
            if (e.KeyCode == Keys.Delete)
            {
                var _button = this.fgMailView.GridControl.EmbeddedNavigator.Buttons.Remove;
                this.fgMailView.GridControl.EmbeddedNavigator.Buttons.DoClick(_button);
                //this.fgMailView.GridControl.EmbeddedNavigator.Buttons.Remove.DoClick();
            }
        }

        private void lboxMail_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxControl _lbox = (sender as ListBoxControl);
            if (this.cbListBoxUse.Checked == true && _lbox.SelectedIndices.Count < 2)
            {
                //Debug.WriteLine("lboxMail_SelectedIndexChanged");
                string _selval = Convert.ToString(_lbox.SelectedValue);
                if (String.IsNullOrEmpty(_selval) == false)
                    this.DomainMailFilterAndSelect(_selval);
            }
        }

        private void lboxMail_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Debug.WriteLine("lboxMail_PreviewKeyDown");

            if (e.KeyData == Keys.Delete)
                this.tsDeleteDomain_Click(null, null);
        }

        private void tsDeleteDomain_Click(object sender, EventArgs e)
        {
            if (this.lboxMail.SelectedIndices.Count > 0)
            {
                List<string> _sb = new List<string>();
                foreach (int _ndx in this.lboxMail.SelectedIndices)
                    _sb.Add(Convert.ToString(this.lboxMail.Items[_ndx]));

                this.RemoveByMailDomain(_sb.ToArray());

                for (int i = this.lboxMail.SelectedIndices.Count - 1 ; i >= 0 ; i--)
                    this.lboxMail.Items.RemoveAt(this.lboxMail.SelectedIndices[i]);
            }
        }

        private void cbListBoxUse_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbListBoxUse.Checked == false)
            {
                this.DomainMailFilterAndSelect(String.Empty);
            }
            else
            {
                string _selval = Convert.ToString(this.lboxMail.SelectedValue);
                if (String.IsNullOrEmpty(_selval) == false)
                    this.DomainMailFilterAndSelect(_selval);
            }
        }

        private void bbClean_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.sbText.Caption = String.Format("{0} record(s) deleted", this.CleanSpamMail());
        }

        private void bbDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (this.ActiveControl == this.lboxMail)
            {
                this.tsDeleteDomain_Click(null, null);
            }
            else
            {
                var _button = this.fgMailView.GridControl.EmbeddedNavigator.Buttons.Remove;
                this.fgMailView.GridControl.EmbeddedNavigator.Buttons.DoClick(_button);
                
                //this.fgMailView.GridControl.EmbeddedNavigator.Buttons.Remove.DoClick();
                this.CheckChanges();
            }
        }

        private void bbSpam_ItemClick(object sender, ItemClickEventArgs e)
        {
            SpamMgr _spam = new SpamMgr();
            _spam.Owner = this;
            _spam.ShowInTaskbar = false;
            _spam.ShowDialog();
        }

        private void tsDeleteMail_Click(object sender, EventArgs e)
        {
            var _button = this.fgMailView.GridControl.EmbeddedNavigator.Buttons.Remove;
            this.fgMailView.GridControl.EmbeddedNavigator.Buttons.DoClick(_button);

            //this.fgMailView.GridControl.EmbeddedNavigator.Buttons.Remove.DoClick();
            this.CheckChanges();
        }

        private void tsSpamMail_Click(object sender, EventArgs e)
        {
            if (this.fgMailView.GetSelectedRows().Length > 0)
            {
                List<string> _sb = new List<string>();
                foreach (int _position in this.fgMailView.GetSelectedRows())
                {
                    DataRow _dr = this.fgMailView.GetDataRow(_position);
                    _sb.Add(Convert.ToString(_dr["sender"]));
                }

                this.InsertSpam(_sb.ToArray(), "M", "S");
            }
        }

        private void tsValidMail_Click(object sender, EventArgs e)
        {
            if (this.fgMailView.GetSelectedRows().Length > 0)
            {
                List<string> _sb = new List<string>();
                foreach (int _position in this.fgMailView.GetSelectedRows())
                {
                    DataRow _dr = this.fgMailView.GetDataRow(_position);
                    _sb.Add(Convert.ToString(_dr["sender"]));
                }

                this.InsertSpam(_sb.ToArray(), "M", "V");
            }
        }

        private void tsSpamDomain_Click(object sender, EventArgs e)
        {
            if (this.lboxMail.SelectedIndices.Count > 0)
            {
                List<string> _sb = new List<string>();
                foreach (int _ndx in this.lboxMail.SelectedIndices)
                    _sb.Add(Convert.ToString(this.lboxMail.Items[_ndx]));

                this.InsertSpam(_sb.ToArray(), "D", "S");
            }
        }

        private void tsValidDomain_Click(object sender, EventArgs e)
        {
            if (this.lboxMail.SelectedIndices.Count > 0)
            {
                List<string> _sb = new List<string>();
                foreach (int _ndx in this.lboxMail.SelectedIndices)
                    _sb.Add(Convert.ToString(this.lboxMail.Items[_ndx]));

                this.InsertSpam(_sb.ToArray(), "D", "V");
            }
        }

        private void cbSpamView_CheckedChanged(object sender, EventArgs e)
        {
            this.bbRefresh_ItemClick(null, null);
        }

        private void bbWidth_ItemClick(object sender, ItemClickEventArgs e)
        {
            ((GridView)fgMail.MainView).BestFitColumns();
        }

        //-------------------------------------------------------------------------------------------------------------//
        // The End
        //-------------------------------------------------------------------------------------------------------------//
    }
}