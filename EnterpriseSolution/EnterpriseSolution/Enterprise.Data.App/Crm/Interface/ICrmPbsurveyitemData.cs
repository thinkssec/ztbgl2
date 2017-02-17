using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmPbsurveyitemData.cs
    /// ��������: ���ݲ�-�ҷ���λ�������ݱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/31 17:16:11
    /// </summary>
    public interface ICrmPbsurveyitemData : IDataApp<CrmPbsurveyitemModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmPbsurveyitemModel> GetListBySQL(string sql);

        #endregion
    }

}
