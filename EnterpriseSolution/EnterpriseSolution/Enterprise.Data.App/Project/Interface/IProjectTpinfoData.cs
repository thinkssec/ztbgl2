using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectTpinfoData.cs
    /// 功能描述: 数据层-立项数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/9/8 23:25:12
    /// </summary>
    public interface IProjectTpinfoData : IDataApp<ProjectTpinfoModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectTpinfoModel> GetListBySQL(string sql);

        #endregion
    }

}
