using Castle.Core.Logging;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using TgApp.Util;
using TgLib;

namespace TgApp
{
    public partial class FrmGroupSend : KryptonForm
    {
        public ITgClient TgClient;
        public ILogger Logger;

        public long GroupId { get; set; }
        public string GroupName { get; set; }
        public FrmGroupSend()
        {
            InitializeComponent();
            this.Logger = WindsorUtil.Resolve<ILogger>();
            this.TgClient = WindsorUtil.Resolve<ITgClient>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                KryptonMessageBox.Show("please enter message!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            var msg = this.txtMessage.Text.Trim();
            try
            {
                await TgClient.SendMessageAsync(GroupId, msg);
            }
            catch (Exception ex)
            {

                KryptonMessageBox.Show(ex.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
