using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Exc;

namespace Enterprise.Data.Basis.Exc
{

    /// <summary>
    /// 文件名:  IExcMessageData.cs
    /// 功能描述: 数据层-即时消息发送表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:19:28
    /// </summary>
    public interface IExcMessageData : IDataBasis<ExcMessageModel>
    {
        /// <summary>
        /// 获取指定的记录
        /// </summary>
        /// <returns></returns>
        ExcMessageModel GetModelById(string Id);
    }
}
