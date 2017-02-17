using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFwsData.cs
    /// ��������: ���ݲ�-��Ŀ�����̹������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/6/1 14:34:34
    /// </summary>
    public interface IProjectFwsData : IDataApp<ProjectFwsModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFwsModel> GetListBySQL(string sql);

        #endregion
    }

}