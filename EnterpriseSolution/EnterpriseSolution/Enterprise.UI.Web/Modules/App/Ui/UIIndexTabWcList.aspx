﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Blank.Master" AutoEventWireup="true"
    CodeBehind="UIIndexTabWcList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Ui.UIIndexTabWcList" %>

<%@ Import Namespace="Enterprise.Component.Infrastructure" %>
<%@ Register Src="~/Component/UserControl/JqueryChart.ascx" TagPrefix="uc1" TagName="JqueryChart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>招标项目</title>
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
                        <a href="/Modules/App/Project/ProjectInfoView.aspx?Lb=3&Cmd=Edit&PROJID=<%#(string)Eval("PROJID") %>"  target="_parent"><%#Eval("PROJNAME")%></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PROJINCOME" HeaderText="计划金额" />
                <asp:BoundField DataField="NKBSJ" HeaderText="开标日期" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="ZJLY" HeaderText="资金来源" />
                <asp:TemplateField HeaderText="状态">
                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                    <ItemTemplate>
                        招投标结束
                    </ItemTemplate>
                </asp:TemplateField>


            </Columns>
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
        </asp:GridView>
    </div>
    <%--<div style="text-align: right; padding: 2px 2px 0px 0px; text-decoration: underline;">
        <a href="/Modules/App/Project/ProjectRunning.aspx" target="_parent" class="easyui-linkbutton" iconcls="icon-form">更多..</a>
    </div>--%>
</asp:Content>
