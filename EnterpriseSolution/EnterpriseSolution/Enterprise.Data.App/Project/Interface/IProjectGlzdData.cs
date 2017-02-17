using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectGlzdData.cs
    /// ��������: ���ݲ�-��Ŀ�����ƶ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/6/21 17:32:40
    /// </summary>
    public interface IProjectGlzdData : IDataApp<ProjectGlzdModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectGlzdModel> GetListBySQL(string sql);

        #endregion
    }

}
