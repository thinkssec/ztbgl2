using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectFzscyjData.cs
    /// 功能描述: 数据层-设计审查意见数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/12/1 14:10:56
    /// </summary>
    public interface IProjectFzscyjData : IDataApp<ProjectFzscyjModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFzscyjModel> GetListBySQL(string sql);

        #endregion
    }

}
