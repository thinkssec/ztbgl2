using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmFbcontractData.cs
    /// ��������: ���ݲ�-�ְ���ͬ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/11 11:28:01
    /// </summary>
    public interface ICrmFbcontractData : IDataApp<CrmFbcontractModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmFbcontractModel> GetListBySQL(string sql);

        #endregion
    }

}
