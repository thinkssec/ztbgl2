<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglPbhqdb.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglPbhqdb" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/EDropDownList.ascx" TagPrefix="uc1" TagName="EDropDownList" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>

<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
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
                    <li class="last">评标会签到表</li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>

        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div1" class="ssec-form">
            <table>
                <tr>
                    <td><uc1:PopWinUploadMuti runat="server" ID="Txt_SCFJ"  Ext="Custom" Required="false"  />
                    </td>
                    <td width="80px">
                        <asp:LinkButton ID="BtnSave" runat="server" ClientIDMode="Static" CssClass="easyui-linkbutton" iconCls="icon-save" OnClick="BtnSave_Click" OnClientClick="showLoading();">保存</asp:LinkButton>
                    </td>
                    <td   width="100px">&nbsp;&nbsp;&nbsp;&nbsp;<a href='' class="easyui-linkbutton" id="H_Down" runat="server">下载</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td   width="100px">
                        <a href='' class="easyui-linkbutton" id="H_Fj" runat="server" onclick="">查看附件</a>
                        <div id="openwin" class="easyui-window" style="width: 600px; height: 360px" title="附件信息" closed="true" modal="true"></div>
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
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>评标会签到表</span></a>
            </p>

            <p class="MsoNoSpacing">
                <span style='font-family: 宋体'>招标项目名称：</span><span
                    lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_PNAME" runat="server"></asp:Label></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>招标文件编号：<span lang="EN-US"><asp:Label ID="Lb_PNUMBER" runat="server"></asp:Label></span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>开标地点：<span lang="EN-US"><asp:Label ID="Lb_P001" runat="server"></asp:Label></span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>截标时间：</span><span lang="EN-US" style='line-height: 150%; font-family: 宋体'><asp:Label ID="Lb_P002" runat="server"></asp:Label></span>
            </p>

            <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" width="640"
                style='width: 480.3pt; border-collapse: collapse; border: none'>
                <tr style='height: 1.0cm'>
                    <td width="64" style='width: 47.95pt; border: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>序号</span>
                        </p>
                    </td>
                    <td width="180" style='width: 134.65pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>单位</span>
                        </p>
                    </td>
                    <td width="76" style='width: 2.0cm; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>姓名</span>
                        </p>
                    </td>
                    <td width="76" style='width: 2.0cm; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>职称</span>
                        </p>
                    </td>
                    <td width="78" style='width: 58.7pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>联系电话</span>
                        </p>
                    </td>
                    <td width="84" valign="top" style='width: 62.8pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>职责</span>
                        </p>
                    </td>
                    <td width="84" valign="top" style='width: 62.8pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>签名</span>
                        </p>
                    </td>
                </tr>
                <%
                    int i = 0;
                    foreach (var m in fwsL) {
                        i++;
                     %>
                <tr style='height: 1.0cm'>
                    <td width="64" style='width: 47.95pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'><%=i %></span>
                        </p>
                    </td>
                    <td width="180" style='width: 134.65pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'>中国石化天然气川气东送管道分公司</span>
                        </p>
                    </td>
                    <td width="76" style='width: 2.0cm; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'><%=m.PERSONNAME %></span>
                        </p>
                    </td>
                    <td width="76" style='width: 2.0cm; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体; color: red'>&nbsp;</span>
                        </p>
                    </td>
                    <td width="78" style='width: 58.7pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体; color: red'>&nbsp;</span>
                        </p>
                    </td>
                    <td width="84" valign="top" style='width: 62.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'>评委</span>
                        </p>
                    </td>
                    <td width="84" valign="top" style='width: 62.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <%
                    
                } %>
            </table>

            <p class="MsoNormal"><span lang="EN-US">&nbsp;</span></p>

        </div>

    </div>
    <script>
        function v() {

            return $('#form1').form('validate');
        }
    </script>
    <%--end--%>
</asp:Content>

