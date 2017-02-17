using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Crm;
namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string q = context.Request["q"].ToRequestString();
            context.Response.ContentType = "text/javascript";
            context.Response.Cache.SetNoStore();
            string result = string.Empty;
            string hql = "from CrmInfoModel ORDER BY NLSSORT(CRMNAME,'NLS_SORT = SCHINESE_PINYIN_M')";
            if (!string.IsNullOrEmpty(q))
            {
                hql = "from CrmInfoModel where CRMNAME like '%" + q + "%' or CRMSERIAL like '%" + q.ToUpper() + "%' ORDER BY NLSSORT(CRMNAME,'NLS_SORT = SCHINESE_PINYIN_M')";
            }
            string key = CrmInfoService.GetCacheClassKey() + "_GetDWMC_" + hql;
            result = (string)CacheHelper.GetCache(key);
            if (string.IsNullOrEmpty(result))
            {
                IList<CrmInfoModel> list = new CrmInfoService().GetListByHQL(hql);
                System.Data.DataTable dt = list.ToDataTable();
                result = dt.ToJsonForComboGrid2("INFOID", "CRMNAME", "CRMKIND", "CRMPROPERTY", "CRMSERIAL");
                //存入缓存
                CacheHelper.Add(key, result);
            }
            context.Response.Write(result);
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