using System.Collections.Generic;

using Enterprise.Data.Common.Webmail;
using Enterprise.Model.Common.Webmail;
using Enterprise.Service.Basis.Rtx;
using Enterprise.Component.Infrastructure;

namespace Enterprise.Service.Common.Webmail
{
    /// <summary>
    /// �ļ���:  WebmailSettingsService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/18 9:28:04
    /// </summary>
    public class WebmailSettingsService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IWebmailSettingsData dal = new WebmailSettingsData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<WebmailSettingsModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(WebmailSettingsModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ���ݵ�ǰ���û�����ȡ��������
        /// </summary>
        /// <param name="userLoginName"></param>
        /// <returns></returns>
        public IList<WebmailSettingsModel> GetListByUser(int userId)
        {
            return dal.GetListByUserId(userId);
        }

        /// <summary>
        /// �������ʼ���������
        /// </summary>
        public static void SendNoticeToUsers()
        {
            IList<WebmailSettingsModel> list = null;
            list = dal.GetList("from WebmailSettingsModel c where c.ISREADY>0");
            //����                           
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
