using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectPfbzmData.cs
    /// 功能描述: 数据层-评分标准模板数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/7/23 23:38:32
    /// </summary>
    public interface IProjectPfbzmData : IDataApp<ProjectPfbzmModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectPfbzmModel> GetListBySQL(string sql);

        #endregion
    }

}
