
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace application.MX
{
        public static class DapperSQLServer<T> where T : new()
        {
        private static readonly object Locker1 = new object();
        private static IDbConnection _conn;
            public static IDbConnection Conn
        {           
            get
            {
                lock (Locker1)
                {
                    _conn = new SqlConnection(DapperExtensions.connString);

                    if (_conn.State == ConnectionState.Closed)
                    {
                        _conn.Open();
                    }
                    else if (_conn.State == ConnectionState.Broken)
                    {
                        Conn.Close();
                        Conn.Open();
                    }
                    return _conn;
                }
   
            }
        }
        /// <summary>
        /// 按sql语句查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> QueryData( string sql)
        {
            using (Conn)
            {
                var data = Conn.Query<T>(sql).ToList();
                Conn.Close();
                return data != null && data.Count > 0 ? data : null;

            }
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public static List<T> QueryAll()
        {
            T t = new T();
            Type tp = t.GetType();
            string tbName = tp.Name.Substring(1, tp.Name.Length - 1);
            string sql = string.Format("select * from {0}", tbName);
            using (Conn)
            {
                var data = Conn.Query<T>(sql).ToList();
                Conn.Close();
                if (data != null && data.Count > 0)
                {
                    return data;
                }
                return null;
            }
        }
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int ExecuteSQL(string sql)
        {
            try
            {
                using (Conn)
                {
                    var list= Conn.Execute(sql);
                    Conn.Close();
                    return list;
            
                }
            }
            catch (Exception )
            {
                return 0;
            }
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="t">添加数据对象</param>
        /// <param name="key">忽略指定列</param>
        /// <returns></returns>
        public static int AddData(T t, params object[] keys)
        {
            Type tp = t.GetType();
            string sql = string.Empty;
            string tbName = tp.Name.Substring(1, tp.Name.Length - 1);
            PropertyInfo[] properties = tp.GetProperties();

            StringBuilder sbKeys = new StringBuilder();
            StringBuilder sbVals = new StringBuilder();
            foreach (var item in properties)
            {
                if (keys.Any((p) => p.Equals(item.Name)))
                {
                    continue;
                }
                object obj = item.GetValue(t);
                if (obj == null)
                {
                    continue;
                }
                string val = string.Empty;
                string dataType = item.PropertyType.ToString().ToLower();
                if (dataType.Contains("int"))
                {
                    sbVals.Append(string.Format("{0},", obj.ToString()));
                }
                else if (dataType.Contains("date"))
                {
                    sbVals.Append(string.Format("'{0}',", Convert.ToDateTime(obj).ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                {
                    sbVals.Append(string.Format("'{0}',", obj.ToString()));
                }

                sbKeys.Append(item.Name + ',');
                sql = string.Format("Insert {0} ( {1}) Values ({2}); select SCOPE_IDENTITY()", tbName, sbKeys.ToString().Substring(0, sbKeys.ToString().Length - 1), sbVals.ToString().Substring(0, sbVals.ToString().Length - 1));
            }
            using (Conn)
            {
                var list= Conn.Query<int>(sql).ToList()[0];
                Conn.Close();
                return list;
            }
        }
        /// <summary>
        /// 删除指定行数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static int DeleteRow(T t, params object[] keys)
        {
            Type tp = t.GetType();
            if (tp.Name.EndsWith("Ex"))
            {
                tp = tp.BaseType;
            }
            string sql = string.Empty;
            string tbName = tp.Name.Substring(1, tp.Name.Length - 1);
            PropertyInfo[] properties = tp.GetProperties();
            if (keys.Length == 0)
            {
                StringBuilder sbSql = new StringBuilder();
                sbSql.Append(string.Format("delete {0} where ", tbName));
                sql = GetWhereStr(t, properties, sbSql);
            }
            else
            {
                PropertyInfo[] ptInfos = properties.Where((p) => keys.Any((o) => o.ToString().ToLower().Equals(p.Name.ToLower()))).ToArray();
                if (ptInfos != null)
                {
                    StringBuilder sbSql = new StringBuilder();
                    sql = string.Format("delete {0} where {1}", tbName, GetWhereStr(t, properties, sbSql, keys));
                }
            }
            using (Conn)
            {
                var list= Conn.Execute(sql);
                Conn.Close();
                return list;
            }
        }
        private static string GetWhereStr(T t, PropertyInfo[] properties, StringBuilder sbSql, params object[] keys)
        {
            foreach (var item in properties)
            {
                object obj = item.GetValue(t);
                if (obj == null)
                {
                    continue;
                }
                if (!keys.Any((p) => p.ToString().ToLower().Equals(item.Name.ToLower())))
                {
                    continue;
                }
                string typeStr = item.PropertyType.ToString().ToLower();
                if (typeStr.Contains("int") || typeStr.Contains("long"))
                {
                    sbSql.Append(string.Format(" {0} = {1} and ", item.Name, obj.ToString()));
                }
                else if (typeStr.Contains("datetime"))
                {
                    DateTime dt = Convert.ToDateTime(obj);
                    if (dt.Year == 1)
                    {
                        continue;
                    }
                    sbSql.Append(string.Format("{0}='{1}'", item.Name, dt.ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else
                {
                    sbSql.Append(string.Format(" {0} = '{1}' and ", item.Name, obj.ToString()));
                }
            }
            return sbSql.ToString().Substring(0, sbSql.ToString().Length - 5);
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="t"></param>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static int UpdateData(T t, params object[] keys)
        {
            Type tp = t.GetType();
            string sql = string.Empty;
            string tbName = tp.Name.Substring(1, tp.Name.Length - 1);
            PropertyInfo[] properties = tp.GetProperties();
            if (keys.Length == 0)
            {
                return -1;
            }
            else
            {
                StringBuilder sbSetData = new StringBuilder();
                StringBuilder sbWhereData = new StringBuilder();
                foreach (var item in properties)
                {
                    object obj = item.GetValue(t);
                    if (obj == null)
                    {
                        continue;
                    }
                    string val = string.Empty;
                    string dataType = item.PropertyType.ToString().ToLower();
                    if (dataType.Contains("int"))
                    {
                        val = "=" + obj.ToString();
                    }
                    else if (dataType.Contains("datetime"))
                    {
                        DateTime dt = Convert.ToDateTime(obj);
                        if (dt.Year == 1)
                        {
                            continue;
                        }
                        val = string.Format("='{0}'", dt.ToString("yyyy-MM-dd HH:mm:ss"));
                    }
                    else
                    {
                        val = string.Format("='{0}'", obj.ToString());
                    }


                    if (!keys.Any((p) => p.ToString().ToLower().Equals(item.Name.ToLower())))
                    {
                        sbSetData.Append(item.Name + val + ',');
                    }
                    else
                    {
                        sbWhereData.Append(item.Name + val + " and ");
                    }
                }
                sql = string.Format("update {0} set {1} where {2}", tbName, sbSetData.ToString().Substring(0, sbSetData.ToString().Length - 1), sbWhereData.ToString().Substring(0, sbWhereData.ToString().Length - 5));
            }
            using (Conn)
            {
                var list= Conn.Execute(sql);
                Conn.Close();
                return list;
            }
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <param name="key">排序列名</param>
        /// <param name="pageIndex">当前查询页</param>
        /// <param name="pageSize">页行数</param>
        /// <param name="sort">排序方式（asc,desc）</param>
        /// <param name="whStr">where条件（and id = 1）</param>
        /// <returns></returns>
        public static List<T> QueryPageSource(string tableName, string key, int pageIndex, int pageSize, out int pageCount, string sort = "", string whStr = "")
        {
            int pageEnd = pageIndex * pageSize;
            pageIndex = (pageIndex - 1) * pageSize;
            string sql = string.Format("select COUNT(*) as pageCount from {1} where 1=1 {5}; select * from (select ROW_NUMBER() over(order by {0} {4}) as rowid, * from {1} where 1=1 {5}) t where t.rowid > {2} and t.rowid <= {3} ; ", key, tableName, pageIndex, pageEnd, sort, whStr);
            var result = Conn.QueryMultiple(sql);
            pageCount = 0;
            //遍历结果集  
            while (!result.IsConsumed)
            {
                if (pageCount == 0)
                {
                    var data = result.Read();
                    if (data != null && data.Count() > 0)
                    {
                        pageCount = data.ToList()[0].pageCount;
                    }
                }
                else
                {
                    return result.Read<T>().ToList();
                }
            }
            return new List<T>();
        }
    }
}
