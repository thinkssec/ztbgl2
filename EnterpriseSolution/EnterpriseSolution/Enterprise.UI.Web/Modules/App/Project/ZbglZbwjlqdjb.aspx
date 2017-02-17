<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglZbwjlqdjb.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglZbwjlqdjb" ValidateRequest="false" enableEventValidation="false"%>

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
                    <li class="last">招标文件领取登记表 </li>
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
        <div class="WordSection1" style='layout-grid: 15.6pt 0pt'>

            <p class="MsoTitle">
                <a name="_Toc402171554"><span style='font-size: 18.0pt; font-family: 宋体'>招标文件领取登记表</span></a>
            </p>

            <p class="MsoNormal" align="left" style='text-align: left; line-height: 47.0pt'>
                <span
                    style='font-family: 宋体'>招标项目名称：</span><span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_PNAME" runat="server"></asp:Label></span><span
                        lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </span><span style='font-family: 宋体'>招标文件编号：</span><span lang="EN-US"
                        style='font-family: 宋体'><asp:Label ID="Lb_PNUMBER" runat="server"></asp:Label></span>
            </p>

            <p class="MsoNormal" style='line-height: 27.0pt'>
                <span style='font-family: 宋体; color: black; letter-spacing: -.2pt'>领取地点：<asp:TextBox ID="Txt_param_001" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" /></span>
            </p>

            <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" width="945"
                style='width: 708.7pt; border-collapse: collapse; border: none'>
                <tr style='height: 21.35pt'>
                    <td width="51" style='width: 38.0pt; border: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 21.35pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>序号</span>
                        </p>
                    </td>
                    <td width="306" style='width: 229.65pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 21.35pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>投标人</span>
                        </p>
                    </td>
                    <td width="170" style='width: 127.6pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 21.35pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>领取时间</span>
                        </p>
                    </td>
                    <td width="104" style='width: 77.9pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 21.35pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>领取人</span>
                        </p>
                    </td>
                    <td width="142" style='width: 106.3pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 21.35pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>联系电话</span>
                        </p>
                    </td>
                    <td width="172" style='width: 129.25pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 21.35pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>邮箱</span>
                        </p>
                    </td>
                </tr>
                <%
                    int i = 0;
                    foreach (var m in fwsL)
                    {
                        i++;
                %>
                <tr style='height: 20.95pt'>
                    <td width="51" style='width: 38.0pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 20.95pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'><%=i %></span>
                        </p>
                    </td>
                    <td width="306" style='width: 229.65pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 20.95pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'><%=m.CRMNAME %></span>
                        </p>
                    </td>
                    <td width="170" style='width: 127.6pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 20.95pt'>
                        <p class="MsoNormal" align="right" style='text-align: right'>
                            <span
                                style='font-family: 宋体; color: black'><span lang="EN-US">&nbsp; </span></span><span
                                    lang="EN-US" style='font-family: 宋体'>年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;月&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;日&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;时</span>
                        </p>
                    </td>
                    <td width="104" style='width: 77.9pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 20.95pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体; color: black'>&nbsp;</span>
                        </p>
                    </td>
                    <td width="142" style='width: 106.3pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 20.95pt'>
                        <p class="MsoNormal" align="left" style='text-align: left'>
                            <span style='font-family: 宋体; color: black'></span>
                        </p>
                    </td>
                    <td width="172" style='width: 129.25pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 20.95pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'></span>
                        </p>
                    </td>
                </tr>
                <%
                    } %>
            </table>

            <p class="MsoNormal" style='line-height: 27.0pt'>
                <span lang="EN-US"
                    style='font-family: 宋体; color: black'>&nbsp;</span><span style='font-family: 宋体; color: black'>发放（售）人：</span><span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_SUBMITTER" runat="server"></asp:Label></span>
            </p>

        </div>
    </div>
    <script>
        function v() {

            return $('#form1').form('validate');
        }
    </script>
    <%--end--%>
</asp:Content>

