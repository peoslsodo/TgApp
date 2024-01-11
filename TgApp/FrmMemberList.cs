using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using TgApp.Model;
using TgApp.Util;
using TgLib;

namespace TgApp
{
    public partial class FrmMemberList : KryptonForm
    {
        public ITgClient TgClient;
        public DbUtil DbUtil;
        private FrmLoading frmLoading = new FrmLoading();
        public long GroupId { get; set; }
        public bool IsSuper { get; set; }

        public FrmMemberList()
        {
            InitializeComponent();
            this.TgClient = WindsorUtil.Resolve<ITgClient>();
            this.DbUtil = WindsorUtil.Resolve<DbUtil>();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FrmMemberList_Load(object sender, EventArgs e)
        {
            await this.GetMemberData();
            this.Bind();
        }

        private async Task GetMemberData()
        {
            if (this.DbUtil.IsExistMemberGroup(this.GroupId))
            {
                return;
            }
            try
            {
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    this.btnClear.Enabled = false;
                    this.progressBar1.PerformStep();
                });

                this.frmLoading.Show(this);
                var list = await this.TgClient.GetGroupUsersAsync(this.GroupId, this.IsSuper);
                this.frmLoading.Hide();
                this.InvokeOnUiThreadIfRequired(() =>
                {
                    this.progressBar1.Maximum = list.Count + 1;
                });

                foreach (var model in list.Select(user => new Members
                {
                    UserId = user.Id,
                    FirstName = user.FirstName,
                    Date = DateTime.Now,
                    GroupId = this.GroupId,
                    IsContact = user.IsContact,
                    IsScam = user.IsScam,
                    Status = user.Status,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    RestrictionReason = user.RestrictionReason,
                    Username = user.Username
                }).Where(model => !this.DbUtil.IsExistMember(this.GroupId, model.UserId)))
                {
                    this.DbUtil.AddModel<Members>(model);

                    this.InvokeOnUiThreadIfRequired(() =>
                    {
                        this.progressBar1.PerformStep();
                    });
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, Msg.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.frmLoading.Hide();
            }
            this.InvokeOnUiThreadIfRequired(() =>
            {
                this.progressBar1.Visible = false;
                this.btnClear.Enabled = true;
            });
        }

        private void Bind()
        {
            var list = this.DbUtil.GetMemberList(this.GroupId)
                .OrderByDescending(c => c.PhoneNumber)
                .ToList();

            this.kryptonDataGridView1.DataSource = list;
            this.labTotal.Text = list.Count.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this.kryptonDataGridView1.Rows.Count == 0) return;
            if (KryptonMessageBox.Show(Msg.ClearAll, Msg.MsgInfo, MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes) return;
            var result = this.DbUtil.DelAll<Members>();
            if (result > 0)
            {
                this.kryptonDataGridView1.DataSource = new List<MemberView>();
            }
            else
            {
                KryptonMessageBox.Show(Msg.DelSucess, Msg.MsgInfo, MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
             


        }
    }
}
