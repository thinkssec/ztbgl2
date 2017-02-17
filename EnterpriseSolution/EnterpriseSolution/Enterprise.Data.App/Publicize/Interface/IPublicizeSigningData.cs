using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Publicize;

namespace Enterprise.Data.App.Publicize
{	

    /// <summary>
    /// 文件名:  IPublicizeSigningData.cs
    /// 功能描述: 数据层-宣传报道签收表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/2/8 10:32:30
    /// </summary>
    public interface IPublicizeSigningData : IDataApp<PublicizeSigningModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<PublicizeSigningModel> GetListBySQL(string sql);

        #endregion
    }

}
