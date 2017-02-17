using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Publicize;

namespace Enterprise.Data.App.Publicize
{	

    /// <summary>
    /// �ļ���:  IPublicizeSigningData.cs
    /// ��������: ���ݲ�-��������ǩ�ձ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/2/8 10:32:30
    /// </summary>
    public interface IPublicizeSigningData : IDataApp<PublicizeSigningModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<PublicizeSigningModel> GetListBySQL(string sql);

        #endregion
    }

}
