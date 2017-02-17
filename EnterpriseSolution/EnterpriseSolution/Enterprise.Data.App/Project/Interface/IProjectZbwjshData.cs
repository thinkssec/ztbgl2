using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectZbwjshData.cs
    /// 功能描述: 数据层-招标文件审核数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/7/6 0:47:36
    /// </summary>
    public interface IProjectZbwjshData : IDataApp<ProjectZbwjshModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZbwjshModel> GetListBySQL(string sql);

        #endregion
    }

}
