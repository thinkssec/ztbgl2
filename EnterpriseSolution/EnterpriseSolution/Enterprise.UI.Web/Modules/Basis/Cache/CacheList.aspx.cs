using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Control;
namespace Enterprise.UI.Web.Modules.Basis.Cache
{
    public partial class CacheList : Enterprise.Service.Basis.BasePage
    {

        //表名称
        string tn = (string)Utility.sink("tn", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 缓存管理服务类
        /// </summary>
        SysCacheService cacheSrv = new SysCacheService();
        /// <summary>
        /// 数据表变化记录集合
        /// </summary>
        private IList<SysTabChangeModel> tabChangeList = null;
        private IList<string> triggers = null;//当前用户的所有触发器

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }

            CreateBT.AddButton("new.gif", Trans("新增"), "CacheManage.aspx?Cmd=New", Utility.PopedomType.New, HeadMenu1);
        }

        private void OnStart()
        {
            if (Cmd == "Reload")
            {
                MyCacheManager.ReloadCache();
            }
            else if (Cmd == "TRI")
            {
                SysCacheService.CreateTriggerToTable(tn, WebKeys.DATABASE_USERNAME);
            }

            OnBindData();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void OnBindData()
        {
            triggers = cacheSrv.GetUserTriggers();
            tabChangeList = SysTabChangeService.GetAllTableChangeList();
            var list = SysCacheService.GetAllCacheList();
            if (!string.IsNullOrEmpty(Txt_TABLENAME.Text))
            {
                list = list.Where(p => p.TABLENAME.Contains(Txt_TABLENAME.Text)).ToList();
            }
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        /// <summary>
        /// 分页处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            OnBindData();
        }

        /// <summary>
        /// 数据表查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Bt_Search_Click(object sender, EventArgs e)
        {
            OnBindData();
        }

        /// <summary>
        /// 显示当前数据表的触发器状态
        /// </summary>
        /// <param name="dataItem"></param>
        /// <returns></returns>
        protected string ShowTriggerStatus(object dataItem)
        {
            string rr = string.Empty;
            SysCacheModel model = dataItem as SysCacheModel;
            if (model != null && triggers != null)
            {
                string trKey = string.Format("TRI_{0}_CHANGE", model.TABLENAME.ToUpper());
                if (triggers.Contains(trKey))
                {
                    //触发器已存在，则检查有无数据
                    rr = "触发器已设置";
                    if (tabChangeList.FirstOrDefault
                        (p => p.USERNAME == model.USERNAME && p.TABLENAME == model.TABLENAME) != null)
                    {
                        rr += "且有数据";
                    }
                    else
                    {
                        rr += ",<font color='orange'>没有数据</font>";
                    }
                }
                else
                {
                    //触发器不存在
                    rr = "<font color='red'>触发器不存在</font>";
                    rr += string.Format("【<a href='CacheList.aspx?tn={0}&Cmd=TRI'>设置</a>】", model.TABLENAME);
                }
            }
            return rr;
        }

    }
}