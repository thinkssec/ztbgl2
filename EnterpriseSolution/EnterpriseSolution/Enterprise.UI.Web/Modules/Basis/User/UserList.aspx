<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserList.aspx.cs" Inherits="Enterprise.UI.Web.Manage.User.List" %>

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
                    <li class="last">
                        <%=Trans("用户管理") %>
                    </li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    
    <div data-options="region:'center'">
        <table>
            <tr>
                <td style="width:200px;vertical-align:top;padding-left:10px;"><asp:TreeView ID="TreeView1" runat="server" ImageSet="Inbox" BorderWidth="0px" CssClass="TreeviewStyle" ShowLines="True">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                VerticalPadding="0px" BackColor="#FF6666" />
        </asp:TreeView></td>
                <td style="width:740px; vertical-align:top;"><div class="main-gridview" >
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="USERID" AutoGenerateColumns="false"
                Width="100%">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="30">
                        <ItemTemplate>
                            <img src="../../../Resources/Styles/_img/arrow_142.gif" alt="" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="40" HeaderText="序号">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称" ItemStyle-Width="180">
                        <ItemTemplate>
                            <a href="UserShow.aspx?Uid=<%#Eval("USERID") %>&Did=<%=Id %>" title="<%#GetRoles((int)Eval("USERID")) %>">
                                <%#Eval("UNAME") %>
                            </a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="uSex" HeaderText="性别" />
                    <asp:BoundField DataField="uLoginName" HeaderText="帐号" />
                    <%--<asp:TemplateField HeaderText="出生日期">
                        <ItemTemplate>
                            <%#(Eval("UBIRTHDAY").ToString().StartsWith("9999")) ? "" : DateTime.Parse(Eval("UBIRTHDAY").ToString()).ToShortDateString() %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="人员状态" ItemStyle-Width="60">
                        <ItemTemplate>
                            <%#((int)Eval("uStatus")) == 0 ? "<img src=\"../../../Resources/Styles/_img/right.gif\" border=\"0\" alt=\"正常登录\">" : "<img src=\"../../../Resources/Styles/_img/wrong.gif\" border=\"0\" alt=\"禁止登录\">"%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="uLoginPass" HeaderText="职务" />
                </Columns>
                <PagerStyle CssClass="pager" />
            </asp:GridView>
        </div></td>
            </tr>
        </table>
        
    </div>
   
</asp:Content>
