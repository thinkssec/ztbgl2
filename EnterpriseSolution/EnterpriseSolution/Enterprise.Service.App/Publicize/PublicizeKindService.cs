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
    /// �ļ���:  PublicizeKindService.cs
    /// ��������: ҵ���߼���-������Ŀ�����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/2/8 10:32:29
    /// </summary>
    public class PublicizeKindService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IPublicizeKindData dal = new PublicizeKindData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<PublicizeKindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(PublicizeKindModel model)
        {
            return dal.Execute(model);
        }


        #endregion
        public PublicizeKindModel GetSingle(string LMID)
        {
            return dal.GetListByHQL("from PublicizeKindModel p where p.LMID = '" + LMID + "'").FirstOrDefault();
        }

        public string GetLanMuName(string LMID)
        {
            PublicizeKindModel Model = dal.GetListByHQL("from PublicizeKindModel p where p.LMID = '" + LMID + "'").FirstOrDefault();
            if (Model != null)
            {
                return Model.LMMC;
            }
            else
                return "";
        }
    }

}
