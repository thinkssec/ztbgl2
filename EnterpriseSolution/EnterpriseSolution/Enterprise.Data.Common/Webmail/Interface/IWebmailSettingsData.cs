using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Data.Common.Webmail
{

    /// <summary>
    /// 文件名:  IWebmailSettingsData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/2/18 9:28:04
    /// </summary>
    public interface IWebmailSettingsData : IDataCommon<WebmailSettingsModel>
    {
        ///// <summary>
        ///// 获取数据集合
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        /// <summary>
        /// 获取邮箱设置
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<WebmailSettingsModel> GetListByUserId(int userId);        
    }
}
