using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Project;
using Enterprise.Model.App.Project;

namespace Enterprise.Service.App.Project
{
	
    /// <summary>
    /// �ļ���:  ProjectZjpfService.cs
    /// ��������: ҵ���߼���-���ֱ�׼���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/7/3 12:43:12
    /// </summary>
    public class ProjectZjpfService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IProjectZjpfData dal = new ProjectZjpfData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectZjpfModel model)
        {
            return dal.Execute(model);
        }

        public void CreateZjpf(string[] bzid, string[] df, string projid, int userid,string crminfo)
        {
            dal.CreateZjpf(bzid, df, projid, userid, crminfo);
        }

        public void CreateZjpf(string[] bzid, string[] df, string projid, int userid)
        {
            dal.CreateZjpf(bzid, df, projid, userid);
        }
        public void UpdZjpf(string projid, int userid, int status)
        {
            dal.UpdZjpf(projid, userid, status);
        }
        #endregion
    }

}
