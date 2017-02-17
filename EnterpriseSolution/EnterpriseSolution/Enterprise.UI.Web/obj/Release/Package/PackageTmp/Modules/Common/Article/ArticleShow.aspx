<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ArticleShow.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Common.Article.ArticleShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .htmlgrid
        {
            border: 1px solid #CCCCCC;
            border-collapse: collapse;
            font-size: 12px;
            padding: 0px;
        }
        .htmlgrid a:link
        {
            color: #666666;
            text-decoration: none;
        }
        .htmlgrid a:hover
        {
            color: #3366CC;
        }
        .htmlgrid a:visited
        {
            color: #666666;
            font-weight: normal;
        }
        .htmlgrid td
        {
            border-right: 1px solid #CCCCCC;
            border-bottom: 1px solid #CCCCCC;
            font-size: 12px;
            padding: 3px 6px 3px 12px;
            color: #4f6b72;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lb" runat="server" Font-Size="12px"></asp:Label>
    </div>
    </form>
</body>
</html>

