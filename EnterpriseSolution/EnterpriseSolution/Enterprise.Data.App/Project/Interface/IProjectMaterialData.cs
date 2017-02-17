using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectMaterialData.cs
    /// ��������: ���ݲ�-��Ŀ�������ı����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/6/19 15:35:15
    /// </summary>
    public interface IProjectMaterialData : IDataApp<ProjectMaterialModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectMaterialModel> GetListBySQL(string sql);

        #endregion
    }

}
