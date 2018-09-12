using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Common
{
    /// <summary>
    /// 计算耗时类
    /// </summary>
   public class ConsumingHelp
    {
        public static string Consuming(DateTime Time)
        {
            return ( DateTime.Now - Time).TotalMilliseconds.ToString();
        }
    }
}
