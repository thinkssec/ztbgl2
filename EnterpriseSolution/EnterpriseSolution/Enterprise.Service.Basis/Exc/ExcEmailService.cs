using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Exc;
using Enterprise.Model.Basis.Exc;

namespace Enterprise.Service.Basis.Exc
{
    /// <summary>
    /// 文件名:  ExcEmailService.cs
    /// 功能描述: 业务逻辑层-邮件发送表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:19:24
    /// </summary>
    public class ExcEmailService
    {

        /// <summary>
        /// 得到未处理的EMAIL数据访问类实例
        /// </summary>
        private static readonly IExcEmailData unhandleDal = new ExcEmailData();
        /// <summary>
        /// 得到已处理的EMAIL数据访问类实例
        /// </summary>
        private static readonly IExcHandleemailData handleDal = new ExcHandleemailData();

        #region 未处理

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcEmailModel> GetUnhandleList()
        {
            return unhandleDal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteUnhandle(ExcEmailModel model)
        {
            return unhandleDal.Execute(model);
        }

        #endregion

        #region 已处理

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcHandleemailModel> GetHandleList()
        {
            return handleDal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteHandle(ExcHandleemailModel model)
        {
            return handleDal.Execute(model);
        }

        #endregion
    }

}
