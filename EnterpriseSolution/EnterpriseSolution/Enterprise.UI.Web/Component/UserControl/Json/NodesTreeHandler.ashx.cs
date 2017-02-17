using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Enterprise.Component.Infrastructure;
using Enterprise.Service.App.Examine;
using Enterprise.Model.App.Examine;

namespace Enterprise.UI.Web.Component.UserControl.Json
{
    /// <summary>
    /// 业务类型节点树生成程序
    /// </summary>
    public class NodesTreeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string kindId = context.Request.QueryString["Type"].ToRequestString();
            context.Response.ContentType = "text/javascript";//plain
            string js = string.Empty;
            //类型节点服务类
            ExamineNodesService nodeSrv = new ExamineNodesService();
            js = nodeSrv.GetNodesTreeJSONById(kindId.ToInt());
            context.Response.Write(js);
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