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
    /// 文件名:  ManagerMsgreplyService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/27 17:55:13
    /// </summary>
    public class ManagerMsgReplyService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IManagerMsgReplyData dal = new ManagerMsgReplyData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgReplyModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ManagerMsgReplyModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ManagerMsgReplyModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
