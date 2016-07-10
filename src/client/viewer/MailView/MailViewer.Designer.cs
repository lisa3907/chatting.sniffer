namespace Sniffer.Client.Viewer.MailView
{
    partial class MailViewer
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
            this.fgMail = new OdinSoft.UIC.Win.Control.DVX.uGridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsDeleteMail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSpamMail = new System.Windows.Forms.ToolStripMenuItem();
            this.tsValidMail = new System.Windows.Forms.ToolStripMenuItem();
            this.fgMailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbCancel = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbClean = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbReset = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbSpam = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbOpen = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbView = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbWidth = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.sbText = new DevExpress.XtraBars.BarStaticItem();
            this.sbProgress = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pmDeleteDomain = new DevExpress.XtraBars.BarButtonItem();
            this.pmSpamDomain = new DevExpress.XtraBars.BarButtonItem();
            this.pmDeleteMail = new DevExpress.XtraBars.BarButtonItem();
            this.pmSpamMail = new DevExpress.XtraBars.BarButtonItem();
            this.lboxMail = new OdinSoft.UIC.Win.Control.DVX.uListBoxControl();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsDeleteDomain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSpamDomain = new System.Windows.Forms.ToolStripMenuItem();
            this.tsValidDomain = new System.Windows.Forms.ToolStripMenuItem();
            this.MailRefresh = new OdinSoft.UIC.Win.Control.uBackgroundWorker(this.components);
            this.uLabel5 = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.dtpToDate = new OdinSoft.UIC.Win.Control.DVX.uDateEdit();
            this.uLabel4 = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.dtpFrDate = new OdinSoft.UIC.Win.Control.DVX.uDateEdit();
            this.pnlCondition = new OdinSoft.UIC.Win.Control.DVX.uPanelControl();
            this.cbSpamView = new OdinSoft.UIC.Win.Control.DVX.uCheckEdit();
            this.cbListBoxUse = new OdinSoft.UIC.Win.Control.DVX.uCheckEdit();
            this.panelControl1 = new OdinSoft.UIC.Win.Control.DVX.uPanelControl();
            this.lbSent = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.uLabelControl2 = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.lbBcc = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.uLabelControl1 = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.lbCc = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.uLabelControl4 = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.lbTo = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.uLabelControl3 = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.lbFrom = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.lbTitle = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.panelControl2 = new OdinSoft.UIC.Win.Control.DVX.uPanelControl();
            this.wbMail = new OdinSoft.UIC.Win.Control.uWebBrowser();
            this.pnAttaches = new OdinSoft.UIC.Win.Control.DVX.uPanelControl();
            this.lbAttaches = new OdinSoft.UIC.Win.Control.DVX.uImageListBoxControl();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.splitterControl2 = new OdinSoft.UIC.Win.Control.DVX.uSplitterControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.splitterControl1 = new OdinSoft.UIC.Win.Control.DVX.uSplitterControl();
            this.MailViewing = new OdinSoft.UIC.Win.Control.uBackgroundWorker(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.fgMail)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgMailView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lboxMail)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSpamView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListBoxUse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnAttaches)).BeginInit();
            this.pnAttaches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbAttaches)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // fgMail
            // 
            this.fgMail.ContextMenuStrip = this.contextMenuStrip1;
            this.fgMail.Dock = System.Windows.Forms.DockStyle.Top;
            this.fgMail.EmbeddedNavigator.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.fgMail.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.fgMail.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.fgMail.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.fgMail.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.fgMail.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.fgMail.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.fgMail.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.fgMail.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.fgMail.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.fgMail.EmbeddedNavigator.CustomButtons.AddRange(new DevExpress.XtraEditors.NavigatorCustomButton[] {
            new DevExpress.XtraEditors.NavigatorCustomButton(-1, 10, true, true, "Cancel Delete", "CancelDelete")});
            this.fgMail.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.fgMail_EmbeddedNavigator_ButtonClick);
            this.fgMail.Location = new System.Drawing.Point(2, 2);
            this.fgMail.MainView = this.fgMailView;
            this.fgMail.MemberName = null;
            this.fgMail.MenuManager = this.barManager1;
            this.fgMail.Name = "fgMail";
            this.fgMail.Size = new System.Drawing.Size(624, 175);
            this.fgMail.TabIndex = 15;
            this.fgMail.UseEmbeddedNavigator = true;
            this.fgMail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fgMailView});
            this.fgMail.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.fgMail_ProcessGridKey);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDeleteMail,
            this.tsSpamMail,
            this.tsValidMail});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 70);
            // 
            // tsDeleteMail
            // 
            this.tsDeleteMail.Name = "tsDeleteMail";
            this.tsDeleteMail.Size = new System.Drawing.Size(138, 22);
            this.tsDeleteMail.Text = "삭제(&D)";
            this.tsDeleteMail.Click += new System.EventHandler(this.tsDeleteMail_Click);
            // 
            // tsSpamMail
            // 
            this.tsSpamMail.Name = "tsSpamMail";
            this.tsSpamMail.Size = new System.Drawing.Size(138, 22);
            this.tsSpamMail.Text = "스팸등록(&R)";
            this.tsSpamMail.Click += new System.EventHandler(this.tsSpamMail_Click);
            // 
            // tsValidMail
            // 
            this.tsValidMail.Name = "tsValidMail";
            this.tsValidMail.Size = new System.Drawing.Size(138, 22);
            this.tsValidMail.Text = "유효메일(&V)";
            this.tsValidMail.Click += new System.EventHandler(this.tsValidMail_Click);
            // 
            // fgMailView
            // 
            this.fgMailView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn15,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn14,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10,
            this.gridColumn13,
            this.gridColumn12,
            this.gridColumn11,
            this.gridColumn1,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.fgMailView.GridControl = this.fgMail;
            this.fgMailView.Name = "fgMailView";
            this.fgMailView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.fgMailView.OptionsBehavior.Editable = false;
            this.fgMailView.OptionsCustomization.AllowGroup = false;
            this.fgMailView.OptionsDetail.EnableMasterViewMode = false;
            this.fgMailView.OptionsDetail.ShowDetailTabs = false;
            this.fgMailView.OptionsDetail.SmartDetailExpand = false;
            this.fgMailView.OptionsLayout.Columns.AddNewColumns = false;
            this.fgMailView.OptionsLayout.Columns.RemoveOldColumns = false;
            this.fgMailView.OptionsLayout.StoreAllOptions = true;
            this.fgMailView.OptionsLayout.StoreAppearance = true;
            this.fgMailView.OptionsMenu.EnableColumnMenu = false;
            this.fgMailView.OptionsMenu.EnableFooterMenu = false;
            this.fgMailView.OptionsMenu.EnableGroupPanelMenu = false;
            this.fgMailView.OptionsPrint.AutoWidth = false;
            this.fgMailView.OptionsPrint.ExpandAllGroups = false;
            this.fgMailView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.fgMailView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.fgMailView.OptionsSelection.MultiSelect = true;
            this.fgMailView.OptionsView.ColumnAutoWidth = false;
            this.fgMailView.OptionsView.ShowGroupPanel = false;
            this.fgMailView.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.fgMailView.Click += new System.EventHandler(this.gridView1_Click);
            this.fgMailView.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            this.fgMailView.GotFocus += new System.EventHandler(this.gridView1_GotFocus);
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "@";
            this.gridColumn15.DisplayFormat.FormatString = "##";
            this.gridColumn15.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn15.FieldName = "attach";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.FixedWidth = true;
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            this.gridColumn15.Width = 22;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "보낸사람";
            this.gridColumn2.FieldName = "sender";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.FixedWidth = true;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 92;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "받은사람";
            this.gridColumn3.FieldName = "receivers";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.FixedWidth = true;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 92;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "제목";
            this.gridColumn14.FieldName = "title";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 3;
            this.gridColumn14.Width = 337;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "받은시간";
            this.gridColumn7.DisplayFormat.FormatString = "yyyy-MM-dd tt hh:mm:ss";
            this.gridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn7.FieldName = "sentime";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 4;
            this.gridColumn7.Width = 69;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "규약";
            this.gridColumn8.FieldName = "protocol";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 42;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "명령";
            this.gridColumn9.FieldName = "command";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 10;
            this.gridColumn9.Width = 40;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "응답";
            this.gridColumn10.FieldName = "response";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 11;
            this.gridColumn10.Width = 40;
            // 
            // gridColumn13
            // 
            this.gridColumn13.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn13.Caption = "정상";
            this.gridColumn13.FieldName = "validation";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 12;
            this.gridColumn13.Width = 40;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn12.Caption = "완료";
            this.gridColumn12.FieldName = "completed";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 13;
            this.gridColumn12.Width = 35;
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn11.Caption = "경과";
            this.gridColumn11.FieldName = "timeout";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 14;
            this.gridColumn11.Width = 34;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "순번";
            this.gridColumn1.FieldName = "seqno";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
            this.gridColumn1.Width = 39;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "보낸IP";
            this.gridColumn4.FieldName = "sendipadrs";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 92;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridColumn5.Caption = "보낸Port";
            this.gridColumn5.FieldName = "sendport";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn5.OptionsFilter.AllowFilter = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 62;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "받은IP";
            this.gridColumn6.FieldName = "recvipadrs";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn6.OptionsFilter.AllowFilter = false;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 91;
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbRefresh,
            this.bbCancel,
            this.bbSave,
            this.bbReset,
            this.bbOpen,
            this.bbView,
            this.sbText,
            this.sbProgress,
            this.bbClean,
            this.bbDelete,
            this.bbSpam,
            this.pmDeleteDomain,
            this.pmSpamDomain,
            this.pmDeleteMail,
            this.pmSpamMail,
            this.bbWidth});
            this.barManager1.MaxItemId = 18;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.barManager1.StatusBar = this.bar2;
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbCancel),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbClean, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbReset, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbSpam, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbOpen, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbView),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbWidth)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 2";
            // 
            // bbRefresh
            // 
            this.bbRefresh.Caption = "검색(&X)";
            this.bbRefresh.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbRefresh.Id = 0;
            this.bbRefresh.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Search;
            this.bbRefresh.Name = "bbRefresh";
            this.bbRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbRefresh_ItemClick);
            // 
            // bbCancel
            // 
            this.bbCancel.Caption = "취소(&C)";
            this.bbCancel.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbCancel.Id = 1;
            this.bbCancel.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.cancel;
            this.bbCancel.Name = "bbCancel";
            this.bbCancel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCancel_ItemClick);
            // 
            // bbDelete
            // 
            this.bbDelete.Caption = "삭제(&D)";
            this.bbDelete.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbDelete.Id = 11;
            this.bbDelete.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Delete;
            this.bbDelete.Name = "bbDelete";
            this.bbDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbDelete_ItemClick);
            // 
            // bbSave
            // 
            this.bbSave.Caption = "저장(&S)";
            this.bbSave.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbSave.Id = 2;
            this.bbSave.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.save;
            this.bbSave.Name = "bbSave";
            this.bbSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSave_ItemClick);
            // 
            // bbClean
            // 
            this.bbClean.Caption = "정리(&L)";
            this.bbClean.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbClean.Id = 10;
            this.bbClean.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Outbox;
            this.bbClean.Name = "bbClean";
            this.bbClean.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbClean_ItemClick);
            // 
            // bbReset
            // 
            this.bbReset.Caption = "리셋(&R)";
            this.bbReset.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbReset.Id = 3;
            this.bbReset.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Flag;
            this.bbReset.Name = "bbReset";
            this.bbReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbReset_ItemClick);
            // 
            // bbSpam
            // 
            this.bbSpam.Caption = "스팸관리";
            this.bbSpam.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbSpam.Id = 12;
            this.bbSpam.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Error;
            this.bbSpam.Name = "bbSpam";
            this.bbSpam.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSpam_ItemClick);
            // 
            // bbOpen
            // 
            this.bbOpen.Caption = "열기(&O)";
            this.bbOpen.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbOpen.Id = 4;
            this.bbOpen.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.inquire;
            this.bbOpen.Name = "bbOpen";
            this.bbOpen.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbOpen_ItemClick);
            // 
            // bbView
            // 
            this.bbView.Caption = "내용(&V)";
            this.bbView.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbView.Id = 5;
            this.bbView.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Outbox;
            this.bbView.Name = "bbView";
            this.bbView.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbView_ItemClick);
            // 
            // bbWidth
            // 
            this.bbWidth.Caption = "너비(W)";
            this.bbWidth.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbWidth.Id = 17;
            this.bbWidth.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Shortcut;
            this.bbWidth.Name = "bbWidth";
            this.bbWidth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbWidth_ItemClick);
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.sbText),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.sbProgress, "", false, true, true, 139)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 3";
            // 
            // sbText
            // 
            this.sbText.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.sbText.Id = 7;
            this.sbText.Name = "sbText";
            this.sbText.TextAlignment = System.Drawing.StringAlignment.Near;
            this.sbText.Width = 32;
            // 
            // sbProgress
            // 
            this.sbProgress.Edit = this.repositoryItemProgressBar1;
            this.sbProgress.Id = 8;
            this.sbProgress.Name = "sbProgress";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(784, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 522);
            this.barDockControlBottom.Size = new System.Drawing.Size(784, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 491);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(784, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 491);
            // 
            // pmDeleteDomain
            // 
            this.pmDeleteDomain.Caption = "삭제(&D)";
            this.pmDeleteDomain.Id = 13;
            this.pmDeleteDomain.Name = "pmDeleteDomain";
            // 
            // pmSpamDomain
            // 
            this.pmSpamDomain.Caption = "스팸등록(&R)";
            this.pmSpamDomain.Id = 14;
            this.pmSpamDomain.Name = "pmSpamDomain";
            // 
            // pmDeleteMail
            // 
            this.pmDeleteMail.Caption = "삭제(&D)";
            this.pmDeleteMail.Id = 15;
            this.pmDeleteMail.Name = "pmDeleteMail";
            // 
            // pmSpamMail
            // 
            this.pmSpamMail.Caption = "스팸등록(&R)";
            this.pmSpamMail.Id = 16;
            this.pmSpamMail.Name = "pmSpamMail";
            // 
            // lboxMail
            // 
            this.lboxMail.ContextMenuStrip = this.contextMenuStrip2;
            this.lboxMail.Dock = System.Windows.Forms.DockStyle.Left;
            this.lboxMail.Location = new System.Drawing.Point(0, 68);
            this.lboxMail.Name = "lboxMail";
            this.lboxMail.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lboxMail.Size = new System.Drawing.Size(156, 454);
            this.lboxMail.TabIndex = 20;
            this.lboxMail.SelectedIndexChanged += new System.EventHandler(this.lboxMail_SelectedIndexChanged);
            this.lboxMail.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.lboxMail_PreviewKeyDown);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDeleteDomain,
            this.tsSpamDomain,
            this.tsValidDomain});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(151, 70);
            // 
            // tsDeleteDomain
            // 
            this.tsDeleteDomain.Name = "tsDeleteDomain";
            this.tsDeleteDomain.Size = new System.Drawing.Size(150, 22);
            this.tsDeleteDomain.Text = "삭제(&D)";
            this.tsDeleteDomain.Click += new System.EventHandler(this.tsDeleteDomain_Click);
            // 
            // tsSpamDomain
            // 
            this.tsSpamDomain.Name = "tsSpamDomain";
            this.tsSpamDomain.Size = new System.Drawing.Size(150, 22);
            this.tsSpamDomain.Text = "스팸등록(&R)";
            this.tsSpamDomain.Click += new System.EventHandler(this.tsSpamDomain_Click);
            // 
            // tsValidDomain
            // 
            this.tsValidDomain.Name = "tsValidDomain";
            this.tsValidDomain.Size = new System.Drawing.Size(150, 22);
            this.tsValidDomain.Text = "유효도메인(&V)";
            this.tsValidDomain.Click += new System.EventHandler(this.tsValidDomain_Click);
            // 
            // MailRefresh
            // 
            this.MailRefresh.WorkerReportsProgress = true;
            this.MailRefresh.WorkerSupportsCancellation = true;
            this.MailRefresh.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MailRefresh_DoWork);
            this.MailRefresh.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MailRefresh_ProgressChanged);
            this.MailRefresh.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MailRefresh_RunWorkerCompleted);
            // 
            // uLabel5
            // 
            this.uLabel5.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabel5.Location = new System.Drawing.Point(158, 8);
            this.uLabel5.Name = "uLabel5";
            this.uLabel5.Size = new System.Drawing.Size(9, 14);
            this.uLabel5.TabIndex = 36;
            this.uLabel5.Text = "~";
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = new System.DateTime(2007, 1, 11, 0, 0, 0, 0);
            this.dtpToDate.Location = new System.Drawing.Point(174, 8);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.MaxValue = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Size = new System.Drawing.Size(100, 20);
            this.dtpToDate.TabIndex = 1;
            // 
            // uLabel4
            // 
            this.uLabel4.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabel4.Location = new System.Drawing.Point(9, 11);
            this.uLabel4.Name = "uLabel4";
            this.uLabel4.Size = new System.Drawing.Size(24, 14);
            this.uLabel4.TabIndex = 36;
            this.uLabel4.Text = "일자";
            // 
            // dtpFrDate
            // 
            this.dtpFrDate.EditValue = new System.DateTime(2007, 1, 11, 0, 0, 0, 0);
            this.dtpFrDate.Location = new System.Drawing.Point(54, 8);
            this.dtpFrDate.Name = "dtpFrDate";
            this.dtpFrDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrDate.Properties.MaxValue = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpFrDate.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFrDate.Size = new System.Drawing.Size(100, 20);
            this.dtpFrDate.TabIndex = 0;
            // 
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.cbSpamView);
            this.pnlCondition.Controls.Add(this.cbListBoxUse);
            this.pnlCondition.Controls.Add(this.dtpFrDate);
            this.pnlCondition.Controls.Add(this.uLabel4);
            this.pnlCondition.Controls.Add(this.dtpToDate);
            this.pnlCondition.Controls.Add(this.uLabel5);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondition.Location = new System.Drawing.Point(0, 31);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(784, 37);
            this.pnlCondition.TabIndex = 4;
            // 
            // cbSpamView
            // 
            this.cbSpamView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSpamView.Location = new System.Drawing.Point(560, 8);
            this.cbSpamView.Name = "cbSpamView";
            this.cbSpamView.Properties.Caption = "View Spam";
            this.cbSpamView.Size = new System.Drawing.Size(81, 19);
            this.cbSpamView.TabIndex = 38;
            this.cbSpamView.CheckedChanged += new System.EventHandler(this.cbSpamView_CheckedChanged);
            // 
            // cbListBoxUse
            // 
            this.cbListBoxUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbListBoxUse.Location = new System.Drawing.Point(647, 9);
            this.cbListBoxUse.Name = "cbListBoxUse";
            this.cbListBoxUse.Properties.Caption = "Filter by domain";
            this.cbListBoxUse.Size = new System.Drawing.Size(125, 19);
            this.cbListBoxUse.TabIndex = 37;
            this.cbListBoxUse.CheckedChanged += new System.EventHandler(this.cbListBoxUse_CheckedChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lbSent);
            this.panelControl1.Controls.Add(this.uLabelControl2);
            this.panelControl1.Controls.Add(this.lbBcc);
            this.panelControl1.Controls.Add(this.uLabelControl1);
            this.panelControl1.Controls.Add(this.lbCc);
            this.panelControl1.Controls.Add(this.uLabelControl4);
            this.panelControl1.Controls.Add(this.lbTo);
            this.panelControl1.Controls.Add(this.uLabelControl3);
            this.panelControl1.Controls.Add(this.lbFrom);
            this.panelControl1.Controls.Add(this.lbTitle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 182);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(624, 88);
            this.panelControl1.TabIndex = 18;
            // 
            // lbSent
            // 
            this.lbSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbSent.Location = new System.Drawing.Point(358, 12);
            this.lbSent.Name = "lbSent";
            this.lbSent.Size = new System.Drawing.Size(0, 14);
            this.lbSent.TabIndex = 48;
            // 
            // uLabelControl2
            // 
            this.uLabelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabelControl2.Location = new System.Drawing.Point(323, 11);
            this.uLabelControl2.Name = "uLabelControl2";
            this.uLabelControl2.Size = new System.Drawing.Size(34, 14);
            this.uLabelControl2.TabIndex = 47;
            this.uLabelControl2.Text = "Sent: ";
            // 
            // lbBcc
            // 
            this.lbBcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBcc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbBcc.Location = new System.Drawing.Point(358, 31);
            this.lbBcc.Name = "lbBcc";
            this.lbBcc.Size = new System.Drawing.Size(0, 14);
            this.lbBcc.TabIndex = 46;
            // 
            // uLabelControl1
            // 
            this.uLabelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabelControl1.Location = new System.Drawing.Point(329, 28);
            this.uLabelControl1.Name = "uLabelControl1";
            this.uLabelControl1.Size = new System.Drawing.Size(27, 14);
            this.uLabelControl1.TabIndex = 45;
            this.uLabelControl1.Text = "Bcc: ";
            // 
            // lbCc
            // 
            this.lbCc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbCc.Location = new System.Drawing.Point(34, 64);
            this.lbCc.Name = "lbCc";
            this.lbCc.Size = new System.Drawing.Size(0, 14);
            this.lbCc.TabIndex = 44;
            // 
            // uLabelControl4
            // 
            this.uLabelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabelControl4.Location = new System.Drawing.Point(9, 64);
            this.uLabelControl4.Name = "uLabelControl4";
            this.uLabelControl4.Size = new System.Drawing.Size(21, 14);
            this.uLabelControl4.TabIndex = 43;
            this.uLabelControl4.Text = "Cc: ";
            // 
            // lbTo
            // 
            this.lbTo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbTo.Location = new System.Drawing.Point(34, 50);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(0, 14);
            this.lbTo.TabIndex = 42;
            // 
            // uLabelControl3
            // 
            this.uLabelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabelControl3.Location = new System.Drawing.Point(9, 50);
            this.uLabelControl3.Name = "uLabelControl3";
            this.uLabelControl3.Size = new System.Drawing.Size(23, 14);
            this.uLabelControl3.TabIndex = 41;
            this.uLabelControl3.Text = "To: ";
            // 
            // lbFrom
            // 
            this.lbFrom.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbFrom.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbFrom.Location = new System.Drawing.Point(12, 26);
            this.lbFrom.Name = "lbFrom";
            this.lbFrom.Size = new System.Drawing.Size(100, 18);
            this.lbFrom.TabIndex = 40;
            this.lbFrom.Text = "....................";
            // 
            // lbTitle
            // 
            this.lbTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbTitle.AutoEllipsis = true;
            this.lbTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbTitle.Location = new System.Drawing.Point(12, 6);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(100, 19);
            this.lbTitle.TabIndex = 38;
            this.lbTitle.Text = "....................";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.wbMail);
            this.panelControl2.Controls.Add(this.pnAttaches);
            this.panelControl2.Controls.Add(this.panelControl1);
            this.panelControl2.Controls.Add(this.splitterControl2);
            this.panelControl2.Controls.Add(this.fgMail);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(156, 68);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(628, 454);
            this.panelControl2.TabIndex = 21;
            // 
            // wbMail
            // 
            this.wbMail.AllowWebBrowserDrop = false;
            this.wbMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMail.IsWebBrowserContextMenuEnabled = false;
            this.wbMail.Location = new System.Drawing.Point(2, 309);
            this.wbMail.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMail.Name = "wbMail";
            this.wbMail.ScriptErrorsSuppressed = true;
            this.wbMail.Size = new System.Drawing.Size(624, 143);
            this.wbMail.TabIndex = 24;
            this.wbMail.WebBrowserShortcutsEnabled = false;
            this.wbMail.StatusTextReplaced += new System.EventHandler(this.wbMail_StatusTextChanged);
            this.wbMail.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMail_DocumentCompleted);
            this.wbMail.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.wbMail_ProgressChanged);
            // 
            // pnAttaches
            // 
            this.pnAttaches.Controls.Add(this.lbAttaches);
            this.pnAttaches.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAttaches.Location = new System.Drawing.Point(2, 270);
            this.pnAttaches.Name = "pnAttaches";
            this.pnAttaches.Size = new System.Drawing.Size(624, 39);
            this.pnAttaches.TabIndex = 22;
            // 
            // lbAttaches
            // 
            this.lbAttaches.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbAttaches.ContextMenuStrip = this.contextMenuStrip3;
            this.lbAttaches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAttaches.Location = new System.Drawing.Point(2, 2);
            this.lbAttaches.MultiColumn = true;
            this.lbAttaches.Name = "lbAttaches";
            this.lbAttaches.Size = new System.Drawing.Size(620, 35);
            this.lbAttaches.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.lbAttaches.SysImageSize = OdinSoft.UIC.Win.Control.Library.SystemImageListSize.SmallIcons;
            this.lbAttaches.TabIndex = 0;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpenFile,
            this.tsSaveFile});
            this.contextMenuStrip3.Name = "contextMenuStrip1";
            this.contextMenuStrip3.Size = new System.Drawing.Size(117, 48);
            // 
            // tsOpenFile
            // 
            this.tsOpenFile.Name = "tsOpenFile";
            this.tsOpenFile.Size = new System.Drawing.Size(116, 22);
            this.tsOpenFile.Text = "&Open";
            // 
            // tsSaveFile
            // 
            this.tsSaveFile.Name = "tsSaveFile";
            this.tsSaveFile.Size = new System.Drawing.Size(116, 22);
            this.tsSaveFile.Text = "&Save As";
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(2, 177);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(624, 5);
            this.splitterControl2.TabIndex = 20;
            this.splitterControl2.TabStop = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(156, 68);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 454);
            this.splitterControl1.TabIndex = 22;
            this.splitterControl1.TabStop = false;
            // 
            // MailViewing
            // 
            this.MailViewing.WorkerReportsProgress = true;
            this.MailViewing.WorkerSupportsCancellation = true;
            this.MailViewing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MailViewing_DoWork);
            this.MailViewing.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MailViewing_ProgressChanged);
            this.MailViewing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MailViewing_RunWorkerCompleted);
            // 
            // MailViewer
            // 
            this.ClientSize = new System.Drawing.Size(784, 547);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.lboxMail);
            this.Controls.Add(this.pnlCondition);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MailViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MailViewer_FormClosing);
            this.Load += new System.EventHandler(this.MailViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fgMail)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgMailView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lboxMail)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSpamView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListBoxUse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnAttaches)).EndInit();
            this.pnAttaches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbAttaches)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OdinSoft.UIC.Win.Control.DVX.uGridControl fgMail;
        private DevExpress.XtraGrid.Views.Grid.GridView fgMailView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabel5;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabel4;
        private OdinSoft.UIC.Win.Control.DVX.uPanelControl pnlCondition;
        private OdinSoft.UIC.Win.Control.DVX.uPanelControl panelControl1;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbTitle;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbCc;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabelControl4;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbTo;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabelControl3;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbFrom;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbSent;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabelControl2;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbBcc;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem bbRefresh;
        private DevExpress.XtraBars.BarLargeButtonItem bbCancel;
        private DevExpress.XtraBars.BarLargeButtonItem bbSave;
        private DevExpress.XtraBars.BarLargeButtonItem bbReset;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem bbOpen;
        private DevExpress.XtraBars.BarLargeButtonItem bbView;

        public OdinSoft.UIC.Win.Control.DVX.uDateEdit dtpToDate;
        public OdinSoft.UIC.Win.Control.DVX.uDateEdit dtpFrDate;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem sbText;
        private DevExpress.XtraBars.BarEditItem sbProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private OdinSoft.UIC.Win.Control.uBackgroundWorker MailRefresh;
        private OdinSoft.UIC.Win.Control.DVX.uSplitterControl splitterControl1;
        private OdinSoft.UIC.Win.Control.DVX.uPanelControl panelControl2;
        private OdinSoft.UIC.Win.Control.DVX.uListBoxControl lboxMail;
        private OdinSoft.UIC.Win.Control.DVX.uSplitterControl splitterControl2;
        private OdinSoft.UIC.Win.Control.DVX.uCheckEdit cbListBoxUse;
        private DevExpress.XtraBars.BarLargeButtonItem bbClean;
        private DevExpress.XtraBars.BarLargeButtonItem bbDelete;
        private DevExpress.XtraBars.BarLargeButtonItem bbSpam;
        private DevExpress.XtraBars.BarButtonItem pmDeleteDomain;
        private DevExpress.XtraBars.BarButtonItem pmSpamDomain;
        private DevExpress.XtraBars.BarButtonItem pmDeleteMail;
        private DevExpress.XtraBars.BarButtonItem pmSpamMail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsDeleteMail;
        private System.Windows.Forms.ToolStripMenuItem tsSpamMail;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem tsDeleteDomain;
        private System.Windows.Forms.ToolStripMenuItem tsSpamDomain;
        private System.Windows.Forms.ToolStripMenuItem tsValidMail;
        private System.Windows.Forms.ToolStripMenuItem tsValidDomain;
        private OdinSoft.UIC.Win.Control.DVX.uCheckEdit cbSpamView;
        private OdinSoft.UIC.Win.Control.uWebBrowser wbMail;
        private OdinSoft.UIC.Win.Control.DVX.uPanelControl pnAttaches;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private System.Windows.Forms.ImageList imageList1;
        private OdinSoft.UIC.Win.Control.DVX.uImageListBoxControl lbAttaches;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem tsOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsSaveFile;
        private OdinSoft.UIC.Win.Control.uBackgroundWorker MailViewing;
        private DevExpress.XtraBars.BarLargeButtonItem bbWidth;
    }
}