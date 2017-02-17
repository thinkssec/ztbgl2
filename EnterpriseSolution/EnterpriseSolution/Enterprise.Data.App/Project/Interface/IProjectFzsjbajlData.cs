using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectFzsjbajlData.cs
    /// ��������: ���ݲ�-��Ʊ�����¼���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/1 14:10:57
    /// </summary>
    public interface IProjectFzsjbajlData : IDataApp<ProjectFzsjbajlModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectFzsjbajlModel> GetListBySQL(string sql);

        #endregion
    }

}
