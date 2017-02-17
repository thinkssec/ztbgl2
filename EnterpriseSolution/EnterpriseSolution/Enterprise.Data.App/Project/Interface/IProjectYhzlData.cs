using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectYhzlData.cs
    /// ��������: ���ݲ�-������������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/11/20 11:34:35
    /// </summary>
    public interface IProjectYhzlData : IDataApp<ProjectYhzlModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectYhzlModel> GetListBySQL(string sql);

        #endregion
    }

}
