using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Hr;

namespace Enterprise.Data.App.Hr
{	

    /// <summary>
    /// �ļ���:  IHrZigeData.cs
    /// ��������: ���ݲ�-��Ա�ʸ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-5 15:48:13
    /// </summary>
    public interface IHrZigeData : IDataApp<HrZigeModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<HrZigeModel> GetListBySQL(string sql);

        #endregion
    }

}
