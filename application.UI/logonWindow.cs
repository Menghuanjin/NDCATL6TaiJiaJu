using application.Model;
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
    public partial class logonWindow : Form
    {
        public logonWindow()
        {
            InitializeComponent();
            this.buttLogin.Focus();
        
        }
  
        private void buttLogin_Click(object sender, EventArgs e)
        {
            if (application.BLL.LoginManager.UserLogin(textuUser.Text.Trim(), textPaw.Text.Trim()))
            {
                MainWindow main = new MainWindow();
                this.Hide();
                main.Show();
            }
            else
            {
                application.Common.Msg.ShowError("登录失败");
            }
        }

        private void buttCancel_Click(object sender, EventArgs e)
        {
            application.Common.GetCurrentProcess.Kill();
        }
    }
}
