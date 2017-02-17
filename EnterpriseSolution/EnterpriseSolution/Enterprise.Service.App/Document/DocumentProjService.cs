using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Document;
using Enterprise.Model.App.Document;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.App.Document
{

    /// <summary>
    /// 文件名:  DocumentProjService.cs
    /// 功能描述: 业务逻辑层-业务文档库数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2014/3/6 8:25:03
    /// </summary>
    public class DocumentProjService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IDocumentProjData dal = new DocumentProjData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentProjModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocumentProjModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentProjModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocumentProjModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取同一文档类型的list
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DocumentProjModel> GetListByDKind(string DKid)
        {
            string hql = "from DocumentProjModel p where p.LBBH='" + DKid + "' order by p.DOCSAVEDATE desc";
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 获得唯一的DocumentProjModel实例
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DocumentProjModel GetSingle(string DOCID)
        {
            string hql = "from DocumentProjModel p where p.DOCID='" + DOCID + "'";
            return dal.GetListByHQL(hql).FirstOrDefault();
        }

        #endregion

        /// <summary>
        /// 获取文档状态
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetDOCSTATUS(int p)
        {
            if (p == 0)
            {
                return "已存档";
            }
            if (p == 1)
            {
                return "已转换";
            }
            if (p == 2)
            {
                return "不开放";
            }
            else return "";
        }
        /// <summary>
        /// 获取下载文件或在线预览文件
        /// </summary>
        /// <param name="DPmode"></param>
        /// <param name="kind"></param>
        /// <returns></returns>
        public static string ToAttachHtml(DocumentProjModel DPmode, string kind)
        {
            //string dbFilesName = DPmode.DOCPATH;
            DocumentConfigService DcService = new DocumentConfigService();
            DocumentDownloadsService DDService = new DocumentDownloadsService();
            DocumentConvertService ser = new DocumentConvertService();
            // string html = "<ul>";
            string html = "";
            var configQuery = DcService.GetList().FirstOrDefault();
            if (kind == "DownLoad")
            {
                var q = ser.GetListByDocId(DPmode.DOCID);
                if (q.Count != 0)
                {
                    if (q.Where(p => p.CVTTYPE == "pdf").FirstOrDefault().CVTPATH != null)
                    {
                        string FilesPath = q.Where(p => p.CVTTYPE == "pdf").FirstOrDefault().CVTPATH;
                        //if (!string.IsNullOrEmpty(dbFilesName))
                        //{
                        if (!string.IsNullOrEmpty(FilesPath))
                        {
                            if (configQuery != null && configQuery.SFYXXZ == 1)
                            {
                                ///将浏览信息存入数据库 
                                //InsertDownLoadModel(DPmode);
                                // string[] str = dbFilesName.Split('|');
                                string[] str = FilesPath.Split('|');
                                for (int i = 0; i < str.Length; i++)
                                {
                                    string[] tmp = str[i].Split('*');
                                    string ext = System.IO.Path.GetExtension(Utility.GetFileExt(tmp.Last()));
                                    string hql = string.Format("from DocumentDownloadsModel p where p.DOWNLOADDATE is not null and p.DOCID ='{0}'", DPmode.DOCID);
                                    int DownLoadCount = DDService.GetListByHQL(hql).Count;
                                    html += string.Format("<a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-" + ext.Replace(".", "") + "',plain:true\" href=\"/Modules/App/Document/DownloadFile.aspx?id={0}&fn={1}&Kind=LoadXianyou\" target='_blank'>{2}</a>  [{3}次]",
                                     DPmode.DOCID,
                                     FileHelper.Encrypt(tmp.Last()),
                                        //tmp.First(),
                                     DPmode.DOCNAME,
                                     DownLoadCount);
                                }
                            }

                            else
                            {
                                html += string.Format("<script>alert('{0}');</script>", "文档不允许下载！");
                            }
                        }
                    }
                }

                ///如果转换文件为空，但是又允许下载时下载源文件信息
                else
                {
                    if (configQuery != null && configQuery.SFYXXZ == 1)
                    {
                        if (DPmode.DOCPATH != null)
                        {
                            string dbFilesName = DPmode.DOCPATH;
                            string[] str = dbFilesName.Split('|');
                            for (int i = 0; i < str.Length; i++)
                            {
                                string[] tmp = str[i].Split('*');
                                string ext = System.IO.Path.GetExtension(Utility.GetFileExt(tmp.Last()));
                                string hql = string.Format("from DocumentDownloadsModel p where p.DOWNLOADDATE is not null and p.DOCID ='{0}'", DPmode.DOCID);
                                int DownLoadCount = DDService.GetListByHQL(hql).Count;
                                html += string.Format("<a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-" + ext.Replace(".", "") + "',plain:true\" href=\"/Modules/App/Document/DownloadFile.aspx?id={0}&fn={1}&Kind=LoadYuan\" target='_blank'>{2}</a>  [{3}次]",
                                 DPmode.DOCID,
                                 FileHelper.Encrypt(tmp.Last()),
                                    //tmp.First(),
                                 DPmode.DOCNAME,
                                 DownLoadCount);
                            }
                        }
                    }

                }
            }

            if (kind == "View")
            { ///将浏览信息存入数据库  
                InsertDownLoadModel(DPmode);
                string hql = string.Format("from DocumentDownloadsModel p where p.DOWNLOADDATE is null and p.DOCID ='{0}'", DPmode.DOCID);
                int ViewCount = DDService.GetListByHQL(hql).Count;
                DocumentConvertModel Mod = ser.GetListByDocId(DPmode.DOCID).Where(p => p.CVTTYPE == "swf").FirstOrDefault();
                if (Mod != null && Mod.CVTPATH != null)
                {
                    html += string.Format("<a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-" + Mod.CVTTYPE + "',plain:true\" href=\"/Component/FlexPaper/DocLibViewer.aspx?id={0}\" target='_blank'>{1}</a>  [{2}次]",
                        Mod.CVTID,
                        //Mod.CVTNAME,
                        DPmode.DOCNAME,
                        ViewCount);
                }
                //add by qw 2014.5.20
                DocumentConvertModel pdfMod = ser.GetListByDocId(DPmode.DOCID).Where(p => p.CVTTYPE == "pdf").FirstOrDefault();
                if (pdfMod != null && pdfMod.CVTPATH != null)
                {
                    string url = Utility.GetHomeUrl().Split(':')[0];
                    string pdfPath = HttpUtility.UrlEncode(FileControl.GetFilePhysicsPath(pdfMod.CVTPATH).TrimEnd(".pdf".ToCharArray()));
                    html += string.Format(
                        "&nbsp;&nbsp;|&nbsp;&nbsp;<a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-png',plain:true\" href=\"http://{0}:6008/ShowPDF.aspx?fn={1}\" target='_blank'>{2}</a>",
                        url, pdfPath, DPmode.DOCNAME);
                }
                //end
            }
            // html += "</ul>";
            return html;
        }

        private static void InsertDownLoadModel(DocumentProjModel DPmode)
        {
            DocumentDownloadsService downloadSrv = new DocumentDownloadsService();
            DocumentDownloadsModel dwldModel = new DocumentDownloadsModel();
            dwldModel.ID = CommonTool.GetPkId();
            dwldModel.DOCID = DPmode.DOCID;
            dwldModel.IPADDR = Utility.GetIPAddress();
            dwldModel.USERID = Utility.Get_UserId;
            dwldModel.LOOKUPDATE = DateTime.Now;
            dwldModel.USERNAME = SysUserService.GetUserName(Utility.Get_UserId);
            dwldModel.DB_Option_Action = WebKeys.InsertAction;
            downloadSrv.Execute(dwldModel);
        }
    }
}


