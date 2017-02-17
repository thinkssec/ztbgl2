<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DemoUserSeletMuti.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.DemoUserSeletMuti" %>

<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/ExamineTypeSelectControl.ascx" TagPrefix="uc1" TagName="ExamineTypeSelectControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/"><%=("首页") %></a>
                    </li>
                    <li><%=("网络办公") %></li>
                    <li class="last"><%=("客户管理") %>
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
    <div data-options="region:'center'" style="padding: 5px;">
        <div>
            <uc1:MutiUserSelectControl runat="server" ID="MutiUserSelectControl" />
        </div>
        <div>
            <uc1:ExamineTypeSelectControl runat="server" ID="ExamineTypeSelectControl" />
        </div>
    </div>
</asp:Content>
