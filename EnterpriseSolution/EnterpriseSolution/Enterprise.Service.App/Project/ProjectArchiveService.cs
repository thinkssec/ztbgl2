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
    /// �ļ���:  ProjectArchiveService.cs
    /// ��������: ҵ���߼���-���ϴ浵�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:13
    /// </summary>
    public class ProjectArchiveService
    {

        #region ����������

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IProjectArchiveData dal = new ProjectArchiveData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectArchiveModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectArchiveModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectArchiveModel model)
        {
            return dal.Execute(model);
        }

        #endregion

        #region �Զ��巽����

        /// <summary>
        /// ������ĿID��ȡ���ݼ���
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public IList<ProjectArchiveModel> GetListByProjectId(string projectId)
        {
            return dal.GetListByHQL("from ProjectArchiveModel p where p.PROJID='" + projectId + "'");
        }

        /// <summary>
        /// ������ĿID��ȡ���ݼ���
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public ProjectArchiveModel GetListSingle(string archiveId)
        {
            return dal.GetListByHQL("from ProjectArchiveModel p where p.ARCHIVEID='" + archiveId + "'").FirstOrDefault();
        }

        #endregion
    }

}
