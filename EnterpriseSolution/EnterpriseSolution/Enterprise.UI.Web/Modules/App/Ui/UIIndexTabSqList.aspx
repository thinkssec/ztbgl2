<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true"
    CodeBehind="UIIndexTabSqList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Ui.UIIndexTabSqList" %>

<%@ Import Namespace="Enterprise.Component.Infrastructure" %>
<%@ Register Src="~/Component/UserControl/JqueryChart.ascx" TagPrefix="uc1" TagName="JqueryChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>招标申请</title>
    <link rel="stylesheet" type="text/css" href="/Resources/OA/jqplot-1.08/jquery.jqplot.min.css" />
    <!--[if lt IE 9]>
    <script language="javascript" type="text/javascript" src="/Resources/OA/jqplot-1.08/excanvas.js"></script>
    <![endif]-->

    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/jquery.jqplot.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.pieRenderer.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.highlighter.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <style>
        .tableheight {
            height: 26px;
        }
    </style>
    <div class="main-gridview">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            AllowPaging="True" PageSize="30" AllowSorting="false"
            CssClass="GridViewStyle" DataKeyNames="PROJID">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <%#(Container.DataItemIndex + 1)%>
                    </ItemTemplate>
                    <HeaderStyle Width="50px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="项目名称">
                    <ItemTemplate>
                        <a href="/Modules/App/Project/ProjectInfoView.aspx?Lb=1&Cmd=Edit&PROJID=<%#(string)Eval("PROJID") %>" target="_parent"><%#Eval("PROJNAME")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="经办人">
                    <ItemTemplate>
                        <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName( (int)Eval("SUBMITTER")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="申请时间">
                    <ItemStyle Width="100" />
                    <ItemTemplate>
                        <%#Eval("SUBMITDATE") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="发起部门">
                    <ItemTemplate>
                        <%#Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName( (int)Eval("DEPTID")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PROJINCOME" HeaderText="计划金额" />
                <%--<asp:BoundField DataField="NKBSJ" HeaderText="拟开标日期" DataFormatString="{0:yyyy-MM-dd}" />--%>
                <asp:BoundField DataField="ZJLY" HeaderText="资金来源" />
                <asp:TemplateField HeaderText="状态">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate>
                        <%#GetStatus(Container.DataItem) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="节点">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <%#GetStatusJd(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                <%--<asp:TemplateField HeaderText="招标申请表" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="50" />
                    <ItemTemplate>
                        <%#GetFile((string)Eval("PROJID")) %>
                    </ItemTemplate>
                </asp:TemplateField>--%>
                <asp:TemplateField HeaderText="立项审批表" ItemStyle-HorizontalAlign="Center">
                    <ItemStyle Width="50" />
                    <ItemTemplate>
                        <%#GetFile2((string)Eval("PROJID")) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="70" />
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("PROJID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
            </Columns>

            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
        </asp:GridView>
    </div>
    <div style="text-align: right; padding: 2px 2px 0px 0px; text-decoration: underline;">
        <a href="/Modules/App/Project/ProjectInfoList.aspx" target="_parent" class="easyui-linkbutton" iconcls="icon-form">更多..</a>
    </div>
</asp:Content>
