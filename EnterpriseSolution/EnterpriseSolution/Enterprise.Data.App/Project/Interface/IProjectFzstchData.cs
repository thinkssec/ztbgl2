using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectFzstchData.cs
    /// 功能描述: 数据层-审图策划数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/12/1 14:10:57
    /// </summary>
    public interface IProjectFzstchData : IDataApp<ProjectFzstchModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFzstchModel> GetListBySQL(string sql);

        #endregion
    }

}
