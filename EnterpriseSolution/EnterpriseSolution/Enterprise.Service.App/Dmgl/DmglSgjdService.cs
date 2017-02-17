using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Dmgl;
using Enterprise.Model.App.Dmgl;

namespace Enterprise.Service.App.Dmgl
{
	
    /// <summary>
    /// 文件名:  DmglSgjdService.cs
    /// 功能描述: 业务逻辑层-施工进度数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/5/17 15:16:26
    /// </summary>
    public class DmglSgjdService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDmglSgjdData dal = new DmglSgjdData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DmglSgjdModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DmglSgjdModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DmglSgjdModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DmglSgjdModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
