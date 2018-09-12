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
    public partial class ErrorQueryPage : UserControl
    {
        public ErrorQueryPage()
        {
            InitializeComponent();
            this.combMac.SelectedIndex = 0;
            this.combSto.SelectedIndex = 0;
        }

        private void buttQuery_Click(object sender, EventArgs e)
        {
            string ss = this.combSto.SelectedItem.ToString().Substring(0, 1);
            string begin = this.dateTBegin.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string end = this.dateTEnd.Value.ToString("yyyy-MM-dd HH:mm:ss");
            List<application.Model.MBakingRecord> model = application.MX.DapperSQLServer<application.Model.MBakingRecord>.QueryData(application.DAL.ErrorDB.QueryErrorInfo(this.combMac.SelectedIndex, ss, begin, end));
            if (model != null)
            {
                dataGridView1.DataSource = model;
            }
        }

        private void buttOut_Click(object sender, EventArgs e)
        {
            application.Common.DataPreserve.DGVToExcel(this.dataGridView1);
        }
    }
}
