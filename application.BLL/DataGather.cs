using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.BLL
{
    public class DataGather
    {
        public static Omron.OmronPLC_tcp[] bakingContent = new Omron.OmronPLC_tcp[6];
        private static string[] listIP = new string[]
         {
             IPAddress._bakingOne,
                 IPAddress._bakingTwo,
                      IPAddress._bakingThree,
                         IPAddress._bakingFour,
                             IPAddress._bakingFive,
                                 IPAddress._bakingSix
         };

        private static Thread[] threadList = new Thread[6];

        public static void loadingBasicInfo()
        {
            for (int i = 0; i < 6; i++)
            {
                threadList[i] = new Thread(new ParameterizedThreadStart(BakingBeUnderway));
                threadList[i].Start(i);
            }

            Thread error = new Thread(new ThreadStart(ErrorInfoAddress));//报警处理
            error.IsBackground = true;
            error.Start();

            Thread tem = new Thread(new ThreadStart(GetTemAddress));//温度采集
            tem.IsBackground = true;
            tem.Start();
        }

        private static void BakingBeUnderway(object num)
        {
            try
            {
                string ss = string.Format("{0}#真空炉建立连接成功", (int)num + 1);
                string re = string.Format("{0}#真空炉建立连接失败", (int)num + 1);

                bakingContent[(int)num] = PLCAddress.ConnectPLC(listIP[(int)num], 9600);

                if (bakingContent[(int)num].Connected)
                {
                    application.Common.logHelp.LogAddress(ss);
                }
                else
                    application.Common.logHelp.LogAddress(re);
            }
            catch (Exception ex)
            {
                application.Common.logHelp.LogAddress(string.Format(@"{0}#炉子建立连接异常，详细内容：{1}", (int)num + 1, ex.Message));
            }
            //建立每一条线程跟baking读取数据 基本数据，比如温度，运行时间，真空度，
            while (true)
            {
                StartCollectingTem((int)num);
                Thread.Sleep(2000);
            }
        }
        private static void StartCollectingTem(int get)
        {
            // plc[get].connect = bakingContent[get].Connected;

            string ss = string.Format("{0}#真空炉读取基本数据包成功", get + 1);
            string re = string.Format("{0}#真空炉读取基本数据包失败", get + 1);
            if (bakingContent[get].Connected)
            {
                application.Common.DataSource.temLeftListA[get] = PLCAddress.ReadMulti(bakingContent[get], 3831, 40);

                application.Common.DataSource.temRightListA[get] = PLCAddress.ReadMulti(bakingContent[get], 3911, 40);

                application.Common.DataSource.temLeftListB[get] = PLCAddress.ReadMulti(bakingContent[get], 3991, 40);

                application.Common.DataSource.tenRightListB[get] = PLCAddress.ReadMulti(bakingContent[get], 4071, 40);

                application.Common.DataSource._listTiemA[get] = PLCAddress.ReadDM(bakingContent[get], "3599");

                application.Common.DataSource._listTiemB[get] = PLCAddress.ReadDM(bakingContent[get], "3643");


                List<string> list = PLCAddress.ReadMulti(bakingContent[get], 3601, 2);
                application.Common.DataSource._listVacA[get] = application.Common.DecimalConversion.HexToTen(list[1] + application.Common.DecimalConversion.Ten2Hex(list[0])).ToString();

                List<string> list2 = PLCAddress.ReadMulti(bakingContent[get], 3645, 2);
                application.Common.DataSource._listVacB[get] = application.Common.DecimalConversion.HexToTen(list2[1] + application.Common.DecimalConversion.Ten2Hex(list2[0])).ToString();



                int ress= application.Common.DataSource._listRunErrorA[get];
                if (ress == 1)
                {
                    application.Common.DataSource._listRunA[get] = "2";
                }
                else if (ress == 0)
                {

                    application.Common.DataSource._listRunA[get] = PLCAddress.ReadDM(bakingContent[get], "3600");
                }

              


                int ress2 = application.Common.DataSource._listRunErrorB[get];
                if (ress2 == 1)
                {
                    application.Common.DataSource._listRunB[get] = "2";
                }
                else if(ress2==0)
                {
                    application.Common.DataSource._listRunB[get] = PLCAddress.ReadDM(bakingContent[get], "3644");
                }




                // application.Common.logHelp.LogAddress(ss);
                Thread.Sleep(3000);
            }
            else
            {
                application.Common.logHelp.LogAddress(string.Format("检测到{0}#真空炉已经断线，系统开始重新进行连接.....", get + 1));
                Thread.Sleep(30000);
                try
                {
                    BakingBeUnderway(get);
                }
                catch (Exception ex)
                {
                    application.Common.logHelp.LogAddress(string.Format("{0}#真空炉异常详细内容:{1}", get + 1, ex.Message));
                }
            }
        }

        public static void ErrorInfoAddress()
        {
            while (true)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (bakingContent[i] != null)
                    {
                        if (bakingContent[i].Connected)
                        {
                            int ss = Convert.ToInt16(PLCAddress.ReadDM(bakingContent[i], "5012"));

                            if (ss > 0)
                            {
                                if (ss == 1 || ss == 3)
                                {
                                    application.Common.DataSource._listRunErrorA[i] = 1;
                                    //下门
                                    List<string> list = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5011, 1);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list, 1);
                                    //下门温度
                                    List<string> list2 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5076, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list2, 1);

                                    List<string> list3 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5080, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list3, 1);


                                    List<string> list4 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5084, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list4, 1);

                                    List<string> list5 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5088, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list5, 1);

                                    List<string> list6 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5032, 2);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list6, 1);

                                    
                                    List<string> list7 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5100, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list2, 1);

                                    List<string> list8 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5104, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list3, 1);


                                }
                                else
                                {
                                    application.Common.DataSource._listRunErrorA[i] = 0;
                                }
                                if (ss == 2 || ss == 3)
                                {
                                    application.Common.DataSource._listRunErrorB[i] = 1;//
                                    //上门
                                    List<string> list = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5120, 1);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list, 2);

                                    //上门温度
                                    List<string> list2 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5185, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list2, 2);

                                    List<string> list3 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5189, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list3, 2);

                                    List<string> list4 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5193, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list4, 2);


                                    List<string> list5 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5197, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list5, 2);

                                    //真空
                                    List<string> list6 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5141, 2);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list6, 2);

                                    List<string> list7 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5209, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list2, 2);

                                    List<string> list8 = AnalyzeDMHelp.ReadMultiToErrorInfo(bakingContent[i], 5213, 4);
                                    application.BLL.DataGather.AnalyzeGetEoor(i, list3, 2);
                                }
                                else
                                {
                                    application.Common.DataSource._listRunErrorB[i] = 0;
                                }
                            }
                            else
                            {
                                application.Common.DataSource._listRunErrorA[i] = 0;
                                application.Common.DataSource._listRunErrorB[i] = 0;
                            }
                           
                        }
                    }
                }
                Thread.Sleep(3000);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public static void GetTemAddress()
        {
            while (true)
            {

                for (int i = 0; i < 6; i++)
                {
                    if (bakingContent[i] != null)
                    {
                        if (bakingContent[i].Connected)
                        {
                            application.BLL.TemWriteSQL.GrtWriteLeftTemA(i);
                            application.BLL.TemWriteSQL.GrtWriteLeftTemB(i);

                            application.BLL.TemWriteSQL.GrtWriteRightTemA(i);
                            application.BLL.TemWriteSQL.GrtWriteRightTemB(i);
                          
                        }
                    }
                }
                Thread.Sleep(60000);
            }
        }
        public static void AnalyzeGetEoor(int i, List<string> list,int sto)
        {
            for (int j = 0; j < list.Count; j++)
            {
                var model = application.BLL.ErrorSource.errorModel.Where(x => x.EWhere == list[j]).ToList();
                if (model != null)
                {
                    foreach (var item in model)
                    {
                        string ress = string.Format(@"报警内容：{0}", item.EContent);

                        //     List <string > sss= list = application.Common.logHelp.list.Skip(m).Take(n).ToList();
                        //  if (application.Common.logHelp.list.Where(x => x.Contains(item.EContent)).ToList().Count == 0)

                        if (application.Common.logHelp.list.Where(x => x.Contains(item.EContent)).ToList().Count == 0)
                        {
                            if (sto == 1)
                            { 
                                application.Model.MBakingRecord model1 = new Model.MBakingRecord()
                                {
                                    BBakingName = string.Format(@"{0}#Baking-A", (i + 1).ToString()),
                                    BRecordCon = ress,
                                    BRecordTime = DateTime.Now,
                                };
                                application.MX.DapperSQLServer<application.Model.MBakingRecord>.AddData(model1);
                            }
                            else if (sto == 2)
                            {
                                application.Model.MBakingRecord model1 = new Model.MBakingRecord()
                                {
                                    BBakingName = string.Format(@"{0}#Baking-B", (i + 1).ToString()),
                                    BRecordCon = ress,
                                    BRecordTime = DateTime.Now,
                                };
                                application.MX.DapperSQLServer<application.Model.MBakingRecord>.AddData(model1);
                            }
                            application.Common.logHelp.LogAddress(string.Format(@"{0}#Baking炉,报警内容：{1}", (i + 1).ToString(), item.EContent));
                        }
                    }
                }
            }
        }
    }
}

