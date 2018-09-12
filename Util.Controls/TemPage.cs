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
    public partial class TemPage : UserControl
    {
        public static bool beginDispose { set; get; }
   
        public TemPage()
        {
            InitializeComponent();
            Timer th = new Timer() { Interval = 1000, Enabled = true };
            th.Tick += Th_Tick;
            this.combMac.SelectedIndex = 0;
            this.combSto.SelectedIndex = 0;
        }


        private void Th_Tick(object sender, EventArgs e)
        {
            if (this.combSto.SelectedIndex == 0)
            {
                DataExhibition(application.Common.DataSource. temLeftListA[this.combMac.SelectedIndex], application.Common.DataSource.temRightListA[this.combMac.SelectedIndex]);
            }
            else if (this.combSto.SelectedIndex == 1)
            {
                DataExhibition(application.Common.DataSource.temLeftListB[this.combMac.SelectedIndex], application.Common.DataSource.tenRightListB[this.combMac.SelectedIndex]);
            }

        }
        private void DataExhibition(List<string> listA, List<string> listB)
        {
            if (listA != null)
            {
                for (int j = 0; j < listA.Count - 20; j++)
                {
                    TextBox C = (TextBox)this.Controls.Find("textLeft" + (j + 1), true)[0];
                    C.Text = (Convert.ToDouble(listA[j]) / 10).ToString();
                }
            }
            if (listB != null)
            {
                for (int j = 0; j < listB.Count - 20; j++)
                {
                    TextBox C = (TextBox)this.Controls.Find("textRight" + (j + 1), true)[0];
                    C.Text = (Convert.ToDouble(listB[j]) / 10).ToString();
                }
            }
        }
    }
}
