using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Sbgl;
using Enterprise.Model.App.Sbgl;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.App.Sbgl
{
	
    /// <summary>
    /// 文件名:  SbglWxjhbService.cs
    /// 功能描述: 业务逻辑层-设备维修计划表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2015/4/30 8:22:37
    /// </summary>
    public class SbglWxjhbService
    {
        #region 代码生成器

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISbglWxjhbData dal = new SbglWxjhbData();

        /// <summary>
        /// 根据主键获取唯一记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglWxjhbModel GetSingle(string key)
        {
            return dal.GetSingle(key);
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SbglWxjhbModel model)
        {
            return dal.Execute(model);
        }

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
        public bool ExecuteListByAction(IList<SbglWxjhbModel> lst, string actionName)
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

        #endregion

        /// <summary>
        /// 根据填报人和日期进行查询
        /// </summary>
        /// <param name="yy">年</param>
        /// <param name="mm">月</param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListByTbrAndTbrq(string yy, string mm)
        {
            string hql = "from SbglWxjhbModel c where c.TBR='" + SysUserService.GetUserName(Utility.Get_UserId) + "' ";
            if (string.IsNullOrEmpty(mm))
            {
                hql += " and to_char(c.TBRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
            }
            else
            {
                hql += " and to_char(c.TBRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
            }
            return GetListByHQL(hql);
        }


        /// <summary>
        /// 根据送修日期进行查询
        /// </summary>
        /// <param name="yy">年</param>
        /// <param name="mm">月</param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListBySXRQ(string yy, string mm)
        {
            string hql = "from SbglWxjhbModel c where 1=1 ";
            if (string.IsNullOrEmpty(mm))
            {
                hql += " and to_char(c.SXRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
            }
            else
            {
                hql += " and to_char(c.SXRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
            }
            return GetListByHQL(hql);
        }


        /// <summary>
        /// 根据维修批号进行查询
        /// </summary>
        /// <param name="wxph">维修批号</param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListBySbwxph(string wxph)
        {
            string hql = "from SbglWxjhbModel c where c.SBWXPH='" + wxph + "' order by c.SBBH";
            return GetListByHQL(hql);
        }

    }

}
