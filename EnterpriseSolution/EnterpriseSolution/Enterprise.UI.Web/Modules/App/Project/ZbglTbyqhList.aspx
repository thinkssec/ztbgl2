<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglTbyqhList.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglTbyqhList" ValidateRequest="false" enableEventValidation="false"%>

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
                    <li class="last">投标邀请函 </li>
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
        <div class="WordSection1" style='layout-grid: 15.6pt'>

            <h1><a name="_Toc402171552"></a><a name="_Toc395522687"></a><a
                name="_Toc395519629"><span style='font-family: 宋体'>投标邀请函</span></a></h1>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>日期：<asp:TextBox ID="Txt_param_001" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/> </span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%'>
                <span
                    style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>招标编号：</span><span
                        style='font-size: 12.0pt;line-height: 150%; font-family: 宋体;'><asp:Label ID="Lb_PNUMBER" runat="server"></asp:Label></span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span lang="EN-US" style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>1.</span><span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>中国石油化工股份有限公司天然气川气东送管道分公司（以下简称“川气东送管道分公司”）邀请合格投标人就</span><u><span
                    style='font-size: 12.0pt;line-height: 150%; font-family: 宋体; '><asp:Label ID="Lb_PNAME" runat="server"></asp:Label></span></u><u><span
                        lang="EN-US" style='line-height: 150%; color: red'>&nbsp; </span></u><span
                            style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>项目提交密封投标：</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span lang="EN-US" style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>2.</span><span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>有兴趣的合格投标人可在川气东送管道分公司得到进一步的信息和查阅招标文件。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span lang="EN-US" style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>3.</span><span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>有兴趣的合格投标人可具体日期区间（节假日除外）上午<span
                    lang="EN-US">8:00 </span>至<span lang="EN-US">12:00, </span>下午<span lang="EN-US">2:00</span>至<span
                        lang="EN-US">6:00</span>（北京时间）在川气东送管道分公司<u><span lang="EN-US"><asp:TextBox ID="Txt_param_002" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span></u>室领取招标文件。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span lang="EN-US" style='font-size: 12.0pt; line-height: 150%; font-family: 宋体; color: black'>4.</span><span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体; color: black'>领取招标文件截止时间：<u><span lang="EN-US"><asp:TextBox ID="Txt_param_003" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/>
                </span></u></span>
            </p>

            <p class="MsoNormal" style='text-indent: 36.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体; color: black'>投标截止时间<span
                    lang="EN-US">/</span>开标时间：<u><span lang="EN-US"><asp:TextBox ID="Txt_param_004" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span></u></span>
            </p>

            <p class="MsoNormal" style='text-indent: 36.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>开标地点：川气东送管道分公司<u><span
                    lang="EN-US"><asp:TextBox ID="Txt_param_005" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span></u>会议室</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span lang="EN-US" style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>5.</span><span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>投标人须在投标截止时间前将投标文件送达指定地点。同时自愿派代表参加开标。</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span lang="EN-US" style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>&nbsp;</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span lang="EN-US" style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>&nbsp;</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>招标人：中国石油化工股份有限公司天然气川气东送管道分公司</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>详细地址：湖北省武汉市东湖高新区光谷大道<span
                    lang="EN-US">126</span>号<u><span lang="EN-US"><asp:TextBox ID="Txt_param_006" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span></u>会议室</span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>邮<span
                    lang="EN-US">&nbsp;&nbsp;&nbsp; </span>编：<span lang="EN-US">430073</span></span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>联 系 人： <asp:TextBox ID="Txt_param_007" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>电<span
                    lang="EN-US">&nbsp;&nbsp;&nbsp; </span>话： <asp:TextBox ID="Txt_param_008" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span>
            </p>

            <p class="MsoNormal" style='text-indent: 24.0pt; line-height: 150%; layout-grid-mode: char'>
                <span style='font-size: 12.0pt; line-height: 150%; font-family: 宋体'>电子信箱：<asp:TextBox ID="Txt_param_009" runat="server" value="" style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none;background-color: transparent;"/></span><span
                    style='font-size: 12.0pt; line-height: 150%'> </span>
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

