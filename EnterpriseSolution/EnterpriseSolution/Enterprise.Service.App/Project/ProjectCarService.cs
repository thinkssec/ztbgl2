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
    /// �ļ���:  ProjectCarService.cs
    /// ��������: ҵ���߼���-��Ŀ���������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2014/6/19 15:35:14
    /// </summary>
    public class ProjectCarService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IProjectCarData dal = new ProjectCarData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCarModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCarModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectCarModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectCarModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// ������ĿID��ȡ������Ϣ����
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectCarModel> GetListByProjectId(string projId)
        {
            return dal.GetListByHQL("from ProjectCarModel c where c.PROJID='" + projId + "' order by c.JLRQ desc");
        }
    }

}
