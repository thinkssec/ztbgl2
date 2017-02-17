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
    /// 文件名:  VoteItemService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/1 10:30:49
    /// </summary>
    public class VoteItemService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IVoteItemData dal = new VoteItemData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<VoteItemModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<VoteItemModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(VoteItemModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        #region "静态方法"
        /// <summary>
        ///  获取选项序号
        /// </summary>
        /// <param name="vId">投票编号</param>
        /// <param name="itemId">投票项编号</param>
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
