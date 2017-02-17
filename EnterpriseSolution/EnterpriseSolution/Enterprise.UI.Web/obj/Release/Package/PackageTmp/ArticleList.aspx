<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticleList.aspx.cs" Inherits="Enterprise.UI.Web.ArticleList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">

    <div data-options="region:'center',border:false" style="padding:0px; overflow:hidden;" >
        <div class="vDaohangtiaoHolder module clear">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/default.aspx">首页</a>
                    </li>
                    <li>
                        <a href="#">办公管理</a>
                    </li>
                    <li class="last">
                        通知公告
                    </li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
        <a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>
    </div>
     <div class="main-gridview-title icon-edit"><span>通知公告文件列表</span></div>

    <div class="main-gridview">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            AllowPaging="True" PageSize="9" 
            onpageindexchanging="GridView1_PageIndexChanging" Width="100%">
            <Columns>
                <asp:BoundField DataField="类型" HeaderText="类型" />
                <asp:BoundField DataField="标题" HeaderText="标题" />
                <asp:BoundField DataField="时间" HeaderText="时间" />
                <asp:BoundField DataField="单位" HeaderText="单位" />
            </Columns>
            <PagerSettings FirstPageText="首页" LastPageText="末页" 
                 NextPageText="下一页" PageButtonCount="4" PreviousPageText="上一页" 
                Mode="NumericFirstLast" />
            <PagerStyle CssClass="pager" />
        </asp:GridView>    
    </div>
    </div>
    
</asp:Content>
