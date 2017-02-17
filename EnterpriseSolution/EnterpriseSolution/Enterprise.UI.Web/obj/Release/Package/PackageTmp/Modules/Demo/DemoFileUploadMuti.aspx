<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" 
    AutoEventWireup="true" CodeBehind="DemoFileUploadMuti.aspx.cs" 
    Inherits="Enterprise.UI.Web.Modules.Demo.DemoFileUploadMuti" EnableEventValidation="false"  ValidateRequest="false"%>

<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <uc1:PopWinUploadMuti runat="server" ID="PopWinUploadMuti" Ext="Office"  Width="200" />
    <br/>

    <uc1:PopWinUploadMuti runat="server" ID="PopWinUploadMuti1"  
        Muti="false" Ext="Office"  Width="200"/>

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" OnClientClick="return $('#form1').form('validate');" />
</asp:Content>
