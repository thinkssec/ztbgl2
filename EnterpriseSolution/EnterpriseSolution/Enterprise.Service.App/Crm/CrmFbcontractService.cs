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
    /// 文件名:  CrmFbcontractService.cs
    /// 功能描述: 业务逻辑层-分包合同表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/12/11 11:28:01
    /// </summary>
    public class CrmFbcontractService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmFbcontractData dal = new CrmFbcontractData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbcontractModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbcontractModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbcontractModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbcontractModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbcontractModel GetSingle(string FBHTID)
        {
            return dal.GetListByHQL("from CrmFbcontractModel p where p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
        }

        /// <summary>
        /// 返回合同金额
        /// </summary>
        /// <param name="FBHTID"></param>
        /// <returns></returns>
        public static string GetHTJE(string FBHTID)
        {
            CrmFbcontractModel Model = dal.GetListByHQL("from CrmFbcontractModel p where p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
            if (Model!=null)
            {
                return Model.HTJE.ToRequestString();
            }
            return "";
        }

        /// <summary>
        /// 返回联系人
        /// </summary>
        /// <param name="FBHTID"></param>
        /// <returns></returns>
        public static string GetGLXTID(string FBHTID)
        {
            CrmFbcontractModel Model = dal.GetListByHQL("from CrmFbcontractModel p where p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
            if (Model != null)
            {
                return Model.GLXTID;
            }
            return "";
        }

        /// <summary>
        /// 返回分包合同名称
        /// </summary>
        /// <param name="FBHTID"></param>
        /// <returns></returns>
        public static string GetContractName(string FBHTID)
        {
            CrmFbcontractModel Model = dal.GetListByHQL("from CrmFbcontractModel p where p.FBHTID = '" + FBHTID + "'").FirstOrDefault();
            if (Model != null)
            {
                return Model.FBHTNAME;
            }
            return "";
        }
    }

}
