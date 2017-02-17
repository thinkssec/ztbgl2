using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysCacheService.cs
    /// 功能描述: 业务逻辑层-缓存表数据处理
    /// 创建人：qw
    /// 创建日期: 2013.1.21
    /// </summary>
    public class SysCacheService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysCacheData dal = new SysCacheData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysCacheModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysCacheModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取当前数据库用户的所有触发器名称
        /// </summary>
        /// <param name="owner">所有者</param>
        /// <returns></returns>
        public IList<string> GetUserTriggers()
        {
            return dal.GetUserTriggers();
        }

        /// <summary>
        /// 执行基于SQL的原生操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSQL(string sql)
        {
           return dal.ExecuteSQL(sql);
        }


        #region 静态方法

        /// <summary>
        /// 返回所有缓存信息集合
        /// </summary>
        /// <returns></returns>
        public static IList<SysCacheModel> GetAllCacheList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 为指定的数据表建立触发器
        /// </summary>
        /// <param name="tableName">表名称</param>
        /// <param name="userName">用户名称</param>
        public static void CreateTriggerToTable(string tableName, string userName)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("create or replace trigger TRI_{TABNAME}_CHANGE before Insert Or Delete Or Update on {TABNAME}\n");
            sb.Append("declare\n n_count number;\n");
            sb.Append("begin\n");
            sb.Append("select count(changeid) into n_count from BASIS_SYS_TABCHANGE where username='{UNAME}' and tablename='{TABNAME}';\n");
            sb.Append("If n_count > 0 then\n");
            sb.Append("update BASIS_SYS_TABCHANGE set changeid=SEQ_BASIS_SYS_TABCHANGE.nextval,changetime=SYSDATE where username='{UNAME}' and tablename='{TABNAME}';\n");
            sb.Append("Else\n");
            sb.Append("insert into BASIS_SYS_TABCHANGE(username,tablename,changeid,changetime) values('{UNAME}','{TABNAME}',SEQ_BASIS_SYS_TABCHANGE.nextval,SYSDATE);\n");
            sb.Append("End if;\n");
            sb.Append("end TRI_{TABNAME}_CHANGE;");
            string sql = sb.ToString();
            sql = sql.Replace("{TABNAME}", tableName).Replace("{UNAME}", userName);
            Debuger.GetInstance().log(sql);
            dal.ExecuteSQL(sql);
        }

        #endregion
    }

}
