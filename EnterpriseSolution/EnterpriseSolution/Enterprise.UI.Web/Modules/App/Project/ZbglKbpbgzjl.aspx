<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglKbpbgzjl.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglKbpbgzjl" ValidateRequest="false" EnableEventValidation="false"%>

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
                    <li class="last">开标评标工作纪律</li>
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
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>开标评标工作纪律</span></a>
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

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 22.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>我是</span><span lang="EN-US"
                        style='font-family: 宋体'><asp:TextBox ID="Txt_param_001" Width="50"  runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span><span style='font-size: 12.0pt; font-family: 宋体'>，本次开标评标工作的监督人员，为保证此次招标投标工作严谨有序地进行，在此宣布如下工作纪律及要求，请大家自觉遵守：</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 22.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>一、招标人及评标委员会成员应遵守的纪律</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>1.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>认真履行职责，以客观严谨的态度和公平、公正的原则开展工作；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>2.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>不私下向投标人询问任何有关投标的问题；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>3.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>不私下与投标人进行接触；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>4.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>不与投标人串通投标；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>5.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>不在投标文件澄清、说明时诱导投标人；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>6.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>不接受投标人的任何馈赠；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>7.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>依法评审，严格保密。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 22.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>二、投标人应遵循的纪律</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>1.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>不发生任何游说、贿赂招标方人员及评标委员会成员的行为；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>2.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>不与其他投标人串通投标；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>3.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>在投标、评标过程中不主动与招标人和评标委员会成员接触；</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>4.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>不回答招标人、评标委员会成员私下提出的任何问题。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 22.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>三、相关要求</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>1.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>评标前，评标委员会成员签订评标委员会宣言。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>2.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>评标过程中，评标委员会成员及相关工作人员不得与外界联系，手机交由监督人保管。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>3.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>评标期间及工作结束后，评标委员会成员及相关工作人员不得将投标文件带离评标地点，不得私自复印、拷贝、带走与评标有关的资料。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 22.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>如果大家在此项目招标投标过程中有任何异议，请与我联系。投诉电话：<asp:TextBox ID="Txt_param_002" Width="70"  runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/>手机：</span><u><span lang="EN-US"
                                style='font-family: 宋体'><asp:TextBox ID="Txt_param_003" Width="70"  runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span></u>
            </p>

            <p class="MsoNormal" style='text-indent: 282.0pt; line-height: 22.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>监督人：</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 22.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="Txt_param_004" Width="30"  runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span><span
    style='font-size: 12.0pt; font-family: 宋体'>年<span lang="EN-US"><asp:TextBox ID="Txt_param_005" Width="30"  runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span>月<span
        lang="EN-US"><asp:TextBox ID="Txt_param_006" Width="30"  runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span>日</span>
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

