using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectYjyaData.cs
    /// ��������: ���ݲ�-Ӧ��Ԥ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/11/20 11:34:37
    /// </summary>
    public interface IProjectYjyaData : IDataApp<ProjectYjyaModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectYjyaModel> GetListBySQL(string sql);

        #endregion
    }

}
