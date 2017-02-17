using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
    /// <summary>
    /// 文件名:  BfPublishService.cs
    /// 功能描述: 业务逻辑层-业务流发布表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-4 12:18:57
    /// </summary>
    public class BfPublishService
    {

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IBfPublishData dal = new BfPublishData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<BfPublishModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfPublishModel model)
        {
            return dal.Execute(model);
        }

    }

}
