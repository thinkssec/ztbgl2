using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectZbwjshData.cs
    /// ��������: ���ݲ�-�б��ļ�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/7/6 0:47:36
    /// </summary>
    public interface IProjectZbwjshData : IDataApp<ProjectZbwjshModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZbwjshModel> GetListBySQL(string sql);

        #endregion
    }

}
