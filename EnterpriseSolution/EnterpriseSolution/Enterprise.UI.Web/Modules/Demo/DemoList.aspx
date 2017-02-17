<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DemoList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.DemoList" %>

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
    <div data-options="region:'center'">
        <div class="main-gridview">
            <div class="main-gridview-title">
                查询条件：
            </div>
            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <table>
                <tr>
                    <td>1</td>
                    <td>100万字</td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>2个字</td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>100个字</td>
                </tr>
            </table>
            <%--end--%>
        </div>
    </div>
</asp:Content>
