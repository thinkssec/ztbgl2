using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectTpinfoData.cs
    /// ��������: ���ݲ�-�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/9/8 23:25:12
    /// </summary>
    public interface IProjectTpinfoData : IDataApp<ProjectTpinfoModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectTpinfoModel> GetListBySQL(string sql);

        #endregion
    }

}
