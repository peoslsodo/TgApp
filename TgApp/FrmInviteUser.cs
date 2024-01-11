using Castle.Core.Logging;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using TgApp.Model;
using TgApp.Util;
using TgLib;

namespace TgApp
{
    public partial class FrmInviteUser : KryptonForm
    {
        public DbUtil DbService;
        public ITgClient TgClient { get; set; }
        public ILogger Logger { get; set; }
        public long UserId { get; set; }
        public string UserName { get; set; }
        public FrmInviteUser()
        {
            InitializeComponent();
            this.DbService = WindsorUtil.Resolve<DbUtil>();
            this.TgClient = WindsorUtil.Resolve<ITgClient>();
            this.Logger = WindsorUtil.Resolve<ILogger>();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmInviteUser_Load(object sender, EventArgs e)
        {
            this.txtUserName.Text = this.UserName;
            var list = this.DbService.GetList<Groups>();
            this.comboxGroups.DataSource = list;
            this.comboxGroups.DisplayMember = "Title";
            this.comboxGroups.ValueMember = "Id";
        }

        private async void btnInvite_Click(object sender, EventArgs e)
        {
            if (this.comboxGroups.SelectedIndex <= -1) return;
            var group = this.comboxGroups.SelectedItem as Groups;
            var msg = string.Empty;
            try
            {
                var result = await this.TgClient.InviteGroupAsync(group.Id, this.UserId, group.IsChannel);
                msg = result.IsSuccess ? "Invite Success" : result.Reason;

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                this.Logger.Error(ex.Message, ex);
            }
            KryptonMessageBox.Show(msg, "Info",
                     MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }
    }
}
