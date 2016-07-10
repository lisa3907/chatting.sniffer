namespace Sniffer.Client.Viewer.ChatView
{
    partial class ChatViewer
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
            this.ChatWorker = new OdinSoft.UIC.Win.Control.uBackgroundWorker(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbRefresh = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbCancel = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbSave = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbReset = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbClean = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbSpamMail = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbWidth = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.sbText = new DevExpress.XtraBars.BarStaticItem();
            this.sbProgress = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnlCondition = new OdinSoft.UIC.Win.Control.DVX.uPanelControl();
            this.cbSpamView = new OdinSoft.UIC.Win.Control.DVX.uCheckEdit();
            this.cbListBoxUse = new OdinSoft.UIC.Win.Control.DVX.uCheckEdit();
            this.dtpFrDate = new OdinSoft.UIC.Win.Control.DVX.uDateEdit();
            this.uLabel4 = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.dtpToDate = new OdinSoft.UIC.Win.Control.DVX.uDateEdit();
            this.uLabel5 = new OdinSoft.UIC.Win.Control.DVX.uLabelControl();
            this.panelControl1 = new OdinSoft.UIC.Win.Control.DVX.uPanelControl();
            this.fgChat = new OdinSoft.UIC.Win.Control.DVX.uGridControl();
            this.fgChatView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.lboxChat = new OdinSoft.UIC.Win.Control.DVX.uListBoxControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsDeleteMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSpamMsg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsValidMsg = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).BeginInit();
            this.pnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSpamView.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListBoxUse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fgChat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgChatView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lboxChat)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChatWorker
            // 
            this.ChatWorker.WorkerReportsProgress = true;
            this.ChatWorker.WorkerSupportsCancellation = true;
            this.ChatWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ChatWorker_DoWork);
            this.ChatWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ChatWorker_RunWorkerCompleted);
            this.ChatWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ChatWorker_ProgressChanged);
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
            this.sbText,
            this.sbProgress,
            this.bbClean,
            this.bbSpamMail,
            this.bbWidth});
            this.barManager1.MaxItemId = 13;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bbSave),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbReset, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbClean),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbSpamMail),
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
            // bbSave
            // 
            this.bbSave.Caption = "저장(&S)";
            this.bbSave.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbSave.Id = 2;
            this.bbSave.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.save;
            this.bbSave.Name = "bbSave";
            this.bbSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSave_ItemClick);
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
            // bbClean
            // 
            this.bbClean.Caption = "정리(&L)";
            this.bbClean.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbClean.Id = 10;
            this.bbClean.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Outbox;
            this.bbClean.Name = "bbClean";
            this.bbClean.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbClean_ItemClick);
            // 
            // bbSpamMail
            // 
            this.bbSpamMail.Caption = "주소관리";
            this.bbSpamMail.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbSpamMail.Id = 11;
            this.bbSpamMail.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.SyncError;
            this.bbSpamMail.Name = "bbSpamMail";
            this.bbSpamMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbSpamMail_ItemClick);
            // 
            // bbWidth
            // 
            this.bbWidth.Caption = "너비(W)";
            this.bbWidth.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbWidth.Id = 12;
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
            // pnlCondition
            // 
            this.pnlCondition.Controls.Add(this.cbSpamView);
            this.pnlCondition.Controls.Add(this.cbListBoxUse);
            this.pnlCondition.Controls.Add(this.dtpFrDate);
            this.pnlCondition.Controls.Add(this.uLabel4);
            this.pnlCondition.Controls.Add(this.dtpToDate);
            this.pnlCondition.Controls.Add(this.uLabel5);
            this.pnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCondition.Location = new System.Drawing.Point(0, 26);
            this.pnlCondition.Name = "pnlCondition";
            this.pnlCondition.Size = new System.Drawing.Size(1016, 34);
            this.pnlCondition.TabIndex = 21;
            // 
            // cbSpamView
            // 
            this.cbSpamView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSpamView.Location = new System.Drawing.Point(657, 8);
            this.cbSpamView.Name = "cbSpamView";
            this.cbSpamView.Properties.Caption = "View All Messages";
            this.cbSpamView.Size = new System.Drawing.Size(156, 19);
            this.cbSpamView.TabIndex = 39;
            this.cbSpamView.CheckedChanged += new System.EventHandler(this.cbSpamView_CheckedChanged);
            // 
            // cbListBoxUse
            // 
            this.cbListBoxUse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbListBoxUse.Location = new System.Drawing.Point(836, 8);
            this.cbListBoxUse.Name = "cbListBoxUse";
            this.cbListBoxUse.Properties.Caption = "Filter by sender";
            this.cbListBoxUse.Size = new System.Drawing.Size(146, 19);
            this.cbListBoxUse.TabIndex = 38;
            this.cbListBoxUse.CheckedChanged += new System.EventHandler(this.cbListBoxUse_CheckedChanged);
            // 
            // dtpFrDate
            // 
            this.dtpFrDate.EditValue = new System.DateTime(2007, 1, 11, 0, 0, 0, 0);
            this.dtpFrDate.Location = new System.Drawing.Point(63, 7);
            this.dtpFrDate.Name = "dtpFrDate";
            this.dtpFrDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpFrDate.Properties.MaxValue = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpFrDate.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpFrDate.Size = new System.Drawing.Size(117, 21);
            this.dtpFrDate.TabIndex = 0;
            // 
            // uLabel4
            // 
            this.uLabel4.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabel4.Appearance.Options.UseForeColor = true;
            this.uLabel4.Location = new System.Drawing.Point(10, 10);
            this.uLabel4.Name = "uLabel4";
            this.uLabel4.Size = new System.Drawing.Size(24, 14);
            this.uLabel4.TabIndex = 36;
            this.uLabel4.Text = "일자";
            // 
            // dtpToDate
            // 
            this.dtpToDate.EditValue = new System.DateTime(2007, 1, 11, 0, 0, 0, 0);
            this.dtpToDate.Location = new System.Drawing.Point(203, 7);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpToDate.Properties.MaxValue = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.Properties.MinValue = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Size = new System.Drawing.Size(117, 21);
            this.dtpToDate.TabIndex = 1;
            // 
            // uLabel5
            // 
            this.uLabel5.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabel5.Appearance.Options.UseForeColor = true;
            this.uLabel5.Location = new System.Drawing.Point(184, 7);
            this.uLabel5.Name = "uLabel5";
            this.uLabel5.Size = new System.Drawing.Size(9, 14);
            this.uLabel5.TabIndex = 36;
            this.uLabel5.Text = "~";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.fgChat);
            this.panelControl1.Controls.Add(this.splitterControl1);
            this.panelControl1.Controls.Add(this.lboxChat);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 60);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1016, 376);
            this.panelControl1.TabIndex = 22;
            this.panelControl1.Text = "panelControl1";
            // 
            // fgChat
            // 
            this.fgChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fgChat.EmbeddedNavigator.Appearance.BackColor = System.Drawing.SystemColors.Window;
            this.fgChat.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.fgChat.EmbeddedNavigator.Buttons.Append.Enabled = false;
            this.fgChat.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.fgChat.EmbeddedNavigator.Buttons.CancelEdit.Enabled = false;
            this.fgChat.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.fgChat.EmbeddedNavigator.Buttons.Edit.Enabled = false;
            this.fgChat.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.fgChat.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
            this.fgChat.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.fgChat.EmbeddedNavigator.Buttons.Remove.Enabled = false;
            this.fgChat.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.fgChat.EmbeddedNavigator.Name = "";
            this.fgChat.Location = new System.Drawing.Point(199, 2);
            this.fgChat.MainView = this.fgChatView;
            this.fgChat.Name = "fgChat";
            this.fgChat.Size = new System.Drawing.Size(815, 372);
            this.fgChat.TabIndex = 21;
            this.fgChat.UseEmbeddedNavigator = true;
            this.fgChat.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.fgChatView});
            // 
            // fgChatView
            // 
            this.fgChatView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn14,
            this.gcContent,
            this.gridColumn13});
            this.fgChatView.GridControl = this.fgChat;
            this.fgChatView.Name = "fgChatView";
            this.fgChatView.OptionsBehavior.AutoSelectAllInEditor = false;
            this.fgChatView.OptionsBehavior.Editable = false;
            this.fgChatView.OptionsCustomization.AllowGroup = false;
            this.fgChatView.OptionsDetail.EnableMasterViewMode = false;
            this.fgChatView.OptionsDetail.ShowDetailTabs = false;
            this.fgChatView.OptionsDetail.SmartDetailExpand = false;
            this.fgChatView.OptionsLayout.Columns.AddNewColumns = false;
            this.fgChatView.OptionsLayout.Columns.RemoveOldColumns = false;
            this.fgChatView.OptionsLayout.StoreAllOptions = true;
            this.fgChatView.OptionsLayout.StoreAppearance = true;
            this.fgChatView.OptionsMenu.EnableColumnMenu = false;
            this.fgChatView.OptionsMenu.EnableFooterMenu = false;
            this.fgChatView.OptionsMenu.EnableGroupPanelMenu = false;
            this.fgChatView.OptionsPrint.AutoWidth = false;
            this.fgChatView.OptionsPrint.ExpandAllGroups = false;
            this.fgChatView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.fgChatView.OptionsSelection.EnableAppearanceHideSelection = false;
            this.fgChatView.OptionsSelection.MultiSelect = true;
            this.fgChatView.OptionsView.ColumnAutoWidth = false;
            this.fgChatView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "일련번호";
            this.gridColumn2.FieldName = "seqno";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowMove = false;
            this.gridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn2.OptionsFilter.AllowFilter = false;
            this.gridColumn2.OptionsFilter.ImmediateUpdateAutoFilter = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 74;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "발송시간";
            this.gridColumn3.DisplayFormat.FormatString = "yyyy-MM-dd tt hh:mm:ss";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "sentime";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.AllowMove = false;
            this.gridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn3.OptionsFilter.AllowFilter = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 77;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "발송자";
            this.gridColumn14.FieldName = "sender";
            this.gridColumn14.Name = "gridColumn14";
            this.gridColumn14.OptionsColumn.AllowEdit = false;
            this.gridColumn14.OptionsColumn.AllowMove = false;
            this.gridColumn14.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn14.OptionsColumn.ReadOnly = true;
            this.gridColumn14.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn14.OptionsFilter.AllowFilter = false;
            this.gridColumn14.Visible = true;
            this.gridColumn14.VisibleIndex = 2;
            this.gridColumn14.Width = 79;
            // 
            // gcContent
            // 
            this.gcContent.Caption = "내용";
            this.gcContent.FieldName = "content";
            this.gcContent.Name = "gcContent";
            this.gcContent.OptionsColumn.AllowEdit = false;
            this.gcContent.OptionsColumn.AllowMove = false;
            this.gcContent.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gcContent.OptionsColumn.FixedWidth = true;
            this.gcContent.OptionsColumn.ReadOnly = true;
            this.gcContent.OptionsFilter.AllowAutoFilter = false;
            this.gcContent.OptionsFilter.AllowFilter = false;
            this.gcContent.Visible = true;
            this.gcContent.VisibleIndex = 3;
            this.gcContent.Width = 301;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "수신자";
            this.gridColumn13.FieldName = "receiver";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.OptionsColumn.AllowEdit = false;
            this.gridColumn13.OptionsColumn.AllowMove = false;
            this.gridColumn13.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn13.OptionsColumn.ReadOnly = true;
            this.gridColumn13.OptionsFilter.AllowAutoFilter = false;
            this.gridColumn13.OptionsFilter.AllowFilter = false;
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 4;
            this.gridColumn13.Width = 90;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(193, 2);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(6, 372);
            this.splitterControl1.TabIndex = 20;
            this.splitterControl1.TabStop = false;
            // 
            // lboxChat
            // 
            this.lboxChat.ContextMenuStrip = this.contextMenuStrip1;
            this.lboxChat.Dock = System.Windows.Forms.DockStyle.Left;
            this.lboxChat.Location = new System.Drawing.Point(2, 2);
            this.lboxChat.Name = "lboxChat";
            this.lboxChat.Size = new System.Drawing.Size(191, 372);
            this.lboxChat.TabIndex = 19;
            this.lboxChat.SelectedIndexChanged += new System.EventHandler(this.lboxChat_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsDeleteMsg,
            this.tsSpamMsg,
            this.tsValidMsg});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 70);
            // 
            // tsDeleteMsg
            // 
            this.tsDeleteMsg.Name = "tsDeleteMsg";
            this.tsDeleteMsg.Size = new System.Drawing.Size(138, 22);
            this.tsDeleteMsg.Text = "삭제(&D)";
            this.tsDeleteMsg.Click += new System.EventHandler(this.tsDeleteMsg_Click);
            // 
            // tsSpamMsg
            // 
            this.tsSpamMsg.Name = "tsSpamMsg";
            this.tsSpamMsg.Size = new System.Drawing.Size(138, 22);
            this.tsSpamMsg.Text = "스팸등록(&R)";
            this.tsSpamMsg.Click += new System.EventHandler(this.tsSpamMsg_Click);
            // 
            // tsValidMsg
            // 
            this.tsValidMsg.Name = "tsValidMsg";
            this.tsValidMsg.Size = new System.Drawing.Size(138, 22);
            this.tsValidMsg.Text = "유효메일(&V)";
            this.tsValidMsg.Click += new System.EventHandler(this.tsValidMsg_Click);
            // 
            // ChatViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 461);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.pnlCondition);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ChatViewer";
            this.Text = "ChatViewer";
            this.Load += new System.EventHandler(this.ChatViewer_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatViewer_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlCondition)).EndInit();
            this.pnlCondition.ResumeLayout(false);
            this.pnlCondition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbSpamView.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbListBoxUse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpFrDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fgChat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fgChatView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lboxChat)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OdinSoft.UIC.Win.Control.uBackgroundWorker ChatWorker;
 
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
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarStaticItem sbText;
        private DevExpress.XtraBars.BarEditItem sbProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private OdinSoft.UIC.Win.Control.DVX.uPanelControl panelControl1;
        private OdinSoft.UIC.Win.Control.DVX.uGridControl fgChat;
        private DevExpress.XtraGrid.Views.Grid.GridView fgChatView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gcContent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private OdinSoft.UIC.Win.Control.DVX.uListBoxControl lboxChat;
        private OdinSoft.UIC.Win.Control.DVX.uPanelControl pnlCondition;
        public OdinSoft.UIC.Win.Control.DVX.uDateEdit dtpFrDate;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabel4;
        public OdinSoft.UIC.Win.Control.DVX.uDateEdit dtpToDate;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabel5;
        private OdinSoft.UIC.Win.Control.DVX.uCheckEdit cbListBoxUse;
        private DevExpress.XtraBars.BarLargeButtonItem bbClean;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsDeleteMsg;
        private System.Windows.Forms.ToolStripMenuItem tsSpamMsg;
        private System.Windows.Forms.ToolStripMenuItem tsValidMsg;
        private OdinSoft.UIC.Win.Control.DVX.uCheckEdit cbSpamView;
        private DevExpress.XtraBars.BarLargeButtonItem bbSpamMail;
        private DevExpress.XtraBars.BarLargeButtonItem bbWidth;
    }
}