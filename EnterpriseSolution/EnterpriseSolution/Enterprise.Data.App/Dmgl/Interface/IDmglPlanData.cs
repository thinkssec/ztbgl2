using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Dmgl;

namespace Enterprise.Data.App.Dmgl
{	

    /// <summary>
    /// 文件名:  IDmglPlanData.cs
    /// 功能描述: 数据层-地面维修计划管理数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/5/12 9:15:46
    /// </summary>
    public interface IDmglPlanData : IDataApp<DmglPlanModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DmglPlanModel> GetListBySQL(string sql);

        #endregion
    }

}
