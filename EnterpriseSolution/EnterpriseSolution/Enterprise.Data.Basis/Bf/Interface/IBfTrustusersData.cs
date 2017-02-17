using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{	

    /// <summary>
    /// 文件名:  IBfTrustusersData.cs
    /// 功能描述: 数据层-事务代办表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-26 15:29:32
    /// </summary>
    public interface IBfTrustusersData : IDataBasis<BfTrustusersModel>
    {
        #region 代码生成器

        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        IList<BfTrustusersModel> GetListByHQL(string hql);

        #endregion
    }

}
