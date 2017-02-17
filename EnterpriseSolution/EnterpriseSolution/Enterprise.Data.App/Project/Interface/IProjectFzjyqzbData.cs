using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFzjyqzbData.cs
    /// ��������: ���ݲ�-����ǰ׼�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/1 14:10:55
    /// </summary>
    public interface IProjectFzjyqzbData : IDataApp<ProjectFzjyqzbModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFzjyqzbModel> GetListBySQL(string sql);

        #endregion
    }

}
