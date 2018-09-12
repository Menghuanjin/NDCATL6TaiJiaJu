using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.MX
{
  public  class DapperExtensions
    {
        public static string connString = string.Empty;
        public static string connStringMySQL = string.Empty;
        public interface ISort
        {
            bool Ascending { get; set; }
            string PropertyName { get; set; }
        }
        public class Sort : ISort
        {       
            public bool Ascending { get; set; }
            public string PropertyName { get; set; }
        }
    }
}
