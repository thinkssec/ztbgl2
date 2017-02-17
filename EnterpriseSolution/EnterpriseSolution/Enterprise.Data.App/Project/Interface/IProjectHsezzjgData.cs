using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectHsezzjgData.cs
    /// ��������: ���ݲ�-HSE��֯�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/11/20 11:34:31
    /// </summary>
    public interface IProjectHsezzjgData : IDataApp<ProjectHsezzjgModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectHsezzjgModel> GetListBySQL(string sql);

        #endregion
    }

}
