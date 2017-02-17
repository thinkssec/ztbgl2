using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Zygl;

namespace Enterprise.Data.App.Zygl
{	

    /// <summary>
    /// 文件名:  IZyglPlanData.cs
    /// 功能描述: 数据层-作业管理开工申请数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/5/19 14:47:47
    /// </summary>
    public interface IZyglPlanData : IDataApp<ZyglPlanModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ZyglPlanModel> GetListBySQL(string sql);

        #endregion
    }

}
