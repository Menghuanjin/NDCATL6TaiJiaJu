using application.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.BLL
{
  public  class LoginManager
    {
        public static bool UserLogin(string uesr, string paw)
        {       
            List<application.Model.MUsers> list = application.MX.DapperSQLServer<application.Model.MUsers>.QueryData(application.DAL.DataDAL.LoginDAL(uesr,paw));
            if (list != null && list.Count > 0)
            {
                AppConfigure.result = list[0];
            }         
            return AppConfigure.result != null ? true : false;
        }
    }
}
