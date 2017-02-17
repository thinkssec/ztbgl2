using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
	
    /// <summary>
    /// �ļ���:  BfTrustusersService.cs
    /// ��������: ҵ���߼���-�����������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-26 15:29:32
    /// </summary>
    public class BfTrustusersService
    {

        #region ����������

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfTrustusersData dal = new BfTrustusersData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfTrustusersModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfTrustusersModel> GetList(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfTrustusersModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ��ȡָ���û���������Ȩί��
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BfTrustusersModel> GetListByUserId(int userId)
        {
            return dal.GetListByHQL("from BfTrustusersModel p where p.BF_FROMUSER='" 
                + userId + "'").OrderByDescending(p=>p.BF_TRUSTDATE).ToList();
        }

        /// <summary>
        /// ��ȡ����ί�и�ָ���û���Ȩ
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BfTrustusersModel> GetListByToUserId(int userId)
        {
            return dal.GetListByHQL("from BfTrustusersModel p where p.BF_TOUSER='"
                + userId + "'").OrderByDescending(p => p.BF_TRUSTDATE).ToList();
        }

        #endregion

        /// <summary>
        /// ��ȡָ���û���ǰ��Ȩί����Ϣ
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static int GetTrustUserByUserId(int userId)
        {
            int trustUserId = userId;
            BfTrustusersService srv = new BfTrustusersService();
            BfTrustusersModel trustModel = srv.GetListByUserId(userId).
                FirstOrDefault(p => (p.BF_TRUSTSTART <= DateTime.Now && p.BF_TRUSTEND >= DateTime.Now) && p.BF_TRUSTSTATUS == 1);
            if (trustModel != null && trustModel.BF_TOUSER.Value != null)
            {
                trustUserId = trustModel.BF_TOUSER.Value;
            }
            return trustUserId;
        }

    }

}
