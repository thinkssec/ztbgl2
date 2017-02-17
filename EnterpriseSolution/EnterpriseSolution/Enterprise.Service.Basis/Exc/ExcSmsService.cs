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
    /// 文件名:  ExcSmsService.cs
    /// 功能描述: 业务逻辑层-短信发送表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:19:29
    /// </summary>
    public class ExcSmsService
    {

        #region 未处理
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExcSmsData unhandleDal = new ExcSmsData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcSmsModel> GetUnhandleList()
        {
            return unhandleDal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteUnhandle(ExcSmsModel model)
        {
            return unhandleDal.Execute(model);
        }

        #endregion

        #region 已处理

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExcHandlesmsData handleDal = new ExcHandlesmsData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcHandlesmsModel> GetHandleList()
        {
            return handleDal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteHandle(ExcHandlesmsModel model)
        {
            return handleDal.Execute(model);
        }

        #endregion


    }

}
