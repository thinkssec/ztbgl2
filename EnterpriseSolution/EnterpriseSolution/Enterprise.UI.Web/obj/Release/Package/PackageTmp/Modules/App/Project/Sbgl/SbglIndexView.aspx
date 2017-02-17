<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" ValidateRequest="false"
    CodeBehind="SbglIndexView.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.Sbgl.SbglIndexView" %>

<%@ Import Namespace="Enterprise.Model.App.Project" %>
<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Resources/OA/jqplot-1.08/jquery.jqplot.min.css" />
    <!--[if lt IE 9]>
    <script language="javascript" type="text/javascript" src="/Resources/OA/jqplot-1.08/excanvas.js"></script>
    <![endif]-->
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/jquery.jqplot.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.pieRenderer.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.highlighter.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.logAxisRenderer.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.canvasTextRenderer.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.canvasAxisLabelRenderer.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.canvasAxisTickRenderer.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.dateAxisRenderer.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.categoryAxisRenderer.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/jqplot-1.08/plugins/jqplot.barRenderer.min.js"></script>
    <link rel="stylesheet" type="text/css" href="/Resources/OA/jqplot-1.08/jquery.jqplot.min.css" />
    <script type="text/javascript">
        //清除所有错误
        window.onerror = function (e) {
            return true;
        };
    </script>
    <style type="text/css">
        .td-right {
            text-align:right;
            height:18px;
        }
        .td-bold {
            font-weight:bold;
            height:18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/" target="_parent">首页</a>
                    </li>
                    <li>设备管理</li>
                    <li class="last">业务动态</li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <%--自定义按钮--%>
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <%--end--%>
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">

        <table style="padding: 0px; margin: 0px">
            <tr>
                <td style="vertical-align: top; width: 100%">
                    <div id="p1" class="easyui-panel" title="信息面板"
                        style="height: 250px; width: auto; padding: 10px;"
                        data-options="closable:false,
                collapsible:false,minimizable:false,maximizable:false">
                        <table style="padding: 0px; margin: 0px; width: 100%">
                            <tr>
                                <td style="vertical-align: top; text-align: left; width: auto;">
                                    <%-- 基础信息 --%>
                                    <table class="project-table" style="width: 98%;">
                                        <tr>
                                            <td class="td-bold">本月设备维修计划数量</td>
                                            <td><%//=Enterprise.Service.App.Examine.ExamineKindService.GetTypeName(ProjectModel.KINDID) %></td>
                                            <td class="td-bold">本年设备维修计划数量</td>
                                            <td><%//=ProjectModel.PRINCIPAL %></td>
                                        </tr>
                                        <tr>
                                            <td style="width: 20%" class="td-bold">本月设备维修累计数量</td>
                                            <td style="width: 30%"><%//=ProjectModel.PROJNAME %></td>
                                            <td style="width: 20%" class="td-bold">本年设备维修累计数量</td>
                                            <td style="width: 30%"><%//=ProjectModel.PROJNUMBER %></td>
                                        </tr>
                                        <tr>
                                            <td class="td-bold">本月设备维修预计费用</td>
                                            <td><%//=ProjectModel.CrmPerson.CrmInfo.CRMNAME %></td>
                                            <td class="td-bold">本年设备维修预计费用</td>
                                            <td><%//=ProjectModel.STARTDATE.ToDateYMDFormat()%></td>
                                        </tr>
                                        <tr>
                                            <td class="td-bold">本月设备维修结算费用</td>
                                            <td><%//=Enterprise.Service.Basis.Sys.SysUserService.GetUserName(ProjectModel.ProjectManager) %></td>
                                            <td class="td-bold">本年设备维修结算费用</td>
                                            <td><%//=GetProjectStatus()%></td>
                                        </tr>
                                        <tr>
                                            <td class="td-bold">待审核维修申请</td>
                                            <td><%//=ProjectModel.CrmPerson.CrmInfo.CRMNAME %></td>
                                            <td class="td-bold">维修中的设备数量</td>
                                            <td><%//=ProjectModel.STARTDATE.ToDateYMDFormat()%></td>
                                        </tr>
                                        <tr>
                                            <td class="td-bold">待审核的结算申请</td>
                                            <td><%//=ProjectModel.CrmPerson.CrmInfo.CRMNAME %></td>
                                            <td class="td-bold">已验收的设备数量</td>
                                            <td><%//=ProjectModel.STARTDATE.ToDateYMDFormat()%></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="text-align: center; vertical-align: central; width: 190px;">
                                    <%-- 日历 --%>
                                    <div id="cc" class="easyui-calendar" style="height: 180px; width: 180px;"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td style="vertical-align: top"></td>
            </tr>
        </table>
    </div>
    <style>
        .reported {
            background-color: #b4f7f7;
        }
    </style>
    <script>
        //var reporteddays = "<%//=ReportedDays%>";//数据库已存在的日报
        //var reportDay = new Date(<%//=ReportDay.AddMonths(-1).ToString("yyyy,M,d")%>);
        $(function () {
            $('#cc').calendar({
                onSelect: function (date) {
                    //var day = date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
                    //window.location.href = "Daily/ProjectDaily.aspx?ProjectId=" + "&Day=" + day;
                }
            });
            //根据参数 移动到指定日期
            $('#cc').calendar('moveTo', new Date(<%=ReportDay.AddMonths(-1).ToString("yyyy,M,d")%>));
        });
    </script>

</asp:Content>