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
    /// 文件名:  CrmPbinfoService.cs
    /// 功能描述: 业务逻辑层-乙方单位信息表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/3/31 17:16:03
    /// </summary>
    public class CrmPbinfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmPbinfoData dal = new CrmPbinfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbinfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbinfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmPbinfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmPbinfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmPbinfoModel GetSingle(string pId)
        {
            string hql = "from CrmPbinfoModel p where p.PBBM='" + pId + "'";
            return dal.GetListByHQL(hql).FirstOrDefault();
        }

        /// <summary>
        ///获取状态：可用、已过时
        /// </summary>
        /// <param name="nullable"></param>
        /// <returns></returns>
        public static string GetSTATUS(int? STATUS)
        {
            if (STATUS == 1)
            {
                return "可用";
            }
            else
            {
                return "已过时";
            }
        }
    }

}
