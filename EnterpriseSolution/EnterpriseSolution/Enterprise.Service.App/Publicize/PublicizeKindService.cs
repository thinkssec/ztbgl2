using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Publicize;
using Enterprise.Model.App.Publicize;

namespace Enterprise.Service.App.Publicize
{

    /// <summary>
    /// 文件名:  PublicizeKindService.cs
    /// 功能描述: 业务逻辑层-文章栏目表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/2/8 10:32:29
    /// </summary>
    public class PublicizeKindService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IPublicizeKindData dal = new PublicizeKindData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<PublicizeKindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(PublicizeKindModel model)
        {
            return dal.Execute(model);
        }


        #endregion
        public PublicizeKindModel GetSingle(string LMID)
        {
            return dal.GetListByHQL("from PublicizeKindModel p where p.LMID = '" + LMID + "'").FirstOrDefault();
        }

        public string GetLanMuName(string LMID)
        {
            PublicizeKindModel Model = dal.GetListByHQL("from PublicizeKindModel p where p.LMID = '" + LMID + "'").FirstOrDefault();
            if (Model != null)
            {
                return Model.LMMC;
            }
            else
                return "";
        }
    }

}
