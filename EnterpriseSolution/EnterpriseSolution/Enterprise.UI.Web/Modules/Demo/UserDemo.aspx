<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDemo.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.UserDemo" %>

<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        
                        <a href="/">首页</a>
                    </li>
                    <li>项目管理</li>
                    <li class="last">项目运行</li>
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
    <div data-options="region:'center'" style="padding:20px">
        
   用户选择控件： <uc1:UserSelectControl runat="server" ID="tb_USERID" Level="144"  /><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">取值</asp:LinkButton>

    <br />
    <br />

   使用方法见后台.cs代码


        <asp:TextBox ID="tttt" runat="server" Text="1" CssClass="easyui-slider"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />

    
    </div>
</asp:Content>



