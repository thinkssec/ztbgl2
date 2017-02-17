using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Article;
using Enterprise.Model.Common.Article;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.Service.Common.Article
{
	
    /// <summary>
    /// 文件名:  ArticleInfoService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/28 10:54:44
    /// </summary>
    public class ArticleInfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IArticleInfoData dal = new ArticleInfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ArticleInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ArticleInfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ArticleInfoModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 根据条件获取数据实体
        /// </summary>
        /// <param name="Id">编号</param>
        /// <returns></returns>
        public ArticleInfoModel ArticleInfoDisp(string Id)
        {
            return GetList("from ArticleInfoModel p where p.ARTICLEID='" + Id + "'").FirstOrDefault();
        }

        /// <summary>
        /// 判断用户对当前通知公告是否有签收权限
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool ArticleQianshouCheck(ArticleInfoModel entity)
        {
            bool rbool = false;
            if (string.IsNullOrEmpty(entity.ARECEVIEUSER))
            {
                rbool = true;
            }
            else
            {
                string[] arr = entity.ARECEVIEUSER.Split(',');
                bool _rbool = arr.Contains(Utility.Get_UserId.ToString());
                if (_rbool || entity.ACREATEUSER == Utility.Get_UserId)
                {
                    rbool = true;
                }
            }
            return rbool;
        }


        /// <summary>
        /// 判断用户对当前通知公告是否有签收权限
        /// 专用于RTX登录用户
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public bool ArticleQianshouCheck(ArticleInfoModel entity, string loginName)
        {
            bool rbool = false;
            if (string.IsNullOrEmpty(entity.ARECEVIEUSER))
            {
                rbool = true;
            }
            else
            {
                string[] arr = entity.ARECEVIEUSER.Split(',');
                int userId = SysUserService.GetUserId(loginName);
                bool _rbool = arr.Contains(userId.ToString());
                if (_rbool || entity.ACREATEUSER == userId)
                {
                    rbool = true;
                }
            }
            return rbool;
        }


        /// <summary>
        /// 按签收范围进行筛选可查看的通知公告
        /// 专用于RTX登录
        /// </summary>
        /// <param name="list"></param>
        /// <param name="loginName"></param>
        /// <returns></returns>
        public List<ArticleInfoModel> ArticleQianshouList(IList<ArticleInfoModel> list,string loginName)
        {
            //加入查看范围控制
            //签收范围以及发布者则可查看
            List<ArticleInfoModel> reList = new List<ArticleInfoModel>();
            foreach (ArticleInfoModel model in list)
            {
                bool rbool = ArticleQianshouCheck(model, loginName);
                if (rbool)
                {
                    reList.Add(model);
                }
            }
            return reList;
        }

        /// <summary>
        ///  按签收范围进行筛选可查看的通知公告
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<ArticleInfoModel> ArticleQianshouList(IList<ArticleInfoModel> list)
        {
            //加入查看范围控制
            //签收范围以及发布者则可查看
            List<ArticleInfoModel> reList = new List<ArticleInfoModel>();
            foreach (ArticleInfoModel model in list)
            {
                bool rbool = ArticleQianshouCheck(model);
                if (rbool)
                {
                    reList.Add(model);
                }
            }
            return reList;
        }

        /// <summary>
        /// 通知公告查询
        /// </summary>
        /// <param name="sType">查询类型</param>
        /// <param name="skey">关键字</param>
        /// <returns></returns>
        public IList<ArticleInfoModel> ArticleSearchList(string sType, string skey)
        {
            string hql = "from ArticleInfoModel p where p." + sType + " like '%" + skey + "%'";           
            return GetList(hql);
        }


        /// <summary>
        /// 首页调用
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static string GetArticleListForIndex(string moduleId, int nums)
        {
            StringBuilder sb = new StringBuilder();
            ArticleInfoService dService = new ArticleInfoService();
            SysModuleService mService = new SysModuleService();
            string swhere = "'" + moduleId + "'";
            List<SysModuleModel> mlist = mService.GetList().Where(p => p.MPARENTID == moduleId).OrderBy(p => p.MORDERBY).ToList();
            string cmd = "";
            if (mlist.Count > 0)
            {
                foreach (var var in mlist)
                {
                    swhere += ",'" + var.MODULEID + "'";
                }
                cmd = "from ArticleInfoModel p where p.AMODULEID in (" + swhere + ")";
            }
            else
            {
                cmd = "from ArticleInfoModel p where p.AMODULEID='" + moduleId + "'";
            }
            var list = dService.ArticleQianshouList(dService.GetList(cmd)).OrderByDescending(p => p.ACREATETIME).Take(nums).ToList();
            foreach (var var in list)
            {
                sb.Append("<div class=\"bottomlinks\">");
                if (Utility.Language == Utility.LanguageType.zhcn)
                {
                    if (var.ATITLE.ToTrim())
                    {
                        sb.Append("<a href=\"/Modules/Common/Article/" + ((moduleId == "304") ? "Rules" : "") + "ArticleDetail.aspx?id=" + var.ARTICLEID + "\" target=\"_blank\">" + var.ATITLE.CutString(38) + "</a>");
                    }
                }
                else
                {
                    if (var.ATITLERU.ToTrim())
                    {
                        sb.Append("<a href=\"/Modules/Common/Article/" + ((moduleId == "304") ? "Rules" : "") + "ArticleDetail.aspx?id=" + var.ARTICLEID + "\" target=\"_blank\">" + var.ATITLERU.CutString(60) + "</a>");
                    }
                }
                sb.Append("</div>");
            }
            return sb.ToString();
        }


        #region PDF附件相关

        /// <summary>
        /// 生成PDF附件的HTML
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public static string GetPDFEnclosureHTML(ArticleInfoModel article)
        {
            StringBuilder htmlSB = new StringBuilder();
            if (article != null && 
                !string.IsNullOrEmpty(article.AFNAMES) && 
                !string.IsNullOrEmpty(article.AFVIEWNAMES))
            {
                ArticleDownloadService downloadSrv = new ArticleDownloadService();
                //显示文件名
                string[] afns = article.AFNAMES.TrimEnd('|').Split('|');
                //实际文件名
                string[] afvns = article.AFVIEWNAMES.TrimEnd('|').Split('|');
                htmlSB.Append("<table border=\"0\" cellspacing=\"2\" class=\"tableborder4\"><tr><td colspan=\"2\" height=\"15\" class=\"tablebody2\">&nbsp;<B>附件</B></td></tr>");
                for (int i = 0; i < afns.Length && i < afvns.Length; i++)
                {
                    string fn = afns[i];
                    if (afns[i].LastIndexOf("_") > 0)
                    {
                        fn = afns[i].Substring(0, afns[i].LastIndexOf("_")) + ".pdf";
                    }
                    string viewFn = afvns[i].Substring(afvns[i].LastIndexOf("/") + 1);
                    string hql = string.Format("from ArticleDownloadModel c where c.ARTICLEID='{0}' and c.FILENAME='{1}'", article.ARTICLEID, fn);
                    int downloadTimes = downloadSrv.GetList(hql).Count;
                    htmlSB.Append("<tr><td colspan=\"2\" height=\"20\" class=\"tablebody1\"><img title=\"dvubb\" src=\"/Resources/Common/filetype/pdf.gif\" border=\"0\" alt=\"\"/>");
                    htmlSB.Append(string.Format("文件名：<a href=\"../../../Component/FlexPaper/PdfViewer.aspx?id={0}&fn={1}\" target=\"_blank\">{2}</a>", article.ARTICLEID, viewFn, fn));
                    htmlSB.Append("&nbsp;&nbsp;|&nbsp;&nbsp;<img title=\"dvubb\" src=\"/Resources/Common/filetype/anchor.png\" border=\"0\" alt=\"\"/>");
                    htmlSB.Append(string.Format("<a href=\"/Modules/Common/Article/DownloadFile.aspx?id={0}&fn={1}\" target=\"_blank\">下载{2}次</a>", article.ARTICLEID, viewFn, downloadTimes));
                    htmlSB.Append("</td></tr>");
                }
                htmlSB.Append("</table>");
            }

            return htmlSB.ToString();
        }

        /// <summary>
        /// 将数据库中的附件描述转换为HTML展示
        /// </summary>
        /// <param name="dbFilesString">格式为：文件名 * 文件路径 | 文件名 * 文件路径  .....</param>
        /// <returns></returns>
        public static string ToAttachHtml(ArticleInfoModel article)
        {
            string dbFilesString = article.AFVIEWNAMES;
            ArticleDownloadService downloadSrv = new ArticleDownloadService();
            
            string html = "<ul>";
            if (!string.IsNullOrEmpty(dbFilesString))
            {
                string[] str = dbFilesString.Split('|');
                for (int i = 0; i < str.Length; i++)
                {
                    string[] tmp = str[i].Split('*');
                    string ext = System.IO.Path.GetExtension(Utility.GetFileExt(tmp.Last()));
                    string hql = string.Format("from ArticleDownloadModel c where c.ARTICLEID='{0}' and c.FILENAME='{1}'", article.ARTICLEID, tmp.First());
                    int downloadTimes = downloadSrv.GetList(hql).Count;
                    html += string.Format("<li><a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-"+ext.Replace(".","")+"',plain:true\" href=\"/Modules/Common/Article/DownloadFile.aspx?id={0}&fn={1}\" target='_blank'>{2}</a>  [ 下载{3}次 ] </li>",
                        article.ARTICLEID,
                        FileHelper.Encrypt(tmp.Last()),
                        tmp.First(),
                        downloadTimes);
                }
                html += "</ul>";
            }
            return html;
        }
        public static string ToAttachHtml2(object article)
        {
            if (article == null) return "";
            string dbFilesString = article.ToRequestString();
            ArticleDownloadService downloadSrv = new ArticleDownloadService();
            string url = "<a href='/Modules/Common/EntDisk/Content/Ashx/FileDownload.ashx?url={0}'><img src='/Resources/OA/site_skin/default/img/page.png'  border=\"0\"/></a>";
            string html = "<ul>";
            if (!string.IsNullOrEmpty(dbFilesString))
            {
                string[] str = dbFilesString.Split('|');
                for (int i = 0; i < str.Length; i++)
                {
                    string[] tmp = str[i].Split('*');
                    string ext = System.IO.Path.GetExtension(Utility.GetFileExt(tmp.Last()));
                    html += string.Format("<li><a class=\"easyui-linkbutton\" data-options=\"iconCls:'icon-" + ext.Replace(".", "") + "',plain:true\" href=\"/Modules/Common/EntDisk/Content/Ashx/FileDownload.ashx?url={0}\" target='_blank'>{2}</a></li>",
                        tmp.Last(),
                        FileHelper.Encrypt(tmp.Last()),
                        tmp.First());
                }
                html += "</ul>";
            }
            return html;
        }
        #endregion


    }

}
