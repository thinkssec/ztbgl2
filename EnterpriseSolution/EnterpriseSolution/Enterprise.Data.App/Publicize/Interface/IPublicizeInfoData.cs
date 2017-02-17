using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Publicize;

namespace Enterprise.Data.App.Publicize
{	

    /// <summary>
    /// �ļ���:  IPublicizeInfoData.cs
    /// ��������: ���ݲ�-��������Ͷ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/2/8 10:32:28
    /// </summary>
    public interface IPublicizeInfoData : IDataApp<PublicizeInfoModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<PublicizeInfoModel> GetListBySQL(string sql);

        #endregion
    }

}
