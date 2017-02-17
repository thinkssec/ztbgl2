using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Manager;
using Enterprise.Model.Common.Manager;

namespace Enterprise.Service.Common.Manager
{
	
    /// <summary>
    /// �ļ���:  ManagerMsgService.cs
    /// ��������: ҵ���߼���-�쵼�������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/27 17:55:12
    /// </summary>
    public class ManagerMsgService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IManagerMsgData dal = new ManagerMsgData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ManagerMsgModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// ���������б�
        /// ����
        ///  1�����ظ��������������˺ͻظ��˿��Կ�
        ///  2���ظ����Ƿ���Թ�����ȡ���ڻظ��˵����ã�����Ϊ������ʱ�������˺ͻظ��˿��Կ�
        /// </summary>
        /// <returns></returns>
        public List<ManagerMsgModel> ManagerMsgListByShow()
        {
            List<ManagerMsgModel> relist = new List<ManagerMsgModel>();
            var q = GetList().OrderByDescending(p => p.MSGCREATETIME);
            ManagerMsgReplyService rService = new ManagerMsgReplyService();
            foreach (ManagerMsgModel _msg in q)
            {
                //�������Ѿ��ظ�����������
                IList<ManagerMsgReplyModel> replylist = rService.GetList("from ManagerMsgReplyModel p where p.MSGID=" + _msg.MSGID);
                if (replylist.Count > 0)
                {
                    ManagerMsgReplyModel mr = replylist.OrderByDescending(p => p.REPLYTIME).FirstOrDefault();
                    if (mr != null)
                    {
                        if (Utility.Get_UserId == _msg.MSGFUSER || mr.REPLYISSHOW == 1)
                        {
                            relist.Add(_msg);
                        }
                    }
                }
            }
            return relist;
        }

        /// <summary>
        /// �յ�����������
        /// </summary>
        /// <returns></returns>
        public List<ManagerMsgModel> ManagerMsgListByOwn()
        {
            return GetList().Where(p => p.MSGTUSER == Utility.Get_UserId).OrderByDescending(p => p.MSGCREATETIME).ToList();
        }


        /// <summary>
        /// ��ȡָ���û��յ�����������
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ManagerMsgModel> ManagerMsgListByUserId(int userId)
        {
            return GetList().Where(p => p.MSGTUSER == userId).OrderByDescending(p => p.MSGCREATETIME).ToList();
        }
    }

}
