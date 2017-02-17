<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SiteMap.aspx.cs" Inherits="Enterprise.UI.Web.Component.Map.SiteMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN"
	"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta name="author" content="Matt Everson of Astuteo, LLC – http://astuteo.com/slickmap" />
	<title>站点地图</title>
	<link rel="stylesheet" type="text/css" media="screen, print" href="slickmap.css" />
</head>

<body>
	<div class="sitemap">
		<h1>FIOC一体化协同平台</h1>
		<h2>Site Map Version 1.0</h2>
		<ul id="utilityNav">
			<li><a href="/Login.aspx">Log In</a></li>
			<li><a href="/Component/Map/SiteMap.aspx">Site Map</a></li>
            <li><a href="/Help/Helper.aspx">Help</a></li>
		</ul>
		<ul id="primaryNav" class="col4">
			<li id="home"><a href="/Default.aspx">Home</a></li>
			<li><a href="/">办公事务</a>
				<ul>
					<li><a href="/Modules/Common/Article/ArticleList.aspx?ModuleId=28">通知公告</a></li>
                    <li><a href="/">规章制度</a></li>
                    <li><a href="/">工作流程</a></li>
                    <li><a href="/Modules/Common/Meeting/MeetingList.aspx">会议管理</a></li>
                    <li><a href="/Modules/Common/Office/OfficeIndex.aspx">公文管理</a></li>
                    <li><a href="/Modules/Common/Busitravel/BusitravelIndex.aspx">差旅管理</a></li>
                    <li><a href="/Modules/Common/Supervise/SuperviseIndex.aspx">事务督办</a></li>
				</ul>
			</li>
			<li><a href="/Modules/App/QYWH/Page01.aspx">企业文化</a>
				<ul>
					<li><a href="/Modules/App/QYWH/Page02.aspx">愿景体系</a></li>
                    <li><a href="/Modules/App/Qywh/Page03.aspx">公司作风</a></li>
                    <li><a href="/Modules/App/Qywh/Page04.aspx">管理理念</a></li>
                    <li><a href="/Modules/App/Qywh/Page05.aspx">管理意识</a></li>
                    <li><a href="/Modules/App/Qywh/Page06.aspx">FIOC之窗</a></li>
                    <li><a href="/Modules/App/Qywh/Page07.aspx">文化园地</a></li>
				</ul>
			</li>
            <li><a href="/">公共事务</a>
				<ul>
					<li><a href="/Modules/Common/Manager/ManagerMsgList.aspx">领导信箱</a></li>
                    <li><a href="/Modules/Common/EntDisk/Index.aspx">公共存储</a></li>
                    <li><a href="/Modules/Common/Vote/VoteIndex.aspx">网上调查</a></li>
				</ul>
			</li>
            <li><a href="/">个人事务</a>
				<ul>
					<li><a href="/Modules/Common/EntDisk/Index.aspx?typeId=1">个人存储</a></li>
                    <li><a href="/Modules/Common/Notice/NoticeIndex.aspx">个人备忘</a></li>
                    <li><a href="/Modules/Common/WebMail/WebMailInbox.aspx">我的邮件</a></li>
                    <li><a href="/Modules/Common/UserConfig/UserWfConfig.aspx">审批授权</a></li>
                    <li><a href="/Modules/Basis/Dictionary/DictionaryList.aspx">字典表</a></li>
				</ul>
			</li>
            <li><a href="/">业务管理</a>
				<ul>
                    <li><a href="/Modules/App/Cwb/Cwb_Index.aspx">财务管理</a></li>
                    <li><a href="/Modules/App/Jhb/JhbIndex.aspx">计划经营</a></li>
                    <li><a href="/">勘探管理</a></li>
                    <li><a href="/Modules/App/Kfb/Kfb_ChanliangIndex.aspx">开发生产</a></li>
                    <li><a href="/">法律事务</a></li>
                    <li><a href="/Modules/App/Yymyb/Yymyb_XiaoshouIndex.aspx">原油销售</a></li>
                    <li><a href="/Modules/App/Gcb/Gcb_ZuanjingChart.aspx">工程技术</a></li>
                    <li><a href="/">地面建设</a></li>
                    <li><a href="/">HSSE</a></li>
				</ul>
			</li>
            <li><a href="/">绩效考核</a>
				<ul>
					<li><a href="http://118.186.56.88:8009/Login.aspx">人员考核</a></li>
                    <li><a href="http://118.186.56.88:8008/Login.aspx">机构考核</a></li>
				</ul>
			</li>
            <li><a href="/">人力资源</a>
				<ul>
					<li><a href="/Modules/Basis/User/UserList.aspx">用户管理</a></li>
                    <li><a href="/Modules/Basis/DepartMent/DepartMentList.aspx">组织机构</a></li>
                    <li><a href="/Modules/Basis/Duty/DutyIndex.aspx">职务管理</a></li>
				</ul>
			</li>
		</ul>
	</div>
</body>
</html>
