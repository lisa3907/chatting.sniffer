namespace Sniffer.Client.Viewer.Dialog
{
    partial class ConnString
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tbPlainText = new OdinSoft.UIC.Win.Control.uTextBox();
            this.tbChiperText = new OdinSoft.UIC.Win.Control.uTextBox();
            this.btPlainToChiper = new OdinSoft.UIC.Win.Control.uButton();
            this.btChiperToPlain = new OdinSoft.UIC.Win.Control.uButton();
            this.btClose = new OdinSoft.UIC.Win.Control.uButton();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 24);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 14);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Plain-Text";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 149);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Chiper-Text";
            // 
            // tbPlainText
            // 
            this.tbPlainText.Location = new System.Drawing.Point(116, 24);
            this.tbPlainText.Multiline = true;
            this.tbPlainText.Name = "tbPlainText";
            this.tbPlainText.Size = new System.Drawing.Size(347, 120);
            this.tbPlainText.TabIndex = 7;
            // 
            // tbChiperText
            // 
            this.tbChiperText.Location = new System.Drawing.Point(116, 149);
            this.tbChiperText.Multiline = true;
            this.tbChiperText.Name = "tbChiperText";
            this.tbChiperText.Size = new System.Drawing.Size(347, 120);
            this.tbChiperText.TabIndex = 8;
            // 
            // btPlainToChiper
            // 
            this.btPlainToChiper.ImageLocation = new System.Drawing.Point(0, 0);
            this.btPlainToChiper.Location = new System.Drawing.Point(116, 313);
            this.btPlainToChiper.Name = "btPlainToChiper";
            this.btPlainToChiper.Size = new System.Drawing.Size(107, 34);
            this.btPlainToChiper.TabIndex = 9;
            this.btPlainToChiper.Text = "PlainToChiper";
            this.btPlainToChiper.UseVisualStyleBackColor = true;
            this.btPlainToChiper.Click += new System.EventHandler(this.btPlainToChiper_Click);
            // 
            // btChiperToPlain
            // 
            this.btChiperToPlain.ImageLocation = new System.Drawing.Point(0, 0);
            this.btChiperToPlain.Location = new System.Drawing.Point(229, 313);
            this.btChiperToPlain.Name = "btChiperToPlain";
            this.btChiperToPlain.Size = new System.Drawing.Size(107, 34);
            this.btChiperToPlain.TabIndex = 10;
            this.btChiperToPlain.Text = "ChiperToPlain";
            this.btChiperToPlain.UseVisualStyleBackColor = true;
            this.btChiperToPlain.Click += new System.EventHandler(this.btChiperToPlain_Click);
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.ImageLocation = new System.Drawing.Point(0, 0);
            this.btClose.Location = new System.Drawing.Point(342, 313);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(107, 34);
            this.btClose.TabIndex = 11;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ConnString
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(479, 363);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btChiperToPlain);
            this.Controls.Add(this.btPlainToChiper);
            this.Controls.Add(this.tbChiperText);
            this.Controls.Add(this.tbPlainText);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConnString";
            this.Text = "Encrypt & Decrypt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConnString_FormClosing);
            this.Load += new System.EventHandler(this.ConnString_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private OdinSoft.UIC.Win.Control.uTextBox tbPlainText;
        private OdinSoft.UIC.Win.Control.uTextBox tbChiperText;
        private OdinSoft.UIC.Win.Control.uButton btPlainToChiper;
        private OdinSoft.UIC.Win.Control.uButton btChiperToPlain;
        private OdinSoft.UIC.Win.Control.uButton btClose;

    }
}