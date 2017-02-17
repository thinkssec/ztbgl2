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
    /// 文件名:  ExcCheckruleService.cs
    /// 功能描述: 业务逻辑层-异常检查规则表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:19:23
    /// </summary>
    public class ExcCheckruleService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExcCheckruleData dal = new ExcCheckruleData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcCheckruleModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcCheckruleModel model)
        {
            return dal.Execute(model);
        }

    }

}
