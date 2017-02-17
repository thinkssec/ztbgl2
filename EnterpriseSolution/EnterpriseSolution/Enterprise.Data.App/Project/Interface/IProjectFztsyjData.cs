using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFztsyjData.cs
    /// ��������: ���ݲ�-����������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/1 14:10:58
    /// </summary>
    public interface IProjectFztsyjData : IDataApp<ProjectFztsyjModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFztsyjModel> GetListBySQL(string sql);

        #endregion
    }

}
