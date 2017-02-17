using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Exc;

namespace Enterprise.Data.Basis.Exc
{

    /// <summary>
    /// 文件名:  IExcEmailData.cs
    /// 功能描述: 数据层-邮件发送表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-4 12:19:24
    /// </summary>
    public interface IExcEmailData : IDataBasis<ExcEmailModel>
    {
        /// <summary>
        /// 获取指定的记录
        /// </summary>
        /// <returns></returns>
        ExcEmailModel GetModelById(string Id);
    }
}
