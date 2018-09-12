using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Common
{
   public class DataSource
    {
        /// <summary>
        /// 存放每一台机A层左侧温度
        /// </summary>
        public static List<string>[] temLeftListA = new List<string>[6];
        /// <summary>
        /// 存放每一台机A层右侧的温度
        /// </summary>
        public static List<string>[] temRightListA = new List<string>[6];
        /// <summary>
        /// 存放每一台机B层左侧温度
        /// </summary>
        public static List<string>[] temLeftListB = new List<string>[6];
        /// <summary>
        /// 存放每一台机B层右侧的温度
        /// </summary>
        public static List<string>[] tenRightListB = new List<string>[6];


        /// <summary>
        /// 存放A层所有时间
        /// </summary>
        public static string[] _listTiemA = new string[6];
        /// <summary>
        /// 存放B层所有时间
        /// </summary>

        public static string[] _listTiemB = new string[6];

        public static List<Image> _listVacPicBox = new List<Image>();
        /// <summary>
        /// 存放上层真空
        /// </summary>
        public static string[] _listVacA = new string[6];
        /// <summary>
        /// 存放下层真空
        /// </summary>
        public static string[] _listVacB = new string[6];

        private static string localLog = "";
        /// <summary>
        ///本地log信息
        /// </summary>
        public static string LocalLog
        {
            get { return localLog; }
            set { localLog = value; }
        }

        public static string [] _listRunA = new string[6];

        public static string[] _listRunB = new string[6];
        /// <summary>
        /// A层是否有报警信息
        /// </summary>
        public static int [] _listRunErrorA = new int[6];
        /// <summary>
        /// B层是否有报警信息
        /// </summary>
        public static int[] _listRunErrorB = new int[6];

    }
}
