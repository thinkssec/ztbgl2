using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectQhsecheckitemData.cs
    /// ��������: ���ݲ�-������ȫ�����Ŀ���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/11/26 17:18:04
    /// </summary>
    public interface IProjectQhsecheckitemData : IDataApp<ProjectQhsecheckitemModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectQhsecheckitemModel> GetListBySQL(string sql);

        #endregion
    }

}
