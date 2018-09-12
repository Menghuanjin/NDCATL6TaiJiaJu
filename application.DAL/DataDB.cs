using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.DAL
{
  public  class DataDAL
    {
        public static string LoginDAL(string uesr,string paw)
        {
            return  string.Format(@"select * from Users where userName='{0}' and userPwd='{1}'", uesr, paw);
        }
        public static string ReviseStatus(string whereinfo)
        {

            return string.Format(@"SELECT  StatusID, SName, SBaking   FROM Status WHERE SName='{0}'", whereinfo);
        }

        public static string InsertData(string info)
        {

            return string.Format(@"INSERT INTO dbo.SystemLog(SysLogInfo, SysLogTime)  VALUES('{0}',GETDATE()) ", info);
        }
        public static string QueryTemData(int mac, string sto, int side, string beginTime, string endTime)
        {
            string sql= string.Format(@"SELECT* FROM  BakingTem  WHERE BBakingName='{0}#Baking-{1}-{2}'AND BEstablish >='{3}' AND  BEstablish<='{4}'", mac+1,sto, side + 1, beginTime, endTime);
            return sql;
        }
        //public static string QueryTemData(int mac, string sto ,string beginTime,string endTime)
        //{
        //    string sql = string.Format(@"SELECT     BakingID AS ID, BBakingName AS 真空炉,BLeft1 AS 左1,BLeft2 AS 左2,BLeft3 AS 左3,BLeft4 AS 左4,
        //                BLeft5 AS 左5, BLeft6 AS 左6, BLeft7 AS 左7,BLeft8 AS 左8,BLeft9 AS 左9, BLeft10 AS 左10,
        //                BLeft11 AS 左11, BLeft12 AS 左12, BLeft13 AS 左13,BLeft14 AS 左14, BLeft15 AS 左15,
        //                BLeft16 AS 左16, BLeft17 AS 左17,BLeft18 AS 左18, BLeft19 AS 左19,BLeft20 AS 左20,
        //                BRight1 AS 右1, BRight2 AS 右2, BRight3 AS 右3, BRight4 AS 右4,BRight5 AS 右5,
        //                BRight6 AS 右6, BRight7 AS 右7,BRight8 AS 右8, BRight9 AS 右9, BRight10 AS 右10,
        //                BRight11 AS 右11, BRight12 AS 右12,BRight13 AS 右13,BRight14 AS 右14,
        //                BRight15 AS 右15, BRight16 AS 右16,BRight17 AS 右17, BRight18 AS 右18,
        //                BRight19 AS 右19,BRight20 AS 右20,BTime AS 时间,BVacuum AS 真空
        //                   FROM BakingTem WHERE BBakingName='{0}#Baking-{1}'AND
        //                 BEstablish >='{2}' AND  BEstablish<='{3}'",mac+1,sto, beginTime, endTime);
        //    return sql;
        //}
    }
}
