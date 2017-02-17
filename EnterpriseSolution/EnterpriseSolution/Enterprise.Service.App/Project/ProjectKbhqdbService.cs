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
    /// �ļ���:  ProjectKbhqdbService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/6/28 23:58:05
    /// </summary>
    public class ProjectKbhqdbService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IProjectKbhqdbData dal = new ProjectKbhqdbData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectKbhqdbModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectKbhqdbModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectKbhqdbModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectKbhqdbModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
