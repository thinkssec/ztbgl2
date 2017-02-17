using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectPfbzData.cs
    /// ��������: ���ݲ�-���ֱ�׼���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/6/17 22:51:44
    /// </summary>
    public interface IProjectPfbzData : IDataApp<ProjectPfbzModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectPfbzModel> GetListBySQL(string sql);

        #endregion
    }

}
