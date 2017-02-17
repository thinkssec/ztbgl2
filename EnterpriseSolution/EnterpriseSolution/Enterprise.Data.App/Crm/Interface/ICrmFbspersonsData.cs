using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// 文件名:  ICrmFbspersonsData.cs
    /// 功能描述: 数据层-分包商联系人表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/12/11 11:28:04
    /// </summary>
    public interface ICrmFbspersonsData : IDataApp<CrmFbspersonsModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmFbspersonsModel> GetListBySQL(string sql);

        #endregion
    }

}
