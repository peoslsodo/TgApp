using ComponentFactory.Krypton.Toolkit;
using System;
using System.Configuration;
using System.Diagnostics;
using TgApp.Util;

namespace TgApp
{
    public partial class FrmTg : KryptonForm
    {
        public FrmTg()
        {
            InitializeComponent();
        }

        private void FrmTg_Load(object sender, EventArgs e)
        {
            var version = WindsorUtil.Resolve<VersionUtils>();
            kryptonLabel1.Text = $"{version.Name} {version.Version}";
            kryptonLinkLabel3.Text = $"{version.Name} {version.Version}(Online Help)";
            kryptonLabel3.Text = $"vsersion {version.Version}";

            this.labd.Text = "This software is to help users send and receive messages conveniently and improve efficiency." + Environment.NewLine +
                 "Please do not use this software to do anything that violates national laws. Anything" + Environment.NewLine +
                 "the user does has nothing to do with the author of this software.";

        }

        private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://codecanyon.net/item/google-maps-data-scraper-pro/34319381");
        }

        private void kryptonLinkLabel2_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://codecanyon.net/item/social-network-data-scraper-pro/34467442");
        }

        private void kryptonLinkLabel3_LinkClicked(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings["Support"].ToString();
            Process.Start(url);
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonLinkLabel4_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://codecanyon.net/item/email-verifier-pro/34217013");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings["Support"].ToString();
            Process.Start(url);
        }
    }
}
