<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DemoProcess.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.DemoProcess" %>
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
        
        <div id="p" class="easyui-progressbar" style="width:400px;" data-options="value:40"></div>
         <br/>

        <div id="Div1" class="easyui-progressbar" style="width:100px; height:16px" data-options="value:100"></div>
    </div>
</asp:Content>
