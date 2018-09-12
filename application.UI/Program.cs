using application.UI.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.UI
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //设置应用程序处理异常方式：ThreadException处理
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                application.MX.DapperExtensions.connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

                application.BLL.IPAddress._bakingOne= System.Configuration.ConfigurationManager.ConnectionStrings["BakingOne"].ToString();

                application.BLL.IPAddress._bakingTwo = System.Configuration.ConfigurationManager.ConnectionStrings["BakingTwo"].ToString();

                application.BLL.IPAddress._bakingThree = System.Configuration.ConfigurationManager.ConnectionStrings["BakingThree"].ToString();

                application.BLL.IPAddress._bakingFour = System.Configuration.ConfigurationManager.ConnectionStrings["BakingFour"].ToString();

                application.BLL.IPAddress._bakingFive= System.Configuration.ConfigurationManager.ConnectionStrings["BakingFive"].ToString();

                application.BLL.IPAddress._bakingSix = System.Configuration.ConfigurationManager.ConnectionStrings["bakingSix"].ToString();

                application.BLL.ErrorSource.errorModel= application.MX.DapperSQLServer<application.Model.MBakingErrorInfo>.QueryAll();

                Application.EnableVisualStyles();

                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new logonWindow());
            }
            catch (Exception ex)
            {
                application.Common.logHelp.WriteError(ex.Message);
            }

        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            application.Common.logHelp.WriteError(e.Exception.ToString());
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            application.Common.logHelp.WriteError((e.ExceptionObject as Exception).ToString());
        }
    }
}
