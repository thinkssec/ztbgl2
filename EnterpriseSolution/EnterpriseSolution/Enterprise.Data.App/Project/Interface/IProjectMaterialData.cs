using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectMaterialData.cs
    /// 功能描述: 数据层-项目物料消耗表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/6/19 15:35:15
    /// </summary>
    public interface IProjectMaterialData : IDataApp<ProjectMaterialModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectMaterialModel> GetListBySQL(string sql);

        #endregion
    }

}
