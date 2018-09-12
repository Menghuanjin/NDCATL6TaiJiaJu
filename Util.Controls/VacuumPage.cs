using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Util.Controls
{
    public partial class VacuumPage : UserControl
    {

        public VacuumPage()
        {
            InitializeComponent();
            //     LoadTheRequiredContent(list);
            Timer tm = new Timer() { Enabled = true, Interval = 1000 };
            tm.Tick += Tm_Tick;
            for (int i = 0; i < 6; i++)
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                C._labName = string.Format(@"{0}#真空炉", (i + 1).ToString());
            }
        }


        public static List<application.Model.MStatus> model = new List<application.Model.MStatus>();
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
                C._labB = model[1 + ss].SBaking;
                ss = ss + 2;
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

            for (int i = 0; i < application.Common.DataSource._listVacA.Length; i++)//A层状态
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                C._textA = application.Common.DataSource._listVacA[i];
            }
            for (int i = 0; i < application.Common.DataSource._listVacB.Length; i++)//B层状态
            {
                BakingPage C = (BakingPage)this.Controls.Find("BakingPage" + (i + 1), true)[0];
                C._textB = application.Common.DataSource._listVacB[i];
            }
        }
    }
}
    

