using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectYhzlData.cs
    /// 功能描述: 数据层-隐患治理表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/11/20 11:34:35
    /// </summary>
    public interface IProjectYhzlData : IDataApp<ProjectYhzlModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectYhzlModel> GetListBySQL(string sql);

        #endregion
    }

}
