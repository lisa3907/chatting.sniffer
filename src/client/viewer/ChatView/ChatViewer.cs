using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

using OdinSoft.LIB.Configuration;
using OdinSoft.LIB.Data;
using OdinSoft.LIB.Data.Collection;
using OdinSoft.UIC.Win.Control.Library;

using Sniffer.Proxy.CPacket;

namespace Sniffer.Client.Viewer.ChatView
{
    public partial class ChatViewer : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------//
        // Creator
        //-------------------------------------------------------------------------------------------------------------//
        public ChatViewer()
        {
            InitializeComponent();

            this.dtpFrDate.DateTime = DateTime.Now;
            this.dtpToDate.DateTime = DateTime.Now;

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

            this.bbSave.Enabled = false;

            this.bbRefresh.Enabled = false;
            this.bbCancel.Enabled = true;
            this.bbReset.Enabled = false;

            this.lboxChat.Enabled = false;
            this.fgChat.Enabled = false;
        }

        private void EndBind()
        {
            this.CheckChanges();

            this.bbRefresh.Enabled = true;
            this.bbCancel.Enabled = false;
            this.bbReset.Enabled = true;

            this.lboxChat.Enabled = true;
            this.fgChat.Enabled = true;

            this.Cursor = Cursors.Default;
        }

        private void ChangeColumnWidth()
        {
            GridView gridView = ((GridView)fgChat.MainView);
            gridView.BestFitColumns();

            int _width = gridView.GridControl.Width;
            foreach (GridColumn column in gridView.Columns)
                _width -= column.Width;

            if (_width > 0)
                gridView.Columns["content"].Width += _width;
        }

        private bool CheckChanges()
        {
            bool _enabled = false;

            if (this.fgChat.DataSource != null)
            {
                DataSet _ds = (this.fgChat.DataSource as DataView).Table.DataSet;
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
            DataSet _ds = (this.fgChat.DataSource as DataView).Table.DataSet;

            DataSet _deltaset = _ds.GetChanges();
            this.g_deltaHelper.UpdateDeltaSet(CPACKET_STRING.g_connString, _deltaset);
            _ds.AcceptChanges();
        }

        private DataSet RefreshDataSet()
        {
            var _result = new DataSet();

            try
            {
                var _sqlstr
                    = "SELECT   x.seqno, x.sentime, x.sendname, x.sendnick, x.senddept, \n"
                    + "         x.sender, x.content, y.receiver, y.recvname, y.recvnick, y.recvdept \n"
                    + "  FROM \n"
                    + "     ( \n"
                    + "         SELECT  a.seqno, a.sender, b.name as sendname, b.nick as sendnick, b.depart as senddept, \n"
                    + "                 a.sentime, a.content \n"
                    + "     	  FROM  TB_iEIP_MONITOR_MSGS a LEFT JOIN TB_iEIP_MONITOR_USRS b \n"
                    + "             ON  a.sender=b.mailadrs \n"
                    + "          WHERE  CONVERT(VARCHAR(10), a.sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) \n"
                    + "            AND  CONVERT(VARCHAR(10), a.sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) \n"
                    + "     ) x, \n"
                    + "     ( \n"
                    + "         SELECT  a.seqno, a.receiver, b.name as recvname, b.nick as recvnick, b.depart as recvdept \n"
                    + "           FROM  TB_iEIP_MONITOR_MSGS a LEFT JOIN TB_iEIP_MONITOR_USRS b \n"
                    + "             ON  a.receiver=b.mailadrs \n"
                    + "          WHERE  CONVERT(VARCHAR(10), a.sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) \n"
                    + "            AND  CONVERT(VARCHAR(10), a.sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) \n"
                    + "     ) y \n"
                    + " WHERE x.seqno=y.seqno \n";

                if (this.cbSpamView.Checked == false)
                {
                    _sqlstr
                    += "    AND  ( \n"
                    + "             sender in \n"
                    + "	            ( \n"
                    + "		            SELECT sender FROM TB_iEIP_MONITOR_MSGS_SPAM \n"
                    + "		            WHERE inclusion='V' \n"
                    + "	            ) \n"
                    + "             OR \n"
                    + "             receiver in \n"
                    + "	            ( \n"
                    + "		            SELECT sender FROM TB_iEIP_MONITOR_MSGS_SPAM \n"
                    + "		            WHERE inclusion='V' \n"
                    + "	            ) \n"
                    + "         ) \n";
                }

                _sqlstr
                    += " ORDER BY x.sentime DESC";

                g_dbps.Clear();
                {
                    g_dbps.Add("@frtime", SqlDbType.DateTime, dtpFrDate.DateTime);
                    g_dbps.Add("@totime", SqlDbType.DateTime, dtpToDate.DateTime);
                }

                DataTable _dt = g_dataHelper.SelectDataSet(CPACKET_STRING.g_connString, _sqlstr, g_dbps).Tables[0];
                _dt.TableName = "TB_iEIP_MONITOR_MSGS";
                _result.Merge(_dt);

                _sqlstr
                    = "SELECT	sender FROM TB_iEIP_MONITOR_MSGS \n"
                    + " WHERE	CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) \n"
                    + "   AND	CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) \n";

                if (this.cbSpamView.Checked == false)
                    _sqlstr += ""
                    + "    AND  ( \n"
                    + "             sender in \n"
                    + "	            ( \n"
                    + "		            SELECT sender FROM TB_iEIP_MONITOR_MSGS_SPAM \n"
                    + "		            WHERE inclusion='V' \n"
                    + "	            ) \n"
                    + "             OR \n"
                    + "             receiver in \n"
                    + "	            ( \n"
                    + "		            SELECT sender FROM TB_iEIP_MONITOR_MSGS_SPAM \n"
                    + "		            WHERE inclusion='V' \n"
                    + "	            ) \n"
                    + "         ) \n";

                _sqlstr += ""
                    + " GROUP	BY sender \n"
                    + " ORDER	BY sender";

                _dt = g_dataHelper.SelectDataSet(CPACKET_STRING.g_connString, _sqlstr, g_dbps).Tables[0];
                _dt.TableName = "TB_iEIP_MONITOR_SENDER";
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

        private int CompressMsg()
        {
            int _result = -1;

            try
            {
                this.BeginBind();

                string _sqlstr = "EXEC SP_iEIP_MONITOR_MSGS "
                        + "'" + dtpFrDate.DateTime.ToShortDateString() + "', "
                        + "'" + dtpToDate.DateTime.ToShortDateString() + "'";

                DataSet _ds = g_dataHelper.ExecuteDataSet(CPACKET_STRING.g_connString, _sqlstr);
                if (_ds.Tables[0].Rows.Count > 0)
                    _result = Convert.ToInt32(_ds.Tables[0].Rows[0][0]);
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

        private int RemoveByMailAdrs(string[] p_mails)
        {
            int _result = 0;

            try
            {
                this.BeginBind();

                var _sqlstr = ""
                        + "DELETE TB_iEIP_MONITOR_MSGS"
                        + " WHERE CONVERT(VARCHAR(10), sentime, 121) >= CONVERT(VARCHAR(10), @frtime, 121) "
                        + "   AND CONVERT(VARCHAR(10), sentime, 121) <= CONVERT(VARCHAR(10), @totime, 121) "
                        + "   AND (sender=@mailadrs OR receiver=@mailadrs)";


                foreach (string _mail in p_mails)
                {
                    g_dbps.Clear();

                    g_dbps.Add("@frtime", SqlDbType.DateTime, dtpFrDate.DateTime);
                    g_dbps.Add("@totime", SqlDbType.DateTime, dtpToDate.DateTime);
                    g_dbps.Add("@mailadrs", SqlDbType.NVarChar, _mail);

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

        private int InsertExclude(string[] p_mails, string p_inclusion)
        {
            int _result = 0;

            try
            {
                this.BeginBind();

                var _sqlstr = ""
                        + "IF EXISTS (SELECT sender FROM TB_iEIP_MONITOR_MSGS_SPAM WHERE sender=@sender) "
                        + "     DELETE TB_iEIP_MONITOR_MSGS_SPAM WHERE sender=@sender "
                        + Environment.NewLine
                        + "INSERT INTO TB_iEIP_MONITOR_MSGS_SPAM "
                        + "(sender, inclusion) VALUES (@sender, @inclusion) ";

                foreach (string _mail in p_mails)
                {
                    g_dbps.Clear();

                    g_dbps.Add("@sender", SqlDbType.NVarChar, _mail);
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

        //-------------------------------------------------------------------------------------------------------------//
        //
        //-------------------------------------------------------------------------------------------------------------//
        private void SenderFilterAndSelect(object p_filter)
        {
            string _selval = Convert.ToString(p_filter);
            if (String.IsNullOrEmpty(_selval) == false)
                (this.fgChat.DataSource as DataView).RowFilter = "sender = '" + p_filter + "' OR receiver = '" + p_filter + "'";
            else
                (this.fgChat.DataSource as DataView).RowFilter = "";

            foreach (int _row in this.fgChatView.GetSelectedRows())
                this.fgChatView.UnselectRow(_row);

            if (this.fgChatView.RowCount > 0)
                this.fgChatView.SelectRow(0);
        }

        //-------------------------------------------------------------------------------------------------------------//
        // 
        //-------------------------------------------------------------------------------------------------------------//
        private void ChatViewer_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);
            this.bbRefresh_ItemClick(null, null);
        }

        private void ChatViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
            this.SaveChanges();
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Running Worker and I am waiting .....
        //-------------------------------------------------------------------------------------------------------------//
        DataSet ChatGridSet = null;

        private void ChatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker _worker = sender as BackgroundWorker;
            e.Cancel = false;

            try
            {
                while (true)
                {
                    double _percent = 0.0;
                    _worker.ReportProgress((int)_percent);

                    if (_worker.CancellationPending)
                    {
                        e.Result = null;
                        e.Cancel = true;
                        break;
                    }

                    ChatGridSet = this.RefreshDataSet();

                    _percent = 90.0;
                    _worker.ReportProgress((int)_percent);

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

        private void ChatWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.sbProgress.EditValue = e.ProgressPercentage;

            if (e.ProgressPercentage < 100)
                this.sbText.Caption = e.ProgressPercentage + "% Completed";
            else
                this.sbText.Caption = "Binding....";
        }

        private void ChatWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled)
                {
                    this.sbText.Caption = "Status: Cancelled";
                    if (e.Result != null)
                    {
                        MessageBox.Show((string)e.Result);
                    }
                }
                else
                {
                    //------------------------------------------------------------------------------------------------------//
                    // Bindings
                    //------------------------------------------------------------------------------------------------------//
                    this.fgChat.DataSource = ChatGridSet.Tables["TB_iEIP_MONITOR_MSGS"].DefaultView;

                    this.lboxChat.SelectedIndexChanged -= new EventHandler(lboxChat_SelectedIndexChanged);
                    ChatGridSet.Tables["TB_iEIP_MONITOR_SENDER"].DefaultView.Sort = "sender";
                    foreach (DataRowView _dr in ChatGridSet.Tables["TB_iEIP_MONITOR_SENDER"].DefaultView)
                        this.lboxChat.Items.Add(_dr["sender"]);
                    this.lboxChat.SelectedIndexChanged += new EventHandler(lboxChat_SelectedIndexChanged);

                    if (this.cbListBoxUse.Checked == true)
                    {
                        if (this.lboxChat.Items.Count > 0)
                        {
                            this.lboxChat.SelectedIndex = 0;
                            this.SenderFilterAndSelect(this.lboxChat.SelectedValue);
                        }
                    }

                    this.ChangeColumnWidth();
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
                this.ActiveControl = this.fgChat;
            }
        }

        //-------------------------------------------------------------------------------------------------------------//
        //
        //-------------------------------------------------------------------------------------------------------------//
        private void bbRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.lboxChat.Items.Clear();

            if (this.ChatWorker.IsBusy == false)
            {
                this.SaveChanges();

                this.BeginBind();
                this.ChatWorker.RunWorkerAsync();
            }
        }

        private void bbCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.ChatWorker.CancelAsync();
        }

        private void bbSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.fgChat.DataSource != null)
            {
                (e.Item as BarLargeButtonItem).Enabled = false;
                this.SaveDataSet();
                (e.Item as BarLargeButtonItem).Enabled = true;

                this.CheckChanges();
            }
        }

        private void bbReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayoutHelper.RemoveFormLayout(this);
            (e.Item as BarLargeButtonItem).Enabled = false;
        }

        private void cbListBoxUse_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbListBoxUse.Checked == false)
            {
                this.SenderFilterAndSelect(String.Empty);
            }
            else
            {
                this.SenderFilterAndSelect(this.lboxChat.SelectedValue);
            }
        }

        void lboxChat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxControl _lbox = (sender as ListBoxControl);
            if (this.cbListBoxUse.Checked == true && _lbox.SelectedIndices.Count < 2)
            {
                this.SenderFilterAndSelect(_lbox.SelectedValue);
            }
        }

        private void bbClean_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.sbText.Caption = String.Format("{0} records deleted", this.CompressMsg());
        }

        private void tsDeleteMsg_Click(object sender, EventArgs e)
        {
            if (this.lboxChat.SelectedIndices.Count > 0)
            {
                List<string> _sb = new List<string>();
                foreach (int _ndx in this.lboxChat.SelectedIndices)
                    _sb.Add(Convert.ToString(this.lboxChat.Items[_ndx]));

                this.sbText.Caption = String.Format("{0} records removed", this.RemoveByMailAdrs(_sb.ToArray()));

                for (int i = this.lboxChat.SelectedIndices.Count - 1; i >= 0; i--)
                    this.lboxChat.Items.RemoveAt(this.lboxChat.SelectedIndices[i]);
            }
        }

        private void tsSpamMsg_Click(object sender, EventArgs e)
        {
            if (this.lboxChat.SelectedIndices.Count > 0)
            {
                List<string> _sb = new List<string>();
                foreach (int _ndx in this.lboxChat.SelectedIndices)
                    _sb.Add(Convert.ToString(this.lboxChat.Items[_ndx]));

                this.sbText.Caption = String.Format("{0} records inserted", this.InsertExclude(_sb.ToArray(), "S"));
            }
        }

        private void tsValidMsg_Click(object sender, EventArgs e)
        {
            if (this.lboxChat.SelectedIndices.Count > 0)
            {
                List<string> _sb = new List<string>();
                foreach (int _ndx in this.lboxChat.SelectedIndices)
                    _sb.Add(Convert.ToString(this.lboxChat.Items[_ndx]));

                this.sbText.Caption = String.Format("{0} records inserted", this.InsertExclude(_sb.ToArray(), "V"));
            }
        }

        private void cbSpamView_CheckedChanged(object sender, EventArgs e)
        {
            this.bbRefresh_ItemClick(null, null);
        }

        private void bbSpamMail_ItemClick(object sender, ItemClickEventArgs e)
        {
            SpamMgr _spam = new SpamMgr()
            {
                Owner = this,
                ShowInTaskbar = false
            };
            _spam.ShowDialog();
        }

        private void bbWidth_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.ChangeColumnWidth();
        }

        //-------------------------------------------------------------------------------------------------------------//
        // 
        //-------------------------------------------------------------------------------------------------------------//
    }
}