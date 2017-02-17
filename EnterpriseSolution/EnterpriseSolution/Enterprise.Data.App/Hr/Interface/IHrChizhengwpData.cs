using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Hr;

namespace Enterprise.Data.App.Hr
{	

    /// <summary>
    /// �ļ���:  IHrChizhengwpData.cs
    /// ��������: ���ݲ�-��Ƹ��Ա��֤��Ϣ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/2/27 17:05:07
    /// </summary>
    public interface IHrChizhengwpData : IDataApp<HrChizhengwpModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<HrChizhengwpModel> GetListBySQL(string sql);

        #endregion
    }

}
