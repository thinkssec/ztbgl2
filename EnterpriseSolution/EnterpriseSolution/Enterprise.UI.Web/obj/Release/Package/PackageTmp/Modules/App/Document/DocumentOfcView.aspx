<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DocumentOfcView.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Document.DocumentOfcView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <ul>
                        <li class="first"><a href="/index.aspx" title="首页">
                            <%=Trans("首页")%></a> </li>
                        <li><a href="DocumentOfcList.aspx?ModuleId=<%=ModuleId %>">
                            <asp:Label ID="lb_MName" runat="server"></asp:Label></a></li>
                        <li class="last">
                            <%=Trans("明细")%>
                        </li>
                    </ul>
            </div>
        </div>

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
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("详细") %></span>
            </div>

            <table class="ssec-table" style="width: 100%">
                <tr>
                    <td class="ssec-label">
                        <div>
                            <%=Trans("部门/单位")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Dept" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("发布人")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_User" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("标题")%>：<span style="color: red; font-weight: bold;">*</span>
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Title" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">

                        <%=Trans("内容")%>：
                        
                    </td>
                    <td>
                        <asp:Label ID="lb_Content" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("附件")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Files" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("签收人")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Lb_Rcv" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>


    </div>


</asp:Content>
