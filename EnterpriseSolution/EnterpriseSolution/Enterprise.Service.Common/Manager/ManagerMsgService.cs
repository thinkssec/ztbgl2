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
    /// 文件名:  ManagerMsgService.cs
    /// 功能描述: 业务逻辑层-领导信箱数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/27 17:55:12
    /// </summary>
    public class ManagerMsgService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IManagerMsgData dal = new ManagerMsgData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ManagerMsgModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 汇总留言列表
        /// 规则：
        ///  1、不回复不公开，留言人和回复人可以看
        ///  2、回复后是否可以公开，取决于回复人的设置，设置为不公开时，留言人和回复人可以看
        /// </summary>
        /// <returns></returns>
        public List<ManagerMsgModel> ManagerMsgListByShow()
        {
            List<ManagerMsgModel> relist = new List<ManagerMsgModel>();
            var q = GetList().OrderByDescending(p => p.MSGCREATETIME);
            ManagerMsgReplyService rService = new ManagerMsgReplyService();
            foreach (ManagerMsgModel _msg in q)
            {
                //把所有已经回复的留言内容
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
        /// 收到的所有留言
        /// </summary>
        /// <returns></returns>
        public List<ManagerMsgModel> ManagerMsgListByOwn()
        {
            return GetList().Where(p => p.MSGTUSER == Utility.Get_UserId).OrderByDescending(p => p.MSGCREATETIME).ToList();
        }


        /// <summary>
        /// 提取指定用户收到的所有留言
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ManagerMsgModel> ManagerMsgListByUserId(int userId)
        {
            return GetList().Where(p => p.MSGTUSER == userId).OrderByDescending(p => p.MSGCREATETIME).ToList();
        }
    }

}
