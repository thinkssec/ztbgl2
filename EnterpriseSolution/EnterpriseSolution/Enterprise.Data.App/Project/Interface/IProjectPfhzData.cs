using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectPfhzData.cs
    /// 功能描述: 数据层-评分汇总表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/7/4 23:32:48
    /// </summary>
    public interface IProjectPfhzData : IDataApp<ProjectPfhzModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectPfhzModel> GetListBySQL(string sql);

        #endregion
    }

}
