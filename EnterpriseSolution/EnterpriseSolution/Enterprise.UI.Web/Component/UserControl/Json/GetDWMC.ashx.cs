using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

using Enterprise.Component.Cache;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Crm;


namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// GetDWMC 的摘要说明
    /// </summary>
    public class GetDWMC : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           // string dId = context.Request["DepId"].ToRequestString();
            context.Response.ContentType = "text/javascript";
            context.Response.Cache.SetNoStore();
            string result = string.Empty;
            string hql = "from CrmInfoModel ORDER BY NLSSORT(CRMNAME,'NLS_SORT = SCHINESE_PINYIN_M')";
            string key = CrmInfoService.GetCacheClassKey() + "_GetDWMC_" + hql;
            result = (string)CacheHelper.GetCache(key);
            if (string.IsNullOrEmpty(result))
            {
                IList<CrmInfoModel> list = new CrmInfoService().GetListByHQL(hql);
                System.Data.DataTable dt = list.ToDataTable();
                result = dt.ToJsonForComboGrid("INFOID", "CRMNAME", "CRMADDR", "CRMPROPERTY");
                //存入缓存
                CacheHelper.Add(key, result);
            }
            context.Response.Write(result);
            // if (string.IsNullOrEmpty(dId))
            // {
            // }
            // else
            // {
            //     hql = "from CrmInfoModel p where p.INFOID='" + dId + "' ORDER BY NLSSORT(CRMNAME,'NLS_SORT = SCHINESE_PINYIN_M')";
            // }
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