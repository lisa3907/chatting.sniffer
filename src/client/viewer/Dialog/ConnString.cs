using System;
using System.Windows.Forms;
using Sniffer.Proxy.CPacket;
using OdinSoft.UIC.Win.Control.Library;

namespace Sniffer.Client.Viewer.Dialog
{
    public partial class ConnString : DevExpress.XtraEditors.XtraForm
    {
        //-------------------------------------------------------------------------------------------------------------//
        // 
        //-------------------------------------------------------------------------------------------------------------//
        public ConnString()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------------------//
        // 
        //-------------------------------------------------------------------------------------------------------------//
        private void ConnString_Load(object sender, EventArgs e)
        {
            LayoutHelper.RestoreFormLayout(this);
        }

        private void ConnString_FormClosing(object sender, FormClosingEventArgs e)
        {
            LayoutHelper.SaveFormLayout(this);
        }

        //-------------------------------------------------------------------------------------------------------------//
        // 
        //-------------------------------------------------------------------------------------------------------------//
        private void btPlainToChiper_Click(object sender, EventArgs e)
        {
            tbChiperText.Text = CPACKET_STRING.g_rencrypt.PlainToChiper(tbPlainText.Text);
        }

        private void btChiperToPlain_Click(object sender, EventArgs e)
        {
            tbPlainText.Text = CPACKET_STRING.g_rencrypt.ChiperToPlain(tbChiperText.Text);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-------------------------------------------------------------------------------------------------------------//
        // 
        //-------------------------------------------------------------------------------------------------------------//
    }
}