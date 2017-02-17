<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DocumentOfcAudit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Document.DocumentOfcAudit" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/ProjectAuditUControl.ascx" TagPrefix="uc1" TagName="ProjectAuditUControl" %>
<%@ Register Src="~/Component/UserControl/ProjectDoAuditUControl.ascx" TagPrefix="uc1" TagName="ProjectDoAuditUControl" %>
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
                        <li class="last">
                            <%=Cmd=="View"?"公文查看":Trans("承办结果审批")%>
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
                <span><%=Trans("公文明细") %></span>
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
                    <td  class="ssec-label" style="vertical-align: top;">

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
            <br/>
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("承办要求") %></span>
            </div>
            <table class="ssec-table" style="width: 100%">
                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("承办人")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Lb_ORGANIZER" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td  class="ssec-label" style="vertical-align: top;">

                        <%=Trans("承办要求")%>：
                        
                    </td>
                    <td>
                        <asp:Label ID="Lb_REQUIREMENT" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("要求完成日期")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Lb_COMPLETEDATE" runat="server"></asp:Label>
                    </td>
                </tr>
             </table>
            <br/>
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("承办结果") %></span>
            </div>
            <table class="ssec-table" style="width: 100%">

                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("实际完成日期")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Lb_RESULTDATE" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td  class="ssec-label" style="vertical-align: top;">

                        <%=Trans("承办结果")%>：
                        
                    </td>
                    <td>
                        <asp:Label ID="Lb_RESULT" runat="server"></asp:Label>
                    </td>
                </tr>
             </table>
            <br/>
            <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span><%=Trans("审核意见") %></span>
                </div>
            <asp:Panel ID="Pnl_Audit_Show" runat="server">
                    <table class="ssec-table" style="width: 100%" >

                    <tr>
                        <td>
                            <div class="ssec-label">
                                <%=Trans("审核结果")%>：
                            </div>
                        </td>
                        <td>
                            <asp:Label ID="Lb_SHSTATUS" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td  class="ssec-label" style="vertical-align: top;">

                            <%=Trans("审核意见")%>：
                        
                        </td>
                        <td>
                            <asp:Label ID="Lb_WHY" runat="server"></asp:Label>
                        </td>
                    </tr>
                 </table>
            </asp:Panel>
        </div>
        <asp:Panel ID="Pnl_Audit" runat="server" Visible="false">
            <uc1:ProjectDoAuditUControl runat="server" ID="UC_DoShenhe" />
            <div class="ssec-form">
                <ul>
                    <li class="ssec-label"></li>
                    <li>
                        <div>
                            <asp:LinkButton ID="LnkBtnAudit" CssClass="easyui-linkbutton" iconCls="icon-save" runat="server" OnClientClick="return checkInputForm();" OnClick="LnkBtnAudit_Click">审批完成</asp:LinkButton>
                            
                        </div>
                    </li>
                </ul>
            </div>
        </asp:Panel>

    </div>


</asp:Content>
