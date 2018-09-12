using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DAL
{
   public class ErrorDB
    {
        public static string ErrData(string wh)
        {
            return string.Format(@"SELECT EContent FROM BakingErrorInfo WHERE EWhere ='{0}'", wh);
        }
        public static string QueryErrorInfo(int mac, string sto, string beginTime, string endTime)
        {
            return string.Format(@"SELECT  * FROM BakingRecord WHERE BBakingName='{0}#Baking-{1}'AND   BRecordTime>='{2}'AND BRecordTime<='{3}'", mac+1, sto, beginTime, endTime);
        }
    }
}
