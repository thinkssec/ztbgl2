using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectWssjdjData.cs
    /// ��������: ���ݲ�-δ���¼��ǼǱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/11/20 11:34:32
    /// </summary>
    public interface IProjectWssjdjData : IDataApp<ProjectWssjdjModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectWssjdjModel> GetListBySQL(string sql);

        #endregion
    }

}
