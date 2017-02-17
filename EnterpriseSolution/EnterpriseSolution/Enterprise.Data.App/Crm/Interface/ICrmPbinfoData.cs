using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmPbinfoData.cs
    /// ��������: ���ݲ�-�ҷ���λ��Ϣ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/3/31 17:16:02
    /// </summary>
    public interface ICrmPbinfoData : IDataApp<CrmPbinfoModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmPbinfoModel> GetListBySQL(string sql);

        #endregion
    }

}
