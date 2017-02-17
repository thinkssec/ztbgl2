using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Vote;
using Enterprise.Model.Common.Vote;

namespace Enterprise.Service.Common.Vote
{
	
    /// <summary>
    /// �ļ���:  VoteItemService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/1 10:30:49
    /// </summary>
    public class VoteItemService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IVoteItemData dal = new VoteItemData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<VoteItemModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<VoteItemModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(VoteItemModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        #region "��̬����"
        /// <summary>
        ///  ��ȡѡ�����
        /// </summary>
        /// <param name="vId">ͶƱ���</param>
        /// <param name="itemId">ͶƱ����</param>
        /// <returns></returns>
        public static string GetVoteItemCode(string vId, int itemId)
        {
            VoteItemService viService = new VoteItemService();
            var query = viService.GetList("from VoteItemModel p where p.VID='"+vId+"'").Where(p => p.VITEMID == itemId).FirstOrDefault();
            if (query != null)
            {
                return query.VITEMCODE;
            }
            return "";
        }
        #endregion
    }

}
