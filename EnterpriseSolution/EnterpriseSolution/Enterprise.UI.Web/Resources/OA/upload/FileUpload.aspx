﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="Enterprise.UI.Web.Resources.OA.upload.FileUpload" %>

<%@ Register Src="~/Component/UserControl/EFileUpload.ascx" TagPrefix="uc1" TagName="EFileUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <uc1:EFileUpload runat="server" ID="EFileUpload" />
</asp:Content>
