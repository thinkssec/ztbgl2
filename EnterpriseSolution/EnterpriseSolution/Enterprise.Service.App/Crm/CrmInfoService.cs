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
    /// 文件名:  CrmInfoService.cs
    /// 功能描述: 业务逻辑层-服务商数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/6/19 0:27:42
    /// </summary>
    public class CrmInfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmInfoData dal = new CrmInfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmInfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmInfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmInfoModel model)
        {
            return dal.Execute(model);
        }
        public static string GetCacheClassKey()
        {
            return CrmInfoData.CacheClassKey;
        }

        public static string GetCrmName(string crmId)
        {
            CrmInfoService cService = new CrmInfoService();
            var q = cService.GetList().Where(p => p.INFOID == crmId).FirstOrDefault();
            if (q != null)
            {
                return q.CRMNAME;
            }
            return "";
        }
        #endregion
    }

}
