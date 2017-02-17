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
    /// �ļ���:  ProjectKbpbgzjlService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/7/1 0:33:14
    /// </summary>
    public class ProjectKbpbgzjlService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IProjectKbpbgzjlData dal = new ProjectKbpbgzjlData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectKbpbgzjlModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectKbpbgzjlModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectKbpbgzjlModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectKbpbgzjlModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
