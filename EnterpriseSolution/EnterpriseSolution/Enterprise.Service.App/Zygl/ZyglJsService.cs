using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Zygl;
using Enterprise.Model.App.Zygl;

namespace Enterprise.Service.App.Zygl
{
	
    /// <summary>
    /// 文件名:  ZyglJsService.cs
    /// 功能描述: 业务逻辑层-作业结算数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/5/29 11:11:47
    /// </summary>
    public class ZyglJsService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IZyglJsData dal = new ZyglJsData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ZyglJsModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ZyglJsModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ZyglJsModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ZyglJsModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
