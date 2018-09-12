using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DAL
{
  public  class StatusDB
    {
        public static string DataDBA(int num)
        {
            return string.Format(@"SELECT SBaking FROM Status WHERE SName ='BakingA{0}'",num);
        }
        public static string DataDBB(int num)
        {
            return string.Format(@"SELECT SBaking FROM Status WHERE SName ='BakingB{0}'", num);
        }
        public static string UpdateDataA(string ss, int num )
        {
            return string.Format(@"UPDATE Status SET SBaking='{0}' WHERE SName ='BakingA{1}'", ss, num);
        }
        public static string UpdateDataB(string ss, int num)
        {
            return string.Format(@"UPDATE Status SET SBaking='{0}' WHERE SName ='BakingB{1}'", ss, num);
        }
    }
}
