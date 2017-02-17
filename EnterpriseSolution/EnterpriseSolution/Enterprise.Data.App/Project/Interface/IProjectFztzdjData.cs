using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFztzdjData.cs
    /// ��������: ���ݲ�-ͼֽ�Ǽ��б����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/1 14:10:59
    /// </summary>
    public interface IProjectFztzdjData : IDataApp<ProjectFztzdjModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFztzdjModel> GetListBySQL(string sql);

        #endregion
    }

}
