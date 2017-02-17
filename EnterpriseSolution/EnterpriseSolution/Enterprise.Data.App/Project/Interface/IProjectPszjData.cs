using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectPszjData.cs
    /// ��������: ���ݲ�-��Ŀ����ר�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/6/20 23:37:41
    /// </summary>
    public interface IProjectPszjData : IDataApp<ProjectPszjModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectPszjModel> GetListBySQL(string sql);

        #endregion
    }

}
