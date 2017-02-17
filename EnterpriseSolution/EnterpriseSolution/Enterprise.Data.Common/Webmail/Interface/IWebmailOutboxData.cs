using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Data.Common.Webmail
{

    /// <summary>
    /// �ļ���:  IWebmailOutboxData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/2/18 9:28:03
    /// </summary>
    public interface IWebmailOutboxData : IDataCommon<WebmailOutboxModel>
    {
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);

        IList<WebmailOutboxModel> GetListByEmail(string email);

        void Delete(List<string> Ids);

        void ReSend(List<string> Ids);

        IList<WebmailOutboxModel> GetListById(int id);
    }
}
