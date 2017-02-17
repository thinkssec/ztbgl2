using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enterprise.Service.App.Examine;
using Enterprise.Component.Cache;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.App;
using System.Data;

namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// 获取指定检验类型的所有子级节点
    /// </summary>
    public class ExamineTypeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sjdm = context.Request.QueryString["sjdm"].ToRequestString();
            string kind = context.Request.QueryString["kind"].ToRequestString();
            string selectValue = context.Request.QueryString["v"].ToRequestString();
            //context.Response.ContentType = "text/javascript";
            context.Response.Cache.SetNoStore();
            DataTable examineTypeDt = AppDataService.GetDataTable("APP_EXAMINE_PROCESS", "BJDM|BJMC|SJDM|KINDID|CJSX");
            DataView dv = examineTypeDt.DefaultView;
            dv.RowFilter = "SJDM like '" + sjdm + "%' and KINDID='" + kind + "'";
            dv.Sort = "BJDM,CJSX";
            //加入缓存处理 2014.1.3 by qw start
            string json = string.Empty;
            string key = ExamineProcessService.GetCacheKey() + "_ExamineTypeHandler_" + sjdm + "_" + kind + "_" + selectValue;
            if (WebKeys.EnableCaching)
            {
                json = (string)CacheHelper.GetCache(key);
            }
            if (string.IsNullOrEmpty(json))
            {
                json = dv.ToTable().ToJsonForEasyuiComboTree("BJDM", "BJMC", "SJDM", sjdm, selectValue);
                if (WebKeys.EnableCaching)
                {
                    //数据存入缓存系统
                    CacheHelper.Add(key, json);
                }
            }
            //end
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}