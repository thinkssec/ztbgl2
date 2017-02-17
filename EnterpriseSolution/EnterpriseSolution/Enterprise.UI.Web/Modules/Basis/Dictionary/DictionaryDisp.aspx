<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DictionaryDisp.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Dictionary.DictionaryDisp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px;
        overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li><a href="DepartMentList.aspx">
                        <%=Trans("字典表") %></a></li>
                    <li class="last">
                        <%=Trans("查看") %>
                    </li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("字典表") %></span></div>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("中文名称") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Zwmc" runat="server"></asp:Label></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("语言") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Language" runat="server"></asp:Label></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("对应名称") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Dymc" runat="server"></asp:Label></div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
