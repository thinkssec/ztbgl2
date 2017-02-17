using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmFbreqformData.cs
    /// ��������: ���ݲ�-�ְ����뵥�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/11 11:28:03
    /// </summary>
    public interface ICrmFbreqformData : IDataApp<CrmFbreqformModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmFbreqformModel> GetListBySQL(string sql);

        #endregion
    }

}
