using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectQhsecheckData.cs
    /// ��������: ���ݲ�-������ȫ�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/11/26 17:18:03
    /// </summary>
    public interface IProjectQhsecheckData : IDataApp<ProjectQhsecheckModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectQhsecheckModel> GetListBySQL(string sql);

        #endregion
    }

}
