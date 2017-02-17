<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglPbwyhxy.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglPbwyhxy" ValidateRequest="false" %>

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
                    <li class="last">评标委员会宣言</li>
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
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>评标委员会宣言</span></a>
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

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>本人声明：本人在评标前未与招标人、招标代理机构、投标人发生可能影响评标结果的接触；无国家有关规定需要回避的情形。在评标过程中严格遵守以下评标工作纪律：</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>1.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>严格遵守《中华人民共和国招标投标法》及有关法规，本着维护国家利益、社会公共利益和招标投标当事人合法权益的目的，按照公平、公正和诚实信用的原则参加评标活动。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>2.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>认真阅读招标文件和投标文件，按照招标文件的要求对投标文件进行严格、科学、实事求是的评审。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>3.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>保证客观、公正地履行职责，对所提出的评审意见承担个人责任。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>4.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>严守保密制度，不与投标人及其他相关人员有私下联系，在任何时候都不泄漏评标的相关情况。评标期间不离开评标场所，一切对外联系均通过招标组织者进行。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>5.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>对投标文件有疑问时，由评标委员会书面通知该投标人进行澄清、说明。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>6.</span><span
                        style='font-size: 12.0pt; font-family: 宋体'>评标结束后，以评标委员会名义形成评标报告。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>&nbsp;</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    style='font-size: 12.0pt; font-family: 宋体'>评标委员会全体成员签字： </span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.1pt; line-height: 27.0pt'>
                <span
                    lang="EN-US" style='font-size: 12.0pt; font-family: 宋体'>&nbsp;</span>
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

