using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Util.Controls
{
    public class StatusChange
    {
        public static application.Model.MStatus model { get; set; }
        public static void click(object sender, EventArgs e)
        {
            ToolStripMenuItem s = (ToolStripMenuItem)sender;

            string bp = Util.Controls.BakingPage._context.Substring(0, 5);

            string ssss = Util.Controls.BakingPage._context.Substring(4, 1);

            string ss = Util.Controls.BakingPage._context.Substring(Util.Controls.BakingPage._context.Length - 1);

            List<application.Model.MStatus> list = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.DataDAL.ReviseStatus(("Baking" + ssss + ss)));

            string reok = string.Format(@"Baking{0}更改运作状态：[{1}]成功", ssss + ss, s.Text);
            string reng = string.Format(@"Baking{0}更改运作状态：[{1}]失败", ssss + ss, s.Text);
            if (list != null)
            {
                model = list[0];
                model.SBaking = s.Text;
                model.SReviseTime = Convert.ToDateTime(DateTime.Now);
            }
            else
                application.Common.logHelp.LogAddress("查询运行状态内容失败");
            if (application.MX.DapperSQLServer<application.Model.MStatus>.UpdateData(model, "StatusID") > 0)
                application.Common.logHelp.LogAddress(reok);
            else
                application.Common.logHelp.LogAddress("更改运行状态内容失败");
        }
    }
}
