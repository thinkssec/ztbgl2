using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectPfbzData.cs
    /// 功能描述: 数据层-评分标准数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/6/17 22:51:44
    /// </summary>
    public interface IProjectPfbzData : IDataApp<ProjectPfbzModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectPfbzModel> GetListBySQL(string sql);

        #endregion
    }

}
