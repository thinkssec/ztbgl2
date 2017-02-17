using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Project;
using Enterprise.Model.App.Project;

namespace Enterprise.Service.App
{

    /// <summary>
    /// 文件名:  AppDataService.cs
    /// 功能描述: 前端数据调用公共服务类
    /// 创建人：qw
    /// 创建时间 ：2013-11-8
    /// </summary>
    public class AppDataService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IProjectInfoData dal = new ProjectInfoData();

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="tname">表名</param>
        /// <param name="tfield">字段名字串，以‘|’分隔</param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tname, string tfield)
        {
            return dal.GetDataTable(tname, tfield);
        }

        ///// <summary>
        ///// 返回原生SQL的查询数据集
        ///// </summary>
        ///// <param name="sql"></param>
        ///// <returns></returns>
        public static DataTable GetDataTableBySQL(string sql)
        {
            return dal.GetDataTableBySQL(sql);
        }
    }
}
