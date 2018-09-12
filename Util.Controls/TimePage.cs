using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Util.Controls
{
    public partial class TimePage : UserControl
    {
        public delegate void MyDelegate(object sender, EventArgs e);//建立委托

        public static MyDelegate myEven_click;
        private int DelectSQLifo { get; set; }
        private void Connect_Click(object sender, EventArgs e)
        {
            if (myEven_click != null)
            {
                myEven_click(sender, e);
            }
        }
        public TimePage()
        {
            InitializeComponent();
           System.Windows.Forms. Timer tm = new System.Windows.Forms.Timer() { Enabled = true, Interval = 1000 };
            tm.Tick += Tm_Tick;  
            for (int i = 0; i < 6; i++)
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                C._labName = string.Format(@"{0}#真空炉", (i + 1).ToString());
            }
            Thread th = new Thread(new ThreadStart(UpdateStatus));
            th.IsBackground = true;
            th.Start();

                //     LoadTheRequiredContent(list);
            Util.Controls.BakingPage.myEven_click += new Util.Controls.BakingPage.MyDelegate(Util.Controls.StatusChange.click);
        }
        private void UpdateStatus()
        {
            while (true)
            {
                try
                {
                    for (int i = 0; i < application.Common.DataSource._listRunA.Length; i++)//每一台运行状态
                    {
                        if (application.Common.DataSource._listRunA[i] == "0")
                        {
                            List<application.Model.MStatus> list = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.DataDAL.ReviseStatus("BakingA" + (i + 1).ToString()));
                            if (list != null) model = list[0];
                            if (model.SBaking != "待机中")
                            {
                                model.SBaking = "待机中";
                                model.SReviseTime = Convert.ToDateTime(DateTime.Now);
                                if (list != null) application.MX.DapperSQLServer<application.Model.MStatus>.UpdateData(model, "StatusID");
                            }
                        }
                        else if (application.Common.DataSource._listRunA[i] == "1")
                        {
                            List<application.Model.MStatus> list = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.DataDAL.ReviseStatus("BakingA" + (i + 1).ToString()));
                            if (list != null) model = list[0];
                            if (model.SBaking != "运行中")
                            {
                                model.SBaking = "运行中";
                                model.SReviseTime = Convert.ToDateTime(DateTime.Now);
                                if (list != null) application.MX.DapperSQLServer<application.Model.MStatus>.UpdateData(model, "StatusID");
                            }
                        }
                        else if (application.Common.DataSource._listRunA[i] == "2")
                        {
                            List<application.Model.MStatus> list = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.DataDAL.ReviseStatus("BakingA" + (i + 1).ToString()));
                            if (list != null) model = list[0];
                            if (model.SBaking != "维修中")
                            {
                                model.SBaking = "维修中";
                                model.SReviseTime = Convert.ToDateTime(DateTime.Now);
                                if (list != null) application.MX.DapperSQLServer<application.Model.MStatus>.UpdateData(model, "StatusID");
                            }
                        }
                        Thread.Sleep(1500);
                    }

                    for (int i = 0; i < application.Common.DataSource._listRunB.Length; i++)//每一台运行状态
                    {
                        if (application.Common.DataSource._listRunB[i] == "0")
                        {
                            List<application.Model.MStatus> list = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.DataDAL.ReviseStatus("BakingB" + (i + 1).ToString()));
                            if (list != null) model = list[0];
                            if (model.SBaking != "待机中")
                            {
                                model.SBaking = "待机中";
                                model.SReviseTime = Convert.ToDateTime(DateTime.Now);
                                if (list != null) application.MX.DapperSQLServer<application.Model.MStatus>.UpdateData(model, "StatusID");
                            }
                        }
                        else if (application.Common.DataSource._listRunB[i] == "1")
                        {
                            List<application.Model.MStatus> list = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.DataDAL.ReviseStatus("BakingB" + (i + 1).ToString()));
                            if (list != null) model = list[0];
                            if (model.SBaking != "运行中")
                            {
                                model.SBaking = "运行中";
                                model.SReviseTime = Convert.ToDateTime(DateTime.Now);
                                if (list != null) application.MX.DapperSQLServer<application.Model.MStatus>.UpdateData(model, "StatusID");
                            }
                        }
                        else if (application.Common.DataSource._listRunB[i] == "2")
                        {
                            List<application.Model.MStatus> list = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.DataDAL.ReviseStatus("BakingB" + (i + 1).ToString()));
                            if (list != null) model = list[0];
                            if (model.SBaking != "维修中")
                            {
                                model.SBaking = "维修中";
                                model.SReviseTime = Convert.ToDateTime(DateTime.Now);
                                if (list != null) application.MX.DapperSQLServer<application.Model.MStatus>.UpdateData(model, "StatusID");
                            }
                        }
                        Thread.Sleep(1500);
                    }
                    Thread.Sleep(3000);
                    //删除超过半年的信息
                    DelectSQLifo++;
                    if (DelectSQLifo == 36000)
                    {
                        DelectSQLifo = 0;
                        application.MX.DapperSQLServer<application.Model.MBakingTem>.ExecuteSQL(application.DAL.DelectDB.DelectTemInfo());
                        application.MX.DapperSQLServer<application.Model.MBakingRecord>.ExecuteSQL(application.DAL.DelectDB.DelectroErrorInfo());
                    }
                }
                catch (Exception ex)
                {
                    application.Common.logHelp.LogAddress(ex.Message);
                  
                }


            }
        }

        //     public static List<application.Model.MStatus> model = new List<application.Model.MStatus>();
        private void LoadTheRequiredContent(List<application.Model.MStatus> model)
        {
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            this.BackColor = Color.FromArgb(0, 0, 0, 0);

            BakingPage.myEven_click += new BakingPage.MyDelegate(Runclick);
            int ss = 0;
            for (int i = 0; i < 6; i++)
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                C._labName = string.Format(@"{0}#真空炉", (i + 1).ToString());
                C._buttA = "buttA" + (i + 1).ToString();
                C._buttB = "buttB" + (i + 1).ToString();
                int sds = i + ss;
                C._labA = model[ss].SBaking;
                C._labB = model[1+ss].SBaking;
                ss=ss+2;
            }
    
        }

        private void Runclick(object sender, EventArgs e)
        {
            ToolStripMenuItem s = (ToolStripMenuItem)sender;
            string bp = Util.Controls.BakingPage._context.Substring(0, 5);
            string ss = Util.Controls.BakingPage._context.Substring(Util.Controls.BakingPage._context.Length - 1);
            BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + ss, true)[0];
            if (bp == "buttA")
            {
                C._labA = s.Text;
            }
            else if (bp == "buttB")
            {
                C._labB = s.Text;
            }
        }
        public static application.Model.MStatus model { get; set; }

        private void Tm_Tick(object sender, EventArgs e)
        {

            for (int i = 0; i < application.Common.DataSource._listRunA.Length; i++)//每一台运行状态
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                if (application.Common.DataSource._listRunA[i] == "0")
                {
                    if (C._labA != "待机中")
                    {
                        C._labA = "待机中";
                    }
                }
                else if (application.Common.DataSource._listRunA[i] == "1")
                {
                    if (C._labA != "运行中")
                    {
                        C._labA = "运行中";
                    }
                }
                else if (application.Common.DataSource._listRunA[i] == "2")
                {
                    if (C._labA != "维修中")
                    {
                        C._labA = "维修中";
                    }

                }
                else if (application.Common.DataSource._listRunA[i] == null)
                {
                    if (C._labA != "无状态")
                    {

                        C._labA = "无状态";
                    }
                }
            }

            for (int i = 0; i < application.Common.DataSource._listRunB.Length; i++)//每一台运行状态
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                if (application.Common.DataSource._listRunB[i] == "0")
                {

                    if (C._labB != "待机中")
                    {
                        C._labB = "待机中";
                    }
                }
                else if (application.Common.DataSource._listRunB[i] == "1")
                {
                    if (C._labB != "运行中")
                    {
                        C._labB = "运行中";
                    }
                }
                else if (application.Common.DataSource._listRunB[i] == "2")
                {
                    if (C._labB != "维修中")
                    {
                        C._labB = "维修中";
                    }
                }
                else if (application.Common.DataSource._listRunB[i] == null)
                {
                    if (C._labB != "无状态")
                    {
                        C._labB = "无状态";

                    }
                }
            }

            for (int i = 0; i < application.Common.DataSource._listTiemA.Length; i++)//A层状态
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                C._textA = application.Common.DataSource._listTiemA[i];
            }
            for (int i = 0; i < application.Common.DataSource._listTiemB.Length; i++)//B层状态
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                C._textB = application.Common.DataSource._listTiemB[i];
            }

        }
    }
}
