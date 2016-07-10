namespace Sniffer.Client.Main
{
    partial class sniffer
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btStop = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btStart = new System.Windows.Forms.Button();
            this.cbIpAdrs = new System.Windows.Forms.ComboBox();
            this.sbSniffer = new System.Windows.Forms.StatusBar();
            this.rtMessage = new System.Windows.Forms.RichTextBox();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.lvMessages = new System.Windows.Forms.ListView();
            this.chProtocol = new System.Windows.Forms.ColumnHeader();
            this.chSrcAdrs = new System.Windows.Forms.ColumnHeader();
            this.chSrcPort = new System.Windows.Forms.ColumnHeader();
            this.chDstAdrs = new System.Windows.Forms.ColumnHeader();
            this.chDstPort = new System.Windows.Forms.ColumnHeader();
            this.chMessage = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(848, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btStop);
            this.panel2.Controls.Add(this.btClear);
            this.panel2.Controls.Add(this.btStart);
            this.panel2.Controls.Add(this.cbIpAdrs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(848, 53);
            this.panel2.TabIndex = 24;
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(424, 9);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(110, 35);
            this.btStop.TabIndex = 5;
            this.btStop.Text = "Stop";
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btClear
            // 
            this.btClear.Location = new System.Drawing.Point(566, 9);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(110, 35);
            this.btClear.TabIndex = 4;
            this.btClear.Text = "Clear";
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(287, 9);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(110, 35);
            this.btStart.TabIndex = 3;
            this.btStart.Text = "Start";
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // cbIpAdrs
            // 
            this.cbIpAdrs.FormattingEnabled = true;
            this.cbIpAdrs.Location = new System.Drawing.Point(23, 12);
            this.cbIpAdrs.Name = "cbIpAdrs";
            this.cbIpAdrs.Size = new System.Drawing.Size(221, 20);
            this.cbIpAdrs.TabIndex = 0;
            // 
            // sbSniffer
            // 
            this.sbSniffer.Location = new System.Drawing.Point(0, 520);
            this.sbSniffer.Name = "sbSniffer";
            this.sbSniffer.Size = new System.Drawing.Size(848, 22);
            this.sbSniffer.TabIndex = 27;
            // 
            // rtMessage
            // 
            this.rtMessage.AcceptsTab = true;
            this.rtMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtMessage.Font = new System.Drawing.Font("굴림체", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rtMessage.Location = new System.Drawing.Point(0, 379);
            this.rtMessage.Name = "rtMessage";
            this.rtMessage.ReadOnly = true;
            this.rtMessage.ShowSelectionMargin = true;
            this.rtMessage.Size = new System.Drawing.Size(848, 141);
            this.rtMessage.TabIndex = 29;
            this.rtMessage.Text = "";
            this.rtMessage.WordWrap = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 376);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(848, 3);
            this.splitter2.TabIndex = 30;
            this.splitter2.TabStop = false;
            // 
            // lvMessages
            // 
            this.lvMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chProtocol,
            this.chSrcAdrs,
            this.chSrcPort,
            this.chDstAdrs,
            this.chDstPort,
            this.chMessage});
            this.lvMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMessages.FullRowSelect = true;
            this.lvMessages.GridLines = true;
            this.lvMessages.HideSelection = false;
            this.lvMessages.LabelWrap = false;
            this.lvMessages.Location = new System.Drawing.Point(0, 77);
            this.lvMessages.Name = "lvMessages";
            this.lvMessages.Size = new System.Drawing.Size(848, 299);
            this.lvMessages.TabIndex = 31;
            this.lvMessages.UseCompatibleStateImageBehavior = false;
            this.lvMessages.View = System.Windows.Forms.View.Details;
            this.lvMessages.SelectedIndexChanged += new System.EventHandler(this.lvMessages_SelectedIndexChanged);
            // 
            // chProtocol
            // 
            this.chProtocol.Text = "Protocol";
            // 
            // chSrcAdrs
            // 
            this.chSrcAdrs.Text = "Source";
            this.chSrcAdrs.Width = 90;
            // 
            // chSrcPort
            // 
            this.chSrcPort.Text = "Port";
            // 
            // chDstAdrs
            // 
            this.chDstAdrs.Text = "Destination";
            // 
            // chDstPort
            // 
            this.chDstPort.Text = "Port";
            // 
            // chMessage
            // 
            this.chMessage.Text = "Message";
            this.chMessage.Width = 500;
            // 
            // sniffer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 542);
            this.Controls.Add(this.lvMessages);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.rtMessage);
            this.Controls.Add(this.sbSniffer);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Name = "sniffer";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sniffer_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.ComboBox cbIpAdrs;
        private System.Windows.Forms.StatusBar sbSniffer;
        private System.Windows.Forms.RichTextBox rtMessage;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.ListView lvMessages;
        private System.Windows.Forms.ColumnHeader chProtocol;
        private System.Windows.Forms.ColumnHeader chSrcAdrs;
        private System.Windows.Forms.ColumnHeader chSrcPort;
        private System.Windows.Forms.ColumnHeader chDstAdrs;
        private System.Windows.Forms.ColumnHeader chDstPort;
        private System.Windows.Forms.ColumnHeader chMessage;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}

