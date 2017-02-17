using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Publicize;
using Enterprise.Model.App.Publicize;

namespace Enterprise.Service.App.Publicize
{

    /// <summary>
    /// �ļ���:  PublicizeSigningService.cs
    /// ��������: ҵ���߼���-��������ǩ�ձ����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/2/8 10:32:30
    /// </summary>
    public class PublicizeSigningService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IPublicizeSigningData dal = new PublicizeSigningData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeSigningModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeSigningModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<PublicizeSigningModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(PublicizeSigningModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public PublicizeSigningModel GetSingle(string pId)
        {
            return dal.GetListByHQL("from PublicizeSigningModel a where a.PUBID='" + pId + "'").FirstOrDefault();
        }
    }

}
