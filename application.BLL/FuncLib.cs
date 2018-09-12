using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.IO.Ports;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Data.OleDb;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace application.BLL
{
   public class FuncLib
    {
        public static System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        // 用于标识在线人数
        public static string uuid = Guid.NewGuid().ToString();
        /// <summary>
        /// Form和Tab属性
        /// </summary>
        /// 
        private static ArrayList frmList; //// 已打开表单集合
        public static ArrayList FrmLsit
        {
            get { return frmList; }
            set { frmList = value; }
        }

        private static ArrayList tabList; //// 已打开Tab选项卡

        public static ArrayList TabList
        {
            get { return tabList; }
            set { tabList = value; }
        }

        private static Form activedFrm;

        public static Form ActivedFrm
        {
            get { return activedFrm; }
            set { activedFrm = value; }
        }

        /// <summary>
        /// 设置关闭的Form
        /// </summary>
        private static string waitCloseFormName;

        public static string WaitCloseFormName
        {
            get { return waitCloseFormName; }
            set { waitCloseFormName = value; }
        }

        /// <summary>
        /// 等待打开的Form名称
        /// </summary>
        private static string waitOpenFormName;

        /// <summary>
        /// 等待打开的Form名称
        /// </summary>
        public static string WaitOpenFormName
        {
            get { return waitOpenFormName; }
            set { waitOpenFormName = value; }
        }

        /// <summary>
        /// 等待打开的Form标题
        /// </summary>
        private static string waitOpenFormTitle;

        /// <summary>
        /// 等待打开的Form标题
        /// </summary>
        public static string WaitOpenFormTitle
        {
            get { return waitOpenFormTitle; }
            set { waitOpenFormTitle = value; }
        }

        private static string tempStr;
        
        public static string TempStr
        {
            get { return tempStr; }
            set { tempStr = value; }
        }


        private static System.Net.CookieContainer cookieContainer;

        public static System.Net.CookieContainer CookieContainer
        {
            get { return cookieContainer; }
            set { cookieContainer = value; }
        }

        private static DataTable sysParameterDataTable;

        public static DataTable SysParameterDataTable
        {
            get { return sysParameterDataTable; }
            set { sysParameterDataTable = value; }
        }

        private static string profileXmlContent;

        /// <summary>
        /// 判断是否登录
        /// </summary>
        private static bool isLogin;

        public static bool IsLogin
        {
            get { return isLogin; }
            set { isLogin = value; }
        }

        /// <summary>
        /// 短信猫串口名称
        /// </summary>
        private static string comName;

        public static string ComName
        {
            get { return comName; }
            set { comName = value; }
        }

        /// <summary>
        /// 消息中心
        /// </summary>
        private static string messageCenter;

        public static string MessageCenter
        {
            get { return messageCenter; }
            set { messageCenter = value; }
        }

        /// <summary>
        /// 主窗口状态栏信息
        /// </summary>
        private static string userinfo;

        public static string Userinfo
        {
            get { return userinfo; }
            set { userinfo = value; }
        }

        private static string ip;

        public static string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        /// <summary>
        /// 当前登录账号的id
        /// </summary>
        private static int userId;

        public static int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private static int firstJobId;

        public static int FirstJobId
        {
            get { return firstJobId; }
            set { firstJobId = value; }
        }

        /// <summary>
        /// 当前登录账号的名称
        /// </summary>
        private static string userName;

        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private static string password;

        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// 当前登录账号的部门
        /// </summary>
        private static string deptName;

        public static string DepaName
        {
            get { return deptName; }
            set { deptName = value; }
        }

        /// <summary>
        /// 权限
        /// </summary>
        private static ArrayList authList;

        public static ArrayList AuthList
        {
            get { return authList; }
            set { authList = value; }
        }

        /// <summary>
        /// 复选框临时存放id
        /// </summary>
        private static string tempIds;

        public static string TempIds
        {
            get { return tempIds; }
            set { tempIds = value; }
        }

       
        private static string localDBConnStr;

        public static string LocalDBConnStr
        {
            get { return localDBConnStr; }
            set { localDBConnStr = value; }
        }

        /// <summary>
        /// DES加解密PasswordKey
        /// </summary>
        private static string passwordKey;

        public static string PasswordKey
        {
            get { return passwordKey; }
            set { passwordKey = value; }
        }
        /// <summary>
        /// 当前程序运行路径
        /// </summary>
        private static string appPath;

        public static string AppPath
        {
            get { return appPath; }
            set { appPath = value; }
        }

        ///// <summary>
        ///// 加载配置文件
        ///// </summary>
        ///// <returns></returns>
        //public static int loadProfile()
        //{
        //    try
        //    {
        //        string fileName = appPath + "profile.ini";
        //        if (System.IO.File.Exists(fileName))
        //        {
        //            string str = System.IO.File.ReadAllText(MyFuncLib.AppPath + "profile.ini");
        //            str = DES.Decrypt(str, passwordKey);
        //            string[] arr = str.Split(';');
        //            if (arr.Length == 5)
        //            {
        //                localDBConnStr = "server=" + arr[0] + ";port=" + arr[1] + ";" + "database=" + arr[2] + ";" + "user=" + arr[3] + ";" + "password=" + arr[4] + ";";
        //            }
        //            else
        //                return -3;
        //        }
        //        else
        //            return -2;
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return -1;
        //    }
        //    return 0;
        //}
        ///// <summary>
        ///// 指定表指定字段当前值是否存在
        ///// </summary>
        ///// <param name="tableName">指定的表</param>
        ///// <param name="name">指定的字段</param>
        ///// <param name="value">待判定的值</param>
        ///// <returns></returns>
        //public static int isItemExists(string tableName, string name, string value)
        //{
        //    try
        //    {
        //        string sql = "select count(*) as tc from " + tableName + " where " + name + " = '" + value + "'";
        //        return int.Parse(MyFuncLib.DBCommandExecScalarBySql(sql, null));
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return -1;
        //    }
        //}

        ///// <summary>
        ///// 指定表指定字段当前值是否存在，两个字段值的判断
        ///// </summary>
        ///// <param name="tableName">指定的表</param>
        ///// <param name="name">指定的字段</param>
        ///// <param name="value">待判定的值</param>
        ///// <param name="name2">指定的字段2</param>
        ///// <param name="value2">待判断的值2</param>
        ///// <returns></returns>
        //public static int isItemExists(string tableName, string name, string value, string name2, string value2)
        //{
        //    try
        //    {
        //        string sql = "select count(*) from " + tableName + " where " + name + " = '" + value + "'" + " and " + name2 + " = '" + value2 + "'";
        //        return int.Parse(MyFuncLib.DBCommandExecScalarBySql(sql, null));
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return -1;
        //    }
        //}

        //public static string getIDByUUID(string tablename, string uuid)
        //{
        //    try
        //    {
        //        string sql = "select isnull(max(ID_),0) as result from " + tablename + " where UUID_ = @uuid";
        //        ArrayList sqlParams = new ArrayList();
        //        sqlParams.Add(new ListItem("@uuid", uuid));
        //        return MyFuncLib.DBCommandExecScalarBySql(sql, sqlParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return "-1";
        //    }
        //}

        ///// <summary>
        ///// 读取指定表指定ID的某个字段的值
        ///// </summary>
        ///// <param name="tableName">指定的表</param>
        ///// <param name="name">待读取值的字段名称</param>
        ///// <param name="id">给定的ID</param>
        ///// <returns></returns>
        //public static string getPropById(string tableName, string name, int id)
        //{
        //    try
        //    {
        //        string sql = "select isnull(min(" + name + "),'') as result from " + tableName + " where ID_ = " + id;
        //        return MyFuncLib.DBCommandExecScalarBySql(sql, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return "-1";
        //    }
        //}

        ///// <summary>
        ///// 读取系统参数的值
        ///// </summary>
        ///// <param name="name">参数名称</param>
        ///// <returns></returns>
        //public static string getSysParameter(string name)
        //{
        //    try
        //    {
        //        if (SysParameterDataTable == null)
        //        {
        //            string sql = "select name,value from core_sysparameters";
        //            SysParameterDataTable = MyFuncLib.DBCommandExecQueryBySql(sql, null);
        //        }
        //        foreach (DataRow row in SysParameterDataTable.Rows)
        //        {
        //            if (name.Equals(MyFuncLib.dtv(row, "name", string.Empty)))
        //                return MyFuncLib.dtv(row, "value", string.Empty);
        //        }
        //        return string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return "-1";
        //    }
        //}

        //public static void loadSysParamter()
        //{
        //    SysParameters.WebDir = getSysParameter("WebDir");
        //    if (!SysParameters.WebDir.EndsWith("\\"))
        //        SysParameters.WebDir += "\\";
        //    // 判断是否使用外部网址
        //    if (SysParameters.External.Equals("N"))
        //        SysParameters.WebHost = getSysParameter("WebHost");
        //    else
        //        SysParameters.WebHost = getSysParameter("WebHost.External");
        //    if (!SysParameters.WebHost.EndsWith("/"))
        //        SysParameters.WebHost += "/";
        //    SysParameters.DefaultPassword = getSysParameter("DefaultPassword");
        //    SysParameters.OnlineTimerInterval = getSysParameter("OnlineTimerInterval");
        //    SysParameters.NoticeIm = getSysParameter("NoticeIm");
        //    SysParameters.NoticeMail = getSysParameter("NoticeMail");
        //    SysParameters.NoticeMobile = getSysParameter("NoticeMobile");
        //    SysParameters.NoticeLocal = getSysParameter("NoticeLocal");
        //    SysParameters.SmtpHost = getSysParameter("SmtpHost");
        //    SysParameters.SmtpPort = getSysParameter("SmtpPort");
        //    SysParameters.SmtpPassword = getSysParameter("SmtpPassword");
        //    SysParameters.SmtpUserName = getSysParameter("SmtpUserName");
        //    SysParameters.SmtpSSL = getSysParameter("SmtpSSL");
        //    SysParameters.SmtpEncrypt = getSysParameter("SmtpEncrypt");
        //    SysParameterDataTable = null;
        //}

        ///// <summary>
        ///// 设置系统参数
        ///// </summary>
        ///// <param name="name">参数名称</param>
        ///// <param name="value">参数值</param>
        ///// <returns></returns>
        //public static int setSysParameter(string name, int value)
        //{
        //    return setSysParameter(name, value.ToString());
        //}

        ///// <summary>
        ///// 设置系统参数
        ///// </summary>
        ///// <param name="name">参数名称</param>
        ///// <param name="value">参数值</param>
        ///// <returns></returns>
        //public static int setSysParameter(string name, string value)
        //{
        //    try
        //    {
        //        string sql = "update core_sysparameters set value = @value where name = @name";
        //        ArrayList sqlParams = new ArrayList();
        //        sqlParams.Add(new ListItem("@name", name));
        //        sqlParams.Add(new ListItem("@value", value));
        //        MyFuncLib.DBCommandExecNoneQueryBySql(sql, sqlParams);
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return -1;
        //    }
        //}

        ///// <summary>
        ///// 取得当前日期 yyyy-MM-dd
        ///// </summary>
        ///// <returns></returns>
        //public static string getDate()
        //{
        //    return DateTime.Now.ToString("yyyy-MM-dd");
        //}

        /// <summary>
        /// 取得当前时间yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <returns></returns>
        public static string getDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 判断一个字符串是否为合法整数(不限制长度)
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsInteger(string s)
        {
            string pattern = @"^\d*$";
            return Regex.IsMatch(s, pattern);
        }

        /// <summary>
        /// 判断一个字符串是否为合法数字(0-32整数)
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string s)
        {
            return IsNumber(s, 32, 0);
        }

        /// <summary>
        /// 判断一个字符串是否为合法数字(指定整数位数和小数位数)
        /// </summary>
        /// <param name="s">字符串</param>
        /// <param name="precision">整数位数</param>
        /// <param name="scale">小数位数</param>
        /// <returns></returns>
        public static bool IsNumber(string s, int precision, int scale)
        {
            if ((precision == 0) && (scale == 0))
            {
                return false;
            }
            string pattern = @"(^\d{1," + precision + "}";
            if (scale > 0)
            {
                pattern += @"\.\d{0," + scale + "}$)|" + pattern;
            }
            pattern += "$)";
            return Regex.IsMatch(s, pattern);
        }

        public static bool IsDouble(string s)
        {
            return Regex.IsMatch(s, @"^[\.\d]*$");
        }
        /// <summary>
        /// 判断一个字符串是否为合法身份证号
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsIDCard(string s)
        {
            string pattern = @"^(^\d{15}$|^\d{18}$|^\d{17}(\d|X|x))$";
            return Regex.IsMatch(s, pattern);
        }

        /// <summary>
        /// 判断一个字符串是否为合法固定电话号码
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsPhoneNum(string s)
        {
            string pattern = @"^(\d{3,4}-)?\d{6,8}$";
            return Regex.IsMatch(s, pattern);
        }

        /// <summary>
        /// 判断一个字符串是否为合法移动电话号码
        /// </summary>
        /// <param name="s">字符串</param>
        /// <returns></returns>
        public static bool IsMobilePhoneNum(string s)
        {
            string pattern = @"^[1]+[3,5,8]+\d{9}";
            return Regex.IsMatch(s, pattern);
        }

        /// <summary>
        /// 检查Email地址
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool isEmail(string email)
        {
            if (email == null || email.Equals(string.Empty))
                return false;
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(email))
                return true;
            return false;
        }

        //public static ErrorInfo isValidPassword(string password)
        //{
        //    ErrorInfo error = new ErrorInfo();
        //    error.HasError = false;
        //    if (string.IsNullOrEmpty(password))
        //    {
        //        error.HasError = true;
        //        error.ErrorCode = 1;
        //        error.ErrorMessage = "密码不能空";
        //    }
        //    else if (password.Length < 8)
        //    {
        //        error.HasError = true;
        //        error.ErrorCode = 2;
        //        error.ErrorMessage = "密码长度不能小于8";
        //    }
        //    else if (Regex.IsMatch(password, @"^\d*$"))
        //    {
        //        error.HasError = true;
        //        error.ErrorCode = 3;
        //        error.ErrorMessage = "密码不能是纯数字";
        //    }
        //    else if (Regex.IsMatch(password, @"^[a-zA-Z]*$"))
        //    {
        //        error.HasError = true;
        //        error.ErrorCode = 4;
        //        error.ErrorMessage = "密码不能是纯字母";
        //    }
        //    return error;
        //}

        #region Write log to local file

        /// <summary>
        /// 本地日志记录
        /// </summary>
        /// <param name="str">要记录的日志内容</param>
        public static void log(string str)
        {
            string filePath = @appPath + "error.log";
            string content = DateTime.Now.ToString("yyyyMMddHHmmss:") + str;
            if (!System.IO.File.Exists(filePath))
            {
                System.IO.File.AppendAllText(filePath, content);
                return;
            }
            ParameterizedThreadStart threadStart = new ParameterizedThreadStart(writeLog);
            Thread thread = new Thread(threadStart);
            thread.Name = "HYAppFrame.log";
            thread.Start(str);
        }

        public static void writeLog(object str)
        {
            string filePath = @appPath + "error.log";
            string content = "\r\n" + DateTime.Now.ToString("yyyyMMddHHmmss:") + str.ToString();
            System.IO.FileInfo info = new System.IO.FileInfo(filePath);
            if (info.Length > 1024 * 1024 * 5)
            {
                while (IsFileInUse(filePath))
                    Thread.Sleep(100);
                System.IO.File.Move(filePath, @appPath + "error" + DateTime.Now.ToString("yyyyMMdd") + ".log");
                System.IO.File.Delete(filePath);
            }
            while (IsFileInUse(filePath))
                Thread.Sleep(100);
            if (!IsFileInUse(filePath))
            {
                #region write file
                System.IO.FileStream fs = null;
                try
                {
                    fs = new System.IO.FileStream(filePath, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.None);
                    fs.Write(Encoding.UTF8.GetBytes(content), 0, Encoding.UTF8.GetByteCount(content));
                }
                catch
                {
                    ;
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
                }
                #endregion
            }
        }

        public static bool IsFileInUse(string fileName)
        {
            bool inUse = true;
            System.IO.FileStream fs = null;
            try
            {
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None);
                inUse = false;
            }
            catch
            {
                inUse = true;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return inUse;
        }
        #endregion

        ///// <summary>
        ///// 将日志写入数据库中
        ///// </summary>
        ///// <param name="logType">日志类型，例如error,login,logout,warning,delete</param>
        ///// <param name="subject">主题</param>
        ///// <param name="exMessage">消息</param>
        ///// <param name="exTrace">调试信息</param>
        //public static int logToDB(string logType, string subject, string exMessage, string exTrace)
        //{
        //    try
        //    {
        //        string sql = "insert into core_log(CID_,CDATE_,logType,subject,exMessage,exStackTrace,ip) values(@cId, getDate(), @type, @subject, @msg, @trace, @ip)";
        //        ArrayList sqlParams = new ArrayList();
        //        sqlParams.Add(new ListItem("@cId", MyFuncLib.UserId));
        //        sqlParams.Add(new ListItem("@type", logType));
        //        sqlParams.Add(new ListItem("@subject", subject));
        //        sqlParams.Add(new ListItem("@msg", exMessage));
        //        sqlParams.Add(new ListItem("@trace", exTrace));
        //        sqlParams.Add(new ListItem("@ip", ip));
        //        return MyFuncLib.DBCommandExecNoneQueryBySql(sql, sqlParams);
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return -1;
        //    }
        //}

        ///// <summary>
        ///// 将消息加入队列
        ///// </summary>
        ///// <param name="msgType">邮件提醒email,手机短信mobile,站内提醒local,即时消息im</param>
        ///// <param name="uName">用户名</param>
        ///// <param name="subject">主题</param>
        ///// <param name="message">正文</param>
        //public static void addToMessageList(string msgType, string uName, string subject, string message)
        //{
        //    try
        //    {
        //        string dName, mPhone, mail;
        //        dName = mPhone = mail = string.Empty;
        //        int tc = 0;
        //        string sql = "select displayName,mobilePhone,email from core_user where username = @username";
        //        ArrayList sqlParams = new ArrayList();
        //        sqlParams.Add(new ListItem("@username", uName));
        //        DataTable dtTemp = MyFuncLib.DBCommandExecQueryBySql(sql, sqlParams);
        //        foreach (DataRow row in dtTemp.Rows)
        //        {
        //            dName = MyFuncLib.dtv(row, "displayName", string.Empty);
        //            mPhone = MyFuncLib.dtv(row, "mobilePhone", string.Empty);
        //            mail = MyFuncLib.dtv(row, "email", string.Empty);
        //            tc++;
        //        }

        //        //// 不将不合法的邮件地址和手机号加入队列
        //        if (msgType.Equals("email") && !MyFuncLib.isEmail(mail))
        //            tc = 0;
        //        else if (msgType.Equals("mobile") && !MyFuncLib.IsMobilePhoneNum(mPhone))
        //            tc = 0;
        //        if (tc > 0)
        //        {
        //            sql = "insert into core_message(CID_,CDATE_,msgType,username,displayName,email,mobilePhone,subject, message,sended) values(@cId,getDate(),@msgType,@username,@displayName,@email,@mobilePhone, @subject, @message,0)";
        //            sqlParams = new ArrayList();
        //            sqlParams.Add(new ListItem("@cId", userId));
        //            sqlParams.Add(new ListItem("@msgType", msgType));
        //            sqlParams.Add(new ListItem("@subject", subject));
        //            sqlParams.Add(new ListItem("@message", message));
        //            sqlParams.Add(new ListItem("@username", uName));
        //            sqlParams.Add(new ListItem("@mobilePhone", mPhone));
        //            sqlParams.Add(new ListItem("@email", mail));
        //            sqlParams.Add(new ListItem("@displayName", dName));
        //            sqlParams.Add(new ListItem("@ip", ip));
        //            MyFuncLib.DBCommandExecNoneQueryBySql(sql, sqlParams);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //    }
        //}

        ///// <summary>
        ///// 将消息加入队列
        ///// </summary>
        ///// <param name="msgType">邮件提醒email,手机短信mobile,站内提醒local,即时消息im</param>
        ///// <param name="uId"></param>
        ///// <param name="subject"></param>
        ///// <param name="message"></param>
        //public static void addToMessageList(string msgType, int uId, string subject, string message)
        //{
        //    try
        //    {
        //        string uName, dName, mPhone, mail;
        //        uName = dName = mPhone = mail = string.Empty;
        //        int tc = 0;
        //        string sql = "select username,displayName,mobilePhone,email from core_user where ID_ = @id";
        //        ArrayList sqlParams = new ArrayList();
        //        sqlParams.Add(new ListItem("@id", uId));
        //        DataTable dtTemp = MyFuncLib.DBCommandExecQueryBySql(sql, sqlParams);
        //        foreach (DataRow row in dtTemp.Rows)
        //        {
        //            uName = MyFuncLib.dtv(row, "username", string.Empty);
        //            dName = MyFuncLib.dtv(row, "displayName", string.Empty);
        //            mPhone = MyFuncLib.dtv(row, "mobilePhone", string.Empty);
        //            mail = MyFuncLib.dtv(row, "email", string.Empty);
        //            tc++;
        //        }
        //        //// 不将不合法的邮件地址和手机号加入队列
        //        if (msgType.Equals("email") && !MyFuncLib.isEmail(mail))
        //            tc = 0;
        //        else if (msgType.Equals("mobile") && !MyFuncLib.IsMobilePhoneNum(mPhone))
        //            tc = 0;
        //        if (tc > 0)
        //        {
        //            sql = "insert into core_message(CID_,CDATE_,msgType,username,displayName,email,mobilePhone,subject, message,sended) values(@cId,getDate(),@msgType,@username,@displayName,@email,@mobilePhone, @subject, @message,0)";
        //            sqlParams = new ArrayList();
        //            sqlParams.Add(new ListItem("@cId", userId));
        //            sqlParams.Add(new ListItem("@msgType", msgType));
        //            sqlParams.Add(new ListItem("@subject", subject));
        //            sqlParams.Add(new ListItem("@message", message));
        //            sqlParams.Add(new ListItem("@username", uName));
        //            sqlParams.Add(new ListItem("@mobilePhone", mPhone));
        //            sqlParams.Add(new ListItem("@email", mail));
        //            sqlParams.Add(new ListItem("@displayName", dName));
        //            sqlParams.Add(new ListItem("@ip", ip));
        //            MyFuncLib.DBCommandExecNoneQueryBySql(sql, sqlParams);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //    }
        //}

        ///// <summary>
        ///// 自定义MessageBox对话框,支持询问q,程序错误e,警告w,提示i
        ///// </summary>
        ///// <param name="lable"></param>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static bool msg(string lable, string type)
        //{
        //    MessageBox frm = new MessageBox();
        //    frm.labelText = lable;
        //    frm.imageType = type;
        //    if ("q".Equals(type))
        //        frm.Text = "询问";
        //    else if ("e".Equals(type))
        //        frm.Text = "程序错误";
        //    else if ("w".Equals(type))
        //        frm.Text = "警告";
        //    else
        //        frm.Text = "提示";
        //    frm.ShowDialog();
        //    return frm.result;
        //}

        ///// <summary>
        ///// 自定义输入对话框
        ///// </summary>
        ///// <param name="title">对话框标题</param>
        ///// <param name="lable">文本提示</param>
        ///// <returns></returns>
        //public static string inputBox(string title, string lable)
        //{
        //    InputBox frm = new InputBox();
        //    frm.Text = title;
        //    frm.labelText = lable;
        //    frm.inputType = "string";
        //    frm.ShowDialog();
        //    return frm.returnStringValue;
        //}

        ///// <summary>
        ///// 自定义输入对话框
        ///// </summary>
        ///// <param name="title">对话框标题</param>
        ///// <param name="lable">文本提示</param>
        ///// <returns></returns>
        //public static string inputBox(string title, string lable, DateTime date)
        //{
        //    InputBox frm = new InputBox();
        //    frm.Text = title;
        //    frm.labelText = lable;
        //    frm.defaultDateValue = date;
        //    frm.inputType = "date";
        //    frm.ShowDialog();
        //    return frm.returnDateValue;
        //}

        ///// <summary>
        ///// 自定义输入对话框，含字符掩码，适用于密码的输入
        ///// </summary>
        ///// <param name="title">对话框标题</param>
        ///// <param name="lable">文本题是</param>
        ///// <param name="passwordChar">字符掩码</param>
        ///// <returns></returns>
        //public static string inputBox(string title, string lable, char passwordChar)
        //{
        //    InputBox frm = new InputBox();
        //    frm.Text = title;
        //    frm.labelText = lable;
        //    frm.inputType = "string";
        //    frm.passwordChar = passwordChar;
        //    frm.ShowDialog();
        //    return frm.returnStringValue;
        //}
        ///// <summary>
        ///// 取得文件
        ///// </summary>
        ///// <param name="fileNameOrFileFullName"></param>
        ///// <returns></returns>
        //public static string getFileName(string fileNameOrFileFullName)
        //{
        //    if (fileNameOrFileFullName.IndexOf("\\") > -1)
        //        return fileNameOrFileFullName.Substring(fileNameOrFileFullName.LastIndexOf("\\") + 1);
        //    else if (fileNameOrFileFullName.IndexOf("/") > -1)
        //        return fileNameOrFileFullName.Substring(fileNameOrFileFullName.LastIndexOf("/") + 1);
        //    else
        //        return string.Empty;
        //}
        ///// <summary>
        ///// 取得文件扩展名
        ///// </summary>
        ///// <param name="fileNameOrFileFullName"></param>
        ///// <returns></returns>
        //public static string getFileNameExt(string fileNameOrFileFullName)
        //{
        //    if (fileNameOrFileFullName.IndexOf(".") > -1)
        //        return fileNameOrFileFullName.Substring(fileNameOrFileFullName.LastIndexOf("."));
        //    else
        //        return string.Empty;
        //}

        //public static void popMessage(string msg)
        //{
        //    FormPop frmPop = new FormPop();
        //    int x = Screen.PrimaryScreen.WorkingArea.Width - frmPop.Width;
        //    int y = Screen.PrimaryScreen.WorkingArea.Height;
        //    Point p = new Point(x, y);
        //    frmPop.PointToScreen(p);
        //    frmPop.msg = msg;
        //    frmPop.Location = p;
        //    frmPop.Opacity = 1;
        //    frmPop.Show();
        //}

        /// <summary>
        /// ip地址校验
        /// </summary>
        /// <param name="ipAdress">ipAdress</param>
        /// <returns>true or false</returns>
        public static bool IsIpAddress(string ipAdress)
        {
            return Regex.IsMatch(ipAdress, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        //public static void initDgv(DataGridView d, string fields)
        //{
        //    System.Windows.Forms.DataGridViewCellStyle style;
        //    string regType = @"^Type=([\w\.]+),";
        //    string regName = @"Name=(\w+),";
        //    string regTag = @"Tag=(\w+),";
        //    string regWidth = @"Width=(\d+),";
        //    string regVisible = @"Visible=(true|false),";
        //    string regReadOnly = @"ReadOnly=(true|false),";
        //    string regFrozen = @"Frozen=(true|false),";
        //    string regOrder = @"Order=(true|false),";
        //    string regHeaderText = @"HeaderText=([\s\S]*)$";
        //    string regFormat = @"Format=(\w+),";
        //    string regNullValue = @"NullValue=(\w+),";
        //    string regAlignment = @"Alignment=(\w+),";
        //    string regMaxInputLength = @"MaxInputLength=(\d+),";
        //    string regSource = @"Source=(\w+),";
        //    string type = string.Empty;
        //    string mStr = string.Empty;
        //    foreach (string s in fields.Split(';'))
        //    {
        //        style = new System.Windows.Forms.DataGridViewCellStyle();
        //        Regex r = new Regex(regType);
        //        if (r.IsMatch(s))
        //        {
        //            type = r.Match(s).Groups[1].Value.ToString();
        //            DataGridViewColumn c = new DataGridViewColumn();
        //            #region 名称
        //            r = new Regex(regName);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                c.Name = mStr;
        //                c.DataPropertyName = mStr;
        //            }
        //            #endregion
        //            #region 显示宽度
        //            r = new Regex(regWidth);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                c.Width = int.Parse(mStr);
        //            }
        //            #endregion
        //            #region 排序
        //            r = new Regex(regOrder);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                if ("true".Equals(mStr))
        //                    c.SortMode = DataGridViewColumnSortMode.Automatic;
        //                else
        //                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
        //            }
        //            #endregion
        //            #region 可视
        //            r = new Regex(regVisible);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                c.Visible = bool.Parse(mStr);
        //            }
        //            #endregion
        //            #region  只读
        //            r = new Regex(regReadOnly);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                c.ReadOnly = bool.Parse(mStr);

        //            }
        //            #endregion
        //            #region  冻结
        //            r = new Regex(regFrozen);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                c.Frozen = bool.Parse(mStr);
        //            }
        //            #endregion
        //            #region  列名
        //            r = new Regex(regHeaderText);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                c.HeaderText = mStr;
        //            }
        //            #endregion
        //            #region 格式化
        //            r = new Regex(regFormat);
        //            if (r.IsMatch(s))
        //            {
        //                // N1,N2,N3,N4,N5,N6 指小数位数
        //                // C1,C2,C3,C4指货币小数位数
        //                // d指日期yyyy-MM-dd
        //                // g指日期时间yyyy-MM-dd HH:mm
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                style.Format = mStr;
        //            }
        //            #endregion
        //            #region 设置Tag，以便确定是否可筛选
        //            r = new Regex(regTag);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                c.Tag = mStr;
        //            }
        //            #endregion
        //            #region 空值
        //            r = new Regex(regNullValue);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                if (mStr.ToLower().Equals("true") || mStr.ToLower().Equals("false"))
        //                    style.NullValue = bool.Parse(mStr);
        //                else
        //                    style.NullValue = mStr;
        //            }
        //            #endregion
        //            #region 对齐
        //            r = new Regex(regAlignment);
        //            if (r.IsMatch(s))
        //            {
        //                mStr = string.Empty;
        //                mStr = r.Match(s).Groups[1].Value.ToString();
        //                if (mStr.Equals("center"))
        //                {
        //                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                }
        //                else if (mStr.Equals("right"))
        //                {
        //                    style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
        //                }
        //                else
        //                {
        //                    style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //                }
        //            }
        //            #endregion
        //            #region 最大长度
        //            r = new Regex(regMaxInputLength);
        //            string len = string.Empty;
        //            if (r.IsMatch(s))
        //                len = r.Match(s).Groups[1].Value.ToString();
        //            #endregion
        //            #region 值来源
        //            string source = string.Empty;
        //            r = new Regex(regSource);
        //            if (r.IsMatch(s))
        //                source = r.Match(s).Groups[1].Value.ToString();
        //            #endregion
        //            if (c.ReadOnly)
        //                style.BackColor = Color.FromArgb(215, 215, 215);
        //            c.DefaultCellStyle = style;
        //            initDgvC2(d, c, type, len, source);
        //        }
        //    }
        //}

        //public static void initDgv(DataGridView d, string formName, int userId)
        //{
        //    System.Windows.Forms.DataGridViewCellStyle style;
        //    try
        //    {
        //        string sql = "select ta.*,tb.isVisible as userVisible from core_formfield ta";
        //        sql += " left join core_formfield_user tb on tb.fieldId = ta.ID_ and tb.CID_ = " + userId;
        //        sql += " where ta.formName = @formName order by ta.fIndex";
        //        ArrayList sqlParams = new ArrayList();
        //        sqlParams.Add(new ListItem("@formName", formName));
        //        DataTable dtTemp = MyFuncLib.DBCommandExecQueryBySql(sql, sqlParams);
        //        DataGridViewColumn c;
        //        string str = string.Empty, type = string.Empty, isGlobal = "0", source = string.Empty;
        //        foreach (DataRow row in dtTemp.Rows)
        //        {
        //            #region c style
        //            style = new System.Windows.Forms.DataGridViewCellStyle();
        //            c = new DataGridViewColumn();
        //            isGlobal = dtv(row, "isGlobal", string.Empty);
        //            source = dtv(row, "fSource", string.Empty);
        //            str = dtv(row, "fName", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                c.Name = str;
        //                c.DataPropertyName = str;
        //            }
        //            str = dtv(row, "fWidth", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                c.Width = int.Parse(str);
        //            }
        //            str = dtv(row, "fOrder", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                if ("1".Equals(str))
        //                    c.SortMode = DataGridViewColumnSortMode.Automatic;
        //                else
        //                    c.SortMode = DataGridViewColumnSortMode.NotSortable;
        //            }
        //            if (isGlobal.Equals("1"))
        //                str = dtv(row, "fVisible", string.Empty);
        //            else
        //            {
        //                str = dtv(row, "userVisible", string.Empty);
        //                if (string.IsNullOrEmpty(str))
        //                    str = dtv(row, "fVisible", string.Empty);
        //            }
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                if ("1".Equals(str))
        //                    c.Visible = true;
        //                else
        //                    c.Visible = false;
        //            }
        //            str = dtv(row, "fReadOnly", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                if ("1".Equals(str))
        //                    c.ReadOnly = true;
        //                else
        //                    c.ReadOnly = false;
        //            }
        //            str = dtv(row, "fFrozen", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                if ("1".Equals(str))
        //                    c.Frozen = true;
        //                else
        //                    c.Frozen = false;
        //            }
        //            str = dtv(row, "fHeaderText", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                c.HeaderText = str;
        //            }
        //            str = dtv(row, "fFormat", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                style.Format = str;
        //            }
        //            str = dtv(row, "fTag", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                c.Tag = str;
        //            }
        //            str = dtv(row, "fNullValue", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                if (str.ToLower().Equals("true") || str.ToLower().Equals("false"))
        //                    style.NullValue = bool.Parse(str);
        //                else
        //                    style.NullValue = str;
        //            }
        //            str = dtv(row, "fAlignment", string.Empty);
        //            if (!string.IsNullOrEmpty(str))
        //            {
        //                if (str.Equals("center"))
        //                {
        //                    style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                }
        //                else if (str.Equals("right"))
        //                {
        //                    style.Alignment = DataGridViewContentAlignment.MiddleRight;
        //                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.BottomRight;
        //                }
        //                else
        //                {
        //                    style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //                    c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //                }
        //            }
        //            if (c.ReadOnly)
        //                style.BackColor = Color.FromArgb(215, 215, 215);
        //            c.DefaultCellStyle = style;
        //            #endregion
        //            type = dtv(row, "fType", string.Empty);
        //            string maxInputlength = dtv(row, "fMaxInputLength", string.Empty);
        //            source = dtv(row, "fSource", string.Empty);
        //            initDgvC2(d, c, type, maxInputlength, source);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MyFuncLib.log(ex.Message + "\r\n" + ex.StackTrace);
        //    }
        //}

        //private static void initDgvC2(DataGridView d, DataGridViewColumn c, string type, string maxInputLength, string source)
        //{
        //    if ("text".Equals(type))
        //    {
        //        #region text
        //        DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        c2.Tag = c.Tag;
        //        if (IsNumber(maxInputLength))
        //            c2.MaxInputLength = int.Parse(maxInputLength);
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //    else if ("double".Equals(type))
        //    {
        //        #region double
        //        DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        c2.Tag = c.Tag;
        //        if (IsNumber(maxInputLength))
        //            c2.MaxInputLength = int.Parse(maxInputLength);
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //    else if ("int".Equals(type))
        //    {
        //        #region int
        //        DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        c2.Tag = c.Tag;
        //        if (IsNumber(maxInputLength))
        //            c2.MaxInputLength = int.Parse(maxInputLength);
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //    else if ("date".Equals(type))
        //    {
        //        #region date
        //        DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        c2.Tag = c.Tag;
        //        if (IsNumber(maxInputLength))
        //            c2.MaxInputLength = int.Parse(maxInputLength);
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //    else if ("datetime".Equals(type))
        //    {
        //        #region datetime
        //        DataGridViewTextBoxColumn c2 = new DataGridViewTextBoxColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        c2.Tag = c.Tag;
        //        if (IsNumber(maxInputLength))
        //            c2.MaxInputLength = int.Parse(maxInputLength);
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //    else if ("checkbox".Equals(type) || "check".Equals(type))
        //    {
        //        #region checkbox
        //        DataGridViewCheckBoxColumn c2 = new DataGridViewCheckBoxColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        c2.Tag = c.Tag;
        //        c2.TrueValue = 1;
        //        c2.FalseValue = 0;
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //    else if ("image".Equals(type))
        //    {
        //        #region image
        //        DataGridViewImageColumn c2 = new DataGridViewImageColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        c2.Tag = c.Tag;
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //    else if (type.StartsWith("comboxlist"))
        //    {
        //        #region comboxlist
        //        DataGridViewComboBoxColumn c2 = new DataGridViewComboBoxColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        foreach (ListItem item in MyFuncLib.loadComboxItems(source))
        //        {
        //            c2.Items.Add(item.Name);
        //        }
        //        c2.Tag = c.Tag;
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //    else if (type.StartsWith("combox"))
        //    {
        //        #region combox
        //        DataGridViewComboBoxColumn c2 = new DataGridViewComboBoxColumn();
        //        c2.Name = c.Name;
        //        c2.DataPropertyName = c.DataPropertyName;
        //        c2.HeaderText = c.HeaderText;
        //        c2.Width = c.Width;
        //        c2.Visible = c.Visible;
        //        c2.ReadOnly = c.ReadOnly;
        //        c2.Frozen = c.Frozen;
        //        c2.DefaultCellStyle = c.DefaultCellStyle;
        //        c2.HeaderCell.Style = c.HeaderCell.Style;
        //        c2.SortMode = c.SortMode;
        //        foreach (ListItem item in MyFuncLib.loadComboxItems(source))
        //        {
        //            c2.Items.Add(item.Name);
        //        }
        //        c2.Tag = c.Tag;
        //        d.Columns.Add(c2);
        //        #endregion
        //    }
        //}

        ///// <summary>
        ///// 将DataGridView中的数据导出到Excel
        ///// </summary>
        ///// <param name="dgv">DataGridView</param>
        ///// <param name="fName">要保存的文件名</param>
        //public static void DataToExcel(DataGridView dgv, string fName)
        //{
        //    try
        //    {

        //        Excel.Application excel = new Excel.Application();

        //        if (excel == null)
        //        {
        //            MyFuncLib.msg("请检查本机是否安装了Excel2007或Excel2010", "w");
        //            return;
        //        }
        //        Excel.Workbook wb = excel.Workbooks.Add(true);
        //        Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;
        //        ws.Name = fName;

        //        string sFile = string.Empty;

        //        SaveFileDialog dialog = new SaveFileDialog();
        //        dialog.Title = "保存文件";
        //        dialog.Filter = "EXECL文件(*.xlsx) |.xlsx";
        //        dialog.FileName = fName;
        //        dialog.FilterIndex = 1;
        //        if (dialog.ShowDialog() == DialogResult.OK)
        //        {
        //            string FileName = dialog.FileName;
        //            if (File.Exists(FileName))
        //                File.Delete(FileName);
        //            sFile = FileName;
        //            excel.Visible = false;
        //            excel.DisplayAlerts = false;
        //            //// 标题
        //            int visibleColumnCount = 0;
        //            foreach (DataGridViewColumn col in dgv.Columns)
        //            {
        //                if (col.Visible)
        //                {
        //                    visibleColumnCount++;
        //                    ws.Cells[1, visibleColumnCount].Value2 = col.HeaderText.ToString();
        //                    ws.Cells[1, visibleColumnCount].Font.Bold = true;
        //                    if (col.ValueType != null)
        //                    {
        //                        if (col.ValueType.Name.Equals("DateTime"))
        //                        {
        //                            ws.Columns[visibleColumnCount].NumberFormatLocal = @"yyyy-mm-dd HH:mm";
        //                            ws.Columns[visibleColumnCount].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Blue);
        //                        }
        //                        else if (col.ValueType.Name.Equals("Decimal"))
        //                        {
        //                            ws.Columns[visibleColumnCount].NumberFormat = "0.00";
        //                        }
        //                        else if (col.ValueType.Name.Equals("Int32"))
        //                        {
        //                            ws.Columns[visibleColumnCount].NumberFormat = "0";
        //                        }
        //                        else
        //                        {
        //                            ws.Columns[visibleColumnCount].NumberFormatLocal = @"@";
        //                        }
        //                    }
        //                    else
        //                        ws.Columns[visibleColumnCount].NumberFormatLocal = @"@";
        //                }
        //            }
        //            //// 逐行写入
        //            //// ValueType=String,Decimal,Int32,DateTime
        //            int i = 2;
        //            foreach (DataGridViewRow row in dgv.Rows)
        //            {
        //                visibleColumnCount = 0;
        //                foreach (DataGridViewColumn col in dgv.Columns)
        //                {
        //                    if (col.Visible)
        //                    {
        //                        visibleColumnCount++;
        //                        ws.Cells[i, visibleColumnCount].Value2 = v(row, col.Index, string.Empty);
        //                    }
        //                }
        //                i++;
        //            }
        //            //// 51表示2007-2010格式的xlsx
        //            ws.SaveAs(FileName, 51, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
        //            wb.Close(true, Type.Missing, Type.Missing);
        //            excel.Quit();
        //            //// 安全回收进程
        //            System.GC.GetGeneration(excel);
        //            if (MyFuncLib.msg("已经导出Excel，您是否要打开？", "q"))
        //                System.Diagnostics.Process.Start(FileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //        msg("请检查您是否安装了Excel2010\r\n" + ex.Message, "e");
        //    }
        //}

        //public static void DataToExcel(DataGridView dgv, DataTable dt, string fName)
        //{
        //    try
        //    {

        //        Excel.Application excel = new Excel.Application();

        //        if (excel == null)
        //        {
        //            MyFuncLib.msg("请检查本机是否安装了Excel2007或Excel2010", "w");
        //            return;
        //        }
        //        Excel.Workbook wb = excel.Workbooks.Add(true);
        //        Excel.Worksheet ws = (Excel.Worksheet)wb.ActiveSheet;
        //        ws.Name = fName;

        //        string sFile = string.Empty;

        //        SaveFileDialog dialog = new SaveFileDialog();
        //        dialog.Title = "保存文件";
        //        dialog.Filter = "EXECL文件(*.xlsx) |.xlsx";
        //        dialog.FileName = fName;
        //        dialog.FilterIndex = 1;
        //        if (dialog.ShowDialog() == DialogResult.OK)
        //        {
        //            DateTime now = DateTime.Now;

        //            string FileName = dialog.FileName;
        //            if (File.Exists(FileName))
        //                File.Delete(FileName);
        //            sFile = FileName;
        //            excel.Visible = false;
        //            excel.DisplayAlerts = false;
        //            //// 标题
        //            int visibleColumnCount = 0;
        //            foreach (DataGridViewColumn col in dgv.Columns)
        //            {
        //                if (col.Visible)
        //                {
        //                    visibleColumnCount++;
        //                    ws.Cells[1, visibleColumnCount].Value2 = col.HeaderText;
        //                    ws.Cells[1, visibleColumnCount].Font.Bold = true;
        //                    if (col.ValueType != null)
        //                    {
        //                        if (col.ValueType.Name.Equals("DateTime"))
        //                        {
        //                            ws.Columns[visibleColumnCount].NumberFormatLocal = @"yyyy-mm-dd HH:mm";
        //                            ws.Columns[visibleColumnCount].Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Blue);
        //                        }
        //                        else if (col.ValueType.Name.Equals("Decimal"))
        //                        {
        //                            ws.Columns[visibleColumnCount].NumberFormat = "0.00";
        //                        }
        //                        else if (col.ValueType.Name.Equals("Int32"))
        //                        {
        //                            ws.Columns[visibleColumnCount].NumberFormat = "0";
        //                        }
        //                        else
        //                        {
        //                            ws.Columns[visibleColumnCount].NumberFormatLocal = @"@";
        //                        }
        //                    }
        //                    else
        //                        ws.Columns[visibleColumnCount].NumberFormatLocal = @"@";
        //                }
        //            }
        //            //// 逐行写入
        //            //// ValueType=String,Decimal,Int32,DateTime
        //            int i = 2;
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                visibleColumnCount = 0;
        //                foreach (DataGridViewColumn col in dgv.Columns)
        //                {
        //                    if (col.Visible)
        //                    {
        //                        visibleColumnCount++;
        //                        ws.Cells[i, visibleColumnCount].Value2 = dtv(row, col.Name, string.Empty);
        //                    }
        //                }
        //                i++;
        //            }
        //            //// 51表示2007-2010格式的xlsx
        //            ws.SaveAs(FileName, 51, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing, Type.Missing);
        //            wb.Close(true, Type.Missing, Type.Missing);
        //            excel.Quit();
        //            //// 安全回收进程
        //            System.GC.GetGeneration(excel);
        //            if (MyFuncLib.msg("已经导出Excel，您是否要打开？", "q"))
        //                System.Diagnostics.Process.Start(FileName);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //        msg("请检查您是否安装了Excel2010\r\n" + ex.Message, "e");
        //    }
        //}

        //public static void DataToCSV(DataTable dt, string dir, string fName, bool open)
        //{
        //    try
        //    {
        //        if (!Directory.Exists(dir))
        //            Directory.CreateDirectory(dir);

        //        StringBuilder sb = new StringBuilder();
        //        foreach (DataColumn col in dt.Columns)
        //        {
        //            sb.Append(col.ColumnName.ToString() + ",");
        //        }
        //        sb.Append("\r\n");

        //        foreach (DataRow row in dt.Rows)
        //        {
        //            foreach (DataColumn col in dt.Columns)
        //            {
        //                sb.Append(dtv(row, col.ColumnName, string.Empty) + ",");
        //            }
        //            sb.Append("\r\n");
        //        }
        //        System.IO.File.WriteAllText(dir + fName, sb.ToString());
        //        if (open)
        //        {
        //            if (MyFuncLib.msg("已经导出CSV，您是否要打开？", "q"))
        //                System.Diagnostics.Process.Start(dir + fName);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //        msg("请检查您是否安装了Excel2010\r\n" + ex.Message, "e");
        //    }
        //}

        //public static string v(DataGridViewRow row, string name, string nullValue)
        //{
        //    if (row == null || !row.DataGridView.Columns.Contains(name) || row.Cells[name].Value == null || row.Cells[name].Value.ToString().Equals(string.Empty))
        //        return nullValue;
        //    else
        //        return row.Cells[name].Value.ToString();
        //}

        //public static string v(DataGridViewRow row, int index, string nullValue)
        //{
        //    if (row == null || row.DataGridView.Columns.Count <= index || row.Cells[index].Value == null || row.Cells[index].Value.ToString().Equals(string.Empty))
        //        return nullValue;
        //    else
        //        return row.Cells[index].Value.ToString();
        //}

        ////public static void deleteAttachement(string tableName, int itemId)
        ////{
        ////    try
        ////    {
        ////        string sql = "select ID_,filename from core_attachment ta where ta.tableName = @tableName and ta.itemId = @itemId";
        ////        ArrayList sqlParams = new ArrayList();
        ////        sqlParams.Add(new ListItem("@itemId", itemId));
        ////        sqlParams.Add(new ListItem("@tableName", tableName));
        ////        DataTable dtTemp = MyFuncLib.DBCommandExecQueryBySql(sql, sqlParams);
        ////        StringBuilder sb = new StringBuilder();
        ////        StringBuilder sb2 = new StringBuilder();
        ////        sb.Append("0");
        ////        sb2.Append("0");
        ////        foreach (DataRow row in dtTemp.Rows)
        ////        {
        ////            sb.Append("," + MyFuncLib.dtv(row, "ID_", string.Empty));
        ////            sb2.Append("," + MyFuncLib.dtv(row, "filename", string.Empty));
        ////        }
        ////        string t = sb.ToString();
        ////        if (t.Length > 2)
        ////            t = t.Substring(2);
        ////        else
        ////            return;
        ////        Array arr = t.Split(',');
        ////        t = sb2.ToString();
        ////        if (t.Length > 2)
        ////            t = t.Substring(2);
        ////        Array arr2 = sb.ToString().Substring(2).Split(',');
        ////        foreach (string s in arr2)
        ////        {
        ////            MyFuncLib.WS.FileDelete(DES.Encrypt(s, MyFuncLib.PasswordKey));
        ////        }
        ////        sql = "delete from core_attachment where ID_ = @id";
        ////        foreach (string s in arr)
        ////        {
        ////            // 删除数据库中的记录
        ////            sqlParams = new ArrayList();
        ////            sqlParams.Add(new ListItem("@id", s));
        ////            MyFuncLib.DBCommandExecNoneQueryBySql(sql, sqlParams);
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        ////        msg("程序遇到未知错误\r\n" + ex.Message, "e");
        ////    }
        ////}

        ////public static void deleteAttachement(DataGridView dgv, string cellName, string cellId)
        ////{
        ////    try
        ////    {
        ////        if (MyFuncLib.msg("您确定要删除选中的文件", "q"))
        ////        {
        ////            int count = 0;
        ////            string fileName;
        ////            string sql = "delete from core_attachment where ID_ = @id";
        ////            string sqlDesc = " select tableName + ',' + oldName + ',' + [fileName] as d from core_attachment where ID_ = @id";
        ////            ArrayList sqlParams;
        ////            foreach (DataGridViewRow row in dgv.SelectedRows)
        ////            {
        ////                fileName = v(row, cellName, string.Empty);
        ////                if (!fileName.Equals(string.Empty))
        ////                {
        ////                    // 删除数据库中的记录
        ////                    sqlParams = new ArrayList();
        ////                    sqlParams.Add(new ListItem("@id", v(row, cellId, "0")));
        ////                    string desc = MyFuncLib.DBCommandExecScalarBySql(sqlDesc, sqlParams);
        ////                    MyFuncLib.logToDB("文件", "删除", desc.Substring(0, 20), desc);
        ////                    // 删除服务器上文件
        ////                    MyFuncLib.WS.FileDelete(DES.Encrypt(fileName, MyFuncLib.PasswordKey));
        ////                    MyFuncLib.DBCommandExecNoneQueryBySql(sql, sqlParams);
        ////                    count++;
        ////                }
        ////            }
        ////            MyFuncLib.msg("共删除" + count + "个文件", "i");
        ////        }
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        ////        msg("程序遇到未知错误\r\n" + ex.Message, "e");
        ////    }
        ////}

        /////// <summary>
        /////// 发送邮件
        /////// </summary>
        /////// <param name="email">邮件地址</param>
        /////// <param name="subject">主题</param>
        /////// <param name="message">邮件正文</param>
        /////// <param name="atts"></param>
        ////public static void sendMail(string email, string subject, string message, ArrayList atts)
        ////{
        ////    try
        ////    {
        ////        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        ////        // 设置smtp服务器, smtp.qq.com
        ////        client.Host = SysParameters.SmtpHost;
        ////        // 设置smtp端口号, 25
        ////        client.Port = int.Parse(SysParameters.SmtpPort);
        ////        // 是否SSL加密
        ////        if (SysParameters.SmtpSSL.Equals("Y"))
        ////            client.EnableSsl = true;
        ////        // 发送邮件是否需要验证
        ////        if (SysParameters.SmtpEncrypt.Equals("Y"))
        ////            client.UseDefaultCredentials = true;
        ////        client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        ////        // 设置邮箱登录帐号, 密码
        ////        client.Credentials = new System.Net.NetworkCredential(SysParameters.SmtpUserName, SysParameters.SmtpPassword);
        ////        // 创建一个邮件消息
        ////        System.Net.Mail.MailMessage Message = new System.Net.Mail.MailMessage();
        ////        Message.From = new System.Net.Mail.MailAddress(SysParameters.SmtpUserName);
        ////        Message.To.Add(email);
        ////        // 邮件主题
        ////        Message.Subject = subject;
        ////        // 邮件正文
        ////        Message.Body = message;
        ////        // 设置邮件编码
        ////        Message.SubjectEncoding = System.Text.Encoding.UTF8;
        ////        Message.BodyEncoding = System.Text.Encoding.UTF8;
        ////        Message.Priority = System.Net.Mail.MailPriority.High;
        ////        #region attachment
        ////        if (atts.Count > 0)
        ////        {
        ////            foreach (string path in atts)
        ////            {
        ////                System.Net.Mail.Attachment myAttachment = new System.Net.Mail.Attachment(path, System.Net.Mime.MediaTypeNames.Application.Octet);
        ////                if (File.Exists(path))
        ////                {
        ////                    System.Net.Mime.ContentDisposition disposition = myAttachment.ContentDisposition;
        ////                    disposition.CreationDate = System.IO.File.GetCreationTime(path);
        ////                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(path);
        ////                    disposition.ReadDate = System.IO.File.GetLastAccessTime(path);
        ////                    Message.Attachments.Add(myAttachment);
        ////                }
        ////            }
        ////        }
        ////        #endregion
        ////        // 设置邮件为html格式
        ////        Message.IsBodyHtml = true;
        ////        // 发送邮件
        ////        client.Send(Message);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        ////    }
        ////}

        ///// <summary>
        ///// 显示或隐藏指定列
        ///// </summary>
        ///// <param name="d">指定Dgv</param>
        ///// <param name="colNames">给定列名，用逗号隔开</param>
        ///// <param name="visible">显示或隐藏</param>
        //public static void setDgvColumnVisible(DataGridView d, string colNames, bool visible)
        //{
        //    try
        //    {
        //        foreach (DataGridViewColumn c in d.Columns)
        //        {
        //            foreach (string s in colNames.Split(','))
        //            {
        //                if (s.Equals(c.Name))
        //                    c.Visible = visible;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //    }
        //}

        //public static void setDgvColumnReadOnly(DataGridView d, string colNames, bool readOnly)
        //{
        //    try
        //    {
        //        foreach (DataGridViewColumn c in d.Columns)
        //        {
        //            foreach (string s in colNames.Split(','))
        //            {
        //                if (s.Equals(c.Name))
        //                    c.ReadOnly = readOnly;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //    }
        //}

        ///// <summary>
        ///// 导入Excel
        ///// </summary>
        ///// <returns>返回一个DataTable</returns>
        //public static DataTable DataFromExcel()
        //{
        //    try
        //    {
        //        var ofd = new OpenFileDialog()
        //        {
        //            Filter = "Microsoft Office Excel 工作簿(*.xlsx)|*.xlsx",
        //            Multiselect = false
        //        };
        //        if (ofd.ShowDialog() == DialogResult.Cancel)
        //            return null;
        //        DataTable dt = new DataTable("excel");
        //        //var strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + ofd.FileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
        //        var strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ofd.FileName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
        //        using (var oledbConn = new OleDbConnection(strConn))
        //        {
        //            oledbConn.Open();
        //            var sheetName = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new[] { null, null, null, "Table" });
        //            var sheet = new string[sheetName.Rows.Count];
        //            for (int i = 0, j = sheetName.Rows.Count; i < j; i++)
        //            {
        //                sheet[i] = sheetName.Rows[i]["TABLE_NAME"].ToString();
        //            }
        //            // 这里您可以用一个for来查询每一个工作簿，我这里只查询了第一个
        //            var adapter = new OleDbDataAdapter(string.Format("select * from [{0}]", sheet[0]), oledbConn);
        //            adapter.Fill(dt);
        //        }
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //        msg("导入Excel时遇到错误", "e");
        //    }
        //    return null;
        //}

        //#region DataGridView 搜索

        //private static string key;

        //public static string Key
        //{
        //    get { return key; }
        //    set { key = value; }
        //}

        //private static int keyIndex;

        //public static int KeyIndex
        //{
        //    get { return keyIndex; }
        //    set { keyIndex = value; }
        //}

        //private static int keysCount;

        //public static int KeysCount
        //{
        //    get { return keysCount; }
        //    set { keysCount = value; }
        //}

        //private static ArrayList keyCells;

        //public static ArrayList KeyCells
        //{
        //    get { return keyCells; }
        //    set { keyCells = value; }
        //}

        //public static void findKey(DataGridView dgv)
        //{
        //    try
        //    {
        //        if (KeysCount == -1)
        //        {
        //            Key = MyFuncLib.inputBox("查找", "请输入关键词（F3查找下一个）：");
        //            if (Key.Length == 0)
        //                return;
        //            KeyCells = new ArrayList();
        //            foreach (DataGridViewRow row in dgv.Rows)
        //            {
        //                foreach (DataGridViewCell cell in row.Cells)
        //                {
        //                    if (cell != null && cell.Value != null && cell.OwningColumn.Visible == true && cell.Value.ToString().IndexOf(key) > -1)
        //                        KeyCells.Add(cell);
        //                }
        //            }
        //            keysCount = KeyCells.Count;
        //            keyIndex = 0;
        //            MyFuncLib.StatusLabel.Text = "共找到" + keysCount + "条符合条件的记录";
        //        }
        //        if (keysCount - keyIndex > 0)
        //        {
        //            dgv.CurrentCell = (DataGridViewCell)KeyCells[keyIndex];
        //            keyIndex++;
        //        }
        //        if (keysCount == keyIndex)
        //            keyIndex = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //    }
        //}
        //#endregion

        ////public static void loadComboxItems(ComboBox cbox, string type, string selectedValue)
        ////{
        ////    try
        ////    {
        ////        cbox.Items.Clear();
        ////        cbox.DisplayMember = "name";
        ////        cbox.ValueMember = "value";
        ////        string sql = "select itemName,itemValue from core_basicdata where name='" + type + "' order by itemValue2";
        ////        ListItem item;
        ////        DataTable dtTemp = MyFuncLib.DBCommandExecQueryBySql(sql, null);
        ////        foreach (DataRow row in dtTemp.Rows)
        ////        {
        ////            item = new ListItem(MyFuncLib.dtv(row, "itemName", string.Empty), MyFuncLib.dtv(row, "itemValue", string.Empty));
        ////            cbox.Items.Add(item);
        ////        }
        ////        setComboxSelectedItem(cbox, selectedValue);
        ////    }
        ////    catch (Exception ex)
        ////    {
        ////        logToDB("错误日志", "加载下拉框数据源时遇到错误", ex.Message, ex.StackTrace);
        ////    }
        ////}

        //public static ArrayList loadComboxItems(string type)
        //{
        //    ArrayList items = new ArrayList();
        //    try
        //    {
        //        string sql = "select itemName,itemValue from core_basicdata where name='" + type + "' order by itemValue2";
        //        ListItem item;
        //        DataTable dtTemp = MyFuncLib.DBCommandExecQueryBySql(sql, null);
        //        foreach (DataRow row in dtTemp.Rows)
        //        {
        //            item = new ListItem(MyFuncLib.dtv(row, "itemName", string.Empty), MyFuncLib.dtv(row, "itemValue", string.Empty));
        //            items.Add(item);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("错误日志", "加载下拉框数据源时遇到错误", ex.Message, ex.StackTrace);
        //    }
        //    return items;
        //}

        //public static void setComboxSelectedItem(ComboBox cbox, string selectedValue)
        //{
        //    ListItem it;
        //    bool find = false;
        //    for (int i = 0; i < cbox.Items.Count; i++)
        //    {
        //        it = (ListItem)cbox.Items[i];
        //        if (it.Value.Equals(selectedValue))
        //        {
        //            cbox.SelectedItem = it;
        //            find = true;
        //            break;
        //        }
        //    }
        //    if (!find)
        //        cbox.Text = selectedValue;
        //}

        //public static string dtv(DataRow row, string name, string nullValue)
        //{
        //    if (row == null || row[name] == null || string.Empty.Equals(row[name].ToString()))
        //        return nullValue;
        //    else
        //        return row[name].ToString();
        //}

        //#region 个人配置文件
        ///// <summary>
        ///// 创建配置文件初始内容
        ///// </summary>
        ///// <returns>返回xml内容</returns>
        //public static string ProfileXmlInit()
        //{
        //    XmlElement xmlElem;
        //    XmlDocument xmlDoc = new XmlDocument();
        //    XmlDeclaration xmlDecl;
        //    xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "gb2312", null);
        //    xmlDoc.AppendChild(xmlDecl);
        //    xmlElem = xmlDoc.CreateElement("", "ROOT", "");
        //    xmlDoc.AppendChild(xmlElem);
        //    //样式
        //    XmlNode root = xmlDoc.SelectSingleNode("ROOT");
        //    XmlElement xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "ws.url");
        //    XmlElement xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "http://localhost/master.asmx?WSDL";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //外部webservice地址
        //    root = xmlDoc.SelectSingleNode("ROOT");
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "ws.url.external");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "http://localhost/master.asmx?WSDL";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //内部或外部
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "external");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "N";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //是否使用代理上网
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "proxy.enable");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "N";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //代理服务器ip
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "proxy.host");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "192.168.1.1";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //代理服务器端口
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "proxy.port");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "80";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //自动登录
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "autologin");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "false";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //账号
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "username");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //密码
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "password");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    //页数
        //    xe1 = xmlDoc.CreateElement("Param");
        //    xe1.SetAttribute("name", "pagesize");
        //    xesub1 = xmlDoc.CreateElement("value");
        //    xesub1.InnerText = "100";
        //    xe1.AppendChild(xesub1);
        //    root.AppendChild(xe1);
        //    return FormatXml(xmlDoc);
        //}

        ///// <summary>
        ///// 读取参数值
        ///// </summary>
        ///// <param name="param">参数名</param>
        ///// <returns>返回参数名对应的值</returns>
        //public static string ProfileXmlRead(string param)
        //{
        //    try
        //    {
        //        // 读取时 先判断profile是否存在，且有内容，如果没有就创建并初始化内容
        //        // 将profile.xml保存在profileXmlContent中
        //        string f = @appPath + "profile.xml";
        //        if (string.IsNullOrEmpty(profileXmlContent))
        //        {
        //            if (!File.Exists(f))
        //                System.IO.File.WriteAllText(f, ProfileXmlInit(), Encoding.UTF8);
        //            string xml = System.IO.File.ReadAllText(f);
        //            profileXmlContent = xml;
        //            if (string.IsNullOrEmpty(xml))
        //            {
        //                xml = ProfileXmlInit();
        //                profileXmlContent = xml;
        //                System.IO.File.WriteAllText(f, xml, Encoding.UTF8);
        //            }
        //        }
        //        string value = string.Empty;
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(profileXmlContent);
        //        XmlNode root = xmlDoc.SelectSingleNode("ROOT");
        //        XmlNodeList xnl = root.ChildNodes;
        //        XmlElement xe;
        //        foreach (XmlNode xn in xnl)
        //        {
        //            xe = (XmlElement)xn;
        //            if (xe.GetAttribute("name").Equals(param))
        //            {
        //                value = xe.GetElementsByTagName("value")[0].InnerText;
        //                break;
        //            }
        //        }
        //        return value;
        //    }
        //    catch (Exception ex)
        //    {
        //        MyFuncLib.logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //    }
        //    return string.Empty;
        //}

        ///// <summary>
        ///// 修改配置文件
        ///// </summary>
        ///// <param name="param">参数名</param>
        ///// <param name="value">值</param>
        ///// <returns>0 表示正常 -1表示异常</returns>
        //public static int ProfileXmlUpdate(string param, string value)
        //{
        //    try
        //    {
        //        // 读取时 先判断profile是否存在，且有内容，如果没有就创建并初始化内容
        //        string f = @appPath + "profile.xml";
        //        if (string.IsNullOrEmpty(profileXmlContent))
        //        {
        //            if (!File.Exists(f))
        //                System.IO.File.WriteAllText(f, ProfileXmlInit(), Encoding.UTF8);
        //            string xml = System.IO.File.ReadAllText(f);
        //            profileXmlContent = xml;
        //            if (string.IsNullOrEmpty(xml))
        //            {
        //                xml = ProfileXmlInit();
        //                System.IO.File.WriteAllText(f, xml, Encoding.UTF8);
        //                profileXmlContent = xml;
        //            }
        //        }
        //        // 设置值
        //        bool isExist = false;
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.LoadXml(profileXmlContent);
        //        XmlNode root = xmlDoc.SelectSingleNode("ROOT");
        //        XmlNodeList xnl = root.ChildNodes;
        //        XmlElement xe;
        //        foreach (XmlNode xn in xnl)
        //        {
        //            xe = (XmlElement)xn;
        //            if (xe.GetAttribute("name").Equals(param))
        //            {
        //                xe.FirstChild.InnerText = value;
        //                isExist = true;
        //                break;
        //            }
        //        }
        //        #region 如果要查找的节点不存在，就创建
        //        if (!isExist)
        //        {
        //            XmlElement xe1 = xmlDoc.CreateElement("Param");
        //            xe1.SetAttribute("name", param);
        //            XmlElement xesub1 = xmlDoc.CreateElement("value");
        //            xesub1.InnerText = value;
        //            xe1.AppendChild(xesub1);
        //            root.AppendChild(xe1);
        //        }
        //        System.IO.File.WriteAllText(f, FormatXml(xmlDoc), Encoding.UTF8);
        //        profileXmlContent = xmlDoc.OuterXml;
        //        #endregion
        //        return 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        MyFuncLib.logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //        return -1;
        //    }
        //}

        //public static string FormatXml(XmlDocument xmldoc)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    StringWriter sw = new StringWriter(sb);
        //    XmlTextWriter xtw = null;
        //    try
        //    {
        //        xtw = new XmlTextWriter(sw);

        //        xtw.Formatting = Formatting.Indented;
        //        xtw.Indentation = 1;
        //        xtw.IndentChar = '\t';
        //        xmldoc.WriteTo(xtw);
        //    }
        //    finally
        //    {
        //        if (xtw != null)
        //            xtw.Close();
        //    }
        //    return sb.ToString();
        //}

        //#endregion

        //#region DBComdmandExec

        ///// <summary>
        ///// 当与服务器失去连接时，主动尝试连再次登录
        ///// </summary>
        ///// <returns></returns>
        //public static void TryLogin()
        //{
        //    try
        //    {
        //        MyFuncLib.CookieContainer = new CookieContainer();
        //        MyFuncLib.WS.CookieContainer = MyFuncLib.CookieContainer;
        //        if (!MyFuncLib.WS.Login(userName, password))
        //            MyFuncLib.msg("连接失败，请重试", "e");
        //    }
        //    catch (Exception ex)
        //    {
        //        MyFuncLib.logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //    }
        //}

        ///// <summary>
        ///// 执行Select语句
        ///// </summary>
        ///// <param name="sql">未加密的SQL语句</param>
        ///// <param name="paras">ArrayList,ListItem格式</param>
        ///// <returns>返回DataTable</returns>
        //public static DataTable DBCommandExecQueryBySql(string sql, ArrayList paras)
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        if (paras != null)
        //        {
        //            DataTable sqlParams = new DataTable("sqlParametersDataTable");
        //            sqlParams.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
        //            sqlParams.Columns.Add(new DataColumn("value", System.Type.GetType("System.String")));
        //            DataRow dRow;
        //            foreach (ListItem item in paras)
        //            {
        //                dRow = sqlParams.NewRow();
        //                dRow["name"] = item.Name;
        //                dRow["value"] = item.Value;
        //                sqlParams.Rows.Add(dRow);
        //            }
        //            dt = MyFuncLib.WS.ExecQueryBySql(DES.Encrypt(sql, MyFuncLib.PasswordKey), sqlParams);
        //        }
        //        else
        //            dt = MyFuncLib.WS.ExecQueryBySql(DES.Encrypt(sql, MyFuncLib.PasswordKey), null);
        //    }
        //    catch (Exception ex)
        //    {
        //        MyFuncLib.logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //    }
        //    return dt;
        //}

        ///// <summary>
        ///// 执行Select语句，返回第一行记录第一列的值
        ///// </summary>
        ///// <param name="sql">未加密的SQL语句</param>
        ///// <param name="paras">ArrayList,ListItem格式</param>
        ///// <returns>返回string</returns>
        //public static string DBCommandExecScalarBySql(string sql, ArrayList paras)
        //{
        //    try
        //    {
        //        DataTable dtTemp;
        //        if (paras != null)
        //        {
        //            DataTable sqlParams = new DataTable("sqlParametersDataTable");
        //            sqlParams.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
        //            sqlParams.Columns.Add(new DataColumn("value", System.Type.GetType("System.String")));
        //            DataRow dRow;
        //            foreach (ListItem item in paras)
        //            {
        //                dRow = sqlParams.NewRow();
        //                dRow["name"] = item.Name;
        //                dRow["value"] = item.Value;
        //                sqlParams.Rows.Add(dRow);
        //            }
        //            dtTemp = MyFuncLib.WS.ExecQueryBySql(DES.Encrypt(sql, MyFuncLib.PasswordKey), sqlParams);
        //        }
        //        else
        //            dtTemp = MyFuncLib.WS.ExecQueryBySql(DES.Encrypt(sql, MyFuncLib.PasswordKey), null);
        //        if (dtTemp != null && dtTemp.Rows.Count > 0)
        //            return dtTemp.Rows[0][0].ToString();
        //        return string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        MyFuncLib.logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //        return "-1";
        //    }
        //}

        ///// <summary>
        ///// 执行update, delete, insert语句
        ///// </summary>
        ///// <param name="sql">未加密的SQL语句</param>
        ///// <param name="paras">ArrayList,ListItem格式</param>
        ///// <returns>返回影响记录的条数，-1表示失败</returns>
        //public static int DBCommandExecNoneQueryBySql(string sql, ArrayList paras)
        //{
        //    int result = 0;
        //    try
        //    {
        //        if (paras != null)
        //        {
        //            DataTable sqlParams = new DataTable("sqlParametersDataTable");
        //            sqlParams.Columns.Add(new DataColumn("name", System.Type.GetType("System.String")));
        //            sqlParams.Columns.Add(new DataColumn("value", System.Type.GetType("System.String")));
        //            DataRow dRow;
        //            foreach (ListItem item in paras)
        //            {
        //                dRow = sqlParams.NewRow();
        //                dRow["name"] = item.Name;
        //                dRow["value"] = item.Value;
        //                sqlParams.Rows.Add(dRow);
        //            }
        //            result = MyFuncLib.WS.ExecNoneQueryBySql(DES.Encrypt(sql, MyFuncLib.PasswordKey), sqlParams);
        //        }
        //        else
        //            result = MyFuncLib.WS.ExecNoneQueryBySql(DES.Encrypt(sql, MyFuncLib.PasswordKey), null);
        //    }
        //    catch (Exception ex)
        //    {
        //        MyFuncLib.logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //    }
        //    return result;
        //}
        //#endregion

        ///// <summary>
        ///// 取得代理服务器
        ///// </summary>
        ///// <returns></returns>
        //public static WebProxy GetWebProxy()
        //{
        //    try
        //    {
        //        if (SysParameters.ProxyEnable.Equals("Y"))
        //        {
        //            WebProxy proxy = new WebProxy(SysParameters.ProxyHost, int.Parse(SysParameters.ProxyPort));
        //            return proxy;
        //        }
        //        else
        //            return null;
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //    }
        //    return null;
        //}

        //#region 测试WebService连接是否可用
        ///// <summary>
        ///// 检查指定Url的WebService是否可用
        ///// </summary>
        ///// <param name="webServiceUrl"></param>
        ///// <returns></returns>
        //public static bool isWebServiceAvailable(string webServiceUrl)
        //{
        //    try
        //    {
        //        //ServicePointManager.ServerCertificateValidationCallback = ValidateServerCertificate;

        //        WebRequest webRequest = WebRequest.Create(webServiceUrl);
        //        HttpWebRequest httpRequest = webRequest as HttpWebRequest;
        //        httpRequest.Proxy = GetWebProxy();
        //        httpRequest.Timeout = 3000;
        //        //X509Certificate cert = X509Certificate.CreateFromCertFile("server.cer");
        //        //httpRequest.ClientCertificates.Add(cert);
        //        //httpRequest.PreAuthenticate = false;
        //        if (httpRequest == null)
        //            return false;
        //        try
        //        {
        //            HttpWebResponse resp = (HttpWebResponse)httpRequest.GetResponse();
        //            return true;
        //        }
        //        catch (Exception ex1)
        //        {
        //            log(ex1.Message + "\r\n" + ex1.StackTrace);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return false;
        //    }
        //}

        //private static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        //{
        //    return true;
        //}

        //#endregion

        ///// <summary>
        ///// 显示DataGridView汇总
        ///// </summary>
        ///// <param name="d"></param>
        //public static void dgvSumAvgInfo(DataGridView d)
        //{
        //    try
        //    {
        //        int count = d.SelectedCells.Count;
        //        if (count > 0)
        //        {
        //            decimal total = 0;
        //            foreach (DataGridViewCell cell in d.SelectedCells)
        //            {
        //                if (cell.Value != null && !string.IsNullOrEmpty(cell.Value.ToString()))
        //                {
        //                    if (cell.OwningColumn.ValueType.ToString().Equals("System.Decimal"))
        //                        total = total + (decimal)cell.Value;
        //                    else if (cell.OwningColumn.ValueType.ToString().StartsWith("System.Int"))
        //                        total = total + (int)cell.Value;
        //                }
        //            }
        //            MyFuncLib.StatusLabel.Text = "合计：" + total + ",计数：" + count + ",平均：" + (total / count).ToString("f2");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logToDB("error", "系统错误", ex.Message, ex.StackTrace);
        //    }
        //}

        /// <summary>
        /// 使用MD5对字符串进行加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string MD5Encrypts(string str)
        {
            string result = string.Empty;
            //先将要加密的字符串转换成byte数组
            byte[] inputData = System.Text.Encoding.Default.GetBytes(str);
            //在通过MD5类加密，并得到加密后的byte[]类型
            byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash(inputData);

            StringBuilder strBuild = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                //将每个byte数据转换成16进制。"X":表示大写16进制；"X2"：表示大写16进制保留2位；"x"：表示小写16进制
                strBuild.Append(data[i].ToString("X2"));
            }
            result = strBuild.ToString();
            return result;
        }

        public static void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (!AuthList.Contains("copydata"))
            {
                if (e.Control && e.KeyCode == Keys.C)
                    e.Handled = true;
            }
            else
                StatusLabel.Text = "你没有权限复制表格数据，请联系管理员。";
        }

        public static int checkSaveData(DataTable dt)
        {
            int waiteSaveCount = 0;
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                        waiteSaveCount++;
                    else if (row.RowState == DataRowState.Modified)
                        waiteSaveCount++;
                }
            }
            return waiteSaveCount;
        }

        public static void DgvAccpetChanges(DataGridView dgv)
        {
            if (dgv.CurrentCell == null)
                return;
            DataGridViewCell cell = dgv.CurrentCell;
            dgv.CurrentCell = null;
            dgv.CurrentCell = cell;
        }
        ///// <summary>
        ///// 根据User Id取得用户名称
        ///// </summary>
        ///// <param name="userId">用户Id</param>
        ///// <returns></returns>
        //public static string getUserDisplayNameById(int userId)
        //{
        //    try
        //    {
        //        string sql = "select isnull(min(displayName),'') from core_user where ID_ = " + userId;
        //        return MyFuncLib.DBCommandExecScalarBySql(sql, null);
        //    }
        //    catch (Exception ex)
        //    {
        //        log(ex.Message + "\r\n" + ex.StackTrace);
        //        return "-1";
        //    }
        //}

        /// <summary>
        /// 返回中国农历日期
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string GetChineseLuniDate(DateTime time)
        {
            string date = string.Empty;
            System.Globalization.ChineseLunisolarCalendar china = new System.Globalization.ChineseLunisolarCalendar();
            int y = china.GetYear(time);
            int m = china.GetMonth(time);
            int d = china.GetDayOfMonth(time);
            date = string.Format("{0}-{1}-{2}", y, m, d);
            return date;
        }

    }
}