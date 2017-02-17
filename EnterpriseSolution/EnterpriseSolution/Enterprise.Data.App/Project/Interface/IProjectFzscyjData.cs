using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFzscyjData.cs
    /// ��������: ���ݲ�-������������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/1 14:10:56
    /// </summary>
    public interface IProjectFzscyjData : IDataApp<ProjectFzscyjModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFzscyjModel> GetListBySQL(string sql);

        #endregion
    }

}
