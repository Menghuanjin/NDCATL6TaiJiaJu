using application.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.UI
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            application.BLL.ControlLogic.DataControls();
            application.BLL.ControlLogic.thisff = this;
            loadingData();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            //    labUser.Text = application.BLL.AppConfigure.result.UserName;
         
        }
        private void loadingData()
        {
          
            application.Common.CommonControl.flp = this.flowLayoutPanel1;

            application.BLL.DataGather.loadingBasicInfo();

            panel1.Controls.AddRange(application.BLL.ControlLogic.InitializeOutlookbar(imageList1));

            Timer tm = new Timer() { Interval = 1000, Enabled = true };
            tm.Tick += Tm_Tick;
        }
        private void Tm_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format(@"欢迎您：{0}", AppConfigure.result.UserName);

            toolStripStatusLabel2.Text = string.Format(@"当前时间：{0}", DateTime.Now.ToString());
        }
    }
}
