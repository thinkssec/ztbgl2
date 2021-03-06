using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Service.Basis.Sys
{
	
    /// <summary>
    /// 文件名:  SysUserindividService.cs
    /// 功能描述: 业务逻辑层-个性化设置表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-7-3 11:42:29
    /// </summary>
    public class SysUserindividService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysUserindividData dal = new SysUserindividData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserindividModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 获取指定ID的数据
        /// </summary>
        /// <returns></returns>
        public SysUserindividModel GetModelById(int id)
        {
            return dal.GetModelById(id);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysUserindividModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
