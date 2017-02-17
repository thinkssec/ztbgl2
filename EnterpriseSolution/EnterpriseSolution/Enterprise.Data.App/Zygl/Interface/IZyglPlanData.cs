using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Zygl;

namespace Enterprise.Data.App.Zygl
{	

    /// <summary>
    /// �ļ���:  IZyglPlanData.cs
    /// ��������: ���ݲ�-��ҵ�������������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/5/19 14:47:47
    /// </summary>
    public interface IZyglPlanData : IDataApp<ZyglPlanModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ZyglPlanModel> GetListBySQL(string sql);

        #endregion
    }

}
