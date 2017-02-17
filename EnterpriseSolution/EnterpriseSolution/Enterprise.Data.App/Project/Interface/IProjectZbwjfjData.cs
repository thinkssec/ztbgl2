using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectZbwjfjData.cs
    /// ��������: ���ݲ�-�б��ļ��������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/7/7 13:02:55
    /// </summary>
    public interface IProjectZbwjfjData : IDataApp<ProjectZbwjfjModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZbwjfjModel> GetListBySQL(string sql);

        #endregion
    }

}
