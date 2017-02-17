using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Office;
using Enterprise.Model.Common.Office;

namespace Enterprise.Service.Common.Office
{
	
    /// <summary>
    /// 文件名:  OfficeDocumentService.cs
    /// 功能描述: 业务逻辑层-公文流转表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-2-27 21:01:29
    /// </summary>
    public class OfficeDocumentService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IOfficeDocumentData dal = new OfficeDocumentData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<OfficeDocumentModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<OfficeDocumentModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        ///  根据ID值获取唯一数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OfficeDocumentModel GetModelById(string id)
        {
            return dal.GetModelById(id);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(OfficeDocumentModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
