using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Data.Common.Busitravel
{	

    /// <summary>
    /// 文件名:  IBusitravelSummaryData.cs
    /// 功能描述: 数据层-出差情况汇总表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-6-24 20:24:42
    /// </summary>
    public interface IBusitravelSummaryData : IDataCommon<BusitravelSummaryModel>
    {

        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<BusitravelSummaryModel> GetListBySQL(string sql);

        #endregion
    }

}
