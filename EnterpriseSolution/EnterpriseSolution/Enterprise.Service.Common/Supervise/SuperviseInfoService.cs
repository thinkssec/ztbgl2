using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Supervise;
using Enterprise.Model.Common.Supervise;

namespace Enterprise.Service.Common.Supervise
{
	
    /// <summary>
    /// 文件名:  SuperviseInfoService.cs
    /// 功能描述: 业务逻辑层-督办事务表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/13 10:53:09
    /// </summary>
    public class SuperviseInfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISuperviseInfoData dal = new SuperviseInfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseInfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SuperviseInfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 删除督办事务及办理明细
        /// </summary>
        /// <param name="dbid"></param>
        public void Delete(string dbid)
        {
            dal.Delete(dbid);
        }

        
    }

}
