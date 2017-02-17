using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Webmail;

namespace Enterprise.Data.Common.Webmail
{

    /// <summary>
    /// �ļ���:  IWebmailSettingsData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/2/18 9:28:04
    /// </summary>
    public interface IWebmailSettingsData : IDataCommon<WebmailSettingsModel>
    {
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        IList<WebmailSettingsModel> GetListByUserId(int userId);        
    }
}
