using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Sbgl;
using Enterprise.Model.App.Sbgl;

namespace Enterprise.Service.App.Sbgl
{
	
    /// <summary>
    /// 文件名:  SbglTzService.cs
    /// 功能描述: 业务逻辑层-设备基础台账表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2015/4/28 15:01:25
    /// </summary>
    public class SbglTzService
    {
        #region 代码生成器

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISbglTzData dal = new SbglTzData();

	/// <summary>
        /// 根据主键获取唯一记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglTzModel GetSingle(string key)
        {
            return dal.GetSingle(key);
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SbglTzModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SbglTzModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SbglTzModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SbglTzModel model)
        {
            return dal.Execute(model);
        }

        #endregion

        /// <summary>
        /// 执行基于SQL的原生操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSQL(string sql)
        {
            return dal.ExecuteSQL(sql);
        }

        /// <summary>
        /// 按指定的动作名称完成数据集合的处理
        /// </summary>
        /// <param name="lst">数据集合</param>
        /// <param name="actionName">动作名称</param>
        /// <returns></returns>
        public bool ExecuteListByAction(IList<SbglTzModel> lst, string actionName)
        {
            bool isResult = false;
            foreach (var q in lst)
            {
                if (actionName == WebKeys.InsertAction)
                {
                    q.DB_Option_Action = WebKeys.InsertAction;
                    isResult = Execute(q);
                }
                else if (actionName == WebKeys.UpdateAction)
                {
                    q.DB_Option_Action = WebKeys.UpdateAction;
                    isResult = Execute(q);
                }
                else if (actionName == WebKeys.DeleteAction)
                {
                    q.DB_Option_Action = WebKeys.DeleteAction;
                    isResult = Execute(q);
                }
            }
            return isResult;
        }
    }

}
