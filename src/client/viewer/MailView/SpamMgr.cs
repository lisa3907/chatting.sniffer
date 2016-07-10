using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using DevExpress.XtraBars;

using OdinSoft.LIB.Configuration;
using OdinSoft.LIB.Data;
using OdinSoft.LIB.Data.Collection;
using OdinSoft.UIC.Win.Control.Library;

using Sniffer.Proxy.CPacket;

namespace Sniffer.Client.Viewer.MailView
{
    public partial class SpamMgr : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        public SpamMgr()
        {
            InitializeComponent();
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
            this.bbSave.Enabled = false;

            this.fgSpam.Enabled = false;
        }

        private void EndBind()
        {
            this.fgSpam.Enabled = true;

            this.bbRefresh.Enabled = true;
            this.CheckChanges();

            this.Cursor = Cursors.Default;
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private bool CheckChanges()
        {
            bool _enabled = false;

            if (this.fgSpam.DataSource != null)
            {
                DataSet _ds = (this.fgSpam.DataSource as DataView).Table.DataSet;
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
            DataSet _ds = (this.fgSpam.DataSource as DataView).Table.DataSet;

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
                    + "SELECT   sender, sendipadrs, typeofsender, inclusion, SFID, SLMD"
                    + "  FROM   TB_iEIP_MONITOR_SMTP_SPAM"
                    + "  ORDER  BY sender";

                DataTable _dt = g_dataHelper.SelectDataSet(CPACKET_STRING.g_connString, _sqlstr, g_dbps).Tables[0];
                _dt.TableName = "TB_iEIP_MONITOR_SMTP_SPAM";
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

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private void SpamMgr_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);
            this.bbRefresh_ItemClick(null, null);
        }

        private void SpamMgr_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
            this.SaveChanges();
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Running Worker and I am waiting .....
        //-------------------------------------------------------------------------------------------------------------//
        DataSet SpamGridSet = null;
        
        private void SpamWorker_DoWork(object sender, DoWorkEventArgs e)
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

                    SpamGridSet = this.RefreshDataSet();

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

        private void SpamWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.sbProgress.EditValue = e.ProgressPercentage;

            if (e.ProgressPercentage < 100)
                this.sbText.Caption = e.ProgressPercentage + "% Completed";
            else
                this.sbText.Caption = "Binding....";
        }

        private void SpamWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                    this.fgSpam.DataSource = SpamGridSet.Tables["TB_iEIP_MONITOR_SMTP_SPAM"].DefaultView;

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
                this.ActiveControl = this.fgSpam;
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private void bbRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.SpamWorker.IsBusy == false)
            {
                this.SaveChanges();

                this.BeginBind();
                this.SpamWorker.RunWorkerAsync();
            }
        }

        private void bbSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.fgSpam.DataSource != null)
            {
                (e.Item as BarLargeButtonItem).Enabled = false;
                this.SaveDataSet();
                (e.Item as BarLargeButtonItem).Enabled = true;

                this.CheckChanges();
            }
        }

        private void fgSpam_EmbeddedNavigator_ButtonClick(object sender, DevExpress.XtraEditors.NavigatorButtonClickEventArgs e)
        {
            this.CheckChanges();
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
    }
}