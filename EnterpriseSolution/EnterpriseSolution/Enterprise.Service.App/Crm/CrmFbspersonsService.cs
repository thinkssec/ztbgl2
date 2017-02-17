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
    /// 文件名:  CrmFbspersonsService.cs
    /// 功能描述: 业务逻辑层-分包商联系人表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2013/12/11 11:28:04
    /// </summary>
    public class CrmFbspersonsService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmFbspersonsData dal = new CrmFbspersonsData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbspersonsModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbspersonsModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbspersonsModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbspersonsModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbspersonsModel GetSingle(string PERID)
        {
            return dal.GetListByHQL("from CrmFbspersonsModel p where p.PERID = '" + PERID + "'").FirstOrDefault();
        }


        /// <summary>
        /// 返回联系人姓名
        /// </summary>
        /// <param name="perId">联系人Id</param>
        /// <returns></returns>
        public static string GetLXRPhone(string perId)
        {
            CrmFbspersonsService Service = new CrmFbspersonsService();
            var q = Service.GetList().Where(p => p.PERID == perId).FirstOrDefault();
            if (q != null)
            {
                return q.NAME;
            }
            return "";
        }

        /// <summary>
        /// 返回联系人联系电话
        /// </summary>
        /// <param name="perId">部门编号</param>
        /// <returns></returns>
        public static string GetLXRName(string perId)
        {
            CrmFbspersonsService Service = new CrmFbspersonsService();
            var q = Service.GetList().Where(p => p.PERID == perId).FirstOrDefault();
            if (q != null)
            {
                return q.PHONE;
            }
            return "";
        }
    }
}
