using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Reflection;
namespace ProductInfoReader
{
    public class DBHelper
    {
        #region 属性

        private string constr;
        private string dbType;

        #endregion

        public DBHelper(string dbType, string dataSource,string userID,string password,string database, bool integratedSecurity)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();

            scsb.DataSource = dataSource;
            scsb.IntegratedSecurity = integratedSecurity;
 
            scsb.UserID = userID;
            scsb.Password = password;
            scsb.InitialCatalog =database;
            constr = scsb.ConnectionString;
            this.dbType = string.IsNullOrEmpty(dbType) ? "SQLServer" : dbType;

        }


        #region 私有方法
        /// <summary>
        /// 根据数据库类型，获取对应数据库的连接
        /// </summary>
        /// <returns>连接接口</returns>
        private IDbConnection GetConnection()
        {
            IDbConnection con = null;
            if (dbType == DBType.SQLServer.ToString())
            {
                con = new SqlConnection(constr);
            }
            else if (dbType == DBType.Oracle.ToString())
            {
                con = new OracleConnection(constr);
            }
            else if (dbType == DBType.OleDb.ToString())
            {
                con = new OleDbConnection(constr);
            }
            else if (dbType == DBType.ODBC.ToString())
            {
                con = new OdbcConnection(constr);
            }
            else
            {
                con = new SqlConnection(constr);
            }
            return con;
        }
        /// <summary>
        /// 根据数据库类型，获取对应Command对象
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdType">SQL命令类型</param>
        /// <param name="con">连接对象</param>
        /// <param name="param">SQL命令参数数组</param>
        /// <returns>Command接口对象</returns>
        private IDbCommand GetCommand(string commandText, CommandType commandType, IDbConnection con, params IDbDataParameter[] paramList)
        {
            IDbCommand cmd = null;
            if (dbType == DBType.SQLServer.ToString())
            {
                cmd = new SqlCommand(commandText, con as SqlConnection);
            }
            else if (dbType == DBType.Oracle.ToString())
            {
                cmd = new OracleCommand(commandText, con as OracleConnection);
            }
            else if (dbType == DBType.OleDb.ToString())
            {
                cmd = new OleDbCommand(commandText, con as OleDbConnection);
            }
            else if (dbType == DBType.ODBC.ToString())
            {
                cmd = new OdbcCommand(commandText, con as OdbcConnection);
            }
            else
            {
                cmd = new SqlCommand(commandText, con as SqlConnection);
            }
            cmd.CommandType = commandType;
            if (paramList != null)
            {
                foreach (SqlParameter param in paramList)
                {
                    cmd.Parameters.Add(param);
                }
            }
            return cmd;
        }

        #endregion
       
        /// <summary>
        /// 执行返回一行一列的数据库操作
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdType">SQL命令类型</param>
        /// <param name="param">SQL命令参数数组</param>
        /// <returns>第一行第一列记录</returns>
        public object ExecuteScalar(string commandText, CommandType commandType, params IDbDataParameter[] param)
        {
            object result = 0;
            try
            {
                IDbConnection con = GetConnection();
                IDbCommand cmd = GetCommand(commandText, commandType, con, param);
                using (con)
                {
                    using (cmd)
                    {
                        con.Open();
                        result= cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// 执行非查询的数据库操作
        /// </summary>
        /// <param name="cmdText">SQL语句或存储过程名</param>
        /// <param name="cmdType">SQL命令类型</param>
        /// <param name="param">SQL命令参数数组</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNonQuery(string commandText, CommandType commandType, params IDbDataParameter[] param)
        {
            int result = 0;
            try
            {
                IDbConnection con = GetConnection();
                IDbCommand cmd = GetCommand(commandText, commandType, con, param);
                using (con)
                {
                    using (cmd)
                    {
                        con.Open();
                        IDbTransaction tr = con.BeginTransaction();
                        cmd.Transaction = tr;
                        try
                        {
                            result = Convert.ToInt32(cmd.ExecuteNonQuery());
                            tr.Commit();
                        }
                        catch (Exception ex)
                        {
                            tr.Rollback();
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        #region 数据库类型枚举
        /// <summary>
        /// 该枚举类型用于创建合适的数据库访问对象
        /// </summary>
        public enum DBType
        {
            SQLServer,
            OleDb,
            ODBC,
            Oracle
        }
        #endregion
    }
}