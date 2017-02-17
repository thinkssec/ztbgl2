using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// 文件名:  ICrmFbreqformData.cs
    /// 功能描述: 数据层-分包申请单表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/12/11 11:28:03
    /// </summary>
    public interface ICrmFbreqformData : IDataApp<CrmFbreqformModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmFbreqformModel> GetListBySQL(string sql);

        #endregion
    }

}
