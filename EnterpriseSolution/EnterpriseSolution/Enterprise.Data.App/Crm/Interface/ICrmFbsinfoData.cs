using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmFbsinfoData.cs
    /// ��������: ���ݲ�-�ְ�����Ϣ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/11 11:28:04
    /// </summary>
    public interface ICrmFbsinfoData : IDataApp<CrmFbsinfoModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmFbsinfoModel> GetListBySQL(string sql);

        #endregion
    }

}
