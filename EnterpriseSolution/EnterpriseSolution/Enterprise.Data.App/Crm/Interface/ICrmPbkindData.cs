using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmPbkindData.cs
    /// ��������: ���ݲ�-�ҷ���λ�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/31 17:16:05
    /// </summary>
    public interface ICrmPbkindData : IDataApp<CrmPbkindModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmPbkindModel> GetListBySQL(string sql);

        #endregion
    }

}
