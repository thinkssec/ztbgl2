<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SysState.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Cache.SysState" %>

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
                        <%=Trans("缓存管理") %>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div data-options="region:'center'">
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
            <tr>
                <td>
                    <%=Trans("缓存清空")%>
                </td>
            </tr>
            <tr>
                <td>
                    执行此操作，所有的web缓存将会清空．数据将重启从数据库中读取．<br />
                    <asp:Button ID="Button1" CssClass="button2" OnClientClick="return confirm('确认要清空当前应用程序缓存吗？');"
                        runat="server" Text="清空" OnClick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <%=Trans("重启Web应用程序")%>
                </td>
            </tr>
            <tr>
                <td style="height: 20px">
                    你可以进行强制关闭并重启Web应用程序。你需要对重启动作确认。Web应用程序将在第一次请求后重启。<br />
                    <b>警告</b>：所有的会话都将丢失，用户操作可能会出错。<br />
                    <b>提示</b>：结果只影响到本Web应用程序。<br />
                    <asp:Button ID="Button2" CssClass="button2" OnClientClick="return confirm('确认要重启当前Web应用程序吗？');"
                        runat="server" Text="重启" OnClick="Button2_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
