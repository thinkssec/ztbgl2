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
    /// 文件名:  CrmPersonService.cs
    /// 功能描述: 业务逻辑层-专家库数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/6/21 1:15:28
    /// </summary>
    public class CrmPersonService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmPersonData dal = new CrmPersonData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmPersonModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmPersonModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }
        public static CrmPersonModel getModel(int id){
            CrmPersonService s = new CrmPersonService();
            CrmPersonModel m = new CrmPersonModel();
            m = s.GetList().FirstOrDefault(f=>f.USRID==id);
            return m;
        }
	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmPersonModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmPersonModel model)
        {
            return dal.Execute(model);
        }
        public static string GetCacheClassKey()
        {
            return CrmPersonData.CacheClassKey;
        }
        #endregion
    }

}
