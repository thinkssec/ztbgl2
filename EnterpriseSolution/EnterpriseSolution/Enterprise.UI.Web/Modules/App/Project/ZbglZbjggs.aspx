<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglZbjggs.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglZbjggs" ValidateRequest="false"  EnableEventValidation="false"%>

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
                    <li class="last">中标结果公示 </li>
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
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>中标结果公示</span></a>
            </p>


                <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" width="568"
                    style='width: 426.1pt; border-collapse: collapse; border: none'>
                    <tr style='height: 42.55pt'>
                        <td width="100" style='width: 75.2pt; border: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>项目名称</span>
                            </p>
                        </td>
                        <td width="216" colspan="2" style='width: 162.0pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'>
                                    <asp:Label ID="Lb_P001" runat="server"></asp:Label>
                                </span>
                            </p>
                        </td>
                        <td width="97" colspan="3" style='width: 72.5pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>项目编号</span>
                            </p>
                        </td>
                        <td width="155" colspan="2" style='width: 116.4pt; border: solid windowtext 1.0pt; border-left: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'> <asp:Label ID="Lb_P002" runat="server"></asp:Label></span>
                            </p>
                        </td>
                    </tr>
                    <tr style='height: 42.55pt'>
                        <td width="100" style='width: 75.2pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>招标单位</span>
                            </p>
                        </td>
                        <td width="216" colspan="2" style='width: 162.0pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'> <asp:Label ID="Lb_P003" runat="server"></asp:Label></span>
                            </p>
                        </td>
                        <td width="97" colspan="3" style='width: 72.5pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>预算金额</span>
                            </p>
                        </td>
                        <td width="155" colspan="2" style='width: 116.4pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'> <asp:Label ID="Lb_P004" runat="server"></asp:Label>(万元)</span>
                            </p>
                        </td>
                    </tr>
                    <tr style='height: 42.55pt'>
                        <td width="100" style='width: 75.2pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>项目主要</span>
                            </p>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>内<span lang="EN-US">&nbsp; </span>容</span>
                            </p>
                        </td>
                        <td width="468" colspan="7" style='width: 350.9pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="left" style='text-align: left; text-indent: 21.0pt; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'>
                                    <asp:TextBox ID="Txt_P005" runat="server" TextMode="MultiLine" Width="450" Height="100"></asp:TextBox>

                                </span>
                            </p>
                        </td>
                    </tr>
                    <tr style='height: 42.55pt'>
                        <td width="100" style='width: 75.2pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>开标时间</span>
                            </p>
                        </td>
                        <td width="196" style='width: 147.35pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'><asp:Label ID="Lb_P006" runat="server"></asp:Label></span>
                            </p>
                        </td>
                        <td width="83" colspan="3" style='width: 62.45pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>开标地点</span>
                            </p>
                        </td>
                        <td width="188" colspan="3" style='width: 141.1pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'> <asp:Label ID="Lb_P007" runat="server"></asp:Label></span>
                            </p>
                        </td>
                    </tr>
                    <tr style='height: 1.0cm'>
                        <td width="100" rowspan="<%=pfL.Count+1 %>" style='width: 75.2pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>评<span lang="EN-US">&nbsp; </span>标</span>
                            </p>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>情<span lang="EN-US">&nbsp; </span>况</span>
                            </p>
                        </td>

                        <td width="237" colspan="3" style='width: 177.75pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>投标单位</span>
                            </p>
                        </td>
                        <td width="123" colspan="3" style='width: 92.35pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>得<span lang="EN-US">&nbsp; </span>分</span>
                            </p>
                        </td>
                        <td width="108" style='width: 80.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>排名</span>
                            </p>
                        </td>
                    </tr>
                     <%
                         Enterprise.Model.App.Project.ProjectZjpfModel p0 = new Enterprise.Model.App.Project.ProjectZjpfModel();
                    for (int i = 0; i < pfL.Count; i++) { 
                        p0=pfL[i];
                        %>
                    <tr style='height: 1.0cm'>
                        <td width="237" colspan="3" style='width: 177.75pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal" align="center" style='text-align: center'>
                                <span lang="EN-US"
                                    style='font-family: 宋体'><%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName(p0.CRMINFO) %></span>
                            </p>
                        </td>
                        <td width="123" colspan="3" style='width: 92.35pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'><%=p0.PF %></span>
                            </p>
                        </td>
                        <td width="108" style='width: 80.8pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'><%=i+1 %></span>
                            </p>
                        </td>
                    </tr>
                    <%
                    } %>
                    
                    <tr style='height: 42.55pt'>
                        <td width="100" style='width: 75.2pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>接收评标报告时间</span>
                            </p>
                        </td>
                        <td width="468" colspan="7" style='width: 350.9pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'>
                                    <asp:TextBox ID="Txt_P008" runat="server" CssClass="easyui-datetimebox" data-options="showSeconds:false"></asp:TextBox>
                                </span>
                            </p>
                        </td>
                    </tr>
                    <tr style='height: 42.55pt'>
                        <td width="100" style='width: 75.2pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>公示时间</span>
                            </p>
                        </td>
                        <td width="468" colspan="7" style='width: 350.9pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 42.55pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span lang="EN-US" style='font-family: 宋体'>

                                    <asp:TextBox ID="Txt_P009" runat="server" CssClass="easyui-datetimebox" data-options="showSeconds:false"></asp:TextBox>
                                </span>
                            </p>
                        </td>
                    </tr>
                    <tr style='height: 2.0cm'>
                        <td width="100" style='width: 75.2pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 2.0cm'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>异议受理形式</span>
                            </p>
                        </td>
                        <td width="468" colspan="7" style='width: 350.9pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 2.0cm'>
                            <p class="MsoNormal" align="left" style='text-align: left; text-indent: 21.0pt'>
                                <span
                                    style='font-family: 宋体'>投标人或者其他利害关系人对本次招标项目的评标结果有异议的，应当在招标结果公示期间提出。招标人将在自收到异议之日起<span
                                        lang="EN-US">3</span>日内作出答复。</span>
                            </p>
                        </td>
                    </tr>
                    <tr style='height: 73.45pt'>
                        <td width="100" style='width: 75.2pt; border: solid windowtext 1.0pt; border-top: none; padding: 0cm 5.4pt 0cm 5.4pt; height: 73.45pt'>
                            <p class="MsoNormal" align="center" style='text-align: center; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>受理部门及联系方式</span>
                            </p>
                        </td>
                        <td width="468" colspan="7" style='width: 350.9pt; border-top: none; border-left: none; border-bottom: solid windowtext 1.0pt; border-right: solid windowtext 1.0pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 73.45pt'>
                            <p class="MsoNormal" align="left" style='text-align: left; text-indent: 21.0pt; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>部<span lang="EN-US">&nbsp;&nbsp;&nbsp;
                                </span>门：纪检监察部</span>
                            </p>
                            <p class="MsoNormal" align="left" style='text-align: left; text-indent: 21.0pt; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>联 系 人：</span><span
                                    lang="EN-US" style='font-family: 宋体'> </span>
                            </p>
                            <p class="MsoNormal" align="left" style='text-align: left; text-indent: 21.0pt; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>举报电话：<span lang="EN-US">027-81992305&nbsp;&nbsp;
  027-81992336</span></span>
                            </p>
                            <p class="MsoNormal" align="left" style='text-align: left; text-indent: 21.0pt; layout-grid-mode: char'>
                                <span style='font-family: 宋体'>举报信箱：</span><a
                                    href="mailto:CQDSjijian@126.COM"><span lang="EN-US" style='font-family: 宋体; color: windowtext; text-decoration: none'>CQDSJIJIAN@126.COM</span></a>
                            </p>
                        </td>
                    </tr>
                    <tr height="0">
                        <td width="100" style='border: none'></td>
                        <td width="196" style='border: none'></td>
                        <td width="20" style='border: none'></td>
                        <td width="21" style='border: none'></td>
                        <td width="43" style='border: none'></td>
                        <td width="33" style='border: none'></td>
                        <td width="47" style='border: none'></td>
                        <td width="108" style='border: none'></td>
                    </tr>
                </table>


            <p class="MsoNormal" style='line-height: 27.0pt'>
                <span lang="EN-US"
                    style='font-size: 16.0pt'>&nbsp;</span>
            </p>

            <p class="MsoNormal" style=' line-height: 20.0pt; layout-grid-mode: char'>
                <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </span><span style='font-family: 宋体'>中国石油化工股份有限公司</span>
            </p>

            <p class="MsoNormal" style='line-height: 20.0pt; layout-grid-mode: char'>
                <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </span><span style='font-family: 宋体'>天然气川气东送管道分公司</span>
            </p>

            <p class="MsoNormal"  style=' line-height: 20.0pt; layout-grid-mode: char'>
                <span lang="EN-US" style='font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </span><span style='font-family: 宋体'>年<span lang="EN-US">&nbsp; </span>月<span
                    lang="EN-US">&nbsp; </span>日</span>
            </p>

            <p class="MsoNormal" style='line-height: 27.0pt'>
                <span lang="EN-US"
                    style='font-size: 16.0pt'>&nbsp;</span>
            </p>

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

