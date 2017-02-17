using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Publicize;

namespace Enterprise.Data.App.Publicize
{	

    /// <summary>
    /// �ļ���:  IPublicizeKindData.cs
    /// ��������: ���ݲ�-������Ŀ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/2/8 10:32:29
    /// </summary>
    public interface IPublicizeKindData : IDataApp<PublicizeKindModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<PublicizeKindModel> GetListBySQL(string sql);

        #endregion
    }

}
