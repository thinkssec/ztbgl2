<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DemoFindControl.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.DemoFindControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>     
    <%--<asp:Panel ID="p1" runat="server"></asp:Panel>  --%>
    <asp:Table ID="table1" runat="server">
        
    </asp:Table> 
    <asp:Panel ID="p1" runat="server">
    <asp:TextBox  ID="TextBox1" runat="server"></asp:TextBox>
    <asp:TextBox  ID="TextBox2" runat="server"></asp:TextBox>
    <asp:TextBox  ID="TextBox3" runat="server"></asp:TextBox>
    <asp:TextBox  ID="TextBox4" runat="server"></asp:TextBox>
    <asp:TextBox  ID="TextBox5" runat="server"></asp:TextBox>
    </asp:Panel>  
</asp:Content>
