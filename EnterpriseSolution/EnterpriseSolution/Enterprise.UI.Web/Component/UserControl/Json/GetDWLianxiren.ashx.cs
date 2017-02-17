using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Crm;
using System.Data;
using Enterprise.Component.Cache;

namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// GetDWLianxiren 的摘要说明
    /// </summary>
    public class GetDWLianxiren : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string result = string.Empty;
            string dwId = context.Request["DWID"].ToRequestString();
            context.Response.ContentType = "text/javascript";
            context.Response.Cache.SetNoStore();
            string key = CrmPersonService.GetCacheClassKey() + "_GetDWLianxiren_" + dwId;
            result = (string)CacheHelper.GetCache(key);
            if (string.IsNullOrEmpty(result))
            {
                List<CrmPersonModel> list = null;
                System.Data.DataTable dt = list.ToDataTable();
                if (!string.IsNullOrEmpty(dwId))
                {
                    string hql = "from CrmPersonModel p where p.INFOID ='" + dwId + "'";
                    list = new CrmPersonService().GetListByHQL(hql).ToList();
                }
                else
                {
                    list = new CrmPersonService().GetList().ToList();
                }
                if (list != null)
                {
                    string JsonData = "[";
                    foreach (var item in list)
                    {
                        JsonData += "{";
                        JsonData += "\"text\":\"" + item.PERSONNAME.ToRequestString() + "|" + item.DEPTNAME.ToRequestString() +
                            "|" + item.PHONE.ToRequestString() + "|" + item.EMAIL.ToRequestString() + "\",";
                        //JsonData += "\"id\":\"" + d[idField].ToString() + "\"},";
                        JsonData += "\"id\":\"" + item.PERSONID.ToString() + "\"},";
                    }
                    if (JsonData.Length > 1)
                        JsonData = JsonData.Remove(JsonData.Length - 1);
                    JsonData += "]";
                    result = JsonData;
                }
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