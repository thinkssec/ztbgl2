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
    /// �ļ���:  VoteResultService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/1 10:30:49
    /// </summary>
    public class VoteResultService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IVoteResultData dal = new VoteResultData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<VoteResultModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<VoteResultModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(VoteResultModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
