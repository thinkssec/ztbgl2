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
    /// 文件名:  BfTrustusersService.cs
    /// 功能描述: 业务逻辑层-事务代办表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-26 15:29:32
    /// </summary>
    public class BfTrustusersService
    {

        #region 代码生成器

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBfTrustusersData dal = new BfTrustusersData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfTrustusersModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfTrustusersModel> GetList(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfTrustusersModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取指定用户的所有授权委托
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<BfTrustusersModel> GetListByUserId(int userId)
        {
            return dal.GetListByHQL("from BfTrustusersModel p where p.BF_FROMUSER='" 
                + userId + "'").OrderByDescending(p=>p.BF_TRUSTDATE).ToList();
        }

        /// <summary>
        /// 获取所有委托给指定用户授权
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
        /// 获取指定用户当前授权委托信息
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
