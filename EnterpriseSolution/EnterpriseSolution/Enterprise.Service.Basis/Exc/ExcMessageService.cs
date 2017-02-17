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
    /// 文件名:  ExcMessageService.cs
    /// 功能描述: 业务逻辑层-即时消息发送表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:19:28
    /// </summary>
    public class ExcMessageService
    {

        #region 未处理
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExcMessageData unhandleDal = new ExcMessageData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcMessageModel> GetUnhandleList()
        {
            return unhandleDal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteUnhandle(ExcMessageModel model)
        {
            return unhandleDal.Execute(model);
        }
        #endregion

        #region 已处理

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExcHandlemessageData handleDal = new ExcHandlemessageData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcHandlemessageModel> GetHandleList()
        {
            return handleDal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteHandle(ExcHandlemessageModel model)
        {
            return handleDal.Execute(model);
        }

        #endregion
    }

}
