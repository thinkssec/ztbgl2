using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Hse;

namespace Enterprise.Data.App.Hse
{	

    /// <summary>
    /// 文件名:  IHseSectcheckdetlData.cs
    /// 功能描述: 数据层-安全检查明细表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/4/29 13:20:45
    /// </summary>
    public interface IHseSectcheckdetlData : IDataApp<HseSectcheckdetlModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<HseSectcheckdetlModel> GetListBySQL(string sql);

        #endregion
    }

}
