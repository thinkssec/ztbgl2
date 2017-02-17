<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" CodeBehind="DemoHtmlEditor.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.DemoHtmlEditor" ValidateRequest="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">    

    <uc1:EHtmlEditor runat="server" ID="EHtmlEditor" Required="true"  MaxLength="100" Height="260" Width="560"/> <br/>   
    
   <br/> 
        <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" iconCls="icon-save" OnClientClick="return $('#form1').form('validate');" OnClick="BtnSave_Click1">保存</asp:LinkButton>
   
</asp:Content>
