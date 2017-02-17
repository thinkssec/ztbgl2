<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RoleIndex.aspx.cs" Inherits="Enterprise.UI.Web.Manage.Role.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx" title="首页">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li class="last">
                        <%=Trans("用户角色") %>
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
        <div class="main-gridview">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="RID" AutoGenerateColumns="false"
                Width="100%">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="30">
                        <ItemTemplate>
                            <a href="RoleDisp.aspx?Id=<%#Eval("RID") %>">
                                <img src="../../../Resources/Styles/_img/arrow_142.gif" alt="" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:HyperLinkField DataTextField="rName" HeaderText="名称" DataNavigateUrlFields="RID"
                        DataNavigateUrlFormatString="RoleDetail.aspx?Id={0}" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-Width="160" />
                    <asp:BoundField DataField="rType" HeaderText="类型" />
                    <asp:BoundField DataField="rRemark" HeaderText="说明" ItemStyle-HorizontalAlign="Left" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
