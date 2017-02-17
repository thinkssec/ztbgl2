using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;
using Enterprise.Model.Common.Busitravel;
using Enterprise.Service.Common.Busitravel;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Component.FlexPaper
{
    /// <summary>
    /// PDF 查看器
    /// </summary>
    public partial class PdfViewer : System.Web.UI.Page
    {
        /// <summary>
        /// 帮助文件swf名称
        /// </summary>
        protected string swfFn = (string)Utility.sink("swfFn", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 出差申请单实例ID
        /// </summary>
        protected string bid = (string)Utility.sink("bid", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 文档实例ID
        /// </summary>
        protected string id = (string)Utility.sink("id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 下载文件显示名称
        /// </summary>
        protected string fn = (string)Utility.sink("fn", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// PDF转为SWF格式后的文件名称（含路径）
        /// </summary>
        protected string SwfFileName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        /// <summary>
        /// 初始化数据内容
        /// </summary>
        private void OnStart()
        {
            if (!string.IsNullOrEmpty(swfFn))
            {
                //帮助文件swf
                SwfFileName = "/Help/" + swfFn + ".swf";
            }
            else if (!string.IsNullOrEmpty(bid))
            {
                //出差
                BusitravelSummaryService summarySrv = new BusitravelSummaryService();
                var q = summarySrv.GetModelById(bid);
                if (q != null)
                {
                    string[] afns = q.BILL.TrimEnd('|').Split('|');
                    if (afns != null && afns.Length > 0)
                    {
                        string[] billFile = afns[0].Split(';');
                        if (billFile != null && billFile.Length == 2)
                        {
                            SwfFileName = billFile[1].Replace("//", "/").Replace(".pdf", ".swf");
                        }
                    }
                    else
                    {
                        Response.Write(string.Format("<script>alert('{0}');</script>", "凭证文件名称不匹配！"));
                    }
                }
            }
            else if (!string.IsNullOrEmpty(id))
            {
                //文档
                ArticleInfoService aService = new ArticleInfoService();
                var q = aService.ArticleInfoDisp(id);
                if (q != null && !string.IsNullOrEmpty(q.AFNAMES) && !string.IsNullOrEmpty(q.AFVIEWNAMES))
                {
                    string[] afns = q.AFNAMES.TrimEnd('|').Split('|');
                    string[] afvns = q.AFVIEWNAMES.TrimEnd('|').Split('|');
                    if (afns != null && afvns != null
                        && afns.Length > 0 && afns.Length == afvns.Length)
                    {
                        for (int i = 0; i < afns.Length && i < afvns.Length; i++)
                        {
                            if (afvns[i].EndsWith(fn) && !string.IsNullOrEmpty(afvns[i]))
                            {
                                SwfFileName = afvns[i].Replace("//", "/").Replace(".pdf", ".swf");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Response.Write(string.Format("<script>alert('{0}');</script>", "文件名称不匹配！"));
                    }
                }
                else
                {
                    Response.Write(string.Format("<script>alert('{0}');</script>", "文件不存在！"));
                }
            }
        }
    }
}