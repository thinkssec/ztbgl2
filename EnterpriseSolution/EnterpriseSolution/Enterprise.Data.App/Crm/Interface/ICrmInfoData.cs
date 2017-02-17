using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// �ļ���:  ICrmInfoData.cs
    /// ��������: ���ݲ�-���������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/6/19 0:27:42
    /// </summary>
    public interface ICrmInfoData : IDataApp<CrmInfoModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmInfoModel> GetListBySQL(string sql);

        #endregion
    }

}
