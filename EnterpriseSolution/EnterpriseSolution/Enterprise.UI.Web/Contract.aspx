<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Contract.aspx.cs" Inherits="Enterprise.UI.Web.Contract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/"><%=Trans("首页") %></a>
                    </li>
                    <li class="last"><%=Trans("通讯录") %>
                    </li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <%--自定义按钮--%>
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <%--end--%>
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("通讯录") %></span>(按Ctrl+F键来检索内容)
            </div>
            <div class="project-table" style="font-family: Arial">
                <%=CreateContract() %>
            </div>
        </div>
    </div>
</asp:Content>
