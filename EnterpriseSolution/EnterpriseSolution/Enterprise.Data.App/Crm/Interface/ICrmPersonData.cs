using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmPersonData.cs
    /// ��������: ���ݲ�-ר�ҿ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/6/21 1:15:28
    /// </summary>
    public interface ICrmPersonData : IDataApp<CrmPersonModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmPersonModel> GetListBySQL(string sql);

        #endregion
    }

}
