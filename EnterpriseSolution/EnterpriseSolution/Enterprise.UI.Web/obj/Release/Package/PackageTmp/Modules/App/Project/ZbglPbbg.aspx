<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglPbbg.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglPbbg" ValidateRequest="false"  EnableEventValidation="false"%>

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
                    <li class="last">评标报告 </li>
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
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>评标报告</span></a>
            </p>

            <table class="MsoNormalTable" border="1" cellspacing="0" cellpadding="0" width="568"
                style='width: 426.1pt; border-collapse: collapse; border: none; mso-border-alt: solid black .5pt; mso-yfti-tbllook: 1184; mso-padding-alt: 0cm 5.4pt 0cm 5.4pt; mso-border-insideh: .5pt solid black; mso-border-insidev: .5pt solid black'>
                <tr style='mso-yfti-irow: 0; mso-yfti-firstrow: yes; height: 67.3pt'>
                    <td width="105" style='width: 78.55pt; border: solid black 1.0pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 67.3pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>评标委员<span lang="EN-US"></span></span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>会成员<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <td width="463" colspan="3" style='width: 347.55pt; border: solid black 1.0pt; border-left: none; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 67.3pt'>
                        <p class="MsoNormal" align="left" style='text-align: left'>
                            <span style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>主任：<span lang="EN-US"><asp:Label ID="Lb_P001" runat="server"></asp:Label></span></span>
                        </p>
                        <p class="MsoNormal" align="left" style='margin-left: 10.5pt; text-align: left; text-indent: -10.5pt; mso-char-indent-count: -1.0'>
                            <span style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>成员：<span lang="EN-US"><asp:Label ID="Lb_P002" runat="server"></asp:Label></span></span>
                        </p>
                    </td>
                </tr>
                <tr style='mso-yfti-irow: 1; height: 1.0cm'>
                    <td width="105" rowspan="3" style='width: 78.55pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>开标情<span lang="EN-US"></span></span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span class="GramE"><span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>况</span></span><span style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>记录<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <td width="463" colspan="3" style='width: 347.55pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>开标地点：<span lang="EN-US"><asp:Label ID="Lb_P003" runat="server"></asp:Label></span></span>
                        </p>
                    </td>
                </tr>
                <tr style='mso-yfti-irow: 2; height: 1.0cm'>
                    <td width="463" colspan="3" style='width: 347.55pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>开标时间：<span lang="EN-US"><asp:Label ID="Lb_P004" runat="server"></asp:Label></span></span>
                        </p>
                    </td>
                </tr>
                <tr style='mso-yfti-irow: 3; height: 1.0cm'>
                    <td width="463" colspan="3" style='width: 347.55pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>开标程序： <span lang="EN-US">
                                <asp:TextBox ID="Txt_P005" Width="350"  runat="server" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/>
                                                                                                                                 </span></span>
                        </p>
                    </td>
                </tr>
                <tr style='mso-yfti-irow: 4; height: 1.0cm'>
                    <td width="105" rowspan="<%=fwsL.Count %>" style='width: 78.55pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>投标一览表<span lang="EN-US"></span></span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>是否符合要求<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <%
                        Enterprise.Model.App.Project.ProjectFwsModel f0= new Enterprise.Model.App.Project.ProjectFwsModel();
                        if(fwsL.Count>0) f0=fwsL[0];
                            %>

                        <td width="307" colspan="2" style='width: 230.05pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal">
                                <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'><%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName( f0.CRMINFO) %></span>
                            </p>
                        </td>

                    <td width="157" style='width: 117.5pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>符合/不符合</span>
                        </p>
                    </td>
                </tr>
                <%
                    for (int i = 1; i < fwsL.Count;i++ )
                    {
                        f0=fwsL[i];
                    %>
                <tr style='mso-yfti-irow: 5; height: 1.0cm'>
                    <td width="307" colspan="2" style='width: 230.05pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                            <p class="MsoNormal">
                                <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'><%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName( f0.CRMINFO) %></span>
                            </p>
                        </td>

                    <td width="157" style='width: 117.5pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>符合/不符合</span>
                        </p>
                    </td>
                </tr>

                <%
                    }
                     %>
                
                <tr style='mso-yfti-irow: 10; height: 1.0cm'>
                    <td width="105" style='width: 78.55pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span class="GramE"><span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>废标情况</span></span><span style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>说明<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <td width="463" colspan="3" style='width: 347.55pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>
                               <asp:TextBox ID="Txt_P006" Width="400"  runat="server" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/>
                            </span>
                        </p>
                    </td>
                </tr>
                <tr style='mso-yfti-irow: 11; height: 1.0cm'>
                    <td width="105" style='width: 78.55pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>评标方法<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <td width="463" colspan="3" style='width: 347.55pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'><asp:TextBox ID="Txt_P007" Width="400"  runat="server" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span>
                        </p>
                    </td>
                </tr>
                <tr style='mso-yfti-irow: 12; height: 1.0cm'>
                    <td width="105" rowspan="<%=pfL.Count %>" style='width: 78.55pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>经评审的投标人分数及排序<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <%
                        Enterprise.Model.App.Project.ProjectZjpfModel p0 = new Enterprise.Model.App.Project.ProjectZjpfModel();
                        if(pfL.Count>0) p0=pfL[0];
                         %>
                    <td width="204" style='width: 152.65pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'><%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName(p0.CRMINFO) %></span>
                        </p>
                    </td>
                    <td width="103" style='width: 77.4pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>综合分数</span>
                        </p>
                    </td>
                    <td width="157" style='width: 117.5pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'><%=p0.PF %></span>
                        </p>
                    </td>
                </tr>
                <%
                    for (int i = 1; i < pfL.Count; i++) { 
                        p0=pfL[i];
                        %>
                <tr style='mso-yfti-irow: 13; height: 1.0cm'>
                    <td width="204" style='width: 152.65pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'><%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName(p0.CRMINFO) %></span>
                        </p>
                    </td>
                    <td width="103" style='width: 77.4pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal">
                            <span lang="EN-US" style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>综合分数</span>
                        </p>
                    </td>
                    <td width="157" style='width: 117.5pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'><%=p0.PF %></span>
                        </p>
                    </td>
                </tr>
                <%
                    }
                     %>
                
                <tr style='mso-yfti-irow: 18; height: 1.0cm'>
                    <td width="105" style='width: 78.55pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>符合条件的<span lang="EN-US"></span></span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>中标候选人<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <td width="463" colspan="3" style='width: 347.55pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'><asp:Label ID="Lb_P008" runat="server"></asp:Label></span>
                        </p>
                    </td>
                </tr>
                <tr style='mso-yfti-irow: 19; height: 1.0cm'>
                    <td width="105" style='width: 78.55pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>澄清、说明、补正事项<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <td width="463" colspan="3" style='width: 347.55pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 1.0cm'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>
                                <asp:TextBox ID="Txt_P009" Width="400"  runat="server" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/>
                            </span>
                        </p>
                    </td>
                </tr>
                <tr style='mso-yfti-irow: 20; height: 83.95pt'>
                    <td width="105" style='width: 78.55pt; border: solid black 1.0pt; border-top: none; mso-border-top-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 83.95pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>评标委员会<span lang="EN-US"></span></span>
                        </p>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>成员签字<span lang="EN-US"></span></span>
                        </p>
                    </td>
                    <td width="463" colspan="3" style='width: 347.55pt; border-top: none; border-left: none; border-bottom: solid black 1.0pt; border-right: solid black 1.0pt; mso-border-top-alt: solid black .5pt; mso-border-left-alt: solid black .5pt; mso-border-alt: solid black .5pt; padding: 0cm 5.4pt 0cm 5.4pt; height: 83.95pt'>
                        <p class="MsoNormal" align="center" style='text-align: center'>
                            <span lang="EN-US"
                                style='mso-bidi-font-size: 10.5pt; font-family: 宋体; color: black; mso-themecolor: text1'>
                                
                            </span>
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

