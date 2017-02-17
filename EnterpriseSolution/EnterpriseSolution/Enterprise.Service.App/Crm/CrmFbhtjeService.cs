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
    /// 文件名:  CrmFbhtjeService.cs
    /// 功能描述: 业务逻辑层-项目分包合同金额表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/12/11 11:28:02
    /// </summary>
    public class CrmFbhtjeService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmFbhtjeData dal = new CrmFbhtjeData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbhtjeModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbhtjeModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbhtjeModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbhtjeModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbhtjeModel GetSingle(string REQID, string FBHTID)
        {
            return dal.GetListByHQL("from CrmFbhtjeModel p where p.REQID = '" + REQID + "' and p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
        }
    }

}
