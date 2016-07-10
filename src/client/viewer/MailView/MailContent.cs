using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;
using OdinSoft.UIC.Win.Control.Library;

namespace Sniffer.Client.Viewer.MailView
{
    public partial class MailContent : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        public MailContent(byte[] p_content)
        {
            InitializeComponent();
            this.m_messageStream = p_content;
        }
        
        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private byte[] m_messageStream = null;

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private void MailContent_Load(object sender, EventArgs e)
        {
            //Debug.WriteLine("MailContent_Load");
            LayoutHelper.RestoreFormLayout(this);
            this.memoEdit1.Text = UTF8Encoding.Default.GetString(this.m_messageStream);
        }

        private void MailContent_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Debug.WriteLine("MailContent_FormClosing");
            LayoutHelper.SaveFormLayout(this);
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
        private void bbSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog _saveDlg = new SaveFileDialog()
            {
                Filter = "E-Mail File|*.eml",
                Title = "Save an e-mail File"
            };
            _saveDlg.ShowDialog();

            if (String.IsNullOrEmpty(_saveDlg.FileName) == false)
            {
                using (System.IO.StreamWriter _sw = new System.IO.StreamWriter(_saveDlg.FileName))
                    _sw.Write(this.memoEdit1.Text);
            }
        }

        //-------------------------------------------------------------------------------------------------------------
        //
        //-------------------------------------------------------------------------------------------------------------
    }
}