<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Enterprise.UI.Web.Mobile.exp.Login" %>

<!DOCTYPE html>

<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>专家打分软件</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport"
        content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
    <meta name="format-detection" content="telephone=no">
    <meta name="renderer" content="webkit">
    <meta http-equiv="Cache-Control" content="no-siteapp" />
    <link rel="alternate icon" type="image/png" href="/Mobile/assets/i/favicon.png">
    <link rel="stylesheet" href="/Mobile/assets/css/amazeui.min.css" />
    <style>
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

        .detail {
            background: #fff;
        }

        .detail-h2 {
            text-align: center;
            font-size: 150%;
            margin: 40px 0;
        }

        .detail-h3 {
            color: #1f8dd6;
        }

        .detail-p {
            color: #7f8c8d;
        }

        .detail-mb {
            margin-bottom: 30px;
        }

        .hope {
            background: #0bb59b;
            padding: 50px 0;
        }

        .hope-img {
            text-align: center;
        }

        .hope-hr {
            border-color: #149C88;
        }

        .hope-title {
            font-size: 140%;
        }

        .about {
            background: #fff;
            padding: 40px 0;
            color: #7f8c8d;
        }

        .about-color {
            color: #34495e;
        }

        .about-title {
            font-size: 180%;
            padding: 30px 0 50px 0;
            text-align: center;
        }

        .footer p {
            color: #7f8c8d;
            margin: 0;
            padding: 15px 0;
            text-align: center;
            background: #2d3e50;
        }
    </style>
</head>
<body>
    <header class="am-topbar am-topbar-fixed-top">
        <div class="am-container">
            <h1 class="am-topbar-brand">
                <a href="#">招投标管理系统</a>
            </h1>

            <button class="am-topbar-btn am-topbar-toggle am-btn am-btn-sm am-btn-secondary am-show-sm-only"
                data-am-collapse="{target: '#collapse-head'}">
                <span class="am-sr-only">导航切换</span> <span
                    class="am-icon-bars"></span>
            </button>

            <div class="am-collapse am-topbar-collapse" id="collapse-head">
                <%--<ul class="am-nav am-nav-pills am-topbar-nav">
                    <li class="am-active"><a href="#">首页</a></li>
                    <li><a href="#">项目</a></li>
                    <li class="am-dropdown" data-am-dropdown>
                        <a class="am-dropdown-toggle" data-am-dropdown-toggle href="javascript:;">下拉菜单 <span class="am-icon-caret-down"></span>
                        </a>
                        <ul class="am-dropdown-content">
                            <li class="am-dropdown-header">标题</li>
                            <li><a href="#">1. 默认样式</a></li>
                            <li><a href="#">2. 基础设置</a></li>
                            <li><a href="#">3. 文字排版</a></li>
                            <li><a href="#">4. 网格系统</a></li>
                        </ul>
                    </li>
                </ul>--%>

                <%--<div class="am-topbar-right">
                    <button class="am-btn am-btn-secondary am-topbar-btn am-btn-sm"><span class="am-icon-pencil"></span>注册</button>
                </div>--%>

                <div class="am-topbar-right">
                    <button class="am-btn am-btn-primary am-topbar-btn am-btn-sm" onclick="document.location='../Login.aspx'"><span class="am-icon-user"></span>登录</button>
                </div>
            </div>
        </div>
    </header>

    <div class="get">
        <div class="am-g">
            <div class="am-u-lg-12">
                <h1 class="get-title">天然气川气东送管道分公司</h1>

                <p>
                    <a href="#" class="am-btn am-btn-sm get-btn">专家评分软件</a>
                </p>
            </div>
        </div>
    </div>

    <div class="detail">
        <div class="am-g am-container">
            <div class="am-u-lg-12">
                <h2 class="detail-h2">注重形式高于实质，坚持公开、公平、公正！</h2>

                <div class="am-g">
                    <div class="am-u-lg-3 am-u-md-6 am-u-sm-12 detail-mb">
                        <h3 class="detail-h3">
                            <i class="am-icon-send-o am-icon-sm"></i>
                           规范化
          </h3>

                        <p class="detail-p">
                            严格按照国家、行业、中石化相应信息系统建设的要求、标准及规范文件。
                        </p>
                    </div>
                    <div class="am-u-lg-3 am-u-md-6 am-u-sm-12 detail-mb">
                        <h3 class="detail-h3">
                            <i class="am-icon-cogs am-icon-sm"></i>
                            技术先进、安全稳定
          </h3>

                        <p class="detail-p">
                            建设坚持科学发展原则，采用先进、成熟的软硬件产品，构建技术先进的、具备较强扩展性、兼容性、安全性，可靠实用的综合信息化平台，满足工作未来发展的需要.
                        </p>
                    </div>
                    <div class="am-u-lg-3 am-u-md-6 am-u-sm-12 detail-mb">
                        <h3 class="detail-h3">
                            <i class="am-icon-check-square-o am-icon-sm"></i>
                            本地化支持
          </h3>

                        <p class="detail-p">
                            针对国内主流移动端操作系统提供更好的兼容性支持，为你提供友好的用户操作体验。
         
                        </p>
                    </div>

                    <div class="am-u-lg-3 am-u-md-6 am-u-sm-12 detail-mb">

                        <h3 class="detail-h3">
                            <i class="am-icon-mobile am-icon-sm"></i>
                             移动端，高性能
          </h3>

                        <p class="detail-p">
                            支持移动端访问，搭配E人E本,使用方便，性能可靠！
         
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>

    

    <footer class="footer">
        <p>
            © 2015 天然气川气东送管道分公司.
        </p>
    </footer>

    <!--[if lt IE 9]>
<script src="http://libs.baidu.com/jquery/1.11.1/jquery.min.js"></script>
<script src="http://cdn.staticfile.org/modernizr/2.8.3/modernizr.js"></script>
<script src="assets/js/amazeui.ie8polyfill.min.js"></script>
<![endif]-->

    <!--[if (gte IE 9)|!(IE)]><!-->
    <script src="/Mobile/assets/js/jquery.min.js"></script>
    <!--<![endif]-->
    <script src="/Mobile/assets/js/amazeui.min.js"></script>
</body>
</html>
