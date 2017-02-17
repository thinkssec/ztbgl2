using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectReportData.cs
    /// ��������: ���ݲ�-��ⱨ������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/11/19 11:36:53
    /// </summary>
    public interface IProjectReportData : IDataApp<ProjectReportModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectReportModel> GetListBySQL(string sql);

        #endregion
    }

}
