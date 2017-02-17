using System;
using System.Data;
using System.Data.OracleClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.Infrastructure;
using Microsoft.Practices.EnterpriseLibrary.Data.Oracle;
namespace Enterprise.Component.DataFactory
{
    /// <summary>
    /// 数据操作类
    /// </summary>
   public class DbExecute
    {

       /// <summary>
       ///  返回dataset
       /// </summary>
       /// <param name="cmd"></param>
       /// <returns></returns>
       public static DataSet GetDataSet(string cmd)
       {
           DataSet ds = DbFactory.HjzxDatabase.ExecuteDataSet(CommandType.Text, cmd);
           return ds;
       }

       /// <summary>
       ///  数据库操作 返回数据集
       /// </summary>
       /// <param name="cmd"></param>
       /// <returns></returns>
       public static IDataReader DataReader(string cmd)
       {
           IDataReader dr =DbFactory.HjzxDatabase.ExecuteReader(CommandType.Text, cmd);
           return dr;
       }

       /// <summary>
       /// 返回结果集中第一行第一列
       /// </summary>
       /// <param name="cmd"></param>
       /// <returns></returns>
       public static object ExecuteScalar(string cmd)
       {

           object obj= DbFactory.HjzxDatabase.ExecuteScalar(CommandType.Text, cmd);
           if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
           {
               return null;
           }
           else
               return obj;
       }       

       /// <summary>
       /// 是否存在:select count(1) from xxxx
       /// </summary>
       /// <param name="cmd"></param>
       /// <returns></returns>
       public static bool Exist(string cmd)
       {
           object obj = ExecuteScalar(cmd);
           int cmdresult;
           if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
           {
               cmdresult = 0;
           }
           else
           {
               cmdresult = int.Parse(obj.ToString());
           }
           if (cmdresult == 0)
           {
               return false;
           }
           else
           {
               return true;
           }
 
       }

       /// <summary>
        /// 数据操作 执行操作
       /// </summary>
       /// <param name="cmd"></param>
       public static void Execute(string cmd)
       {
           try
           {
               int result =DbFactory.HjzxDatabase.ExecuteNonQuery(CommandType.Text, cmd);
           }
           catch (Exception ex)
           {
               LogHelper.WriteLog(ex.Message);
           }
       }

       /// <summary>
        /// 数据操作 执行操作
       /// </summary>
       /// <param name="cmd"></param>
       public static void ExecuteCommand(string cmd,string item1,object item1Value,string item2,object item2Value)
       {
           try
           {
               OracleDatabase db = (OracleDatabase)DbFactory.HjzxDatabase;
               OracleCommand dbCommand = (OracleCommand)DbFactory.HjzxDatabase.GetSqlStringCommand(cmd);
               ////为SQL中的变量赋值
               db.AddParameter(dbCommand, item1, OracleType.Clob, item1Value.ToString().Length, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, item1Value);  /*内容*/
               db.AddParameter(dbCommand, item2, OracleType.Clob, item2Value.ToString().Length, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Default, item2Value);  /*内容*/
               ////执行操作
               int result =db.ExecuteNonQuery(dbCommand);
           }
           catch (Exception ex)
           {
               LogHelper.WriteLog(ex.Message);
           }
       }

       /// 为指定查询对象增加一个clob类型参数并赋值
       /// </summary>
       /// <param name="command">查询对象</param>
       /// <param name="paranme">参数名</param>
       /// <param name="data">参数值</param>
       public static void AddInClobParameter(IDbCommand command, string paranme, string data)
       {
           OracleParameter p = new OracleParameter(paranme, OracleType.Clob);
           p.Direction = ParameterDirection.Input;
           p.Value = data;
           command.Parameters.Add(p);
       }

       /// <summary>
       /// 数据操作 执行操作
       /// </summary>
       /// <param name="cmd"></param>
       public static int ExecuteSql(string cmd)
       {
           try
           {
               int result = DbFactory.HjzxDatabase.ExecuteNonQuery(CommandType.Text, cmd);
               return result;
           }
           catch (Exception ex)
           {
               LogHelper.WriteLog(ex.Message);
               return 0;
           }
       }
    }
}
