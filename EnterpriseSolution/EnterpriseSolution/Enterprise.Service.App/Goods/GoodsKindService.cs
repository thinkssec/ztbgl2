using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Goods;
using Enterprise.Model.App.Goods;

namespace Enterprise.Service.App.Goods
{
	
    /// <summary>
    /// 文件名:  GoodsKindService.cs
    /// 功能描述: 业务逻辑层-物资类别表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-11-5 15:48:12
    /// </summary>
    public class GoodsKindService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IGoodsKindData dal = new GoodsKindData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<GoodsKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<GoodsKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(GoodsKindModel model)
        {
            return dal.Execute(model);
        }
        #endregion


        #region 自定义方法

        /// <summary>
        /// 获取类型名称
        /// </summary>
        /// <param name="kindId"></param>
        /// <returns></returns>
        public static string GetKindName(string kindId)
        {
            GoodsKindModel model = dal.GetList().FirstOrDefault(p => p.KINDID == kindId);
            return (model != null) ? model.KINDNAME : "";
        }

        #endregion

    }

}
