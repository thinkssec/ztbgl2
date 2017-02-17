using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Examine;
using Enterprise.Model.App.Examine;

namespace Enterprise.Service.App.Examine
{

    /// <summary>
    /// 文件名:  ExamineCostitemService.cs
    /// 功能描述: 业务逻辑层-成本费用项目表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2013-11-7 14:36:27
    /// </summary>
    public class ExamineCostitemService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExamineCostitemData dal = new ExamineCostitemData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostitemModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostitemModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineCostitemModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public ExamineCostitemModel GetSigle(string Id)
        {
            return dal.GetListByHQL("from ExamineCostitemModel p where p.ITEMCODE='" + Id + "'").FirstOrDefault();
        }
    }

}
