using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectZjpfData.cs
    /// ��������: ���ݲ�-���ֱ�׼���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/7/3 12:43:12
    /// </summary>
    public interface IProjectZjpfData : IDataApp<ProjectZjpfModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZjpfModel> GetListBySQL(string sql);
        void CreateZjpf(string[] bzid, string[] df, string projid, int userid, string crminfo);
        void CreateZjpf(string[] bzid, string[] df, string projid, int userid);
        void UpdZjpf(string projid, int userid, int status);
        #endregion
    }

}
