
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Windows.Forms;
using TgApp.Model;
using TgApp.Util;
using TgLib;

namespace TgApp
{
    public partial class FrmCreateGroup : KryptonForm
    {
        public DbUtil DbUtil;
        public ITgClient TgClient;
        public FrmCreateGroup()
        {
            InitializeComponent();
            this.DbUtil = WindsorUtil.Resolve<DbUtil>();
            this.TgClient = WindsorUtil.Container.Resolve<ITgClient>();
        }

        private async void btnCreate_Click(object sender, EventArgs e)
        {
            var title = this.txtTitle.Text.Trim();
            var about = this.txtAbout.Text.Trim();
            var result = await this.TgClient.CreateGroupAsync(title, about);
            var cModel = new Groups()
            {
                Id = result.Id,
                Title = title,
                GroupId = result.GroupId,
                IsBlocked = result.IsBlocked,
                IsChannel = result.IsChannel,
                IsSuper = result.IsSuper
            };
            this.DbUtil.AddModel(cModel, false);
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
