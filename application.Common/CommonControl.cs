using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Common
{
  public  class CommonControl
    {
        public static FlowLayoutPanel flp { get; set; }
        public static void GetGpb(Control ff)
        {
            ff.Show();
            flp.Controls.Clear();
            flp.Controls.Add(ff);
        }
    }
}
