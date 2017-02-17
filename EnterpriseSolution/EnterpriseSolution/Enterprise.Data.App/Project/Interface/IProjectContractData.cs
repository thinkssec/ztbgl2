using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectContractData.cs
    /// 功能描述: 数据层-合同收入数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-11-5 15:48:16
    /// </summary>
    public interface IProjectContractData : IDataApp<ProjectContractModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectContractModel> GetListBySQL(string sql);

        #endregion
    }

}
