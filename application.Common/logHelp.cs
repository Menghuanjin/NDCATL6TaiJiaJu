using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace application.Common
{
   public class logHelp
    {
        private static StreamWriter streamWriter; //写文件 

        public static List<string> list = new List<string>();

        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="log"></param>
        public static void LogAddress(string log )
        {
            //SynchronizationContext _SynchronizationContext = SynchronizationContext.Current;
            //application.Model.MSystemLog model = new application.Model.MSystemLog()
            //{
            //    SysLogInfo = log,
            //    SysLogTime = DateTime.Now
            //};
            //application.MX.DapperSQLServer<application.Model.MSystemLog>.AddData(model);
     
                application.Common.logHelp.WriteLog(log);
            list.Insert(0,string.Format(@"[{0}] : {1}", DateTime.Now.ToString(), log));
          //  application.Common.DataSource.LocalLog = string.Format(" {0} ==>{1}\r\n", DateTime.Now.ToString("HH:mm:ss"), log) + application.Common.DataSource.LocalLog;
        }
        private static readonly object Locker1 = new object();
        public static void WriteError(string message)
        {

            lock (Locker1)
            {
                try
                {
                    string directPath = Application.StartupPath;    //获得文件夹路径
                    if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                    {
                        Directory.CreateDirectory(directPath);
                    }
                    directPath += string.Format(@"\Error{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
                    if (streamWriter == null)
                    {
                        streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                    }

                    streamWriter.WriteLine("***********************************************************************");
                    streamWriter.WriteLine(DateTime.Now.ToString("HH:mm:ss"));
                    streamWriter.WriteLine("输出信息：错误信息");
                    if (!string.IsNullOrEmpty(message))
                    {
                        streamWriter.WriteLine("异常信息：\r\n" + message);
                    }
                }
                finally
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Flush();
                        streamWriter.Dispose();
                        streamWriter = null;
                    }
                }
            }
        }
        public static void WriteLog(string message)
        {
            lock (Locker1)
            {
                try
                {
                    string directPath = Application.StartupPath;    //获得文件夹路径
                    if (!Directory.Exists(directPath))   //判断文件夹是否存在，如果不存在则创建
                    {
                        Directory.CreateDirectory(directPath);
                    }
                    directPath += string.Format(@"\{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
                    if (streamWriter == null)
                    {
                        streamWriter = !File.Exists(directPath) ? File.CreateText(directPath) : File.AppendText(directPath);    //判断文件是否存在如果不存在则创建，如果存在则添加。
                    }

                    if (!string.IsNullOrEmpty(message))
                    {
                        streamWriter.WriteLine(string.Format(@"{0}{1}  ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "  " + message));
                    }
                }
                finally
                {
                    if (streamWriter != null)
                    {
                        streamWriter.Flush();
                        streamWriter.Dispose();
                        streamWriter = null;
                    }
                }
            }
        }
     }
}
