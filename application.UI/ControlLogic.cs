using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UtilityLibrary.WinControls;

namespace application.BLL
{
    public class ControlLogic
    {
        public static Form thisff = null;
        private static Util.Controls.VacuumPage vp = null;

        private static Util.Controls.TimePage tp = null;

        private static Util.Controls.TemPage ttp = null;

        private static Util.Controls.TemQueryPage tqp = null;

        private static Util.Controls.ErrorQueryPage eqp = null;

        private static OutlookBar outlookBar1 = null;

        private static Util.Controls.StatusQueryPage sqp = null;

        private static Util.Controls.LogPage np = null;

        public static void DataControls()
        {
         //   List<application.Model.MStatus> list = application.MX.DapperSQLServer<application.Model.MStatus>.QueryAll();

            vp = new Util.Controls.VacuumPage(); tp = new Util.Controls.TimePage();

            ttp = new Util.Controls.TemPage(); tqp = new Util.Controls.TemQueryPage();

            eqp = new Util.Controls.ErrorQueryPage(); sqp = new Util.Controls.StatusQueryPage();

            np = new Util.Controls.LogPage();
        }
        public static Control[] InitializeOutlookbar(ImageList imageList)
        {
            outlookBar1 = new OutlookBar();
            

            #region 页面管理
            OutlookBarBand outlookShortcutsBand = new OutlookBarBand("功能管理");

            outlookShortcutsBand.SmallImageList = imageList;

            outlookShortcutsBand.LargeImageList = imageList;
         

            outlookShortcutsBand.Items.Add(new OutlookBarItem("运行温度", 0));

            outlookShortcutsBand.Items.Add(new OutlookBarItem("运行时间", 1));

            outlookShortcutsBand.Items.Add(new OutlookBarItem("运行真空", 2));

            //outlookShortcutsBand.Items.Add(new OutlookBarItem("运行配置", 3));

            outlookShortcutsBand.Items.Add(new OutlookBarItem("运行日志", 4));


            outlookShortcutsBand.Items.Add(new OutlookBarItem("温度查询", 5));

            outlookShortcutsBand.Items.Add(new OutlookBarItem("报警查询", 6));

            //outlookShortcutsBand.Items.Add(new OutlookBarItem("日志查询", 7));

            outlookShortcutsBand.Background = Color.LightSteelBlue;

            outlookShortcutsBand.TextColor = Color.Black;


            
            outlookBar1.Bands.Add(outlookShortcutsBand);

            #endregion

            //#region 页面展示
            //OutlookBarBand mystorageBand = new OutlookBarBand("查询管理");

            //mystorageBand.SmallImageList = imageList;

            //mystorageBand.LargeImageList = imageList;

            //mystorageBand.Items.Add(new OutlookBarItem("温度查询", 5));

            //mystorageBand.Items.Add(new OutlookBarItem("报警查询", 6));

            //mystorageBand.Items.Add(new OutlookBarItem("日志查询", 7));

            //mystorageBand.Background = Color.White;

            //mystorageBand.TextColor = Color.Black;

            //outlookBar1.Bands.Add(mystorageBand);
            //#endregion
            #region 系统管理
            OutlookBarBand system = new OutlookBarBand("系统管理");

            system.SmallImageList = imageList;

            system.LargeImageList = imageList;

            system.Items.Add(new OutlookBarItem("最小化", 8));

            system.Items.Add(new OutlookBarItem("切换登录", 9));

            system.Items.Add(new OutlookBarItem("退出系统", 10));

            system.Background = Color.LightSteelBlue;

            system.TextColor = Color.Black;

            outlookBar1.Bands.Add(system);
            #endregion



            outlookBar1.Dock = DockStyle.Fill;

            outlookBar1.SetCurrentBand(0);

            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);

            outlookBar1.ItemDropped += new OutlookBarItemDroppedHandler(OnOutlookBarItemDropped);

            return new Control[] { outlookBar1 };

        }
        private static  void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            switch (item.Text)
            {
                case "运行真空":
                    application.Common.CommonControl.GetGpb(vp);
                    break;
                case "运行时间":
                    application.Common.CommonControl.GetGpb(tp);
                    break;
                case "运行温度":
                    application.Common.CommonControl.GetGpb(ttp);
                    break;
                case "运行日志":
                    application.Common.CommonControl.GetGpb(np);
                    break;
                case "温度查询":
                    application.Common.CommonControl.GetGpb(tqp);
                    break;
                case "报警查询":
                    application.Common.CommonControl.GetGpb(eqp);
                    break;
                case "状态查询":
                    application.Common.CommonControl.GetGpb(sqp);
                    break;
                case "最小化":
                     thisff.WindowState = FormWindowState.Minimized;
                    break;
                case "切换登录":
                    if (!Common.Msg.AskQuestion("是否切换用户?"))
                        return;
                    string appStartupPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
                    System.Diagnostics.Process.Start(appStartupPath + @"\application.UI.exe");
                    Process.GetCurrentProcess().Kill();
                    break;
                case "退出系统":
                    if(application.Common.Msg.AskQuestion("确定要退出应用程序吗？"))
                        //for (int i = 0; i < 1; i++)
                        //{
                        //    DataGather.bakingContent[0].Close();
                        //}
                      
                    application.Common.GetCurrentProcess.Kill();
                    break;
            }
        }

        private  static void OnOutlookBarItemDropped(OutlookBarBand band, OutlookBarItem item)
        {

        }
    }
}
