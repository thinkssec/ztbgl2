using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectInfoData.cs
    /// ��������: ���ݲ�-�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/6/1 14:34:34
    /// </summary>
    public interface IProjectInfoData : IDataApp<ProjectInfoModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectInfoModel> GetListBySQL(string sql);
        DataTable GetDataTableBySQL(string sql);
        DataTable GetDataTable(string tname, string tfield);
        #endregion
    }

}
