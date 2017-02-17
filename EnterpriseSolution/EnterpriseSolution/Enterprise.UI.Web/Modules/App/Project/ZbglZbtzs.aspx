<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglZbtzs.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglZbtzs" ValidateRequest="false" EnableEventValidation="false" %>

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
                    <li class="last">中标通知书 </li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>

        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div1" class="ssec-form">
            <table id="Tb_MENU" runat="server">
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
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>中标通知书</span></a>
            </p>


            <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" width="568"
                style='width: 426.1pt; border-collapse: collapse; border: none'>
                <tr style='height: 1.0cm'>
                    <td width="127" colspan="2" rowspan="3" style='width: 95.3pt; border: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>中 标 单 位</span>
                        </p>
                    </td>
                    <td width="98" style='width: 73.45pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>名称</span>
                        </p>
                    </td>
                    <td width="343" colspan="3" style='width: 257.35pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'><asp:Label ID="Lb_P001" runat="server"></asp:Label></span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="98" style='width: 73.45pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>法人代表</span>
                        </p>
                    </td>
                    <td width="136" style='width: 101.85pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                    <td width="88" style='width: 66.2pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>项目经理</span>
                        </p>
                    </td>
                    <td width="119" style='width: 89.3pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="98" style='width: 73.45pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>联系电话</span>
                        </p>
                    </td>
                    <td width="136" style='width: 101.85pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                    <td width="88" style='width: 66.2pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='font-family: 宋体'>传真</span>
                        </p>
                    </td>
                    <td width="119" style='width: 89.3pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="127" colspan="2" style='width: 95.3pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>项目名称</span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'><asp:Label ID="Lb_P002" runat="server"></asp:Label></span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="127" colspan="2" style='width: 95.3pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>项目内容</span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='font-family: 宋体'>
                                <asp:TextBox ID="Txt_P003" runat="server" TextMode="MultiLine" Width="450" Height="100"></asp:TextBox>
                            </span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="55" rowspan="3" style='width: 41.45pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>中标条件</span>
                        </p>
                    </td>
                    <td width="72" style='width: 53.85pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>中标价</span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                lang="EN-US" style='font-family: 宋体'>(</span><span style='font-family: 宋体'>含税<span
                                    lang="EN-US">)</span></span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="72" style='width: 53.85pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>工期</span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="72" style='width: 53.85pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>其他</span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 1.0cm'>
                    <td width="127" colspan="2" style='width: 95.3pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>合同签订期限</span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 47.7pt'>
                    <td width="127" colspan="2" style='width: 95.3pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 47.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>领导签字</span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 47.7pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 148.3pt'>
                    <td width="127" colspan="2" style='width: 95.3pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 148.3pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>单位公章</span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 148.3pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
                </tr>
                <tr style='height: 34.9pt'>
                    <td width="127" colspan="2" style='width: 95.3pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 34.9pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                style='font-family: 宋体'>备注</span>
                        </p>
                    </td>
                    <td width="441" colspan="4" style='width: 330.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 34.9pt'>
                        <p class="MsoNormal" align="center" style='text-align: center; line-height: 11.0pt'>
                            <span
                                lang="EN-US" style='font-family: 宋体'>&nbsp;</span>
                        </p>
                    </td>
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

