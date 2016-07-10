using System;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using OdinSoft.LIB.Configuration;
using OdinSoft.LIB.Queue;
using OdinSoft.UIC.Win.Control.Library;

namespace Sniffer.Client.Viewer
{
    public partial class MainViewer : DevExpress.XtraEditors.XtraForm, OdinSoft.UTL.Signer.ISigner
    {
        //-------------------------------------------------------------------------------------------------------------//
        // Creator
        //-------------------------------------------------------------------------------------------------------------//
        public MainViewer()
        {
            const string licenceKey = "OdinSoft Inc  (Single Developer)/8202290F138938808F2E5117716068";
            Quiksoft.EasyMail.Parse.License.Key = licenceKey;

            // 01) 사업장아이디를 설정합니다.
            this.m_cocd = this.GetConstant(MKindOfAppKey.CurrentCompanyID.ToString(), String.Empty);

            // 02) 로그인 창을 표시해서 인증요청을 합니다.
            if (this.Login() == false)
                Environment.Exit(0);

            InitializeComponent();

            this.Text += String.Format(", CID: {0}, PID: {1}", this.m_cocd, this.m_loginId);
        }

        //-------------------------------------------------------------------------------------------------------------//
        //
        //-------------------------------------------------------------------------------------------------------------//
        private string m_cocd = String.Empty;
        private string m_loginId = String.Empty;
        private Guid m_certKey = Guid.Empty;

        private OdinSoft.UTL.Signer.DlgSigner m_logDialog = null;
        private OdinSoft.UTL.Signer.DlgSigner g_logDialog
        {
            get
            {
                if (m_logDialog == null)
                    m_logDialog = new OdinSoft.UTL.Signer.DlgSigner(this);
                return m_logDialog;
            }
        }

        private QService m_qmaster = null;
        public QService QMaster
        {
            get
            {
                if (m_qmaster == null)
                    m_qmaster = new QService("tcp", "corptool", "Chat_Sniffer", "Sniffer", "V4.5.2013.10", false);

                return m_qmaster;
            }
        }

        //=========================================================================================
        // interface of signer for DlgSigner
        //=========================================================================================

        /// <summary>
        /// 프로그램 이름을 가져온다.
        /// </summary>
        /// <returns></returns>
        public string GetTitle()
        {
            return QMaster.ProductName;
        }

        /// <summary>
        /// 프로그램의 설명을 가져온다.
        /// </summary>
        /// <returns></returns>
        public string GetToolTip()
        {
            return QMaster.ProductName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetCategoryId()
        {
            return QMaster.CategoryId;
        }

        /// <summary>
        /// 프로그램의 ID를 가져온다.
        /// </summary>
        /// <returns></returns>
        public string GetProductId()
        {
            return QMaster.ProductId;
        }

        /// <summary>
        /// 프로그램의 버전을 가져온다.
        /// </summary>
        /// <returns></returns>
        public string GetPVersion()
        {
            return QMaster.pVersion;
        }

        /// <summary>
        /// 계정정보를 이용하여 멤버정보를 가져온다.
        /// </summary>
        /// <param name="p_certkey">SSO에 등록되어진 Guid Certi-Key</param>
        /// <param name="p_account">계정</param>
        /// <returns></returns>
        public DataSet GetMemberInfoByCode(Guid p_certkey, string p_account)
        {
            //return CQMonitor.GetMemberInfoByCode(p_certkey, p_account);
            return null;
        }

        /// <summary>
        /// 그룹이름를 이용하여 그룹정보를 가져온다.(Like검색)
        /// </summary>        
        /// <param name="p_groupName">그룹명</param>
        /// <returns></returns>
        public DataSet GetGroupInfoByName(Guid p_certkey, string p_groupName)
        {
            //return CQMonitor.GetGroupInfoByName(p_groupName);
            return null;
        }

        /// <summary>
        /// 인증처리
        /// </summary>
        /// <param name="p_categoryId"></param>
        /// <param name="p_productId">Product ID - 서버에서 자동설정</param>
        /// <param name="p_pVersion">Product Version - 서버에서 자동설정</param>
        /// <param name="p_account">계정</param>
        /// <param name="p_password">암호</param>
        /// <param name="p_expire">인증유지여부</param>
        /// <returns></returns>
        public Guid SignIn(string p_machineName, string p_ipAddress, string p_categoryId, string p_productId, string p_pVersion, string p_account, string p_password, bool p_expire)
        {
            //return CQMonitor.SignIn(p_account, p_password);
            return Guid.Empty;
        }

        /// <summary>
        /// 인증된 정보를 로그아웃 한다.
        /// </summary>
        /// <param name="p_certkey">SSO에 등록되어진 Guid Certi-Key</param>
        /// <param name="p_ipAddress">Host IP Address</param>
        /// <returns></returns>
        public bool SignOut(Guid p_certkey, string p_ipAddress)
        {
            var _result = false;

            //if (p_certkey != Guid.Empty)
            //    _result = CQMonitor.SignOut(p_certkey, p_ipAddress);

            return _result;
        }

        /// <summary>
        /// 인증된 정보가 유효한지 확인한다.
        /// </summary>
        /// <param name="p_certkey">SSO에 등록되어진 Guid Certi-Key</param>
        /// <param name="p_ipAddress">Host IP Address</param>
        /// <returns></returns>
        public bool IsValidSign(Guid p_certkey, string p_ipAddress)
        {
            //return CQMonitor.IsValidSign(p_certkey, p_ipAddress);
            return false;
        }

        /// <summary>
        /// 인증된 정보의 계정을 가져온다.
        /// </summary>
        /// <param name="p_certkey">SSO에 등록되어진 Guid Certi-Key</param>
        /// <param name="p_ipAddress">Host IP Address</param>
        /// <returns></returns>
        public string GetAccountId(Guid p_certkey, string p_ipAddress)
        {
            //return CQMonitor.GetAccountId();
            return String.Empty;
        }

        /// <summary>
        /// 암호를 변경한다.
        /// </summary>        
        /// <param name="p_password">암호</param>
        /// <returns></returns>
        public bool ChangePassword(Guid p_certkey, string p_password)
        {
            //return CQMonitor.ChangePassword(p_password);
            return false;
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Internal functions
        //-------------------------------------------------------------------------------------------------------------//
        private string GetConstant(string p_appkey, string defaultValue)
        {
            return (string)RegHelper.SNG.GetClient("corptool", "Sniffer", p_appkey, defaultValue);
        }

        /// <summary></summary>
        private bool Login()
        {
            var _result = false;

            try
            {
                g_logDialog.ClearLoginCertkey();
                g_logDialog.SetAutoLogin(false);
                g_logDialog.SetAutoPassword(false);

                // 01) 로그인 창을 표시합니다.
                if (g_logDialog.ShowDialog() != DialogResult.Cancel)
                {
                    this.m_loginId = g_logDialog.LoginId;
                    this.m_certKey = g_logDialog.CertificationKey;

                    _result = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return _result;
        }

        private bool AreYouLoginUser()
        {
            var _result = false;

            if (this.m_certKey != Guid.Empty && this.m_cocd.ToLower().Equals("1001") == true && this.m_loginId.ToLower().Equals("lisa") == true)
                _result = true;

            return _result;
        }

        //-------------------------------------------------------------------------------------------------------------//
        // Event Process
        //-------------------------------------------------------------------------------------------------------------//
        private void bbExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void bbMail_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.AreYouLoginUser() == true)
            {
                bool _reuse = false;

                foreach (Form _f in this.MdiChildren)
                {
                    if (_f.GetType().Name == "MailViewer")
                    {
                        _f.Activate();
                        _reuse = true;
                    }
                }

                if (_reuse == false)
                {
                    MailView.MailViewer _childform = new MailView.MailViewer()
                    {
                        MdiParent = this
                    };
                    _childform.Show();
                }
            }
        }

        private void bbChat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (this.AreYouLoginUser() == true)
            {
                bool _reuse = false;

                foreach (Form _f in this.MdiChildren)
                {
                    if (_f.GetType().Name == "ChatViewer")
                    {
                        _f.Activate();
                        _reuse = true;
                    }
                }

                if (_reuse == false)
                {
                    ChatView.ChatViewer _childform = new ChatView.ChatViewer()
                    {
                        MdiParent = this
                    };
                    _childform.Show();
                }
            }
        }

        private void bbEncrypt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool _reuse = false;

            foreach (Form _f in this.MdiChildren)
            {
                if (_f.GetType().Name == "ConnString")
                {
                    _f.Activate();
                    _reuse = true;
                }
            }

            if (_reuse == false)
            {
                Dialog.ConnString _childform = new Dialog.ConnString()
                {
                    MdiParent = this
                };
                _childform.Show();
            }
        }

        private void bbCascade_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void bbTileHorizontal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void bbTileVertical_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void bbArrangeIcons_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        //-------------------------------------------------------------------------------------------------------------
        // Maintanance UI
        //-------------------------------------------------------------------------------------------------------------
        private void MainViewer_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);
        }

        private void MainViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
        }

        private void bbLayoutReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LayoutHelper.RemoveFormLayout(this);
        }

        //-------------------------------------------------------------------------------------------------------------//
        // The End
        //-------------------------------------------------------------------------------------------------------------//
    }
}