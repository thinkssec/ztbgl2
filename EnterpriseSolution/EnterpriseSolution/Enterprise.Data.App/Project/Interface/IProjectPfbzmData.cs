using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectPfbzmData.cs
    /// ��������: ���ݲ�-���ֱ�׼ģ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/7/23 23:38:32
    /// </summary>
    public interface IProjectPfbzmData : IDataApp<ProjectPfbzmModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectPfbzmModel> GetListBySQL(string sql);

        #endregion
    }

}
