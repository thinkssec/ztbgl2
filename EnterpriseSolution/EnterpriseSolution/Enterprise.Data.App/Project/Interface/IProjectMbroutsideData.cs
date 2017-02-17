using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectMbroutsideData.cs
    /// ��������: ���ݲ�-���Ա�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/6/19 15:35:19
    /// </summary>
    public interface IProjectMbroutsideData : IDataApp<ProjectMbroutsideModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectMbroutsideModel> GetListBySQL(string sql);

        #endregion
    }

}
