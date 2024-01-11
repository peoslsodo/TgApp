using System;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using TgApp.Util;

namespace TgApp
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
          
            try
            {
                WindsorUtil.Register();
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
            }
            catch (Exception ex)
            {
              

            }
        }
    }

}
