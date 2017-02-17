using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Hse;

namespace Enterprise.Data.App.Hse
{	

    /// <summary>
    /// �ļ���:  IHseSectcheckdetlData.cs
    /// ��������: ���ݲ�-��ȫ�����ϸ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/4/29 13:20:45
    /// </summary>
    public interface IHseSectcheckdetlData : IDataApp<HseSectcheckdetlModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<HseSectcheckdetlModel> GetListBySQL(string sql);

        #endregion
    }

}
