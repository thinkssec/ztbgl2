using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;
using Enterprise.Model.Common.Busitravel;
using Enterprise.Service.Common.Busitravel;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.Common.Article
{
    public partial class DownloadFile : System.Web.UI.Page
    {
        ///// <summary>
        ///// 出差申请单实例ID
        ///// </summary>
        //protected string bid = (string)Utility.sink("bid", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 文档实例ID
        /// </summary>
        protected string id = (string)Utility.sink("id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 下载文件显示名称
        /// </summary>
        protected string fn = (string)Utility.sink("fn", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                ArticleInfoService aService = new ArticleInfoService();
                var q = aService.ArticleInfoDisp(id);
                if (q != null)
                {
                    ArticleDownloadService downloadSrv = new ArticleDownloadService();
                    string[] afvns = q.AFVIEWNAMES.TrimEnd('|').Split('|');
                    if (afvns != null)
                    {
                        for (int i = 0;  i < afvns.Length; i++)
                        {
                            string file = afvns[i].Split('*').First();
                            string path = afvns[i].Split('*').Last();
                            if (path.EndsWith(fn))
                            {
                                string docFile = Server.MapPath(path);
                                if (File.Exists(docFile))
                                {
                                    //记录下载情况
                                    ArticleDownloadModel dwldModel = new ArticleDownloadModel();
                                    dwldModel.ID = CommonTool.GetPkId();
                                    dwldModel.FILENAME = file;
                                    dwldModel.UIP = Utility.GetIPAddress();
                                    dwldModel.ULOGIN = Page.User.Identity.Name;
                                    dwldModel.XZRQ = DateTime.Now;
                                    dwldModel.ARTICLEID = q.ARTICLEID.ToString();
                                    dwldModel.DB_Option_Action = WebKeys.InsertAction;
                                    downloadSrv.Execute(dwldModel);
                                    if (!string.IsNullOrEmpty(file))
                                    {
                                        //开始下载
                                        Response.ContentType = "application/octet-stream";
                                        Response.AddHeader("Content-Disposition", "attachment; filename=" +
                                            System.Web.HttpUtility.UrlEncode(System.Text.Encoding.GetEncoding(65001).GetBytes(Path.GetFileName(fn))));
                                        //Response.ContentType = "application/pdf'";
                                        //Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(fn, System.Text.Encoding.UTF8));
                                        //Response.TransmitFile(docFile);
                                        break;
                                    }
                                }
                                else
                                {
                                    Response.Write(string.Format("<script>alert('{0}');</script>", "文件不存在！"));
                                }
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