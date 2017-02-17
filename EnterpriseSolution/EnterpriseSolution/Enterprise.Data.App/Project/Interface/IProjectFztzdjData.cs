using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectFztzdjData.cs
    /// 功能描述: 数据层-图纸登记列表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/12/1 14:10:59
    /// </summary>
    public interface IProjectFztzdjData : IDataApp<ProjectFztzdjModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFztzdjModel> GetListBySQL(string sql);

        #endregion
    }

}
