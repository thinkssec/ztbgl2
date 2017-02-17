using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectCarData.cs
    /// ��������: ���ݲ�-��Ŀ���������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/6/19 15:35:13
    /// </summary>
    public interface IProjectCarData : IDataApp<ProjectCarModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectCarModel> GetListBySQL(string sql);

        #endregion
    }

}
