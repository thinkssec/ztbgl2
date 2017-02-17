using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectFzzjpsData.cs
    /// 功能描述: 数据层-专家评审数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/12/1 14:11:00
    /// </summary>
    public interface IProjectFzzjpsData : IDataApp<ProjectFzzjpsModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFzzjpsModel> GetListBySQL(string sql);

        #endregion
    }

}
