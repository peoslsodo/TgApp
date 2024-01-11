using System;
using System.Drawing;
using System.Windows.Forms;
using TgApp.Model;
using TgApp.Util;

namespace TgApp
{
    public partial class FrmSetup : Form
    {
        public DbUtil Db = new DbUtil();
        public int Id { get; set; }

        public FrmSetup()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtPhone.Text))
            {
                MessageBox.Show(Msg.ConfigPhone, Msg.MsgInfo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(this.txtApiId.Text))
            {
                MessageBox.Show(Msg.ConfigApiId, Msg.MsgInfo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(this.txtApiHash.Text))
            {
                MessageBox.Show(Msg.ConfigApiHash, Msg.MsgInfo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var phone = this.txtPhone.Text.Trim();
            var apiId = this.txtApiId.Text.Trim();
            var apiHash = this.txtApiHash.Text.Trim();
            var pwd=this.txtPwd.Text.Trim();
            var config = new Config
            {
               
            };
            var result = 0;
            if (this.Id > 0)
            {
                result = this.Db.UpdateConfig(config);
            }
            else
            {
                if (this.Db.IsExistCofig(""))
                {
                    MessageBox.Show(Msg.ConfigExist, Msg.MsgInfo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    result = this.Db.AddModel(config);
                }

            }
            var msg = result > 0 ? Msg.SaveSuccess : Msg.SaveFail;
            if (result > 0)
            {
                this.Id = 0;
                this.Bind();
                this.txtPhone.Clear();
                this.txtApiId.Clear();
                this.txtApiHash.Clear();
            }
            MessageBox.Show(msg, Msg.MsgInfo, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        private void FrmSetup_Load(object sender, EventArgs e)
        {
            this.Bind();
        }

        private void Bind()
        {
            var list = this.Db.GetList<Config>();
            this.dgvConfig.DataSource = list;
        }

        private void kryptonDataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (dgvConfig.Rows[e.RowIndex].Selected == false)
                    {
                        dgvConfig.ClearSelection();
                        dgvConfig.Rows[e.RowIndex].Selected = true;
                    }
                    var point = new Point(MousePosition.X, MousePosition.Y);
                    this.kryptonContextMenu1.Show(this.dgvConfig, point);

                }

            }
        }

        private void kryptonContextMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.dgvConfig.CurrentRow != null)
            {
                var model = (Config)this.dgvConfig.CurrentRow.DataBoundItem;
                this.txtApiId.Text = model?.ApiId;
                this.txtApiHash.Text = model?.ApiHash;
                this.txtPhone.Text = model?.Phone;
                this.txtPwd.Text = model?.Pwd;
                this.Id = model?.Id ?? 0;
            }
        }

        private void kryptonContextMenuItem2_Click(object sender, EventArgs e)
        {
            if (this.dgvConfig.CurrentRow != null)
            {
                if (MessageBox.Show(Msg.DelSure, Msg.MsgInfo, MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    var model = this.dgvConfig.CurrentRow.DataBoundItem as Config;
                    this.Db.DelById<Config>(Convert.ToInt32(model.Id));
                    this.Bind();
                }

            }
        }
    }
}
