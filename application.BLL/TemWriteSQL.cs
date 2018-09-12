using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.BLL
{
    public class TemWriteSQL
    {
        public static void GrtWriteLeftTemA(int i)
        {
            string sss = string.Format(@"{0}#真空炉A层左侧数据保存成功", (i + 1).ToString());
            string re = string.Format(@"{0}#真空炉A层左侧数据保存失败", (i + 1).ToString());

            List<string> list = application.Common.DataSource.temLeftListA[i];//左侧


            List<application.Model.MStatus> model = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.StatusDB.DataDBA(i + 1));

            if (list != null && !string.IsNullOrEmpty(application.Common.DataSource._listVacA[i]) && !string.IsNullOrEmpty(application.Common.DataSource._listTiemA[i]) && !string.IsNullOrEmpty(model[0].SBaking))
            {
                if (list[0] != "0")
                {
                    application.Model.MBakingTem mbk = new application.Model.MBakingTem()
                    {
                        BBakingName = string.Format(@"{0}#Baking-A-1", i + 1),
                        BStatus = model[0].SBaking,
                        K1 = (Convert.ToDouble(list[0]) / 10).ToString(),
                        K2 = (Convert.ToDouble(list[1]) / 10).ToString(),
                        K3 = (Convert.ToDouble(list[2]) / 10).ToString(),
                        K4 = (Convert.ToDouble(list[3]) / 10).ToString(),
                        K5 = (Convert.ToDouble(list[4]) / 10).ToString(),
                        K6 = (Convert.ToDouble(list[5]) / 10).ToString(),
                        K7 = (Convert.ToDouble(list[6]) / 10).ToString(),
                        K8 = (Convert.ToDouble(list[7]) / 10).ToString(),
                        K9 = (Convert.ToDouble(list[8]) / 10).ToString(),
                        K10 = (Convert.ToDouble(list[9]) / 10).ToString(),
                        K11 = (Convert.ToDouble(list[10]) / 10).ToString(),
                        K12 = (Convert.ToDouble(list[11]) / 10).ToString(),
                        K13 = (Convert.ToDouble(list[12]) / 10).ToString(),
                        K14 = (Convert.ToDouble(list[13]) / 10).ToString(),
                        K15 = (Convert.ToDouble(list[14]) / 10).ToString(),
                        K16 = (Convert.ToDouble(list[15]) / 10).ToString(),
                        K17 = (Convert.ToDouble(list[16]) / 10).ToString(),
                        K18 = (Convert.ToDouble(list[17]) / 10).ToString(),
                        K19 = (Convert.ToDouble(list[18]) / 10).ToString(),
                        K20 = (Convert.ToDouble(list[19]) / 10).ToString(),
                        C1 = (Convert.ToDouble(list[20]) / 10).ToString(),
                        C2 = (Convert.ToDouble(list[21]) / 10).ToString(),
                        C3 = (Convert.ToDouble(list[22]) / 10).ToString(),
                        C4 = (Convert.ToDouble(list[23]) / 10).ToString(),
                        C5 = (Convert.ToDouble(list[24]) / 10).ToString(),
                        C6 = (Convert.ToDouble(list[25]) / 10).ToString(),
                        C7 = (Convert.ToDouble(list[26]) / 10).ToString(),
                        C8 = (Convert.ToDouble(list[27]) / 10).ToString(),
                        C9 = (Convert.ToDouble(list[28]) / 10).ToString(),
                        C10 = (Convert.ToDouble(list[29]) / 10).ToString(),
                        C11 = (Convert.ToDouble(list[30]) / 10).ToString(),
                        C12 = (Convert.ToDouble(list[31]) / 10).ToString(),
                        C13 = (Convert.ToDouble(list[32]) / 10).ToString(),
                        C14 = (Convert.ToDouble(list[33]) / 10).ToString(),
                        C15 = (Convert.ToDouble(list[34]) / 10).ToString(),
                        C16 = (Convert.ToDouble(list[35]) / 10).ToString(),
                        C17 = (Convert.ToDouble(list[36]) / 10).ToString(),
                        C18 = (Convert.ToDouble(list[37]) / 10).ToString(),
                        C19 = (Convert.ToDouble(list[38]) / 10).ToString(),
                        C20 = (Convert.ToDouble(list[39]) / 10).ToString(),
                        BEstablish = DateTime.Now,
                        BTime = Convert.ToInt16(application.Common.DataSource._listTiemA[i]),
                        BVacuum = application.Common.DataSource._listVacA[i]
                    };
                    if (application.MX.DapperSQLServer<application.Model.MBakingTem>.AddData(mbk) == 0)
                        application.Common.logHelp.LogAddress(re);
                    //if (application.MX.DapperSQLServer<application.Model.MBakingTem>.AddData(mbk) > 0)
                    //    application.Common.logHelp.LogAddress(sss);
                    //else
                    //    application.Common.logHelp.LogAddress(re);
                }
            }
        }
        public static void GrtWriteRightTemA(int i)
        {
            string sss = string.Format(@"{0}#真空炉A层右侧数据保存成功", (i + 1).ToString());
            string re = string.Format(@"{0}#真空炉A层右侧数据保存失败", (i + 1).ToString());


            List<string> list2 = application.Common.DataSource.temRightListA[i];//右侧 

            List<application.Model.MStatus> model = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.StatusDB.DataDBA(i + 1));

            if (list2 != null && !string.IsNullOrEmpty(application.Common.DataSource._listVacA[i]) && !string.IsNullOrEmpty(application.Common.DataSource._listTiemA[i]) && !string.IsNullOrEmpty(model[0].SBaking))
            {
                if (list2[0] != "0")
                {
                    application.Model.MBakingTem mbk = new application.Model.MBakingTem()
                    {
                        BBakingName = string.Format(@"{0}#Baking-A-2", i + 1),
                        BStatus = model[0].SBaking,
                        K1 = (Convert.ToDouble(list2[0]) / 10).ToString(),
                        K2 = (Convert.ToDouble(list2[1]) / 10).ToString(),
                        K3 = (Convert.ToDouble(list2[2]) / 10).ToString(),
                        K4 = (Convert.ToDouble(list2[3]) / 10).ToString(),
                        K5 = (Convert.ToDouble(list2[4]) / 10).ToString(),
                        K6 = (Convert.ToDouble(list2[5]) / 10).ToString(),
                        K7 = (Convert.ToDouble(list2[6]) / 10).ToString(),
                        K8 = (Convert.ToDouble(list2[7]) / 10).ToString(),
                        K9 = (Convert.ToDouble(list2[8]) / 10).ToString(),
                        K10 = (Convert.ToDouble(list2[9]) / 10).ToString(),
                        K11 = (Convert.ToDouble(list2[10]) / 10).ToString(),
                        K12 = (Convert.ToDouble(list2[11]) / 10).ToString(),
                        K13 = (Convert.ToDouble(list2[12]) / 10).ToString(),
                        K14 = (Convert.ToDouble(list2[13]) / 10).ToString(),
                        K15 = (Convert.ToDouble(list2[14]) / 10).ToString(),
                        K16 = (Convert.ToDouble(list2[15]) / 10).ToString(),
                        K17 = (Convert.ToDouble(list2[16]) / 10).ToString(),
                        K18 = (Convert.ToDouble(list2[17]) / 10).ToString(),
                        K19 = (Convert.ToDouble(list2[18]) / 10).ToString(),
                        K20 = (Convert.ToDouble(list2[19]) / 10).ToString(),
                        C1 = (Convert.ToDouble(list2[20]) / 10).ToString(),
                        C2 = (Convert.ToDouble(list2[21]) / 10).ToString(),
                        C3 = (Convert.ToDouble(list2[22]) / 10).ToString(),
                        C4 = (Convert.ToDouble(list2[23]) / 10).ToString(),
                        C5 = (Convert.ToDouble(list2[24]) / 10).ToString(),
                        C6 = (Convert.ToDouble(list2[25]) / 10).ToString(),
                        C7 = (Convert.ToDouble(list2[26]) / 10).ToString(),
                        C8 = (Convert.ToDouble(list2[27]) / 10).ToString(),
                        C9 = (Convert.ToDouble(list2[28]) / 10).ToString(),
                        C10 = (Convert.ToDouble(list2[29]) / 10).ToString(),
                        C11 = (Convert.ToDouble(list2[30]) / 10).ToString(),
                        C12 = (Convert.ToDouble(list2[31]) / 10).ToString(),
                        C13 = (Convert.ToDouble(list2[32]) / 10).ToString(),
                        C14 = (Convert.ToDouble(list2[33]) / 10).ToString(),
                        C15 = (Convert.ToDouble(list2[34]) / 10).ToString(),
                        C16 = (Convert.ToDouble(list2[35]) / 10).ToString(),
                        C17 = (Convert.ToDouble(list2[36]) / 10).ToString(),
                        C18 = (Convert.ToDouble(list2[37]) / 10).ToString(),
                        C19 = (Convert.ToDouble(list2[38]) / 10).ToString(),
                        C20 = (Convert.ToDouble(list2[39]) / 10).ToString(),
                        BEstablish = DateTime.Now,
                        BTime = Convert.ToInt16(application.Common.DataSource._listTiemA[i]),
                        BVacuum = application.Common.DataSource._listVacA[i]
                    };
                    if (application.MX.DapperSQLServer<application.Model.MBakingTem>.AddData(mbk) == 0)
                        application.Common.logHelp.LogAddress(re);
                    //if (application.MX.DapperSQLServer<application.Model.MBakingTem>.AddData(mbk) > 0)
                    //    application.Common.logHelp.LogAddress(sss);
                    //else
                    //    application.Common.logHelp.LogAddress(re);
                }
            }
        }

        public static void GrtWriteLeftTemB(int i)
        {
            string sss = string.Format(@"{0}#真空炉B层数据保存成功", (i + 1).ToString());
            string re = string.Format(@"{0}#真空炉B层数据保存失败", (i + 1).ToString());

            List<string> list = application.Common.DataSource.temLeftListB[i];

            List<application.Model.MStatus> model = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.StatusDB.DataDBB(i + 1));

            if (list != null && !string.IsNullOrEmpty(application.Common.DataSource._listVacB[i]) && !string.IsNullOrEmpty(application.Common.DataSource._listTiemB[i]) && !string.IsNullOrEmpty(model[0].SBaking))
            {
                if (list[0] != "0")
                {
                    application.Model.MBakingTem mbk = new application.Model.MBakingTem()
                    {
                        BBakingName = string.Format(@"{0}#Baking-B-1", i + 1),
                        BStatus = model[0].SBaking,
                        K1 = (Convert.ToDouble(list[0]) / 10).ToString(),
                        K2 = (Convert.ToDouble(list[1]) / 10).ToString(),
                        K3 = (Convert.ToDouble(list[2]) / 10).ToString(),
                        K4 = (Convert.ToDouble(list[3]) / 10).ToString(),
                        K5 = (Convert.ToDouble(list[4]) / 10).ToString(),
                        K6 = (Convert.ToDouble(list[5]) / 10).ToString(),
                        K7 = (Convert.ToDouble(list[6]) / 10).ToString(),
                        K8 = (Convert.ToDouble(list[7]) / 10).ToString(),
                        K9 = (Convert.ToDouble(list[8]) / 10).ToString(),
                        K10 = (Convert.ToDouble(list[9]) / 10).ToString(),
                        K11 = (Convert.ToDouble(list[10]) / 10).ToString(),
                        K12 = (Convert.ToDouble(list[11]) / 10).ToString(),
                        K13 = (Convert.ToDouble(list[12]) / 10).ToString(),
                        K14 = (Convert.ToDouble(list[13]) / 10).ToString(),
                        K15 = (Convert.ToDouble(list[14]) / 10).ToString(),
                        K16 = (Convert.ToDouble(list[15]) / 10).ToString(),
                        K17 = (Convert.ToDouble(list[16]) / 10).ToString(),
                        K18 = (Convert.ToDouble(list[17]) / 10).ToString(),
                        K19 = (Convert.ToDouble(list[18]) / 10).ToString(),
                        K20 = (Convert.ToDouble(list[19]) / 10).ToString(),
                        C1 = (Convert.ToDouble(list[20]) / 10).ToString(),
                        C2 = (Convert.ToDouble(list[21]) / 10).ToString(),
                        C3 = (Convert.ToDouble(list[22]) / 10).ToString(),
                        C4 = (Convert.ToDouble(list[23]) / 10).ToString(),
                        C5 = (Convert.ToDouble(list[24]) / 10).ToString(),
                        C6 = (Convert.ToDouble(list[25]) / 10).ToString(),
                        C7 = (Convert.ToDouble(list[26]) / 10).ToString(),
                        C8 = (Convert.ToDouble(list[27]) / 10).ToString(),
                        C9 = (Convert.ToDouble(list[28]) / 10).ToString(),
                        C10 = (Convert.ToDouble(list[29]) / 10).ToString(),
                        C11 = (Convert.ToDouble(list[30]) / 10).ToString(),
                        C12 = (Convert.ToDouble(list[31]) / 10).ToString(),
                        C13 = (Convert.ToDouble(list[32]) / 10).ToString(),
                        C14 = (Convert.ToDouble(list[33]) / 10).ToString(),
                        C15 = (Convert.ToDouble(list[34]) / 10).ToString(),
                        C16 = (Convert.ToDouble(list[35]) / 10).ToString(),
                        C17 = (Convert.ToDouble(list[36]) / 10).ToString(),
                        C18 = (Convert.ToDouble(list[37]) / 10).ToString(),
                        C19 = (Convert.ToDouble(list[38]) / 10).ToString(),
                        C20 = (Convert.ToDouble(list[39]) / 10).ToString(),
                        BEstablish = DateTime.Now,
                        BTime = Convert.ToInt16(application.Common.DataSource._listTiemB[i]),
                        BVacuum = application.Common.DataSource._listVacB[i]
                    };
                    if (application.MX.DapperSQLServer<application.Model.MBakingTem>.AddData(mbk) == 0)
                        application.Common.logHelp.LogAddress(re);
                    //if (application.MX.DapperSQLServer<application.Model.MBakingTem>.AddData(mbk) > 0)
                    //    application.Common.logHelp.LogAddress(sss);
                    //else
                    //    application.Common.logHelp.LogAddress(re);
                }
            }
        }

        public static void GrtWriteRightTemB(int i)
        {
            string sss = string.Format(@"{0}#真空炉B层数据保存成功", (i + 1).ToString());
            string re = string.Format(@"{0}#真空炉B层数据保存失败", (i + 1).ToString());

            List<string> list2 = application.Common.DataSource.tenRightListB[i];//右侧 

            List<application.Model.MStatus> model = application.MX.DapperSQLServer<application.Model.MStatus>.QueryData(application.DAL.StatusDB.DataDBB(i + 1));

            if (list2 != null && !string.IsNullOrEmpty(application.Common.DataSource._listVacB[i]) && !string.IsNullOrEmpty(application.Common.DataSource._listTiemB[i]) && !string.IsNullOrEmpty(model[0].SBaking))
            {
                if (list2[0] != "0")
                {
                    application.Model.MBakingTem mbk = new application.Model.MBakingTem()
                    {
                        BBakingName = string.Format(@"{0}#Baking-B-2", i + 1),
                        BStatus = model[0].SBaking,
                        K1 = (Convert.ToDouble(list2[0]) / 10).ToString(),
                        K2 = (Convert.ToDouble(list2[1]) / 10).ToString(),
                        K3 = (Convert.ToDouble(list2[2]) / 10).ToString(),
                        K4 = (Convert.ToDouble(list2[3]) / 10).ToString(),
                        K5 = (Convert.ToDouble(list2[4]) / 10).ToString(),
                        K6 = (Convert.ToDouble(list2[5]) / 10).ToString(),
                        K7 = (Convert.ToDouble(list2[6]) / 10).ToString(),
                        K8 = (Convert.ToDouble(list2[7]) / 10).ToString(),
                        K9 = (Convert.ToDouble(list2[8]) / 10).ToString(),
                        K10 = (Convert.ToDouble(list2[9]) / 10).ToString(),
                        K11 = (Convert.ToDouble(list2[10]) / 10).ToString(),
                        K12 = (Convert.ToDouble(list2[11]) / 10).ToString(),
                        K13 = (Convert.ToDouble(list2[12]) / 10).ToString(),
                        K14 = (Convert.ToDouble(list2[13]) / 10).ToString(),
                        K15 = (Convert.ToDouble(list2[14]) / 10).ToString(),
                        K16 = (Convert.ToDouble(list2[15]) / 10).ToString(),
                        K17 = (Convert.ToDouble(list2[16]) / 10).ToString(),
                        K18 = (Convert.ToDouble(list2[17]) / 10).ToString(),
                        K19 = (Convert.ToDouble(list2[18]) / 10).ToString(),
                        K20 = (Convert.ToDouble(list2[19]) / 10).ToString(),
                        C1 = (Convert.ToDouble(list2[20]) / 10).ToString(),
                        C2 = (Convert.ToDouble(list2[21]) / 10).ToString(),
                        C3 = (Convert.ToDouble(list2[22]) / 10).ToString(),
                        C4 = (Convert.ToDouble(list2[23]) / 10).ToString(),
                        C5 = (Convert.ToDouble(list2[24]) / 10).ToString(),
                        C6 = (Convert.ToDouble(list2[25]) / 10).ToString(),
                        C7 = (Convert.ToDouble(list2[26]) / 10).ToString(),
                        C8 = (Convert.ToDouble(list2[27]) / 10).ToString(),
                        C9 = (Convert.ToDouble(list2[28]) / 10).ToString(),
                        C10 = (Convert.ToDouble(list2[29]) / 10).ToString(),
                        C11 = (Convert.ToDouble(list2[30]) / 10).ToString(),
                        C12 = (Convert.ToDouble(list2[31]) / 10).ToString(),
                        C13 = (Convert.ToDouble(list2[32]) / 10).ToString(),
                        C14 = (Convert.ToDouble(list2[33]) / 10).ToString(),
                        C15 = (Convert.ToDouble(list2[34]) / 10).ToString(),
                        C16 = (Convert.ToDouble(list2[35]) / 10).ToString(),
                        C17 = (Convert.ToDouble(list2[36]) / 10).ToString(),
                        C18 = (Convert.ToDouble(list2[37]) / 10).ToString(),
                        C19 = (Convert.ToDouble(list2[38]) / 10).ToString(),
                        C20 = (Convert.ToDouble(list2[39]) / 10).ToString(),
                        BEstablish = DateTime.Now,
                        BTime = Convert.ToInt16(application.Common.DataSource._listTiemB[i]),
                        BVacuum = application.Common.DataSource._listVacB[i]
                    };
                    if (application.MX.DapperSQLServer<application.Model.MBakingTem>.AddData(mbk) == 0)
                        application.Common.logHelp.LogAddress(re);
                }
            }
        }
    }
}
