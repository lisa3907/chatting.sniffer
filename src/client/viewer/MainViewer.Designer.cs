namespace Sniffer.Client.Viewer
{
    partial class MainViewer
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.bbExit = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.bbMail = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbChat = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barSubItem4 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbLayoutReset = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbEncrypt = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem7 = new DevExpress.XtraBars.BarSubItem();
            this.barMdiChildrenListItem1 = new DevExpress.XtraBars.BarMdiChildrenListItem();
            this.bbCascade = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbTileHorizontal = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbTileVertical = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bbArrangeIcons = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barSubItem5 = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem8 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem9 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barButtonItem11 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.sbProgress = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barSubItem6 = new DevExpress.XtraBars.BarSubItem();
            this.repositoryItemMemoExEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.Controller = this.barAndDockingController1;
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.sbProgress,
            this.barSubItem1,
            this.barSubItem2,
            this.barSubItem3,
            this.barSubItem4,
            this.barSubItem5,
            this.bbExit,
            this.barSubItem6,
            this.barButtonItem2,
            this.bbMail,
            this.bbChat,
            this.barSubItem7,
            this.barMdiChildrenListItem1,
            this.bbCascade,
            this.bbTileHorizontal,
            this.bbTileVertical,
            this.bbArrangeIcons,
            this.barButtonItem4,
            this.barButtonItem7,
            this.barButtonItem8,
            this.barButtonItem9,
            this.barButtonItem10,
            this.barButtonItem11,
            this.bbLayoutReset,
            this.bbEncrypt});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 32;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1,
            this.repositoryItemMemoExEdit1});
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem7),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem5)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.RotateWhenVertical = false;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Custom 3";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "파일(&F)";
            this.barSubItem1.Id = 2;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbExit)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // bbExit
            // 
            this.bbExit.Caption = "끝내기(&X)";
            this.bbExit.Id = 7;
            this.bbExit.Name = "bbExit";
            this.bbExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbExit_ItemClick);
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "편집(&E)";
            this.barSubItem2.Id = 3;
            this.barSubItem2.Name = "barSubItem2";
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "보기(&V)";
            this.barSubItem3.Id = 4;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.bbMail),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbChat)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // bbMail
            // 
            this.bbMail.Caption = "전자우편(&Mail)";
            this.bbMail.Id = 10;
            this.bbMail.Name = "bbMail";
            this.bbMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbMail_ItemClick);
            // 
            // bbChat
            // 
            this.bbChat.Caption = "메신져(&Chat)";
            this.bbChat.Id = 11;
            this.bbChat.Name = "bbChat";
            this.bbChat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbChat_ItemClick);
            // 
            // barSubItem4
            // 
            this.barSubItem4.Caption = "도구(&T)";
            this.barSubItem4.Id = 5;
            this.barSubItem4.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbLayoutReset),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbEncrypt)});
            this.barSubItem4.Name = "barSubItem4";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "옵션(&O)";
            this.barButtonItem2.Id = 9;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bbLayoutReset
            // 
            this.bbLayoutReset.Caption = "레이아웃 리셋(&R)";
            this.bbLayoutReset.Id = 29;
            this.bbLayoutReset.Name = "bbLayoutReset";
            this.bbLayoutReset.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbLayoutReset_ItemClick);
            // 
            // bbEncrypt
            // 
            this.bbEncrypt.Caption = "암호화(&E)";
            this.bbEncrypt.Id = 31;
            this.bbEncrypt.Name = "bbEncrypt";
            this.bbEncrypt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbEncrypt_ItemClick);
            // 
            // barSubItem7
            // 
            this.barSubItem7.Caption = "창(&W)";
            this.barSubItem7.Id = 12;
            this.barSubItem7.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barMdiChildrenListItem1),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Caption, this.bbCascade, "&Cascade", true),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbTileHorizontal),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbTileVertical),
            new DevExpress.XtraBars.LinkPersistInfo(this.bbArrangeIcons)});
            this.barSubItem7.Name = "barSubItem7";
            // 
            // barMdiChildrenListItem1
            // 
            this.barMdiChildrenListItem1.Caption = "barMdiChildrenListItem1";
            this.barMdiChildrenListItem1.Id = 13;
            this.barMdiChildrenListItem1.Name = "barMdiChildrenListItem1";
            // 
            // bbCascade
            // 
            this.bbCascade.Caption = "Cascade";
            this.bbCascade.Id = 14;
            this.bbCascade.Name = "bbCascade";
            this.bbCascade.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbCascade_ItemClick);
            // 
            // bbTileHorizontal
            // 
            this.bbTileHorizontal.Caption = "Tile&Horizontal";
            this.bbTileHorizontal.Id = 15;
            this.bbTileHorizontal.Name = "bbTileHorizontal";
            this.bbTileHorizontal.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbTileHorizontal_ItemClick);
            // 
            // bbTileVertical
            // 
            this.bbTileVertical.Caption = "Tile&Vertical";
            this.bbTileVertical.Id = 16;
            this.bbTileVertical.Name = "bbTileVertical";
            this.bbTileVertical.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbTileVertical_ItemClick);
            // 
            // bbArrangeIcons
            // 
            this.bbArrangeIcons.Caption = "Arrange&Icons";
            this.bbArrangeIcons.Id = 17;
            this.bbArrangeIcons.Name = "bbArrangeIcons";
            this.bbArrangeIcons.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbArrangeIcons_ItemClick);
            // 
            // barSubItem5
            // 
            this.barSubItem5.Caption = "도움말(&H)";
            this.barSubItem5.Id = 6;
            this.barSubItem5.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem8),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem9),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem10),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem11, true)});
            this.barSubItem5.Name = "barSubItem5";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "목차";
            this.barButtonItem4.Id = 21;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "사용자의견";
            this.barButtonItem7.Id = 24;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            this.barButtonItem8.Caption = "제품등록";
            this.barButtonItem8.Id = 25;
            this.barButtonItem8.Name = "barButtonItem8";
            // 
            // barButtonItem9
            // 
            this.barButtonItem9.Caption = "업데이트확인";
            this.barButtonItem9.Id = 26;
            this.barButtonItem9.Name = "barButtonItem9";
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "기술지원";
            this.barButtonItem10.Id = 27;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // barButtonItem11
            // 
            this.barButtonItem11.Caption = "스나이퍼 정보";
            this.barButtonItem11.Id = 28;
            this.barButtonItem11.Name = "barButtonItem11";
            // 
            // barAndDockingController1
            // 
            this.barAndDockingController1.PropertiesBar.AllowLinkLighting = false;
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
            // barSubItem6
            // 
            this.barSubItem6.Caption = "옵션(&O)";
            this.barSubItem6.Id = 8;
            this.barSubItem6.Name = "barSubItem6";
            // 
            // repositoryItemMemoExEdit1
            // 
            this.repositoryItemMemoExEdit1.AutoHeight = false;
            this.repositoryItemMemoExEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemMemoExEdit1.Name = "repositoryItemMemoExEdit1";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "iMaginary";
            // 
            // MainViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 521);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.Name = "MainViewer";
            this.Text = "MainViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainViewer_FormClosing);
            this.Load += new System.EventHandler(this.MainViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoExEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarLargeButtonItem bbExit;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarSubItem barSubItem4;
        private DevExpress.XtraBars.BarLargeButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarSubItem barSubItem5;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarSubItem barSubItem6;
        private DevExpress.XtraBars.BarLargeButtonItem bbMail;
        private DevExpress.XtraBars.BarLargeButtonItem bbChat;
        private DevExpress.XtraBars.BarSubItem barSubItem7;
        private DevExpress.XtraBars.BarMdiChildrenListItem barMdiChildrenListItem1;
        private DevExpress.XtraBars.BarLargeButtonItem bbCascade;
        private DevExpress.XtraBars.BarLargeButtonItem bbTileHorizontal;
        private DevExpress.XtraBars.BarLargeButtonItem bbTileVertical;
        private DevExpress.XtraBars.BarLargeButtonItem bbArrangeIcons;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoExEdit repositoryItemMemoExEdit1;
        private DevExpress.XtraBars.BarLargeButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarLargeButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarLargeButtonItem barButtonItem8;
        private DevExpress.XtraBars.BarLargeButtonItem barButtonItem9;
        private DevExpress.XtraBars.BarLargeButtonItem barButtonItem10;
        private DevExpress.XtraBars.BarLargeButtonItem barButtonItem11;
        private DevExpress.XtraBars.BarLargeButtonItem bbLayoutReset;
        public DevExpress.XtraBars.BarEditItem sbProgress;
        private DevExpress.XtraBars.BarButtonItem bbEncrypt;
    }
}