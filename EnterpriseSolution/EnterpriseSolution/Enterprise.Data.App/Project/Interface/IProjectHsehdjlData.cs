using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectHsehdjlData.cs
    /// ��������: ���ݲ�-HSE������¼���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/11/20 11:34:29
    /// </summary>
    public interface IProjectHsehdjlData : IDataApp<ProjectHsehdjlModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectHsehdjlModel> GetListBySQL(string sql);

        #endregion
    }

}
