using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Hr;

namespace Enterprise.Data.App.Hr
{	

    /// <summary>
    /// 文件名:  IHrZigeData.cs
    /// 功能描述: 数据层-人员资格表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-11-5 15:48:13
    /// </summary>
    public interface IHrZigeData : IDataApp<HrZigeModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<HrZigeModel> GetListBySQL(string sql);

        #endregion
    }

}
