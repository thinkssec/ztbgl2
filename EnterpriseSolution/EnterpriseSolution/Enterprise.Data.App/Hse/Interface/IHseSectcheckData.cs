using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Hse;

namespace Enterprise.Data.App.Hse
{	

    /// <summary>
    /// �ļ���:  IHseSectcheckData.cs
    /// ��������: ���ݲ�-��ȫ�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/4/28 11:31:36
    /// </summary>
    public interface IHseSectcheckData : IDataApp<HseSectcheckModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<HseSectcheckModel> GetListBySQL(string sql);

        #endregion
    }

}
