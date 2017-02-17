using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectMbroutsideData.cs
    /// 功能描述: 数据层-外雇员工表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/6/19 15:35:19
    /// </summary>
    public interface IProjectMbroutsideData : IDataApp<ProjectMbroutsideModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectMbroutsideModel> GetListBySQL(string sql);

        #endregion
    }

}
