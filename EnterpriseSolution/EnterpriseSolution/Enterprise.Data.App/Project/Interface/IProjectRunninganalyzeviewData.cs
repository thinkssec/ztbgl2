using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectRunninganalyzeviewData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/12/4 17:33:32
    /// </summary>
    public interface IProjectRunninganalyzeviewData : IDataApp<ProjectRunninganalyzeviewModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectRunninganalyzeviewModel> GetListBySQL(string sql);

        #endregion
    }

}
