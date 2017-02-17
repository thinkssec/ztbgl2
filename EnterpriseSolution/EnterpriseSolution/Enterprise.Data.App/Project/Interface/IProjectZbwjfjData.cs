using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectZbwjfjData.cs
    /// 功能描述: 数据层-招标文件附件数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/7/7 13:02:55
    /// </summary>
    public interface IProjectZbwjfjData : IDataApp<ProjectZbwjfjModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZbwjfjModel> GetListBySQL(string sql);

        #endregion
    }

}
