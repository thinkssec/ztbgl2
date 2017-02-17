using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Hr;

namespace Enterprise.Data.App.Hr
{	

    /// <summary>
    /// 文件名:  IHrChizhengwpData.cs
    /// 功能描述: 数据层-外聘人员持证信息表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/2/27 17:05:07
    /// </summary>
    public interface IHrChizhengwpData : IDataApp<HrChizhengwpModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<HrChizhengwpModel> GetListBySQL(string sql);

        #endregion
    }

}
