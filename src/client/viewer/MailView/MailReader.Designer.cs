namespace Sniffer.Client.Viewer.MailView
{
    partial class MailReader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailReader));
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.sbText = new DevExpress.XtraBars.BarStaticItem();
            this.sbPosition = new DevExpress.XtraBars.BarStaticItem();
            this.sbProgress = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.bbFirst = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbPrev = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbNext = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbLast = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbDelete = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.pnAttaches = new OdinSoft.UIC.Win.Control.DVX.uPanelControl();
            this.lbAttaches = new OdinSoft.UIC.Win.Control.DVX.uImageListBoxControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSaveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.wbMail = new OdinSoft.UIC.Win.Control.uWebBrowser();
            this.MailViewing = new OdinSoft.UIC.Win.Control.uBackgroundWorker(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnAttaches)).BeginInit();
            this.pnAttaches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbAttaches)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
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
            this.panelControl1.Location = new System.Drawing.Point(0, 31);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(915, 94);
            this.panelControl1.TabIndex = 19;
            // 
            // lbSent
            // 
            this.lbSent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbSent.Location = new System.Drawing.Point(604, 13);
            this.lbSent.Name = "lbSent";
            this.lbSent.Size = new System.Drawing.Size(0, 14);
            this.lbSent.TabIndex = 48;
            // 
            // uLabelControl2
            // 
            this.uLabelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabelControl2.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabelControl2.Location = new System.Drawing.Point(563, 12);
            this.uLabelControl2.Name = "uLabelControl2";
            this.uLabelControl2.Size = new System.Drawing.Size(34, 14);
            this.uLabelControl2.TabIndex = 47;
            this.uLabelControl2.Text = "Sent: ";
            // 
            // lbBcc
            // 
            this.lbBcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBcc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbBcc.Location = new System.Drawing.Point(604, 34);
            this.lbBcc.Name = "lbBcc";
            this.lbBcc.Size = new System.Drawing.Size(0, 14);
            this.lbBcc.TabIndex = 46;
            // 
            // uLabelControl1
            // 
            this.uLabelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uLabelControl1.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabelControl1.Location = new System.Drawing.Point(570, 30);
            this.uLabelControl1.Name = "uLabelControl1";
            this.uLabelControl1.Size = new System.Drawing.Size(27, 14);
            this.uLabelControl1.TabIndex = 45;
            this.uLabelControl1.Text = "Bcc: ";
            // 
            // lbCc
            // 
            this.lbCc.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbCc.Location = new System.Drawing.Point(40, 69);
            this.lbCc.Name = "lbCc";
            this.lbCc.Size = new System.Drawing.Size(0, 14);
            this.lbCc.TabIndex = 44;
            // 
            // uLabelControl4
            // 
            this.uLabelControl4.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabelControl4.Location = new System.Drawing.Point(10, 69);
            this.uLabelControl4.Name = "uLabelControl4";
            this.uLabelControl4.Size = new System.Drawing.Size(21, 14);
            this.uLabelControl4.TabIndex = 43;
            this.uLabelControl4.Text = "Cc: ";
            // 
            // lbTo
            // 
            this.lbTo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbTo.Location = new System.Drawing.Point(40, 54);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(0, 14);
            this.lbTo.TabIndex = 42;
            // 
            // uLabelControl3
            // 
            this.uLabelControl3.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.uLabelControl3.Location = new System.Drawing.Point(10, 54);
            this.uLabelControl3.Name = "uLabelControl3";
            this.uLabelControl3.Size = new System.Drawing.Size(23, 14);
            this.uLabelControl3.TabIndex = 41;
            this.uLabelControl3.Text = "To: ";
            // 
            // lbFrom
            // 
            this.lbFrom.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbFrom.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.lbFrom.Location = new System.Drawing.Point(14, 28);
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
            this.lbTitle.Location = new System.Drawing.Point(14, 7);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(100, 19);
            this.lbTitle.TabIndex = 38;
            this.lbTitle.Text = "....................";
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
            this.bbPrev,
            this.bbNext,
            this.sbPosition,
            this.bbFirst,
            this.bbLast,
            this.bbDelete});
            this.barManager1.MaxItemId = 10;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.sbPosition),
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
            // sbPosition
            // 
            this.sbPosition.AutoSize = DevExpress.XtraBars.BarStaticItemSize.Spring;
            this.sbPosition.Id = 6;
            this.sbPosition.Name = "sbPosition";
            this.sbPosition.TextAlignment = System.Drawing.StringAlignment.Near;
            this.sbPosition.Width = 32;
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
            new DevExpress.XtraBars.LinkPersistInfo(this.bbFirst),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbPrev),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbLast),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbDelete)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 2";
            // 
            // bbFirst
            // 
            this.bbFirst.Caption = "처음(&F)";
            this.bbFirst.Id = 7;
            this.bbFirst.Name = "bbFirst";
            this.bbFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbFirst_ItemClick);
            // 
            // bbPrev
            // 
            this.bbPrev.Caption = "이전(&P)";
            this.bbPrev.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbPrev.Id = 4;
            this.bbPrev.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbPrev.LargeGlyph")));
            this.bbPrev.Name = "bbPrev";
            this.bbPrev.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbPrev_ItemClick);
            // 
            // bbNext
            // 
            this.bbNext.Caption = "다음(&N)";
            this.bbNext.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Left;
            this.bbNext.Id = 5;
            this.bbNext.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbNext.LargeGlyph")));
            this.bbNext.Name = "bbNext";
            this.bbNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbNext_ItemClick);
            // 
            // bbLast
            // 
            this.bbLast.Caption = "마지막(&L)";
            this.bbLast.Id = 8;
            this.bbLast.Name = "bbLast";
            this.bbLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbLast_ItemClick);
            // 
            // bbDelete
            // 
            this.bbDelete.Caption = "삭제(&R)";
            this.bbDelete.CaptionAlignment = DevExpress.XtraBars.BarItemCaptionAlignment.Right;
            this.bbDelete.Id = 9;
            this.bbDelete.LargeGlyph = global::Sniffer.Client.Viewer.Properties.Resources.Delete;
            this.bbDelete.Name = "bbDelete";
            this.bbDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbDelete_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(915, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 496);
            this.barDockControlBottom.Size = new System.Drawing.Size(915, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 465);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(915, 31);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 465);
            // 
            // pnAttaches
            // 
            this.pnAttaches.Controls.Add(this.lbAttaches);
            this.pnAttaches.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnAttaches.Location = new System.Drawing.Point(0, 125);
            this.pnAttaches.Name = "pnAttaches";
            this.pnAttaches.Size = new System.Drawing.Size(915, 37);
            this.pnAttaches.TabIndex = 21;
            // 
            // lbAttaches
            // 
            this.lbAttaches.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lbAttaches.ContextMenuStrip = this.contextMenuStrip1;
            this.lbAttaches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAttaches.Location = new System.Drawing.Point(2, 2);
            this.lbAttaches.MultiColumn = true;
            this.lbAttaches.Name = "lbAttaches";
            this.lbAttaches.Size = new System.Drawing.Size(911, 33);
            this.lbAttaches.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.lbAttaches.SysImageSize = OdinSoft.UIC.Win.Control.Library.SystemImageListSize.SmallIcons;
            this.lbAttaches.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpenFile,
            this.tsSaveFile});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // tsOpenFile
            // 
            this.tsOpenFile.Name = "tsOpenFile";
            this.tsOpenFile.Size = new System.Drawing.Size(116, 22);
            this.tsOpenFile.Text = "&Open";
            this.tsOpenFile.Click += new System.EventHandler(this.tsOpenFile_Click);
            // 
            // tsSaveFile
            // 
            this.tsSaveFile.Name = "tsSaveFile";
            this.tsSaveFile.Size = new System.Drawing.Size(116, 22);
            this.tsSaveFile.Text = "&Save As";
            this.tsSaveFile.Click += new System.EventHandler(this.tsSaveFile_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // wbMail
            // 
            this.wbMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMail.Location = new System.Drawing.Point(0, 162);
            this.wbMail.MinimumSize = new System.Drawing.Size(23, 21);
            this.wbMail.Name = "wbMail";
            this.wbMail.Size = new System.Drawing.Size(915, 334);
            this.wbMail.TabIndex = 22;
            this.wbMail.StatusTextReplaced += new System.EventHandler(this.wbMail_StatusTextChanged);
            this.wbMail.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMail_DocumentCompleted);
            this.wbMail.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.wbMail_ProgressChanged);
            // 
            // MailViewing
            // 
            this.MailViewing.WorkerReportsProgress = true;
            this.MailViewing.WorkerSupportsCancellation = true;
            this.MailViewing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.MailViewing_DoWork);
            this.MailViewing.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.MailViewing_ProgressChanged);
            this.MailViewing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.MailViewing_RunWorkerCompleted);
            // 
            // MailReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 521);
            this.Controls.Add(this.wbMail);
            this.Controls.Add(this.pnAttaches);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "MailReader";
            this.Text = "MailReader";
            this.Activated += new System.EventHandler(this.MailReader_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MailReader_FormClosing);
            this.Load += new System.EventHandler(this.MailReader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnAttaches)).EndInit();
            this.pnAttaches.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbAttaches)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private OdinSoft.UIC.Win.Control.DVX.uPanelControl panelControl1;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbSent;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabelControl2;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbBcc;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabelControl1;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbCc;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabelControl4;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbTo;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl uLabelControl3;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbFrom;
        private OdinSoft.UIC.Win.Control.DVX.uLabelControl lbTitle;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem sbText;
        private DevExpress.XtraBars.BarEditItem sbProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarLargeButtonItem bbPrev;
        private DevExpress.XtraBars.BarLargeButtonItem bbNext;
        private DevExpress.XtraBars.BarStaticItem sbPosition;
        private OdinSoft.UIC.Win.Control.DVX.uPanelControl pnAttaches;
        private OdinSoft.UIC.Win.Control.uWebBrowser wbMail;
        private OdinSoft.UIC.Win.Control.DVX.uImageListBoxControl lbAttaches;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsOpenFile;
        private System.Windows.Forms.ToolStripMenuItem tsSaveFile;
        private DevExpress.XtraBars.BarLargeButtonItem bbFirst;
        private DevExpress.XtraBars.BarLargeButtonItem bbLast;
        private DevExpress.XtraBars.BarLargeButtonItem bbDelete;
        private OdinSoft.UIC.Win.Control.uBackgroundWorker MailViewing;
    }
}