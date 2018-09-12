using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Model
{
    /// <summary>
    /// Status:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>

    public class MStatus
    {

        #region Model
        private int _statusid;
        private string _sname;
        private string _sbaking;
        private DateTime? _srevisetime;
        /// <summary>
        /// 
        /// </summary>
        public int StatusID
        {
            set { _statusid = value; }
            get { return _statusid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SBaking
        {
            set { _sbaking = value; }
            get { return _sbaking; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SReviseTime
        {
            set { _srevisetime = value; }
            get { return _srevisetime; }
        }
        #endregion Model
    }
}
