<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Enterprise.UI.Web.Mobile.Login" %>

<!DOCTYPE html>

<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>招投标管理</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="alternate icon" type="image/png" href="assets/i/favicon.png">
    <link rel="stylesheet" href="assets/css/amazeui.min.css" />
    <style>
        .header {
            text-align: center;
        }

            .header h1 {
                font-size: 200%;
                color: #333;
                margin-top: 30px;
            }

            .header p {
                font-size: 14px;
            }

        .get {
            background: #1E5B94;
            color: #fff;
            text-align: center;
            padding: 100px 0;
        }

        .get-title {
            font-size: 200%;
            border: 2px solid #fff;
            padding: 20px;
            display: inline-block;
        }

        .get-btn {
            background: #fff;
        }
    </style>
</head>
<body>
    <div class="get">
        <%--<div class="am-g">
            <h1>招投标管理</h1>
            <p>专家打分软件</p>
        </div>--%>
        <div class="am-g">
            <div class="am-u-lg-12">
                <h1 class="get-title">招投标管理</h1>

                <p>
                    <a href="#" class="am-btn am-btn-sm get-btn">专家评分软件</a>
                </p>
            </div>
        </div>

    </div>
    <div class="am-g">
        <div class="am-u-lg-6 am-u-md-8 am-u-sm-centered">
            <%--<h3>登录</h3>
            <hr>--%>
            <%--    <div class="am-btn-group">
      <a href="#" class="am-btn am-btn-secondary am-btn-sm"><i class="am-icon-github am-icon-sm"></i> Github</a>
      <a href="#" class="am-btn am-btn-success am-btn-sm"><i class="am-icon-google-plus-square am-icon-sm"></i> Google+</a>
      <a href="#" class="am-btn am-btn-primary am-btn-sm"><i class="am-icon-stack-overflow am-icon-sm"></i> stackOverflow</a>
    </div>
    <br>
    <br>--%>

            <form runat="server" class="am-form">
                <label for="email">用户名:</label>
                <%--<input type="email" name="" id="email" value="" >--%>
                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                <br>
                <label for="password">密码:</label>
                <%--<input type="password" name="" id="password" value="" runat="server">--%>
                <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                    ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1"></asp:RequiredFieldValidator>
                <br>
                <label for="remember-me">
                    <input id="remember-me" type="checkbox">记住密码</label>
                <br />
                <div class="am-cf">
                    <asp:LinkButton ID="Btn_LG" runat="server" CssClass="am-btn am-btn-primary am-btn-sm am-fl" OnClick="Btn_LG_Click">登 录</asp:LinkButton>
                    <%--<input type="submit" name="" id="d" runat="server" value="登 录" class="am-btn am-btn-primary am-btn-sm am-fl">--%>
                    <%--<input type="submit" name="" value="忘记密码 ^_^? " class="am-btn am-btn-default am-btn-sm am-fr">--%>
                </div>
            </form>
        </div>
    </div>
</body>
</html>
