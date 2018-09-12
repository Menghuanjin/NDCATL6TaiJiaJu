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
    public partial class LogPage : UserControl
    {
        public static SynchronizationContext _SynchronizationContext;
        public LogPage()
        {
            InitializeComponent();
            System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer() { Interval = 5000, Enabled = true };
            tm.Tick += Tm_Tick;
        }
        private void Tm_Tick(object sender, EventArgs e)
        {

            if (application.Common.logHelp.list.Count > 30)
            {
                application.Common.logHelp.list.Clear();

            }
            this.listBox1.DataSource = null;
            this.listBox1.DataSource = application.Common.logHelp.list;
        }
    }
   
}
