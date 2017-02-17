using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Data.Common.Webmail
{

    /// <summary>
    /// �ļ���:  IWebmailInboxData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/2/18 9:28:02
    /// </summary>
    public interface IWebmailInboxData : IDataCommon<WebmailInboxModel>
    {
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);

        /// <summary>
        /// ����ID��ȡ�ʼ�
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IList<WebmailInboxModel> GetListById(string Id);

        /// <summary>
        /// ���������ȡ�ʼ�
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        IList<WebmailInboxModel> GetListByEmail(string email);

        /// <summary>
        /// �������ɾ��
        /// </summary>
        /// <param name="messageIds"></param>
        void SetDelelted(List<string> messageIds);

        /// <summary>
        /// ������ǳ��Ѷ�
        /// </summary>
        /// <param name="messageIds"></param>
        void SetReaded(List<string> messageIds);

        /// <summary>
        /// �������ʼ���Ϣ���û�
        /// </summary>
        void SendNoticeToUsers();
    }
}
