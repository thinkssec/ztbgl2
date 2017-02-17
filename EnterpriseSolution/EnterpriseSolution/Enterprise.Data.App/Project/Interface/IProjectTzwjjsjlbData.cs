using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectTzwjjsjlbData.cs
    /// ��������: ���ݲ�-Ͷ���ļ����ռ�¼�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/6/28 1:26:18
    /// </summary>
    public interface IProjectTzwjjsjlbData : IDataApp<ProjectTzwjjsjlbModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectTzwjjsjlbModel> GetListBySQL(string sql);

        #endregion
    }

}
