using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.Article;
using Enterprise.Service.Common.Article;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
namespace Enterprise.UI.Web.Modules.Common.Article
{
    public partial class ArticleShow : Enterprise.Service.Basis.BasePage
    {
        string Id = (string)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string type = (string)Utility.sink("type", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void OnStart()
        {
            if (string.IsNullOrEmpty(Id))
                return;

            ArticleInfoService aService = new ArticleInfoService();
            ArticleRecevieService arService = new ArticleRecevieService();
            var q = aService.ArticleInfoDisp(Id);
            int yqsUserCount = 0;//已签收人员数量
            if (q != null)
            {
                IList<ArticleRecevieModel> olr = arService.GetList("from ArticleRecevieModel p where p.INFOID='" + Id + "'");
                if (type == "ok")
                {
                    StringBuilder sb = new StringBuilder();
                    SysDepartmentService dService = new SysDepartmentService();
                    var list = dService.GetList();
                    sb.Append("<table class=\"htmlgrid\" width=\"100%\">");
                    foreach (SysDepartMentModel dept in list)
                    {
                        int deptUserCount = GetUserList(dept.DEPTID, olr).Count;
                        if (deptUserCount > 0)
                        {
                            yqsUserCount += deptUserCount;
                            sb.Append("<tr class=\"datarow\">");
                            sb.AppendFormat("<td width=\"100\" align=\"left\">{0}</td>", dept.DNAME);
                            sb.AppendFormat("<td align=\"left\">{0}</td>", GetUsers(dept.DEPTID, olr));
                            sb.Append("</tr>");
                        }
                    }
                    sb.Append("<tr class=\"datarow\">");
                    sb.AppendFormat("<td align=\"left\" colspan=\"2\">共{0}人已签收</td>", yqsUserCount);
                    sb.Append("</tr>");
                    sb.Append("</table>");
                    lb.Text = sb.ToString();
                }
                else if (type == "no")
                {
                    StringBuilder sb = new StringBuilder();
                    int wqsUserCount = 0;
                    //取得总的需要签收的人员
                    List<ArticleRecevieModel> noread = new List<ArticleRecevieModel>();
                    if (!string.IsNullOrEmpty(q.ARECEVIEUSER))
                    {
                        string[] arr = q.ARECEVIEUSER.Split(',');
                        string[] arrok = new string[olr.Count];
                        for (int i = 0; i < olr.Count; i++)
                        {
                            arrok[i] = olr[i].RUSERID.ToString();
                        }
                        //在两个数组中找出不同元素
                        var query = arr.Except(arrok).ToList();
                        wqsUserCount += query.Count;
                        foreach (var var in query)
                        {
                            sb.AppendFormat("{0}  ",SysUserService.GetUserName(int.Parse(var)));
                        }
                        if (string.IsNullOrEmpty(sb.ToString()))
                        {
                            sb.Append("无");
                        }
                        else
                        {
                            sb.AppendFormat("<br/>共{0}人还未签收", wqsUserCount);
                        }
                    }
                    else
                    {
                        sb.Append("无签收范围");
                    }
                    lb.Text = sb.ToString();
                }
            }

        }
        /// <summary>
        /// 返回用户姓名
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private string GetUsers(int deptId, IList<ArticleRecevieModel> list)
        {
            StringBuilder sb = new StringBuilder();
            SysUserService uService = new SysUserService();
            var listUser =uService.GetList().Where(p => p.DEPTID == deptId).ToList();
            var q = from p in listUser
                    join pp in list on p.USERID equals pp.RUSERID
                    select p;
            foreach (var var in q)
            {
                sb.AppendFormat("{0}  ", var.UNAME);
            }
            return sb.ToString();
        }

        /// <summary>
        /// 返回用户列表
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        private List<SysUserModel> GetUserList(int deptId, IList<ArticleRecevieModel> list)
        {
            SysUserService uService = new SysUserService();
            List<SysUserModel> listUser = uService.GetList().Where(p => p.DEPTID == deptId).ToList();
            var q = from p in listUser
                    join pp in list on p.USERID equals pp.RUSERID
                    select p;
            return q.ToList();
        }

    }
}