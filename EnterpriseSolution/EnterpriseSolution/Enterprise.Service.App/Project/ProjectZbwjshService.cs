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
    /// �ļ���:  ProjectZbwjshService.cs
    /// ��������: ҵ���߼���-�б��ļ�������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/7/6 0:47:36
    /// </summary>
    public class ProjectZbwjshService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IProjectZbwjshData dal = new ProjectZbwjshData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZbwjshModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZbwjshModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectZbwjshModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectZbwjshModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
