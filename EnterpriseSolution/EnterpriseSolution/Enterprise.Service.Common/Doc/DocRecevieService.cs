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
    /// �ļ���:  DocRecevieService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/26 15:10:24
    /// </summary>
    public class DocRecevieService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDocRecevieData dal = new DocRecevieData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocRecevieModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocRecevieModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocRecevieModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
