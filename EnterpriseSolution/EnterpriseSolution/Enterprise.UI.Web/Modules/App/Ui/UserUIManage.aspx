<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserUIManage.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Ui.UserUIManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/"><%=Trans("首页") %></a>
                    </li>
                    <li><%=Trans("系统管理") %></li>
                    <li class="last"><%=Trans("用户界面定制") %>
                    </li>
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

            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="用户信息">
                        <ItemTemplate>
                            <%#GetUserInfo(Eval("USERID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="定制显示的标签">
                        <ItemTemplate>
                            <%#GetTabNames(Eval("UICONTENT"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" ItemStyle-Width="150">
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("CUSTOMID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <div id="Edit" runat="server" visible="false">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>为用户定制首页标签</span>
                </div>
                <%--表单构建开始--%>
                <ul>
                    <li class="ssec-label">用户：</li>
                    <li>
                        <Inf:SSECDropDownList ID="tb_Users" runat="server">
                        </Inf:SSECDropDownList>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">标签：</li>
                    <li>
                        <asp:HiddenField ID="HId" runat="server" />
                        <asp:ListBox ID="tb_tablist" runat="server" SelectionMode="Multiple" Width="200" Height="210"></asp:ListBox>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label"></li>
                    <li>
                        <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" OnClick="BtnSave_Click">保存</asp:LinkButton></li>
                </ul>

            </div>
        </div>
    </div>
</asp:Content>
