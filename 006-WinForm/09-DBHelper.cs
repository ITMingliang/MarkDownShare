using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class DBHelper
    {
        //SQL连接字符串-SQL身份认证方式登录
        public static string connStr = "server=.;database=DBTEST;uid=sa;pwd=123456;";

        //SQL连接字符串-Windows身份认证方式登录
        //public static string connStr = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=.";

        //读取配置文件appSettings节点读取字符串(需要添加引用System.Configuration)
        //public static string connStr = ConfigurationManager.AppSettings["DefaultConn"].ToString();
        //对应的配置文件如下：
        //<appSettings>
        //  <add key="DefaultConn" value="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=."/>
        //</appSettings>

        //读取配置文件ConnectionStrings节点读取字符串(需要添加引用System.Configuration)
        //public static string connStr = ConfigurationManager.ConnectionStrings["DefaultConn"].ConnectionString;
        //对应配置文件如下：
        //<connectionStrings>
        //    <add name="DefaultConn" connectionString="Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DBTEST;Data Source=."/>
        //</connectionStrings>

        public static SqlConnection conn = null;
        public static SqlDataAdapter adp = null;

        #region 连接数据库
        /// <summary>
        /// 连接数据库
        /// </summary>
        public static void OpenConn()
        {
            if (conn == null)
            {
                conn = new SqlConnection(connStr);
                conn.Open();
            }
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == System.Data.ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }
        #endregion

        #region 执行SQL语句前准备
        /// <summary>
        /// 准备执行一个SQL语句
        /// </summary>
        /// <param name="sql">需要执行的SQL语句</param>
        public static void PrepareSql(string sql)
        {
            OpenConn(); //打开数据库连接
            adp = new SqlDataAdapter(sql, conn);
        }
        #endregion

        #region 设置和获取sql语句的参数
        /// <summary>
        /// 设置传入参数
        /// </summary>
        /// <param name="parameterName">参数名称</param>
        /// <param name="parameterValue">参数值</param>
        public static void SetParameter(string parameterName, object parameterValue)
        {
            parameterName = "@" + parameterName.Trim();
            if (parameterValue == null)
                parameterValue = DBNull.Value;
            adp.SelectCommand.Parameters.Add(new SqlParameter(parameterName, parameterValue));
        }
        #endregion

        #region 执行SQL语句
        /// <summary>
        /// 执行非查询SQL语句
        /// </summary>
        /// <returns>受影响行数</returns>
        public static int ExecNonQuery()
        {
            int result = adp.SelectCommand.ExecuteNonQuery();
            conn.Close();
            return result;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <returns>DataTable类型查询结果</returns>
        public static DataTable ExecQuery()
        {
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            return dt;
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <returns>SqlDataReader类型查询结果,SqlDataReader需要手动关闭</returns>
        public static SqlDataReader ExecDataReader()
        {
            return adp.SelectCommand.ExecuteReader(CommandBehavior.CloseConnection);
        }
        /// <summary>
        /// 执行查询SQL语句
        /// </summary>
        /// <returns>查询结果第一行第一列</returns>
        public static object ExecScalar()
        {
            object obj = adp.SelectCommand.ExecuteScalar();
            conn.Close();
            return obj;
        }
        #endregion
    }
}
