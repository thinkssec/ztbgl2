using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Crm;
using Enterprise.Model.App.Crm;

namespace Enterprise.Service.App.Crm
{

    /// <summary>
    /// �ļ���:  CrmPbinfoService.cs
    /// ��������: ҵ���߼���-�ҷ���λ��Ϣ�����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/3/31 17:16:03
    /// </summary>
    public class CrmPbinfoService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmPbinfoData dal = new CrmPbinfoData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbinfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbinfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmPbinfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmPbinfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmPbinfoModel GetSingle(string pId)
        {
            string hql = "from CrmPbinfoModel p where p.PBBM='" + pId + "'";
            return dal.GetListByHQL(hql).FirstOrDefault();
        }

        /// <summary>
        ///��ȡ״̬�����á��ѹ�ʱ
        /// </summary>
        /// <param name="nullable"></param>
        /// <returns></returns>
        public static string GetSTATUS(int? STATUS)
        {
            if (STATUS == 1)
            {
                return "����";
            }
            else
            {
                return "�ѹ�ʱ";
            }
        }
    }

}
