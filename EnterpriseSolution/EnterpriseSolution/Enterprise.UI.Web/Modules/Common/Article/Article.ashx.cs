using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;
using Enterprise.Model.App.Publicize;
using Enterprise.Service.App.Publicize;
using Enterprise.Service.Basis.Sys;
using LitJson;

namespace Enterprise.UI.Web.Modules.Common.Article
{
    /// <summary>
    /// Article 的摘要说明
    /// </summary>
    public class Article : IHttpHandler
    {

        /// <summary>
        ///  生成首页右上部的内容
        /// </summary>
        string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        /// <summary>
        /// 首页信息集合
        /// </summary>
        private static List<IndexArticleModel> articleLst = new List<IndexArticleModel>();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string result = string.Empty;

            string mtype = context.Request["MType"];
            switch (mtype)
            {
                case "1"://通知公告
                    result = getTzgz();
                    break;
                case "2"://宣传报道
                    result = getXcbd();
                    break;
                case "3"://交流论坛
                    result = getBBS();
                    break;
                case "0"://所有信息按日期排序
                    result = getAllArticle();
                    break;
            }
            context.Response.Write(result);
        }




        #region 专用方法

        /// <summary>
        /// 获取通知公告信息
        /// </summary>
        /// <returns></returns>
        private string getTzgz()
        {
            StringBuilder sb = new StringBuilder();
            ArticleInfoService aService = new ArticleInfoService();
            List<ArticleInfoModel> list = aService.ArticleQianshouList(aService.GetList("from ArticleInfoModel p where p.AMODULEID='" + Id + "'")).Take(8).OrderByDescending(p => p.ACREATETIME).ToList();
            articleLst.RemoveAll(p => p.ArticleKind == "1");//删除已缓存的类型的所有记录
            foreach (ArticleInfoModel entity in list)
            {
                if (!string.IsNullOrEmpty(entity.ATITLE))
                {
                    sb.Append("<div class=\"rightlinks\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>");
                    sb.Append(" <td width=\"18\" align=\"left\" valign=\"middle\"><img src='/Resources/OA/site_skin/images/liimg.jpg'></td>");
                    sb.Append("<td align=\"left\" valign=\"middle\" style=\"padding-right: 9px\"><a href=\"/Modules/Common/Article/ArticleDetail.aspx?Id=" + entity.ARTICLEID + "\" target=\"_blank\">" + entity.ATITLE +
                        (checkDateIsToday(entity.ACREATETIME.ToDateYMDFormat()) ? "<img src='/Resources/OA/site_skin/images/new.gif'>" : "") + "</a></td>");
                    sb.Append(" <td width=\"80\" align=\"center\" valign=\"middle\" class=\"newsdate\">" + entity.ACREATETIME.Value.ToString("yyyy-MM-dd") + "</td>");
                    sb.Append("</tr></table></div>");
                    //重新添加
                    articleLst.Add(new IndexArticleModel
                        (entity.ATITLE, "1", entity.ACREATETIME.ToDateTime(),
                        "/Modules/Common/Article/ArticleDetail.aspx?Id=" + entity.ARTICLEID));
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取宣传报道信息
        /// </summary>
        /// <returns></returns>
        private string getXcbd()
        {
            StringBuilder sb = new StringBuilder();
            PublicizeInfoService infoSrv = new PublicizeInfoService();
            string hql = "from PublicizeInfoModel p where p.STATUS='3' order by p.PUBDATE desc";
            IList<PublicizeInfoModel> list = infoSrv.GetListByHQL(hql).Take(8).ToList();
            articleLst.RemoveAll(p => p.ArticleKind == "2");//删除已缓存的类型的所有记录
            foreach (PublicizeInfoModel model in list)
            {
                sb.Append("<div class=\"rightlinks\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>");
                sb.Append(" <td width=\"18\" align=\"left\" valign=\"middle\"><img src='/Resources/OA/site_skin/images/liimg.jpg'></td>");
                sb.Append("<td align=\"left\" valign=\"middle\" style=\"padding-right: 9px\"><a href=\"/Modules/App/Publicize/PublicizeDetail.aspx?pid=" + model.PUBID + "\" target=\"_blank\">" + model.PUBTITLE +
                    (checkDateIsToday(model.PUBDATE.ToDateYMDFormat()) ? "<img src='/Resources/OA/site_skin/images/new.gif'>" : "") + "</a></td>");
                sb.Append(" <td width=\"80\" align=\"center\" valign=\"middle\" class=\"newsdate\">" + model.PUBDATE.ToDateYMDFormat() + "</td>");
                sb.Append("</tr></table></div>");
                //重新添加
                articleLst.Add(new IndexArticleModel
                    (model.PUBTITLE, "2", model.PUBDATE.ToDateTime()
                    , "/Modules/App/Publicize/PublicizeDetail.aspx?pid=" + model.PUBID));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取论坛信息
        /// </summary>
        /// <returns></returns>
        private string getBBS()
        {
            StringBuilder sb = new StringBuilder();
            //SysModuleService moduleSrv = new SysModuleService();
            //var m = moduleSrv.ModuleDisp(121);
            //if (m != null && m.MURL != null)
            //{
            //    string url = m.MURL.Substring(0, m.MURL.IndexOf(".php") + 4);//"http://10.66.72.30:10008/startbbs/index.php";
            //    string paramUrl = url + "/forum/jlist/?size=8&tlen=25";
            //    HttpClient client = new HttpClient(paramUrl);
            //    string bbsHtml = client.GetString();
            //    bbsHtml = bbsHtml.Replace("\\/", "/");
            //    JsonData jsonData = JsonMapper.ToObject(bbsHtml);
            //    articleLst.RemoveAll(p => p.ArticleKind == "3");//删除已缓存的类型的所有记录
            //    for (int i = 0; i < jsonData["rows"].Count; i++)
            //    {
            //        sb.Append("<div class=\"rightlinks\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>");
            //        sb.Append(" <td width=\"18\" align=\"left\" valign=\"middle\"><img src='/Resources/OA/site_skin/images/liimg.jpg'></td>");
            //        sb.Append("<td align=\"left\" valign=\"middle\" style=\"padding-right: 9px\"><a href=\"" + (url + "/" + jsonData["rows"][i]["Vurl"]) + "\" target=\"_blank\">" + jsonData["rows"][i]["Title"]
            //            + (checkDateIsToday(jsonData["rows"][i]["Date"].ToString()) ? "<img src='/Resources/OA/site_skin/images/new.gif'>" : "") + "</a></td>");
            //        sb.Append(" <td width=\"80\" align=\"center\" valign=\"middle\" class=\"newsdate\">" + jsonData["rows"][i]["Date"] + "</td>");
            //        sb.Append("</tr></table></div>");
            //        //重新添加
            //        articleLst.Add(new IndexArticleModel
            //            (jsonData["rows"][i]["Title"].ToString(), "3", jsonData["rows"][i]["Date"].ToDateTime(), 
            //            (url + "/" + jsonData["rows"][i]["Vurl"])));
            //    }
            //}
            return sb.ToString();
        }


        /// <summary>
        /// 获取所有信息集合（按日期从近到远）
        /// </summary>
        /// <returns></returns>
        private string getAllArticle()
        {
            StringBuilder sb = new StringBuilder();
            var list = articleLst.OrderByDescending(p => p.PublishDate).Take(8).ToList();
            foreach (IndexArticleModel model in list)
            {
                sb.Append("<div class=\"rightlinks\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"><tr>");
                sb.Append(" <td width=\"18\" align=\"left\" valign=\"middle\"><img src='/Resources/OA/site_skin/images/liimg.jpg'></td>");
                sb.Append("<td align=\"left\" valign=\"middle\" style=\"padding-right: 9px\"><a href=\""+model.Url+"\" target=\"_blank\">" + model.Title +
                    (checkDateIsToday(model.PublishDate.ToDateYMDFormat()) ? "<img src='/Resources/OA/site_skin/images/new.gif'>" : "") + "</a></td>");
                sb.Append(" <td width=\"80\" align=\"center\" valign=\"middle\" class=\"newsdate\">" + model.PublishDate.ToDateYMDFormat() + "</td>");
                sb.Append("</tr></table></div>");
            }
            return sb.ToString();
        }


        /// <summary>
        /// 检测日期是否为今天
        /// </summary>
        /// <param name="rq"></param>
        /// <returns></returns>
        private bool checkDateIsToday(string rq) 
        {
            bool isToday = false;
            DateTime dt;
            DateTime.TryParse(rq, out dt);
            if (DateTime.Now.Date == dt.Date)
            {
                isToday = true;
            }
            return isToday;
        }

        #endregion

        
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 首页右上角信息MODEL
    /// </summary>
    public class IndexArticleModel
    {

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="_Title">标题</param>
        /// <param name="_ArticleKind">类型</param>
        /// <param name="_PublishDate">发布日期</param>
        public IndexArticleModel(string _Title, string _ArticleKind, DateTime _PublishDate,string _Url) 
        {
            this.Title = _Title;
            this.ArticleKind = _ArticleKind;
            this.PublishDate = _PublishDate;
            this.Url = _Url;
        }
        /// <summary>
        /// 信息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 信息类型
        /// 1-通知公告  2-宣传报道  3-交流论坛
        /// </summary>
        public string ArticleKind { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime PublishDate { get; set; }
        /// <summary>
        /// 访问路径
        /// </summary>
        public string Url { get; set; }
    }

}