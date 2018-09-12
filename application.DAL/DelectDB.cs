using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DAL
{
  public   class DelectDB
    {
        public static string DelectTemInfo()
        {
            return string.Format(@"DELETE BakingTem WHERE BEstablish  <='{0}'",DateTime.Now.AddDays(-183).ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public static string DelectroErrorInfo()
        {
            return string.Format(@"DELETE BakingRecord  WHERE BRecordTime  <='{0}'", DateTime.Now.AddDays(-183).ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
