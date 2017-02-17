using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Document;
using Enterprise.Service.App.Document;
using Enterprise.Service.Basis.Sys;
using System.IO;

namespace Enterprise.UI.Web.Modules.App.Document
{
    public partial class DownloadFile : System.Web.UI.Page
    {
        protected string id = (string)Utility.sink("id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string fn = (string)Utility.sink("fn", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected string kind = (string)Utility.sink("Kind", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(id))
            {
                DocumentDownloadsService downloadSrv = new DocumentDownloadsService();
                string[] afvns;
                ///下载原文件信息
                if (kind == "LoadYuan")
                {
                    DocumentProjService dService = new DocumentProjService();
                    DocumentProjModel q = dService.GetSingle(id);
                    if (q != null)
                    {
                        FileInfo fInfo = new FileInfo(Server.MapPath(q.DOCPATH));
                        if (fInfo.Exists)
                        {
                            afvns = new string[] { q.DOCNAME + fInfo.Extension + "*" + q.DOCPATH };
                            //afvns = q.DOCPATH.TrimEnd('|').Split('|');
                            DoDownLoad(downloadSrv, afvns);
                        }
                        else
                        {
                            Response.Write(string.Format("<script>alert('{0}');</script>", "文件不存在！"));
                        }
                    }
                }
                ///下载转换路径的文件
                else
                {
                    DocumentConvertService DCservice = new DocumentConvertService();
                    DocumentConvertModel q = DCservice.GetModelByCvtId(DCservice.GetListByDocId(id).Where(p=>p.CVTTYPE=="pdf").FirstOrDefault().CVTID);
                    if (q != null)
                    {
                        FileInfo fInfo = new FileInfo(Server.MapPath(q.CVTPATH));
                        if (fInfo.Exists)
                        {
                            afvns = new string[] { q.DocumentProj.DOCNAME + fInfo.Extension + "*" + q.CVTPATH };
                            //afvns = q.CVTPATH.TrimEnd('|').Split('|');
                            DoDownLoad(downloadSrv, afvns);
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
                Response.Write(string.Format("<script>alert('{0}');</script>", "文件不存在！"));
            }
        }

        private void DoDownLoad(DocumentDownloadsService downloadSrv, string[] afvns)
        {
            if (afvns != null)
            {
                for (int i = 0; i < afvns.Length; i++)
                {
                    string file = afvns[i].Split('*').First();
                    string path = afvns[i].Split('*').Last();
                    if (path.EndsWith(fn))
                    {
                        string docFile = Server.MapPath(path);
                        if (File.Exists(docFile))
                        {
                            //记录下载情况
                            DocumentDownloadsModel dwldModel = new DocumentDownloadsModel();
                            dwldModel.ID = CommonTool.GetPkId();
                            dwldModel.DOCID = id;
                            dwldModel.IPADDR = Utility.GetIPAddress();
                            dwldModel.DOWNLOADDATE = DateTime.Now;
                            dwldModel.USERID = Utility.Get_UserId;
                            dwldModel.USERNAME = Page.User.Identity.Name;
                            dwldModel.LOOKUPDATE = DateTime.Now;
                            dwldModel.DB_Option_Action = WebKeys.InsertAction;
                            downloadSrv.Execute(dwldModel);
                            if (!string.IsNullOrEmpty(file))
                            {
                                //开始下载
                                Response.ContentType = "application/octet-stream";
                                Response.AddHeader("Content-Disposition", "attachment; filename=" +
                                    System.Web.HttpUtility.UrlEncode(System.Text.Encoding.GetEncoding(65001).GetBytes(Path.GetFileName(file))));
                                Response.TransmitFile(docFile);
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
    }
}