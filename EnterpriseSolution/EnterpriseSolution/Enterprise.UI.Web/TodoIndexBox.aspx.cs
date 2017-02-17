using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.Common.Article;
using Enterprise.Model.Basis.Sys;
using Enterprise.Model.Basis.Bf;
using Enterprise.Service.Basis.Bf;
using Enterprise.Service.Common.Article;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web
{
    /// <summary>
    /// 我的待办箱
    /// </summary>
    public partial class TodoIndexBox : Enterprise.Service.Basis.BasePage
    {

        /// <summary>
        /// 当前页码
        /// </summary>
        protected int PageIndex = (int)Utility.sink("Page", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnCommand();
                GridView1.PageIndex = PageIndex;
                BindGrid();
            }
        }

        private void OnCommand()
        {
            if (Cmd == "Close")
            {
                BfMsgService.UpdateMsgOver(MsgID);
                Response.Redirect("TodoIndexBox.aspx?Page=" + PageIndex, true);
            }

            lb_MName.Text = Trans("我的待办箱");
            Ddl_ISREAD.Items.Clear();
            Ddl_ISREAD.Items.Add(new ListItem(Trans("全部"),""));
            Ddl_ISREAD.Items.Add(new ListItem(Trans("未办理"),"0"));
            Ddl_ISREAD.Items.Add(new ListItem(Trans("已办理"),"1"));
        }

        /// <summary>
        /// 绑定列表
        /// </summary>
        private void BindGrid()
        {
            string sendTime = (string)Utility.sink(Txt_SENDTIME.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            string status = (string)Utility.sink(Ddl_ISREAD.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
            string hql = "from BfUnhandledmsgModel c where c.BF_RECIPIENTS='" + userModel.USERID + "' ";
            if (!string.IsNullOrEmpty(sendTime))
            {
                hql += " and to_char(c.BF_SENDTIME,'yyyy-MM-dd')='" + sendTime + "' ";
            }
            if (!string.IsNullOrEmpty(status))
            {
                hql += " and c.BF_ISREAD='" + status + "' ";
            }
            else
            {
                hql += " and c.BF_ISREAD >= '0' ";
            }
            if (!string.IsNullOrEmpty(Txt_MSGTITLE.Text))
            {
                hql += " and c.BF_MSGTITLE like '%" + Txt_MSGTITLE.Text + "%' ";
            }
            hql += " order by c.BF_SENDTIME desc";
            BfMsgService msgSrv = new BfMsgService();
            var list = msgSrv.GetMsgLstByHQL(hql);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PageIndex = GridView1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        /// <summary>
        /// 查询操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Bt_Search_OnClick(object sender, EventArgs e)
        {
            BindGrid();
        }

        /// <summary>
        /// 根据消息内容中的链接判断跳转的页面
        /// </summary>
        /// <param name="msgTitle"></param>
        /// <param name="msgContent"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        protected string GetUrl(object msgTitle, object msgContent,int status)
        {
            string url = string.Empty;
            if (msgContent != null)
            {
                string ss = string.Format("<a href=\"{0}\" target=\"_self\" style=\"color:red\">{1}</a>", 
                    msgContent.ToRequestString(), msgTitle.ToRequestString());
                if (status == 0)
                {
                    //未处理，直接返回
                    return ss;
                }
                else
                {
                    //已处理，则返回管理界面
                    url = msgTitle.ToRequestString();
                }
            }
            return url;
        }


        /// <summary>
        /// 得到消息的状态
        /// </summary>
        /// <param name="msgId"></param>
        /// <returns></returns>
        protected string GetStatus(string msgId,int isRead)
        {
            string status = string.Empty;
            if (isRead == 0)
            {
                status += "<img alt=\"\" src=\"/Resources/Styles/icon/application_edit.png\" border=\"0\" title=\"未办理\"/>";
                status += "&nbsp;&nbsp;|&nbsp;&nbsp;<a onclick='return confirm(\"您确定要关闭该条消息吗?\");' href='TodoIndexBox.aspx?Cmd=Close&Page=" + PageIndex + "&MsgID=" + msgId
                    + "'><img alt=\"\" src=\"/Resources/Common/img/icon/delete.gif\" border=\"0\" /></a>";
            }
            else
            {
                status += "<img alt=\"\" src=\"/Resources/Styles/icon/accept.png\" border=\"0\" title=\"已办理\" />";
            }
 
            return status;
        }


        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_selectall_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cb_select");
                if (cb.Enabled)
                    cb.Checked = true;
            }
        }

        /// <summary>
        /// 取消全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_cancelselect_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cb_select");
                cb.Checked = false;
            }
        }

        /// <summary>
        /// 清理消息，状态置为-1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_lock_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.Cells[0].FindControl("cb_select");
                if (cb.Checked)
                {
                    string msgId = GridView1.DataKeys[row.RowIndex].Value.ToString();
                    //更新状态为删除
                    BfMsgService.UpdateMsgStatus(msgId, -1);
                }
            }
            BindGrid();
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox cb = (CheckBox)e.Row.Cells[0].FindControl("cb_select");
                BfUnhandledmsgModel model = e.Row.DataItem as BfUnhandledmsgModel;
                if (model.BF_ISREAD == 0)
                {
                    cb.Enabled = false;//未处理的消息不能删除
                }
                else
                {
                    cb.Enabled = true;
                }
            }
        }

    }
}