using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Doc;
using Enterprise.Model.Common.Doc;

namespace Enterprise.Service.Common.Doc
{
	
    /// <summary>
    /// �ļ���:  DocClassService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/26 15:10:23
    /// </summary>
    public class DocClassService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDocClassData dal = new DocClassData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocClassModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocClassModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocClassModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// ����ID��ȡ����
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DocClassModel GetListById(int classId)
        {
            return dal.GetListById(classId);
        }

        /// <summary>
        /// ��Ŀ���Ƿ�������
        /// </summary>
        /// <param name="classId">��ĿID</param>
        /// <returns></returns>
        public bool HasArticle(int classId)
        {
            return dal.HasArticle(classId);
        }

        /// <summary>
        /// �û��Ƿ���������Ȩ��
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool AllowPubArticleInClass(int classId, int userId)
        {
            return dal.AllowPubArticleInClass(classId, userId);
        }
    }

}
