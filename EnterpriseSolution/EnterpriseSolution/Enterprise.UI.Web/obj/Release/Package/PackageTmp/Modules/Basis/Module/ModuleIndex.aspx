<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ModuleIndex.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Module.ModuleIndex" %>
<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px;
        overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx" title="首页">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li class="last">
                        <%=Trans("功能模块") %>
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
            <!--div class="main-gridview-title">
            </div-->
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="MODULEID" AutoGenerateColumns="false"
                Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="序号" ItemStyle-Width="30">
                        <ItemTemplate>
                            <a href="ModuleDisp.aspx?Id=<%#Eval("MODULEID") %>">
                                <%#Container.DataItemIndex+1 %></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="mCode" HeaderText="编码" ItemStyle-Width="50" />
                    <asp:HyperLinkField DataTextField="mName" HeaderText="名称" DataNavigateUrlFields="MODULEID"
                        DataNavigateUrlFormatString="ModuleIndex.aspx?Id={0}" ItemStyle-HorizontalAlign="Left"
                        ItemStyle-Width="120" />
                    <asp:TemplateField HeaderText="链接地址" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%#(Eval("mUrl").ToRequestString())%>
                            <br/>
                            <%#(Eval("MWEBURL").ToRequestString() + Eval("MWEBPARAM").ToRequestString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否系统外链接" ItemStyle-Width="70">
                        <ItemTemplate>
                            <%#((int)Eval("MSINGLE")) == 0 ? "否" : "是"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MIMAGE" HeaderText="图标样式" ItemStyle-Width="70" />
                    <asp:BoundField DataField="mTarget" HeaderText="链接目标" ItemStyle-Width="70" />
                    <asp:TemplateField HeaderText="是否启用" ItemStyle-Width="70">
                        <ItemTemplate>
                            <%#(int)Eval("mDelete") == 0 ? "<img src=\"../../../Resources/Styles/_img/right.gif\" border=\"0\">" : "<img src=\"../../../Resources/Styles/_img/wrong.gif\" border=\"0\">"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="排序" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60">
                        <ItemTemplate>
                            <a href="ModuleIndex.aspx?Id=<%=Id %>&mId=<%#Eval("MODULEID") %>&Action=Up">
                                <img src="../../../Resources/Styles/_img/up.gif" title="上移" alt="" border="0" /></a>&nbsp;&nbsp;<a
                                    href="ModuleIndex.aspx?Id=<%=Id %>&mId=<%#Eval("MODULEID") %>&Action=Down"><img src="../../../Resources/Styles/_img/down.gif"
                                        title="下移" alt="" border="0" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
