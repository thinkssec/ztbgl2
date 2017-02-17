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
    /// 文件名:  SysTabChangeService.cs
    /// 功能描述: 业务逻辑层-数据表更新记录表数据处理
    /// 创建人：qw
    /// 创建日期: 2013.1.21
    /// </summary>
    public class SysTabChangeService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysTabChangeData dal = new SysTabChangeData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysTabChangeModel> GetList()
        {
            return dal.GetList();
        }


        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysTabChangeModel model)
        {
            return dal.Execute(model);
        }


        #region 静态方法

        /// <summary>
        /// 返回数据表更新记录表中的所有信息集合
        /// </summary>
        /// <returns></returns>
        public static IList<SysTabChangeModel> GetAllTableChangeList() 
        {
            return dal.GetList();
        }

        #endregion

    }

}
