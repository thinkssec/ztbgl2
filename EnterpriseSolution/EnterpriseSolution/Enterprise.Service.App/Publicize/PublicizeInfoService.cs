using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Publicize;
using Enterprise.Model.App.Publicize;
using Enterprise.Service.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Common.Article;


namespace Enterprise.Service.App.Publicize
{

    /// <summary>
    /// 文件名:  PublicizeInfoService.cs
    /// 功能描述: 业务逻辑层-宣传报道投稿数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/2/8 10:32:28
    /// </summary>
    public class PublicizeInfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IPublicizeInfoData dal = new PublicizeInfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<PublicizeInfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<PublicizeInfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(PublicizeInfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public PublicizeInfoModel GetSingle(string pubId)
        {
            return dal.GetListByHQL("from PublicizeInfoModel p where p.PUBID='" + pubId + "'").FirstOrDefault();
        }
        /// <summary>
        /// 显示审核状态
        /// </summary>
        /// <returns></returns>
        public static string Getstatus(int STATUS)
        {
            if (STATUS == 0)
            {
                return "未审核";
            }
            if (STATUS == 1)
            {
                return "审核通过";
            }
            if (STATUS == 2)
            {
                return "未通过审核";
            }
            if (STATUS == 3)
            {
                return "已发布";
            }
            return "";

        }
        /// <summary>
        /// 获取审核人员信息，实为党政办公室主任
        /// </summary>
        /// <returns></returns>
        public int GetChecker()
        {
            SysDepartmentService Dservice = new SysDepartmentService();
            SysDepartMentModel Model = Dservice.DepartmentDisp(122);
            return Model.DMANAGER.ToInt();
        }
    }

}
