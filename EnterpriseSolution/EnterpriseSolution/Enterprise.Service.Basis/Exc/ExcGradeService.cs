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
    /// 文件名:  ExcGradeService.cs
    /// 功能描述: 业务逻辑层-异常等级表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:19:25
    /// </summary>
    public class ExcGradeService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExcGradeData dal = new ExcGradeData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExcGradeModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcGradeModel model)
        {
            return dal.Execute(model);
        }

    }

}
