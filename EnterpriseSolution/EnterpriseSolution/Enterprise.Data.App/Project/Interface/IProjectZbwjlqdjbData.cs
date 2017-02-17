using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectZbwjlqdjbData.cs
    /// ��������: ���ݲ�-�б��ļ���ȡ�ǼǱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/6/28 0:06:20
    /// </summary>
    public interface IProjectZbwjlqdjbData : IDataApp<ProjectZbwjlqdjbModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZbwjlqdjbModel> GetListBySQL(string sql);

        #endregion
    }

}
