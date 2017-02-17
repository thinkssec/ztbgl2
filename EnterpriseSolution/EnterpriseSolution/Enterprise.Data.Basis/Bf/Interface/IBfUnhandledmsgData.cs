using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// 文件名:  IBfUnhandledmsgData.cs
    /// 功能描述: 数据层-业务流未处理消息表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:18:58
    /// </summary>
    public interface IBfUnhandledmsgData : IDataBasis<BfUnhandledmsgModel>
    {
        /// <summary>
        /// 获取满足查询条件的数据集合
        /// </summary>
        /// <param name="hql">Hibernate查询语句</param>
        /// <returns></returns>
        IList<BfUnhandledmsgModel> GetListByHQL(string hql);

        /// <summary>
        ///  根据ID值获取唯一数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BfUnhandledmsgModel GetModelById(string id);
    }
}
