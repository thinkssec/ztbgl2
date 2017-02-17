<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglKbhyc.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglKbhyc" ValidateRequest="false" EnableEventValidation="false" %>

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
                    <li class="last">开标会议程</li>
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
                    <td   width="100px">&nbsp;&nbsp;&nbsp;&nbsp;<%--<a href='' class="easyui-linkbutton" id="H_Down" runat="server">下载</a>--%>&nbsp;&nbsp;&nbsp;&nbsp;
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
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>开标会议程</span></a>
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


            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 27.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>（一）主持人介绍本次招标的有关情况；</span>
            </p>


            <p class="MsoBodyTextIndent" style='text-indent: 23.5pt; line-height: 27.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>（二）工作人员<u><span lang="EN-US"><asp:TextBox ID="Txt_param_002" Width="50"  runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span></u>检查标书密封情况；</span>
            </p>

            <p class="MsoBodyTextIndent" style='text-indent: 23.5pt; line-height: 27.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>（三）现场开标，根据签到表逆向顺序，投标人分别单独宣读投标报价书，并作投标陈述，时间控制在<u><asp:TextBox ID="Txt_param_003" runat="server" value="" Width="50" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></u>分钟。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 27.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>（四）投标方代表退出评标现场，评标委员会对投标方的标书进行评审、打分，并汇总评标结果。</span>
            </p>

            <p class="MsoNormal" style='line-height: 27.0pt'>
                <span lang="EN-US"
                    style='font-size: 12.0pt; font-family: 宋体'>&nbsp;</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>&nbsp;</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>&nbsp;</span>
            </p>

            <p class="MsoNormal" style='text-indent: 174.0pt; line-height: 27.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>天然气川气东送管道分公司</span>
            </p>

            <p class="MsoNormal" style='margin-left: 251.95pt; text-indent: -228.0pt; line-height: 27.0pt'>
                <span lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <u><asp:TextBox ID="Txt_param_004" Width="30" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></u></span><span style='font-size: 12.0pt; font-family: 宋体'>年<u><span
                        lang="EN-US"><asp:TextBox ID="Txt_param_005"  Width="10" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span></u>月<u><span lang="EN-US"><asp:TextBox ID="Txt_param_006" Width="20"  runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span></u>日</span>
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

