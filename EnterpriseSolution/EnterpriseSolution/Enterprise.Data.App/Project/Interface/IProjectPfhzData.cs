using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectPfhzData.cs
    /// ��������: ���ݲ�-���ֻ��ܱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/7/4 23:32:48
    /// </summary>
    public interface IProjectPfhzData : IDataApp<ProjectPfhzModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectPfhzModel> GetListBySQL(string sql);

        #endregion
    }

}
