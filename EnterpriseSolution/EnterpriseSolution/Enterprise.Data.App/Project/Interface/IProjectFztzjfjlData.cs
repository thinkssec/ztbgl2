using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFztzjfjlData.cs
    /// ��������: ���ݲ�-ͼֽ������¼�б����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/1 14:10:59
    /// </summary>
    public interface IProjectFztzjfjlData : IDataApp<ProjectFztzjfjlModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFztzjfjlModel> GetListBySQL(string sql);

        #endregion
    }

}
