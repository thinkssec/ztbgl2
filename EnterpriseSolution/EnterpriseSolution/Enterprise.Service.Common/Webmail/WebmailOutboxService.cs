using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Webmail;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Service.Common.Webmail
{
    /// <summary>
    /// 文件名:  WebmailOutboxService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/18 9:28:03
    /// </summary>
    public class WebmailOutboxService
    {
        #region '代码生成器'
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IWebmailOutboxData dal = new WebmailOutboxData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="hql"></param>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailOutboxModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 根据邮箱名称获取数据集合
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public IList<WebmailOutboxModel> GetListByEmail(string email)
        {
            return dal.GetListByEmail(email);
        }


        public void Delete(List<string> Ids)
        {
            dal.Delete(Ids);
        }

        public void ReSend(List<string> Ids)
        {
            dal.ReSend(Ids);
        }

        public IList<WebmailOutboxModel> GetListById(int id)
        {
            return dal.GetListById(id);
        }
    }

}
