<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RoleDisp.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Role.RoleDisp" %>

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
                    <li><a href="RoleIndex.aspx">
                        <%=Trans("用户角色") %></a></li>
                    <li class="last">
                        <%=Trans("操作") %>
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
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("用户角色") %></span></div>
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
                        <%=Trans("备注") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Remark" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
