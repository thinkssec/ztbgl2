<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ModuleDisp.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Module.ModuleDisp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px;
        overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx" title="首页">
                        <%=Trans("首页") %></a></li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li><a href="ModuleIndex.aspx">
                        <%=Trans("功能模块") %></a></li>
                    <li class="last">
                        <%=Trans("查看") %></li>
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
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("功能模块") %></span></div>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("编码") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Code" runat="server"></asp:Label></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("名称") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Name" runat="server"></asp:Label></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("系统外链接") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Link" runat="server"></asp:Label></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("链接地址") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Url" runat="server"></asp:Label></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("WEB映射地址") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_WebUrl" runat="server"></asp:Label></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("链接目标") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Target" runat="server"></asp:Label></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("是否显示") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Show" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("图标样式") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Image" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
