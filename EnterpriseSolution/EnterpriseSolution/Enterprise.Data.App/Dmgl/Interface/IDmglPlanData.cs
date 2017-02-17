using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Dmgl;

namespace Enterprise.Data.App.Dmgl
{	

    /// <summary>
    /// �ļ���:  IDmglPlanData.cs
    /// ��������: ���ݲ�-����ά�޼ƻ��������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/5/12 9:15:46
    /// </summary>
    public interface IDmglPlanData : IDataApp<DmglPlanModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DmglPlanModel> GetListBySQL(string sql);

        #endregion
    }

}
