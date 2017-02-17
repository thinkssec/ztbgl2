using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmPbsurveyData.cs
    /// ��������: ���ݲ�-�ҷ���λ���۱����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/31 17:16:08
    /// </summary>
    public interface ICrmPbsurveyData : IDataApp<CrmPbsurveyModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmPbsurveyModel> GetListBySQL(string sql);

        #endregion
    }

}
