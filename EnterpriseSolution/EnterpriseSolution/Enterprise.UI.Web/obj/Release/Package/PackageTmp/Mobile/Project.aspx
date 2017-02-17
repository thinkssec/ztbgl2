<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="Enterprise.UI.Web.Mobile.Project" %>

<!DOCTYPE html>

<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta name="viewport"
        content="width=device-width,initial-scale=1,maximum-scale=1,user-scalable=no">
  <title></title>
  <link rel="stylesheet" href="assets/css/amazeui.css"/>
  <style>
    html,
    body,
    .page {
      height: 100%;
    }

    #wrapper {
      position: absolute;
      top: 49px;
      bottom: 0;
      overflow: hidden;
      margin: 0;
      width: 100%;
      padding: 0 8px;
      background-color: #f8f8f8;
    }

    .am-list {
      margin: 0;
    }

    .am-list > li {
      background: none;
      box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.8);
    }

    .pull-action {
      text-align: center;
      height: 45px;
      line-height: 45px;
      color: #999;
    }

    .pull-action .am-icon-spin {
      display: none;
    }

    .pull-action.loading .am-icon-spin {
      display: block;
    }

    .pull-action.loading .pull-label {
      display: none;
    }
  </style>
</head>
<body>
<div class="page">
  <header data-am-widget="header" class="am-header am-header-default">
    <h1 class="am-header-title">
      参评项目
    </h1>
  </header>

  <div data-am-widget="list_news" class="am-list-news am-list-news-default">
  <!--列表标题-->
  <div class="am-list-news-hd am-cf">
    <!--带更多链接-->
    <a href="###" class="">
      <h2>项目简介</h2>
      <span class="am-list-news-more am-fr" onclick="document.location='Logout.aspx'">切换用户</span>
    </a>
  </div>
  <div class="am-list-news-bd">
    <ul class="am-list">
        <%
            foreach (var m in mL)
            {
                
            
             %>
      <li class="am-g am-list-item-desced">
        <a href="admin-index.aspx?ProjectId=<%=m.PROJID %>" class="am-list-item-hd "><%=m.PROJNAME %></a>
        <div >
            <%=m.PROJCONTENT %>
        </div>
      </li>
        <%
            }
             %>
<%--      <li class="am-g am-list-item-desced">
        <a href="http://www.douban.com/online/11624755/" class="am-list-item-hd ">我最喜欢的一张画</a>
        <div class="am-list-item-text">你最喜欢的艺术作品，告诉大家它们的------名图画，色彩，交织，撞色，线条雕塑装置当代古代现代作品的照片美我最喜欢的画群296795413进群发画，少说多发图，</div>
      </li>--%>

    </ul>
  </div>
</div>
</body>
</html>