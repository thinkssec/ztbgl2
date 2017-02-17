<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Enterprise.UI.Web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/ecmascript">
        $(function () {
            //关闭缓存
            $.ajaxSetup({ cache: false });
            //代办条数
            $.ajax({
                type: "post", url: "/Component/BF/BFLoadHandler.ashx?TypeId=0", datatype: "text", async: true,
                success: function (result)
                { setTimeout($("#daiban").html(result), 5000); }
            });
            //通知公告
            $.ajax({
                type: "post",
                url: "/Modules/Common/Article/Article.ashx?MType=1&Id=0101",
                datatype: "text",
                async: true,
                success: function (result) {
                    setTimeout($("#dAnnounce").html(result), 2000);
                    ////最新消息
                    //$.ajax({
                    //    type: "post",
                    //    url: "/Modules/Common/Article/Article.ashx?MType=0",
                    //    datatype: "text",
                    //    async: true,
                    //    success: function (result) {
                    //        setTimeout($("#dArticles").html(result), 1000);
                    //    }
                    //});
                }
            });
            ////宣传报道
            //$.ajax({
            //    type: "post",
            //    url: "/Modules/Common/Article/Article.ashx?MType=2",
            //    datatype: "text",
            //    async: true,
            //    success: function (result) {
            //        setTimeout($("#dXcbd").html(result), 3000);
            //    }
            //});
            ////交流论坛
            //$.ajax({
            //    type: "post",
            //    url: "/Modules/Common/Article/Article.ashx?MType=3",
            //    datatype: "text",
            //    async: true,
            //    success: function (result) {
            //        setTimeout($("#dBBS").html(result), 3000);
            //    }
            //});

        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'center',border:false" style="padding: 0px">
        <%--导航栏--%>
        <div style="padding-left: 5px; line-height: 32px;">
            <div>
                <img src="/Resources/OA/site_skin/images/bell.png" style="vertical-align: middle" />&nbsp;&nbsp; <%=GetBirthday() %>
            </div>

        </div>
        <div style="width: 472px; float: left; padding-bottom: 5px;">
            <%--快捷方式-start--%>
            <div class="easyui-panel" title=" <span style='padding-left:5px;'>快捷方式</span>" data-options="border:true,iconCls:'icon-color',headerCls:'ssec-pheader'" style="height: 255px; overflow: hidden;">
                <div style="padding-top: 35px; padding-left: 10px">
                    <div class="main-index-qlink">
                        <a href="/TodoIndexBox.aspx">
                            <img src="/Resources/OA/site_skin/default/icons/index/q1.png" alt="待办事务" />
                            <span>待办事务</span>
                        </a>
                        <div class="num" id="daiban">
                        </div>
                    </div>
<%--                    <div class="main-index-qlink">
                        <a href="#">
                            <img src="/Resources/OA/site_skin/default/icons/index/q2.png" alt="我的异常" />
                            <span>我的异常</span></a>
                        <div class="num">0</div>
                    </div>--%>
                    <div class="main-index-qlink">
                        <a href="/Modules/App/Project/ProjectRegister2.aspx?Cmd=New">
                            <img src="/Resources/OA/site_skin/default/icons/index/q3.png" alt="招标申请" /><span>招标申请</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>
                    <div class="main-index-qlink">
                        <a href="/Modules/App/Crm/CrmInfoList.aspx">
                            <img src="/Resources/OA/site_skin/default/icons/index/q11.png" alt="服务商" /><span>服务商库</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>
                    <div class="main-index-qlink">
                        <a href="/Modules/App/Crm/CrmPersonList.aspx">
                            <img src="/Resources/OA/site_skin/default/icons/index/q5.png" alt="专家库" /><span>专家管理</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>
                    <div class="main-index-qlink">
                        <a href="/Modules/App/Document/DocunmentList.aspx">
                            <img src="/Resources/OA/site_skin/default/icons/index/q6.png" alt="文档库" /><span>文档库</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>
                    <div class="main-index-qlink">
                        <a href="/Modules/App/Project/ProjectInfoList.aspx">
                            <img src="/Resources/OA/site_skin/default/icons/index/q8.png" alt="招标项目" /><span>招标项目</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>
                    <%--<div class="main-index-qlink">
                        <a href="/Modules/Common/Manager/ManagerMsgList.aspx">
                            <img src="/Resources/OA/site_skin/default/icons/index/q7.png" alt="领导信箱" /><span>领导信箱</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>
                    <div class="main-index-qlink">
                        <a href="/Modules/App/Project/ProjectDailyReport.aspx">
                            <img src="/Resources/OA/site_skin/default/icons/index/q8.png" alt="HSE管理" /><span>HSE管理</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>
                    <div class="main-index-qlink">
                        <a href="/Contract.aspx">
                            <img src="/Resources/OA/site_skin/default/icons/index/q9.png" alt="通讯录" /><span>通讯录</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>--%>
                    <div class="main-index-qlink">
                        <a href="<%=GetBBSVerifyUrl() %>" target="_blank">
                            <img src="/Resources/OA/site_skin/default/icons/index/q10.png" alt="系统帮助" /><span>系统帮助</span>
                        </a>
                        <div class="none">&nbsp;</div>
                    </div>
                </div>
            </div>

            <%--快捷方式-end--%>
        </div>
        <div style="width: 480px; float: right; height: 255px; padding-left: 5px; overflow: hidden">
            <%--通知公告列表展示-start--%>
            <%-- 
            <div class="easyui-panel" title="<span style='padding-left:5px;'>通知公告</span>" data-options="fit:true,border:true,iconCls:'icon-folder_table',headerCls:'ssec-pheader'" style="padding: 5px; overflow: hidden;">
                <div id="dAnnounce">
                    <img src="/Resources/OA/site_skin/images/loading_16x16.gif" alt="" title="" />
                </div>
            </div>
            --%>
            <div class="easyui-tabs" style="width:480px;height:255px">
                <%--<div id="dArticles" title="最新消息" data-options="iconCls:'icon-tip',closable:false" style="padding:10px">
		        </div>--%>
		        <div id="dAnnounce" title="通知公告" data-options="iconCls:'icon-folder_table',closable:false" style="padding:10px">
		        </div>
		        <%--<div id="dXcbd" title="宣传报道" data-options="iconCls:'icon-141',closable:false" style="padding:10px">
		        </div>
		        <div id="dBBS" title="交流论坛" data-options="iconCls:'icon-projectp4',closable:false" style="padding:10px">
		        </div>--%>
	        </div>
            <%--通知公告列表展示-end--%>
        </div>
    </div>

    <%--信息定制-end--%>
    <div data-options="region:'south',border:false" style="height: 350px">
        <div class="easyui-tabs" data-options="fit:true,border:true,tools:'#tab-tools'" id="usertab">
            <%=new Enterprise.Service.App.Ui.UiCustomService()
            .GetTabHtml(this.Page.User.Identity.Name) %>
        </div>
	</div>

    <%--扩展按钮--%>
    <div id="tab-tools" style="border-right: none">
        <a href="javascript:void(0)" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'" onclick="addPanel()"></a>
    </div>
    <div id="tabreg" class="easyui-window" data-options="title:'自定义标签',closed:true" style="width: 500px; height: 300px"></div>
    <script>
        function addPanel() {
            openwin('tabreg', "/Modules/App/Ui/UIIndexTabSet.aspx");
        }
    </script>

</asp:Content>
