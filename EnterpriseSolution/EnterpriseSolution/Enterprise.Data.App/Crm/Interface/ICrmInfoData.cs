using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// 文件名:  ICrmInfoData.cs
    /// 功能描述: 数据层-服务商数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/6/19 0:27:42
    /// </summary>
    public interface ICrmInfoData : IDataApp<CrmInfoModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmInfoModel> GetListBySQL(string sql);

        #endregion
    }

}
