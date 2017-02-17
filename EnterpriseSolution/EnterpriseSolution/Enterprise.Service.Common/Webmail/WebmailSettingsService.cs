using System.Collections.Generic;

using Enterprise.Data.Common.Webmail;
using Enterprise.Model.Common.Webmail;
using Enterprise.Service.Basis.Rtx;
using Enterprise.Component.Infrastructure;

namespace Enterprise.Service.Common.Webmail
{
    /// <summary>
    /// 文件名:  WebmailSettingsService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/18 9:28:04
    /// </summary>
    public class WebmailSettingsService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IWebmailSettingsData dal = new WebmailSettingsData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<WebmailSettingsModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailSettingsModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 根据当前的用户名获取邮箱设置
        /// </summary>
        /// <param name="userLoginName"></param>
        /// <returns></returns>
        public IList<WebmailSettingsModel> GetListByUser(int userId)
        {
            return dal.GetListByUserId(userId);
        }

        /// <summary>
        /// 发送新邮件到达提醒
        /// </summary>
        public static void SendNoticeToUsers()
        {
            IList<WebmailSettingsModel> list = null;
            list = dal.GetList("from WebmailSettingsModel c where c.ISREADY>0");
            //提醒                           
            foreach (WebmailSettingsModel model in list)
            {
                RtxService.SendRtxMessageByUserId(model.USERID, "Email Message",model.EMAIL+" have [ "+model.ISREADY+" ] new emails..");
                model.ISREADY = 0;
                model.DB_Option_Action = WebKeys.UpdateAction;
                dal.Execute(model);
            }            
        }

    }

}
