using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Archives;
using Enterprise.Model.App.Archives;

namespace Enterprise.Service.App.Archives
{
	
    /// <summary>
    /// �ļ���:  ArchivesKindService.cs
    /// ��������: ҵ���߼���-�����������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2014/2/7 13:50:46
    /// </summary>
    public class ArchivesKindService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IArchivesKindData dal = new ArchivesKindData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArchivesKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ArchivesKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ArchivesKindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ArchivesKindModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
