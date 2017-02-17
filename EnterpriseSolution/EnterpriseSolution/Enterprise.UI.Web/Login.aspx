<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Enterprise.UI.Web.Login" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>用户登录</title>
    <link href="/Resources/Styles/css/login.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/Resources/easyui1.2.6/themes/icon.css" />
    <link rel="stylesheet" type="text/css" href="/Resources/easyui1.2.6/themes/default/easyui.css" />
    <script type="text/javascript" src="/Resources/Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="/Resources/easyui1.2.6/jquery.easyui.min.js"></script>
    <style>
        .logindiv {
            position: absolute;
            top: 205px;
            left: -222px;
            background-color: #f3f2f2;
            line-height: 40px;
            border: solid 1px #808080;
            padding-left: 10px;
            padding-right: 5px;
            color: #808080;
            width: 603px;
            font-family: Arial;
        }
    </style>
</head>
<body>
    <div class="xlogin">
        <form id="form1" runat="server" defaultbutton="BtnLogin">
            <table class="loginp">
                <tr>
                    <td>
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用&nbsp;户&nbsp;名:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="username"></asp:TextBox>@sinopec.com
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                        ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密&nbsp;码:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                        ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">语言:
                                </td>
                                <td>
                                    <asp:DropDownList ID="Language" runat="server">
                                        <asp:ListItem Text="简体中文(zhcn)" Value="zhcn"></asp:ListItem>

                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="color: Red;">
                                    <asp:LinkButton ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" CssClass="button"
                                        ><span style="font-weight:bold">登录</span></asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;">
                                    <asp:Label ID="Lbl_Msg" runat="server" ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;">&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color: Red;">&nbsp;</td>
                            </tr>
<%--                            <tr>
                                <td align="center" colspan="2" style="color: Red;">&nbsp;</td>
                            </tr>--%>
                            <tr>
                                <td align="left" colspan="2" style="color: gray;">Copyright © 2015 - 2018&nbsp;
                                    <%--<div class="logindiv">RTX系统设置:&nbsp;&nbsp;服务器地址：<span style="color: #ff6a00; font-weight: bold">10.66.72.30</span> &nbsp;/&nbsp;&nbsp;端口：<span style="color: #ff6a00; font-weight: bold">8000</span>&nbsp;/&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="/Public/Platform/rtx.rar"><img src="Resources/OA/site_skin/images/down.png" style="vertical-align: middle" /></a>
                                        <br/>
                                        VPN或外网用户可以访问：<a href="http://221.2.243.42:6006/"><span style="color: #ff6a00; font-weight: bold">http://221.2.243.42:6006/</span></a>
                                    </div>--%>
                                    <div class="logindiv"><a href="招投标管理评分系统.rar">移动客户端下载</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="E人E本【专家评分软件】使用说明.docx">移动客户端用户手册下载</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href="http://10.17.45.18:8080/">进入绩效考核系统</a>
                                    </div>
                                </td>
                            </tr>

                        </table>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
