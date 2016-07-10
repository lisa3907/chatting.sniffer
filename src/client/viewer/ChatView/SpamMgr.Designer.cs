namespace Sniffer.Client.Viewer.ChatView
{
    partial class SpamMgr
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SpamWorker = new OdinSoft.UIC.Win.Control.uBackgroundWorker(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.sbText = new DevExpress.XtraBars.BarStaticItem();
            this.sbProgress = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.fgSpam = new OdinSoft.UIC.Win.Control.DVX.uGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize) (this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.fgSpam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // SpamWorker
            // 
            this.SpamWorker.WorkerReportsProgress = true;
            this.SpamWorker.WorkerSupportsCancellation = true;
            this.SpamWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SpamWorker_DoWork);
            this.SpamWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SpamWorker_RunWorkerCompleted);
            this.SpamWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SpamWorker_ProgressChanged);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.sbText,
            this.sbProgress,
            this.bbRefresh,
            this.bbSave});
            this.barManager1.MaxItemId = 6;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Custom 4";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.sbText),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.sbProgress, "", false, true, true, 131)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Custom 4";
            // 
            // sbText
            // 
            this.sbText.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.sbText.Id = 0;
            this.sbText.Name = "sbText";
            this.sbText.TextAlignment = System.Drawing.StringAlignment.Near;
            this.sbText.Width = 32;
            // 
            // sbProgress
            // 
            this.sbProgress.Edit = this.repositoryItemProgressBar1;
            this.sbProgress.Id = 1;
            this.sbProgress.Name = "sbProgress";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbSave)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 2";
            // 
            // bbRefresh
            // 
            this.bbRefresh.Caption = "검색(&R)";
            this.bbRefresh.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbRefresh.Id = 4;
            this.bbRefresh.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Search;
            this.bbRefresh.Name = "bbRefresh";
            this.bbRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbRefresh_ItemClick);
            // 
            // bbSave
            // 
            this.bbSave.Caption = "저장(&S)";
            this.bbSave.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbSave.Id = 5;
            this.bbSave.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.save;
            this.bbSave.Name = "bbSave";
            this.bbSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSave_ItemClick);
            // 
            // fgSpam
            // 
            this.fgSpam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fgSpam.EmbeddedNavigator.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.fgSpam.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.fgSpam.EmbeddedNavigator.Name = "";
            this.fgSpam.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.fgSpam_EmbeddedNavigator_ButtonClick);
            this.fgSpam.Location = new System.Drawing.Point(0, 26);
            this.fgSpam.MainView = this.gridView1;
            this.fgSpam.Name = "fgSpam";
            this.fgSpam.Size = new System.Drawing.Size(600, 449);
            this.fgSpam.TabIndex = 17;
            this.fgSpam.UseEmbeddedNavigator = true;
            this.fgSpam.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn3});
            this.gridView1.GridControl = this.fgSpam;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsDetail.ShowDetailTabs = false;
            this.gridView1.OptionsDetail.SmartDetailExpand = false;
            this.gridView1.OptionsLayout.Columns.AddNewColumns = false;
            this.gridView1.OptionsLayout.Columns.RemoveOldColumns = false;
            this.gridView1.OptionsLayout.StoreAllOptions = true;
            this.gridView1.OptionsLayout.StoreAppearance = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsMenu.EnableFooterMenu = false;
            this.gridView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.ExpandAllGroups = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "보낸사람";
            this.gridColumn2.FieldName = "sender";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 201;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "스팸여부";
            this.gridColumn5.FieldName = "inclusion";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "SFID";
            this.gridColumn7.DisplayFormat.FormatString = "yyyy-MM-dd tt hh:mm:ss";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "SFID";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 130;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "SLMD";
            this.gridColumn3.DisplayFormat.FormatString = "yyyy-MM-dd tt hh:mm:ss";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "SLMD";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 126;
            // 
            // SpamMgr
            // 
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.fgSpam);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SpamMgr";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpamMgr_FormClosing);
            this.Load += new System.EventHandler(this.SpamMgr_Load);
            ((System.ComponentModel.ISupportInitialize) (this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.fgSpam)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OdinSoft.UIC.Win.Control.uBackgroundWorker SpamWorker;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem sbText;
        private DevExpress.XtraBars.BarEditItem sbProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem bbRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem bbSave;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private OdinSoft.UIC.Win.Control.DVX.uGridControl fgSpam;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}