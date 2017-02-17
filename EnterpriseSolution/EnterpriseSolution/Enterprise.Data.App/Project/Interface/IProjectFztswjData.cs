using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFztswjData.cs
    /// ��������: ���ݲ�-������ļ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/1 14:10:58
    /// </summary>
    public interface IProjectFztswjData : IDataApp<ProjectFztswjModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFztswjModel> GetListBySQL(string sql);

        #endregion
    }

}
