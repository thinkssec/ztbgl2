using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Data.Common.Webmail
{

    /// <summary>
    /// 文件名:  IWebmailOutboxData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/2/18 9:28:03
    /// </summary>
    public interface IWebmailOutboxData : IDataCommon<WebmailOutboxModel>
    {
        ///// <summary>
        ///// 获取数据集合
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);

        IList<WebmailOutboxModel> GetListByEmail(string email);

        void Delete(List<string> Ids);

        void ReSend(List<string> Ids);

        IList<WebmailOutboxModel> GetListById(int id);
    }
}
