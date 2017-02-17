using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Ui;
using Enterprise.Model.App.Ui;

namespace Enterprise.Service.App.Ui
{
	
    /// <summary>
    /// 文件名:  UiDefaultService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/12/3 13:48:42
    /// </summary>
    public class UiDefaultService
    {
                

        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IUiDefaultData dal = new UiDefaultData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<UiDefaultModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<UiDefaultModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<UiDefaultModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(UiDefaultModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public UiDefaultModel GetListById(string Id)
        {
            return dal.GetListByHQL("from UiDefaultModel where DefaultID='"+Id+"'").FirstOrDefault();
        }

        public UiDefaultModel GetListByRoleId(string RoleId)
        {
            return dal.GetListByHQL("from UiDefaultModel where ROLEID='" + RoleId + "'").FirstOrDefault();
        }

        /// <summary>
        /// 根据角色集合获取数据
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public IList<UiDefaultModel> GetListByRoles(IList<int> roles)
        {
            return dal.GetListByHQL("from UiDefaultModel where roleid in ("+ roles.ToJoin(',')+")");
        }

        /// <summary>
        /// 根据角色集合获取允许用户定制的索引
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public IList<string> GetListUserTabIndexByRoles(IList<int> roles)
        {
            List<string> rtnList = new List<string>();
            IList<UiDefaultModel> list = dal.GetListByHQL("from UiDefaultModel where roleid in (" + roles.ToJoin(',') + ")");
            foreach (var q in list)
            {
                if (q.UICONTENT != "")
                {
                    rtnList.AddRange(q.UICONTENT.Split(','));
                }                
            }
            //去除重复数据
            return rtnList.Distinct().ToList();
        }
    }

}
