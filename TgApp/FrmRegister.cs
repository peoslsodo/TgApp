using ComponentFactory.Krypton.Toolkit;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using TgApp.Util;

namespace TgApp
{
    public partial class FrmRegister : KryptonForm
    {
        public CheckUtil CheckUtil;
        public string Msg { get; set; }
        public FrmRegister()
        {
            InitializeComponent();
            this.CheckUtil = WindsorUtil.Resolve<CheckUtil>();
        }

        private void picHelp_Click(object sender, EventArgs e)
        {
            var url= ConfigurationManager.AppSettings["Support"].ToString();
            Process.Start(url);
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            this.labMsg.Text = this.Msg;
            this.txtCode.Text=this.CheckUtil.GetMCode();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtKey.Text))
            {
                KryptonMessageBox.Show("Authorization key cannot be empty!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                try
                {
                    var result = this.CheckUtil.UpdateVersion(this.txtKey.Text);
                    if (result.Item1)
                    {
                        KryptonMessageBox.Show("Authorized successfully!", "Info",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        var frm = new FrmMain();
                        frm.ShowDialog();
                    }
                    else
                    {
                        KryptonMessageBox.Show(result.Item2, "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {

                    KryptonMessageBox.Show(ex.Message, "Info",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
