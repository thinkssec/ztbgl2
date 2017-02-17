using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Document;
using Enterprise.Service.App.Document;
using Enterprise.Model.Common.Busitravel;
using Enterprise.Service.Common.Busitravel;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Document
{
    public partial class DownloadOfcFile : System.Web.UI.Page
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
                DocumentOfficialService aService = new DocumentOfficialService();
                var q = aService.GetList().FirstOrDefault(p=>p.DOCID==id);
                if (q != null)
                {
                    string[] afvns = q.FVIEWNAMES.TrimEnd('|').Split('|');
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
                                   
                                    if (!string.IsNullOrEmpty(file))
                                    {
                                        FileStream fs = new FileStream(docFile, FileMode.Open);
                                        byte[] bytes = new byte[(int)fs.Length];
                                        fs.Read(bytes, 0, bytes.Length);
                                        fs.Close();

                                        Response.ContentType = "application/octet-stream";
                                        Response.AddHeader("Content-Disposition", "attachment; filename=" +
                                            System.Web.HttpUtility.UrlEncode(System.Text.Encoding.GetEncoding(65001).GetBytes(Path.GetFileName(file))));
                                        Response.BinaryWrite(bytes);
                                        Response.Flush();
                                        Response.End();
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