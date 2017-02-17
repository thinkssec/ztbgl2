using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmFbhtjeData.cs
    /// ��������: ���ݲ�-��Ŀ�ְ���ͬ�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/11 11:28:02
    /// </summary>
    public interface ICrmFbhtjeData : IDataApp<CrmFbhtjeModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmFbhtjeModel> GetListBySQL(string sql);

        #endregion
    }

}
