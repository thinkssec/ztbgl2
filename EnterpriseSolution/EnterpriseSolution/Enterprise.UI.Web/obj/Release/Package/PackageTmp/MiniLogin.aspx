<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiniLogin.aspx.cs" Inherits="Enterprise.UI.Web.MiniLogin" %>
<%@ Import Namespace="Enterprise.Service.Basis.Sys" %>
<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="/Resources/Scripts/jquery-1.7.2.min.js"></script> 
    <link rel="stylesheet" href="/Resources/Styles/css/miniindex.css" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            loadUserData();
        });
        //加载用户数据
        function loadUserData() {
            //待办事务
            var loginName = "<%=user %>";
            if (loginName != "") {
//                $.ajax({
//                    type: "post",
//                    url: "/Component/BF/BFLoadHandler.ashx?TypeId=2&user=" + loginName,
//                    datatype: "text",
//                    async: true,
//                    success: function (result) {
//                        $("#sNum").html(result); 
//                    }
//                });
                //最新的通知公告
                $.ajax({
                    type: "post",
                    url: "/Component/BF/BFLoadHandler.ashx?TypeId=3&user=" + loginName,
                    datatype: "text",
                    async: true,
                    success: function (result) {
                        $("#pCont").html(result);
                    }
                });
            }
        }
        //调用缺省浏览器
        //需要降低IE浏览器的安全级别：允许执行未经签名的ActiveX控件
        function callDefExplorer(webUrl) {
            //alert(webUrl);
            new ActiveXObject("Wscript.Shell").run(webUrl);
        } 
    </script>
</head>
<body style="width: 91px; height: 240px;">
    <div id="main">
        <div id="nav">
            <%=GetEnterInfo() %>
        </div>
        <div id="navlink">
            <ul>
                <li>
                    <%=GetBacklogInfo()%>
                </li>
            </ul>
        </div>
        <div class="ptitle">
            <img src="/Resources/Styles/_img/news.png" title="最新消息" />
        </div>
        <div class="pcontent" id="pCont">
        </div>
        <%--
        <div class="ptitle">
            <img alt="" src="/Resources/Styles/images/link.png" title="系统链接" />
        </div>
        <div class="pcontent">
            <%=GetLinkUrl() %> 
        </div>
        <a href="settings.htm" target="_blank"><font color='red'>Tips：打开有问题,如何设置?</font></a>
        --%>
    </div>
</body>
</html>
