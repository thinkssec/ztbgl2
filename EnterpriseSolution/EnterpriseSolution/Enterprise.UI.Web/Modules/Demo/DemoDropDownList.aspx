<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DemoDropDownList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.DemoDropDownList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%@ Register Src="~/Component/UserControl/EDropDownList.ascx" TagPrefix="uc1" TagName="EDropDownList" %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
      <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
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
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'" style="padding:20px">
        <%--主要内容区域--%>
        <uc1:EDropDownList runat="server" ID="TextBox1" DataUrl="/Component/UserControl/Json/GetHrZige.ashx?where=BGSHR" />

        使用方法同TextBox
    </div>
</asp:Content>
