using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectMbrattendanceData.cs
    /// ��������: ���ݲ�-��Ŀ��Ա��̬�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/6/19 15:35:18
    /// </summary>
    public interface IProjectMbrattendanceData : IDataApp<ProjectMbrattendanceModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectMbrattendanceModel> GetListBySQL(string sql);

        #endregion
    }

}
