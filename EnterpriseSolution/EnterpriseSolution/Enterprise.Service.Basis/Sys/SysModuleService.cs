using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using Enterprise.Component.Cache;
using Enterprise.Component.MVC;

namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysModuleService.cs
    /// 功能描述: 业务逻辑层-模块数据处理
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysModuleService
    {
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysModuleData dal = new SysModuleData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysModuleModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysModuleModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 系统模块记录 返回单个模块记录
        /// </summary>
        /// <param name="mId"></param>
        /// <returns></returns>
        public SysModuleModel ModuleDisp(string mId)
        {
            return GetList().Where(p => p.MODULEID == mId).FirstOrDefault();
        }

        #region 路由配置相关

        /// <summary>
        /// 加载所有模块的路由配置信息
        /// </summary>
        /// <returns></returns>
        public static List<UrlMapPageRoute> LoadUrlRoute()
        {
            List<UrlMapPageRoute> routeList = new List<UrlMapPageRoute>();
            var moduleList = dal.GetList();
            string urlPrefix = "~/";
            foreach (var m in moduleList)
            {
                if (!string.IsNullOrEmpty(m.MWEBURL) && !string.IsNullOrEmpty(m.MURL))
                {
                    UrlMapPageRoute route = new UrlMapPageRoute(
                        m.MODULEID, m.MWEBURL.TrimStart(urlPrefix.ToCharArray()), urlPrefix + m.MURL.TrimStart(urlPrefix.ToCharArray()));
                    routeList.Add(route);
                }
            }
            return routeList;
        }

        #endregion

        #region "模块排序相关"

        /// <summary>
        /// 系统模块上移一位
        /// </summary>
        /// <param name="Id"></param>
        public void ModuleMoveUpService(string Id)
        {
            var entity = ModuleDisp(Id);
            if (entity != null)
            {
                var upentity = GetList().
                    Where(p => p.MPARENTID == entity.MPARENTID && p.MORDERBY < entity.MORDERBY).
                    OrderByDescending(p => p.MORDERBY).FirstOrDefault();
                if (upentity != null)
                {
                    int tempV = upentity.MORDERBY.ToInt();
                    upentity.MORDERBY = entity.MORDERBY;
                    upentity.DB_Option_Action = WebKeys.UpdateAction;
                    Execute(upentity);

                    entity.MORDERBY = tempV;
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                    Execute(entity);
                }
            }
        }

        /// <summary>
        /// 系统模块下移一位
        /// </summary>
        /// <param name="Id"></param>
        public void ModuleMoveDownService(string Id)
        {
            var entity = ModuleDisp(Id);
            if (entity != null)
            {
                var downentity = GetList().
                    Where(p => p.MPARENTID == entity.MPARENTID && p.MORDERBY > entity.MORDERBY).
                    OrderBy(p => p.MORDERBY).FirstOrDefault();
                if (downentity != null)
                {

                    int tempV = downentity.MORDERBY.ToInt();
                    downentity.MORDERBY = entity.MORDERBY;
                    downentity.DB_Option_Action = WebKeys.UpdateAction;
                    Execute(downentity);

                    entity.MORDERBY = tempV;
                    entity.DB_Option_Action = WebKeys.UpdateAction;
                    Execute(entity);
                }
            }
        }

        /// <summary>
        /// 获取功能菜单模块最大排序值
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>
        public int GetMaxModuleOrderBy(string ParentId)
        {
            var q = GetList().Where(p => p.MPARENTID == ParentId).OrderByDescending(p => p.MORDERBY).FirstOrDefault();
            if (q != null)
            {
                return q.MORDERBY.ToInt();
            }
            return 0;
        }

        #endregion

        #region "获取模块名称"
        /// <summary>
        /// 获取模块名称
        /// </summary>
        /// <param name="moduleId"></param>
        /// <returns></returns>
        public static string GetModuleName(string moduleId)
        {
            SysModuleService mService = new SysModuleService();
            var query = mService.ModuleDisp(moduleId);
            if (query != null)
            {
                return query.MNAME;
            }
            return "";
        }
        #endregion

        #region "EasyUI-According折叠菜单Html"

        /// <summary>
        /// 获得折叠菜单的html
        /// </summary>
        /// <returns></returns>
        public string LoadAccordingHtml()
        {
            var list = GetList().ToList();
            string sMenu = CreateAccording(list, "0");
            return sMenu;
        }

        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="list"></param>
        /// <param name="Parentid"></param>
        /// <returns></returns>
        private string CreateAccording(List<SysModuleModel> list, string ParentId)
        {
            string _html = "";
            var q = list.Where(p => p.MPARENTID == ParentId && p.MDELETE == 0).OrderBy(p => p.MORDERBY);
            int i = 0;
            foreach (var t in q)
            {
                if (t.MSINGLE == 1)
                {
                    if (t.MNAME == "系统管理")
                    {
                        if (SysUserService.GetUserLoginName(Utility.Get_UserId) == "admin")
                        {
                            _html += string.Format("<li><a href=\"{1}\" target=\"_blank\">{0}</a>", SysDictionaryService.TransTo(t.MNAME), t.MURL == "" ? "#" : t.MURL);
                        }
                    }
                    else
                    {
                        _html += string.Format("<li ><a href=\"{1}\" target=\"_blank\">{0}</a>", SysDictionaryService.TransTo(t.MNAME), t.MURL == "" ? "#" : t.MURL);
                    }
                }
                else
                {
                    var childlist = list.Where(p => p.MPARENTID == t.MODULEID && p.MDELETE == 0).ToList();
                    //移除没有权限菜单
                    childlist = PermissionService.RemoveNoPermission(childlist);
                    if (childlist.Count > 0)
                    {
                        _html += string.Format("<li><a href=\"{1}\">{0}</a>", SysDictionaryService.TransTo(t.MNAME), t.MURL==""?"#":t.MURL);
                        _html += CreateChildAccording(list, t.MODULEID, i);
                    }
                }
                _html += "</li>";
                i++;
            }
            return _html;
        }

        /// <summary>
        /// According子菜单Html
        /// </summary>
        /// <param name="list"></param>
        /// <param name="IntParent"></param>
        /// <returns></returns>
        private string CreateChildAccording(List<SysModuleModel> list, string IntParent, int i)
        {
            string _html = "";
            var q = list.Where(p => p.MPARENTID == IntParent && p.MDELETE == 0).OrderBy(p => p.MORDERBY).ToList();
            //移除没有权限菜单
            q = PermissionService.RemoveNoPermission(q);
            _html += "<ul id=\"sub_" + i + "\">";
            foreach (var t in q)
            {
                var childlist = list.Where(p => p.MPARENTID == t.MODULEID && p.MDELETE == 0).OrderBy(p => p.MORDERBY).ToList();
                if (childlist.Count > 0)
                {
                    _html += string.Format("<li><a href=\"{1}\">{0}</a>", SysDictionaryService.TransTo(t.MNAME), t.MURL == "" ? "#" : t.MURL);
                    _html += CreateChildAccording(list, t.MODULEID, i);
                    _html += string.Format("</li>");
                }
                else
                {
                    if (t.MURL == "/Modules/Common/Article/ArticleList.aspx")
                    {
                        _html += string.Format("<li><a href=\"" + t.MURL + "?ModuleId=" + t.MODULEID + "\">" + SysDictionaryService.TransTo(t.MNAME) + "</a></li>");
                    }
                    else if (t.MURL == "/Modules/Common/Doc/DocList.aspx")
                    {
                        _html += string.Format("<li><a href=\"" + t.MURL + "?ModuleId=" + t.MODULEID + "\">" + SysDictionaryService.TransTo(t.MNAME) + "</a></li>");
                    }
                    else
                    {
                        if (t.MTARGET == "_blank")
                        {
                            if (t.MNAME == "人员考核" || t.MNAME == "机构考核")
                            {
                                //传递参数"key"，如："jian_li|zhcn|2013-03-13 15:36:42|公司领导|jian_li,jian_li_spc"
                                SysUserService userSrv = new SysUserService();
                                SysUserModel userModel = userSrv.Disp(Utility.Get_UserId);
                                string keys = string.Empty;
                                if (userModel != null)
                                {
                                    keys = userModel.ULOGINNAME + "|" + userModel.UDEFAULTLANGUAGE + "|"
                                        + DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss") + "|"
                                        + SysDepartmentService.GetDepartMentName(userModel.DEPTID) + "|"
                                        + ((t.MNAME == "人员考核") ? userModel.USYSTEM2 : userModel.USYSTEM1);
                                }
                                _html += string.Format("<li><a href=\"{0}?Key={3}\" target=\"{2}\">{1}</a></li>",
                                        t.MURL, SysDictionaryService.TransTo(t.MNAME), t.MTARGET, DESEncrypt.Encrypt(keys));
                            }
                            else
                            {
                                _html += string.Format("<li><a href=\"{0}\" target=\"{2}\">{1}</a></li>", t.MURL, SysDictionaryService.TransTo(t.MNAME), t.MTARGET);
                            }
                        }
                        else
                        {
                            _html += string.Format("<li><a href=\"{0}\">{1}</a></li>", t.MURL, SysDictionaryService.TransTo(t.MNAME));
                        }
                    }
                }
            }
            _html += "</ul>";
            return _html;
        }

        #endregion

        #region "Easyui-MenuButton 菜单Html"

        /// <summary>
        /// 用户一级菜单缓存项名称
        /// </summary>
        public static readonly string UserParentMenuCacheKey = SysRolePermissionData.CacheClassKey + "_UserParentMenuCacheKey";
        
        private string _EasyuiMenuButtonParentHtml;
        /// <summary>
        /// 一级菜单
        /// </summary>
        public string EasyuiMenuButtonParentHtml {
            get {
                if (WebKeys.EnableCaching)
                {
                    _EasyuiMenuButtonParentHtml = (string)
                        CacheHelper.GetCache(UserParentMenuCacheKey + "_" + Utility.Get_UserId);
                }
                return _EasyuiMenuButtonParentHtml; 
            }
            set { 
                this._EasyuiMenuButtonParentHtml = value;
                if (WebKeys.EnableCaching)
                {
                    CacheHelper.Add(UserParentMenuCacheKey + "_" + Utility.Get_UserId, _EasyuiMenuButtonParentHtml);
                }
            } 
        }

        /// <summary>
        /// 用户子菜单缓存项名称
        /// </summary>
        public static readonly string UserChildMenuCacheKey = SysRolePermissionData.CacheClassKey + "_UserChildMenuCacheKey";

        private string _EasyuiMenuButtonChildHtml;
        /// <summary>
        /// 子菜单
        /// </summary>
        public string EasyuiMenuButtonChildHtml
        {
            get {
                if (WebKeys.EnableCaching)
                {
                    _EasyuiMenuButtonChildHtml = (string)
                        CacheHelper.GetCache(UserChildMenuCacheKey + "_" + Utility.Get_UserId);
                }
                return _EasyuiMenuButtonChildHtml; 
            }
            set { 
                this._EasyuiMenuButtonChildHtml = value;
                if (WebKeys.EnableCaching)
                {
                    CacheHelper.Add(UserChildMenuCacheKey + "_" + Utility.Get_UserId, _EasyuiMenuButtonChildHtml);
                }
            }
        }

        public void CreateParentMenu(List<SysModuleModel> list, string parentId)
        {                        
            var q = list.Where(p => p.MPARENTID == parentId && p.MDELETE == 0).OrderBy(p => p.MORDERBY);
            int i = 0;
            foreach (var t in q)
            {
                if (t.MSINGLE == 1)
                {
                    if (t.MNAME == "系统管理")
                    {
                        if (SysUserService.GetUserLoginName(Utility.Get_UserId) == "admin")
                        {
                            EasyuiMenuButtonParentHtml += string.Format("<a href=\"{1}\" class=\"easyui-menubutton\" target=\"_blank\">{0}</a>", SysDictionaryService.TransTo(t.MNAME), getUrl(t));
                        }
                    }
                    else
                    {
                        EasyuiMenuButtonParentHtml += string.Format("<a href=\"{1}\" class=\"easyui-menubutton\" target=\"_blank\">{0}</a>", SysDictionaryService.TransTo(t.MNAME), getUrl(t));
                    }
                }
                else
                {
                    var childlist = list.Where(p => p.MPARENTID == t.MODULEID && p.MDELETE == 0).ToList();
                    //移除没有权限菜单
                    childlist = PermissionService.RemoveNoPermission(childlist);
                    if (childlist.Count > 0)
                    {
                        EasyuiMenuButtonParentHtml += string.Format("<a  class=\"easyui-menubutton\" data-options=\"menu:'#mm" + t.MODULEID + "',iconCls:'" + t.MIMAGE + "'\" href=\"{1}\">{0}</a>", SysDictionaryService.TransTo(t.MNAME), getUrl(t));
                        //如果有子菜单 创建子菜单 id为mm+Id
                        EasyuiMenuButtonChildHtml += "<div id=\"mm" + t.MODULEID + "\" style=\"display:none\">";

                        EasyuiMenuButtonChildHtml += CreateChildMenu(list, t.MODULEID, i);

                        EasyuiMenuButtonChildHtml += "</div>";
                    }
                }
                EasyuiMenuButtonParentHtml += "";
                i++;
            }            
        }

        public string CreateChildMenu(List<SysModuleModel> list, string IntParent, int i)
        {
            EasyuiMenuButtonChildHtml = "";
            var q = list.Where(p => p.MPARENTID == IntParent && p.MDELETE == 0).OrderBy(p => p.MORDERBY).ToList();
            //移除没有权限菜单
            q = PermissionService.RemoveNoPermission(q);            
            foreach (var t in q)
            {
                //再加图标从这里
                EasyuiMenuButtonChildHtml += "<div data-options=\"iconCls:'icon-online'\">";
                var childlist = list.Where(p => p.MPARENTID == t.MODULEID && p.MDELETE == 0).OrderBy(p => p.MORDERBY).ToList();
                if (childlist.Count > 0)
                {
                    EasyuiMenuButtonChildHtml += string.Format("<span><a href=\"{1}\" {2}>{0}</a></span>", SysDictionaryService.TransTo(t.MNAME), getUrl(t), ((t.MTARGET == "_blank") ? " target='_blank' " : ""));
                    EasyuiMenuButtonChildHtml += "<div>";
                    EasyuiMenuButtonChildHtml += CreateChildMenu(list, t.MODULEID, i);
                    EasyuiMenuButtonChildHtml += "</div>";
                }
                else
                {
                    string url = getUrl(t);
                    if (t.MNAME.Contains("交流论坛"))
                    {
                        url += SysUserService.GetBBSVerifyUrl(SysUserService.GetUserModelByUserId(Utility.Get_UserId));
                    }
                    //没有子节点
                    EasyuiMenuButtonChildHtml += string.Format("<a href=\"{1}\" {2}>{0}</a>", SysDictionaryService.TransTo(t.MNAME), url, ((t.MTARGET == "_blank") ? " target='_blank' " : ""));
                }
                EasyuiMenuButtonChildHtml += "</div>";
            }
            
            return EasyuiMenuButtonChildHtml;
        }

        /// <summary>
        /// 根据模块信息生成URL
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private string getUrl(SysModuleModel m)
        {
            string url = "#";
            if (!string.IsNullOrEmpty(m.MWEBURL))
            {
                url = m.MWEBURL + m.MWEBPARAM;
            }
            else if (!string.IsNullOrEmpty(m.MURL))
            {
                url = m.MURL;
            }
            return url;
        }

        #endregion
    }
}
