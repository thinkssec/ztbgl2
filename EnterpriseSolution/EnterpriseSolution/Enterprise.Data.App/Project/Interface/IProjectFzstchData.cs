using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFzstchData.cs
    /// ��������: ���ݲ�-��ͼ�߻����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/1 14:10:57
    /// </summary>
    public interface IProjectFzstchData : IDataApp<ProjectFzstchModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFzstchModel> GetListBySQL(string sql);

        #endregion
    }

}
