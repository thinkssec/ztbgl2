<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglZbjgspb.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglZbjgspb" ValidateRequest="false" EnableEventValidation="false"%>

<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/EDropDownList.ascx" TagPrefix="uc1" TagName="EDropDownList" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>

<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Resources/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Resources/uploadify/jquery.uploadify.min.js"></script>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent"><%=Trans("首页") %></a></li>
                    <li>招标流程管理</li>
                    <li class="last">招标结果审批表 </li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>

        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div1" class="ssec-form">
            <table  id="Tb_MENU" runat="server">
                <tr>
                    <td><uc1:PopWinUploadMuti runat="server" ID="Txt_SCFJ"  Ext="Custom" Required="false"  />
                    </td>
                    <td width="80px">
                        <asp:LinkButton ID="BtnSave" runat="server" ClientIDMode="Static" CssClass="easyui-linkbutton" iconCls="icon-save" OnClick="BtnSave_Click" OnClientClick="showLoading();">保存</asp:LinkButton>
                    </td>
                    <td   width="100px">&nbsp;&nbsp;&nbsp;&nbsp;<a href='' class="easyui-linkbutton" id="H_Down" runat="server">下载</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td>&nbsp;
                        </td>
                    <%--<td width="100px" align="left">
                            <asp:LinkButton ID="Btn_UP" runat="server" ClientIDMode="Static" CssClass="easyui-linkbutton" iconCls="icon-save" OnClick="BtnSave_Up"  OnClientClick="showLoading();">上传</asp:LinkButton>
                        </td>--%>
                </tr>
            </table>
        </div>

        <asp:HiddenField ID="Hid_SMJ" runat="server" ClientIDMode="Static" />
        <div class="WordSection1" style='layout-grid: 15.6pt'>

            <p class="MsoTitle">
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>综合类项目招标结果审批表</span></a>
            </p>


            <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" width="568"
                style='width: 426.1pt; border-collapse: collapse; border: none'>
                <tr style='height: 1.0cm'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>项目名称</span>
                        </p>
                    </td>
                    <td width="215" colspan="3" style='width: 161.6pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_P001" runat="server"></asp:Label></span>
                        </p>
                    </td>
                    <td width="98" colspan="4" style='width: 73.45pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>项目编号</span>
                        </p>
                    </td>
                    <td width="155" colspan="2" style='width: 116.0pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_P002" runat="server"></asp:Label></span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>招标单位</span>
                        </p>
                    </td>
                    <td width="215" colspan="3" style='width: 161.6pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_P003" runat="server"></asp:Label></span>
                        </p>
                    </td>
                    <td width="98" colspan="4" style='width: 73.45pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>计划投资</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>（资金）</span>
                        </p>
                    </td>
                    <td width="155" colspan="2" style='width: 116.0pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_P004" runat="server"></asp:Label></span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>项目主要</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>内<span lang="EN-US">&nbsp; </span>容</span>
                        </p>
                    </td>
                    <td width="468" colspan="9" style='width: 351.05pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" style='layout-grid-mode: char'>
                            <span lang="EN-US"
                                style='font-family: 宋体; color: red'>
                                <asp:TextBox ID="Txt_P005" runat="server" TextMode="MultiLine" Width="450" Height="100"></asp:TextBox>

                            </span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>开标时间</span>
                        </p>
                    </td>
                    <td width="189" colspan="2" style='width: 141.65pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_P006" runat="server"></asp:Label></span>
                        </p>
                    </td>
                    <td width="92" colspan="3" style='width: 68.75pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>开标地点</span>
                        </p>
                    </td>
                    <td width="188" colspan="4" style='width: 140.65pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_P007" runat="server"></asp:Label></span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 22.7pt'>
                    <td width="100" rowspan="<%=pfL.Count+1 %>" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>评<span lang="EN-US">&nbsp; </span>标</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>情<span lang="EN-US">&nbsp; </span>况</span>
                        </p>
                    </td>
                    <td width="142" style='width: 106.35pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>投标单位</span>
                        </p>
                    </td>
                    <td width="87" colspan="3" style='width: 64.95pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>开标价</span>
                        </p>
                    </td>
                    <td width="76" colspan="2" style='width: 56.75pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>概算价</span>
                        </p>
                    </td>
                    <td width="85" colspan="2" style='width: 63.85pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>节约金额</span>
                        </p>
                    </td>
                    <td width="79" style='width: 59.15pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>节资率<span lang="EN-US"> %</span></span>
                        </p>
                    </td>
                </tr>
                <%
                         Enterprise.Model.App.Project.ProjectZjpfModel p0 = new Enterprise.Model.App.Project.ProjectZjpfModel();
                    for (int i = 0; i < pfL.Count; i++) { 
                        p0=pfL[i];
                        %>
                <tr style='height: 22.7pt'>
                    <td width="142" style='width: 106.35pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'><%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName(p0.CRMINFO) %></span>
                        </p>
                    </td>
                    <td width="87" colspan="3" style='width: 64.95pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体; color: red'>&nbsp;</span>
                        </p>
                    </td>
                    <td width="76" colspan="2" style='width: 56.75pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体; color: red'>&nbsp;</span>
                        </p>
                    </td>
                    <td width="85" colspan="2" style='width: 63.85pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体; color: red'>&nbsp;</span>
                        </p>
                    </td>
                    <td width="79" style='width: 59.15pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 22.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <%} %>
                
                <tr style='height: 60.4pt'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 60.4pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>招标单位</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>申报意见</span>
                        </p>
                    </td>
                    <td width="468" colspan="9" style='width: 351.05pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 60.4pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>按照评标办法，经评标委员会评审（评标报告另附），拟推荐中标单位如下：</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span>
                        </p>
                        <p class="MsoNormal" align="center" style='margin-left: 197.6pt; text-align: center; text-indent: -5.25pt; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>（公章）</span>
                        </p>
                        <p class="MsoNormal" align="center" style='margin-left: 197.6pt; text-align: center; text-indent: -5.25pt; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;</span><span style='font-family: 宋体'>年<span lang="EN-US">&nbsp;&nbsp; </span>月<span
                                lang="EN-US">&nbsp;&nbsp; </span>日</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 24.4pt'>
                    <td width="568" colspan="10" style='width: 426.1pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 24.4pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>审<span lang="EN-US">&nbsp; </span>批<span
                                lang="EN-US">&nbsp; </span>意<span lang="EN-US">&nbsp; </span>见</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 46.0pt'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 46.0pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>业务管理</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>部门</span>
                        </p>
                    </td>
                    <td width="468" colspan="9" style='width: 351.05pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 46.0pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>（公章）</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>年<span lang="EN-US">&nbsp;&nbsp;&nbsp; </span>月<span
                                lang="EN-US">&nbsp;&nbsp;&nbsp; </span>日</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 34.6pt'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 34.6pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>招标投标专业办公室</span>
                        </p>
                    </td>
                    <td width="468" colspan="9" valign="top" style='width: 351.05pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 34.6pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>（公章）</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>年<span lang="EN-US">&nbsp;&nbsp;&nbsp; </span>月<span
                                lang="EN-US">&nbsp;&nbsp;&nbsp; </span>日</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 42.85pt'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.85pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>招标投标办公室</span>
                        </p>
                    </td>
                    <td width="468" colspan="9" valign="top" style='width: 351.05pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.85pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>（公章）</span>
                        </p>
                        <p class="MsoNormal">
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>年<span lang="EN-US">&nbsp;&nbsp;&nbsp; </span>月<span
                                lang="EN-US">&nbsp;&nbsp;&nbsp; </span>日</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 49.2pt'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 49.2pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>招标投标管理委员会副主任</span>
                        </p>
                    </td>
                    <td width="468" colspan="9" style='width: 351.05pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 49.2pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>（公章）</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>年<span lang="EN-US">&nbsp;&nbsp;&nbsp; </span>月<span
                                lang="EN-US">&nbsp;&nbsp;&nbsp; </span>日</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 2.0cm'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 2.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>招标投标管理委员会主任</span>
                        </p>
                    </td>
                    <td width="468" colspan="9" style='width: 351.05pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 2.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>（公章）</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span><span style='font-family: 宋体'>年<span lang="EN-US">&nbsp;&nbsp;&nbsp; </span>月<span
                                lang="EN-US">&nbsp;&nbsp;&nbsp; </span>日</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 30.7pt'>
                    <td width="100" style='width: 75.05pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 30.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span style='font-family: 宋体'>备<span lang="EN-US">&nbsp; </span>注</span>
                        </p>
                    </td>
                    <td width="468" colspan="9" style='width: 351.05pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 30.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                            <span lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr height="0">
                    <td width="100" style='border: none'></td>
                    <td width="142" style='border: none'></td>
                    <td width="47" style='border: none'></td>
                    <td width="27" style='border: none'></td>
                    <td width="13" style='border: none'></td>
                    <td width="52" style='border: none'></td>
                    <td width="24" style='border: none'></td>
                    <td width="9" style='border: none'></td>
                    <td width="76" style='border: none'></td>
                    <td width="79" style='border: none'></td>
                </tr>
            </table>





        </div>

    </div>
    <script>
        function v() {

            return $('#form1').form('validate');
        }
    </script>
    <%--end--%>
</asp:Content>

