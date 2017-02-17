using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Ui;
using Enterprise.Model.App.Ui;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.App.Ui
{
	
    /// <summary>
    /// 文件名:  UiCustomService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/12/3 13:48:43
    /// </summary>
    public class UiCustomService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IUiCustomData dal = new UiCustomData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<UiCustomModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<UiCustomModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 获取与ID对应的唯一记录
        /// </summary>
        /// <param name="cId"></param>
        /// <returns></returns>
        public UiCustomModel GetSingleById(string cId)
        {
            return dal.GetListByHQL("from UiCustomModel c where c.CUSTOMID='" + cId + "'").FirstOrDefault();
        }

	    /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<UiCustomModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(UiCustomModel model)
        {
            return dal.Execute(model);
        }

        #endregion

        /// <summary>
        /// 获取一个用户的定制界面对象
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UiCustomModel GetSingleByUserId(string userId)
        {
            return dal.GetListByHQL("from UiCustomModel where USERID='"+userId+"'").FirstOrDefault();
        }

        /// <summary>
        /// 获取一个用户的定制的Tab集合
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IList<UiTabModel> GetTabsByUserId(string userId)
        {
            IList<UiTabModel> list = new List<UiTabModel>();
            UiTabService uiTabService = new UiTabService();
            UiDefaultService uiDefaultService  = new UiDefaultService();
            string uiCustomContent = "0";
            var q = GetSingleByUserId(userId);
            if (q != null)
            {
                uiCustomContent = q.UICONTENT;
                var userUiTabList = uiTabService.GetListByHQL("from UiTabModel p where p.TABID in (" + ConvertSqlIn(uiCustomContent) + ")");
                if (userUiTabList != null)
                {
                    //按用户设定的顺序显示
                    string[] uiTabIds = uiCustomContent.Split(',');
                    foreach (string uiTabId in uiTabIds)
                    {
                        var model = userUiTabList.FirstOrDefault(p => p.TABID == uiTabId);
                        if (model != null)
                        {
                            list.Add(model);
                        }
                    }
                }
            }
            else
            {
                //mod by qw 2014.6.11 根据当前用户的所有角色提取所有定制功能 start
                SysUserRoleService userRoleSrv = new SysUserRoleService();
                var roleList = userRoleSrv.GetListByUserId(userId);
                //如果没有定制过 则显示该用户所有角色的默认内容
                var uiDefaultLst = uiDefaultService.GetListByRoles(roleList.Select(p => p.ROLEID).ToList<int>());
                StringBuilder uicontSB = new StringBuilder();
                foreach (var uiDefault in uiDefaultLst)
                {
                    uicontSB.Append(uiDefault.UICONTENT + ",");
                }
                list = uiTabService.GetListByHQL("from UiTabModel p where p.TABID in (" + ConvertSqlIn(uicontSB.ToString().TrimEnd(',')) + ")")
                    .OrderBy(p=>p.TABPX).ToList();
                //end
            }

            return list;
        }

        /// <summary>
        /// 获取首页Tab标签的HTml
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public string GetTabHtml(string userId)
        {
            string html = "";
            var q = GetTabsByUserId(userId);//.OrderBy(s=>s.TABPX);
            foreach (var t in q)
            {
                html += "<div title=\"" + t.TABNAME + "\" style=\"padding: 2px;\" href=\"/Modules/App/Ui/Iframe.aspx?url=" + t.TABURL + "\"></div>";
            }
            return html;
            
        }

        public string ConvertSqlIn(string uiContent)
        {
            string rtn = "";
            if (!string.IsNullOrEmpty(uiContent))
            {
                
                string[] str = uiContent.Split(',');
                foreach (string s in str)
                {
                    rtn += "'" + s + "',";
                }
                rtn = rtn.TrimEnd(',');
            }
            return rtn;
        }
        
    }

}
