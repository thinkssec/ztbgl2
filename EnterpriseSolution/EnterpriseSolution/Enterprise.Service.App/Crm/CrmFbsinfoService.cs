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
    /// 文件名:  CrmFbsinfoService.cs
    /// 功能描述: 业务逻辑层-分包商信息表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2013/12/11 11:28:04
    /// </summary>
    public class CrmFbsinfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmFbsinfoData dal = new CrmFbsinfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbsinfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbsinfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbsinfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbsinfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbsinfoModel GetSingle(string fbsId)
        {
            return dal.GetListByHQL("from CrmFbsinfoModel p where p.FBSID = '" + fbsId + "'").FirstOrDefault();
        }

        /// <summary>
        ///  返回分包商名称
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetFBSName(string fbsId)
        {
            CrmFbsinfoService service = new CrmFbsinfoService();
            var q = service.GetList().Where(p => p.FBSID == fbsId).FirstOrDefault();
            if (q != null)
            {
                return q.FBSMC;
            }
            return "";
        }
    }

}
