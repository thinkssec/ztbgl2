using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Publicize;
using Enterprise.Model.App.Publicize;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Common.Article;


namespace Enterprise.Service.App.Publicize
{

    /// <summary>
    /// �ļ���:  PublicizeInfoService.cs
    /// ��������: ҵ���߼���-��������Ͷ�����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/2/8 10:32:28
    /// </summary>
    public class PublicizeInfoService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IPublicizeInfoData dal = new PublicizeInfoData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeInfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<PublicizeInfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(PublicizeInfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public PublicizeInfoModel GetSingle(string pubId)
        {
            return dal.GetListByHQL("from PublicizeInfoModel p where p.PUBID='" + pubId + "'").FirstOrDefault();
        }
        /// <summary>
        /// ��ʾ���״̬
        /// </summary>
        /// <returns></returns>
        public static string Getstatus(int STATUS)
        {
            if (STATUS == 0)
            {
                return "δ���";
            }
            if (STATUS == 1)
            {
                return "���ͨ��";
            }
            if (STATUS == 2)
            {
                return "δͨ�����";
            }
            if (STATUS == 3)
            {
                return "�ѷ���";
            }
            return "";

        }
        /// <summary>
        /// ��ȡ�����Ա��Ϣ��ʵΪ�����칫������
        /// </summary>
        /// <returns></returns>
        public int GetChecker()
        {
            SysDepartmentService Dservice = new SysDepartmentService();
            SysDepartMentModel Model = Dservice.DepartmentDisp(122);
            return Model.DMANAGER.ToInt();
        }
    }

}
