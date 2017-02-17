<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
     EnableEventValidation="false" ValidateRequest="false" 
    CodeBehind="ZbwjReportAudit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.ZbwjReportAudit" %>

<%@ Register Src="~/Component/UserControl/EDropDownList.ascx" TagPrefix="uc1" TagName="EDropDownList" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/ProjectAuditUControl.ascx" TagPrefix="uc1" TagName="ProjectAuditUControl" %>
<%@ Register Src="~/Component/UserControl/ProjectDoAuditUControl.ascx" TagPrefix="uc1" TagName="ProjectDoAuditUControl" %>
<%@ Import Namespace="Enterprise.Model.App.Project" %>
<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent">首页</a></li>
                    <li>招标文件编制</li>
                    <li class="last">招标文件审核</li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <asp:HiddenField ID="hid" runat="server" />
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>招标文件审核</span>
            </div>
        </div>
        <div class="main-gridview">
            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="RPTID" AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex + 1)%>
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发起人">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName((int)Eval("SUBMITTER")) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="SUBMITDATE" HeaderText="文件日期"></asp:BoundField>
                    <asp:TemplateField HeaderText="附件">
                        <ItemTemplate>
                            <%#Eval("ATTACHMENT").ToAttachHtmlByOne() %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#GetStatus(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Pnl_Audit_Show" runat="server">
            <uc1:ProjectAuditUControl runat="server" ID="UC_Shenhe_Show" />
        </asp:Panel>
        <asp:Panel ID="Pnl_Audit" runat="server" Visible="false">
            <uc1:ProjectDoAuditUControl runat="server" ID="UC_DoShenhe" />
            <div class="ssec-form">
                <ul>
                    <li class="ssec-label"></li>
                    <li>
                        <div>
                            <asp:LinkButton ID="LnkBtnAudit" CssClass="easyui-linkbutton" iconCls="icon-save" runat="server" OnClientClick="return checkInputForm();" OnClick="LnkBtnAudit_Click">审核完成</asp:LinkButton>
                            <asp:LinkButton ID="LnkBtnApprover" CssClass="easyui-linkbutton" iconCls="icon-save" runat="server" OnClientClick="return checkInputForm();" OnClick="LnkBtnApprover_Click">审批完成</asp:LinkButton>
                        </div>
                    </li>
                </ul>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
