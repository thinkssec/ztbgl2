using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// 文件名:  ICrmPersonData.cs
    /// 功能描述: 数据层-专家库数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/6/21 1:15:28
    /// </summary>
    public interface ICrmPersonData : IDataApp<CrmPersonModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmPersonModel> GetListBySQL(string sql);

        #endregion
    }

}
