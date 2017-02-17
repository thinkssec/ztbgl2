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
    /// 文件名:  CrmPbkindService.cs
    /// 功能描述: 业务逻辑层-乙方单位类别表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/3/31 17:16:05
    /// </summary>
    public class CrmPbkindService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmPbkindData dal = new CrmPbkindData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbkindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbkindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmPbkindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmPbkindModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 根据栏目ID返回栏目名称
        /// </summary>
        /// <param name="p"></param>
        public static string GetLMName(string lmId)
        {
            string hql = "from CrmPbkindModel p where p.LBBH='" + lmId + "'";
            return dal.GetListByHQL(hql).FirstOrDefault().LBMC;
        }
    }

}
