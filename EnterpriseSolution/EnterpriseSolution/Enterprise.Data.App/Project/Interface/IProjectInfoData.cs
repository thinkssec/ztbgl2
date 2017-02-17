using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectInfoData.cs
    /// 功能描述: 数据层-立项数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/6/1 14:34:34
    /// </summary>
    public interface IProjectInfoData : IDataApp<ProjectInfoModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectInfoModel> GetListBySQL(string sql);
        DataTable GetDataTableBySQL(string sql);
        DataTable GetDataTable(string tname, string tfield);
        #endregion
    }

}
