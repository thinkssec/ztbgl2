<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EDropDownList.ascx.cs" Inherits="Enterprise.UI.Web.Component.UserControl.EDropDownList" %>
<asp:TextBox ID="txtc" runat="server" CssClass="easyui-combobox"></asp:TextBox>
<script>
    $('#<%=txtc.ClientID%>').combobox({
        url:'<%=DataUrl%><%=Addition%>',
        valueField: 'id',
        textField: 'text',
        required:<%=Required.ToString().ToLower()%>,
        editable:false        
    }); 
</script>
