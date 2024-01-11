using Castle.Core.Logging;
using ComponentFactory.Krypton.Navigator;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TgApp.Model;
using TgApp.Util;
using ITgClient = TgLib.ITgClient;

namespace TgApp
{
    public partial class FrmMain : KryptonForm
    {
        public ITgClient TgClient;
       
        public ILogger _logger;
        public FrmMain()
        {
            InitializeComponent();
           // this.TgClient = WindsorUtil.Resolve<ITgClient>();
           
            _logger = WindsorUtil.Resolve<ILogger>();
        }
        private void CreatePage(Control control)
        {
            var page = new KryptonPage();
            page.Text = control.Text;
            page.TextTitle = control.Text;
            control.Dock = DockStyle.Fill;
            page.Controls.Add(control);

        }
        /// <summary>
        ///   Close the page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClosePage(object sender, EventArgs e)
        {
            var bsa = (ButtonSpecAny)sender;
            var page = (KryptonPage)bsa.Tag;
            if (page != null)
            {
                var cell = this.kryptonWorkspace1.CellForPage(page);
                cell.Pages.Remove(page);
                page.Dispose();
            }
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.kryptonRibbon1.SelectedTab = this.ribTabUser;
        

          


        }

        private void ribBtnSetup_Click(object sender, EventArgs e)
        {
            new FrmSetup().ShowDialog();
        }

        private void ribBtnAuth_Click(object sender, EventArgs e)
        {
            //var frm = new FrmAuth();
            //frm.ShowDialog();
        }

        private void rgbMsgPreset_Click(object sender, EventArgs e)
        {
            
        }

        private void btnContactList_Click(object sender, EventArgs e)
        {
            
        }

        private void btnGroupList_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBatchInvite_Click(object sender, EventArgs e)
        {
           
        }

        private void btnGroupBatchSend_Click(object sender, EventArgs e)
        {
            
        }

        private void btnContactSend_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSendImg_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDownHistory_Click(object sender, EventArgs e)
        {

         
        }

        private void rgbTg_Click(object sender, EventArgs e)
        {
            var frm = new FrmTg();
            frm.ShowDialog();
        }

        private void kryptonRibbonGroupGallery1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = this.kryptonRibbonGroupGallery1.SelectedIndex;
            if (index <= -1) return;
            string lang;
        }

        private void ChangeLang(string lang = default)
        {

        }

        private void btnOffice07Blue_Click(object sender, EventArgs e)
        {
           
        }

        private void btnOffice07Sliver_Click(object sender, EventArgs e)
        {
          
        }

        private void btnOffice07Black_Click(object sender, EventArgs e)
        {
         
        }

        private void btnOffice10Sliver_Click(object sender, EventArgs e)
        {
           
        }

        private void btnOffice10Black_Click(object sender, EventArgs e)
        {
           
        }

        private void btnOffice10Blue_Click(object sender, EventArgs e)
        {
            kryptonManager1.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
        }

        private void btnGroupMember_Click(object sender, EventArgs e)
        {
           
        }

        private void btnOnlineChannel_Click(object sender, EventArgs e)
        {
           
        }


        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void groupHelpBtn_Click(object sender, EventArgs e)
        {
           

        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (KryptonMessageBox.Show("Are you sure Exit?", Msg.MsgInfo,
              MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    e.Cancel = false;
                }
                else
                {
                    e.Cancel = true;
                }

            }
          
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void krgbService_Click(object sender, EventArgs e)
        {
            var url = ConfigurationManager.AppSettings["Support"].ToString();
            Process.Start(url);
        }

        private void krgbuserInviteBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void krgbBtnGroup_Click(object sender, EventArgs e)
        {
        }

        private void krgbReceiveBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void krgbNearByUser_Click(object sender, EventArgs e)
        {
           
        }

        private void krgbNearGroup_Click(object sender, EventArgs e)
        {
           
        }
    }
}
