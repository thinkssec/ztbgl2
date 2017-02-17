<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbwjEdit.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbwjEdit" ValidateRequest="false" EnableEventValidation="false" %>

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
                    <li>招标文件编制</li>
                    <li class="last">文件编制</li>
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
                    <%--<td><uc1:PopWinUploadMuti runat="server" ID="Txt_SCFJ"  Ext="Custom" Required="false"  />
                    </td>--%>
                    <td width="80px">
                        <asp:LinkButton ID="BtnSave" runat="server" ClientIDMode="Static" CssClass="easyui-linkbutton" iconCls="icon-save" OnClick="BtnSave_Click" OnClientClick="showLoading();">保存</asp:LinkButton>
                    </td>
                    <td width="100px">&nbsp;&nbsp;&nbsp;&nbsp;<a href='' class="easyui-linkbutton" id="H_Down" runat="server">下载</a>&nbsp;&nbsp;&nbsp;&nbsp;
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
                <a name="_Toc402171557"><span style='font-size: 22.0pt; font-family: 宋体'>招标文件</span></a>
            </p>

            <p class="MsoNoSpacing">
                <span style='font-family: 宋体'>招标项目名称：</span><span
                    lang="EN-US" style='font-family: 宋体'>
                    <asp:TextBox ID="Txt_PROJNAME" Width="300" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" /></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>招标文件编号：<span lang="EN-US">
                    川气东送<asp:TextBox ID="Txt_P91" Width="50" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" />
                    招字第<asp:TextBox ID="Txt_P101" Width="50" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" />号</span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>招标内容：<span lang="EN-US">

                </span></span>
            </p>
            <p class="MsoNormal" style='line-height: 150%'>
                <asp:TextBox ID="Txt_P8" runat="server" CssClass="easyui-validatebox large"
                    validType="length[0,500]" invalidMessage="不能超过500个字！"
                    Width="500" Height="50" TextMode="MultiLine"></asp:TextBox>

            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>资质要求：<span lang="EN-US">

                </span></span>
            </p>
            <p class="MsoNormal" style='line-height: 150%'>
                <asp:TextBox ID="Txt_Z1" runat="server" CssClass="easyui-validatebox large"
                    validType="length[0,500]" invalidMessage="不能超过500个字！"
                    Width="500" Height="50" TextMode="MultiLine"></asp:TextBox>

            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>技术要求：<span lang="EN-US">

                </span></span>
            </p>
            <p class="MsoNormal" style='line-height: 150%'>
                <asp:TextBox ID="Txt_Z2" runat="server" CssClass="easyui-validatebox large"
                    validType="length[0,500]" invalidMessage="不能超过500个字！"
                    Width="500" Height="50" TextMode="MultiLine"></asp:TextBox>

            </p>
            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>质量要求：<span lang="EN-US">

                </span></span>
            </p>
            <p class="MsoNormal" style='line-height: 150%'>
                <asp:TextBox ID="Txt_Z3" runat="server" CssClass="easyui-validatebox large"
                    validType="length[0,500]" invalidMessage="不能超过500个字！"
                    Width="500" Height="50" TextMode="MultiLine"></asp:TextBox>

            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>服务周期\工期\到货周期：<span lang="EN-US">
                    <asp:TextBox ID="Txt_Z4" runat="server" CssClass="easyui-datebox"></asp:TextBox>至
                    <asp:TextBox ID="Txt_Z5" runat="server" CssClass="easyui-datebox"></asp:TextBox>
                </span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>发售招标文件起止时间：<span lang="EN-US">

                    <asp:TextBox ID="Txt_P1" Width="400" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" />
                    </span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>领取招标文件地点：<span lang="EN-US">

                    <asp:TextBox ID="Txt_Z6" Width="500" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" /></span></span>
            </p>
            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>招标文件澄清截止时间：<span lang="EN-US">

                    <asp:TextBox ID="Txt_P2" Width="300" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" /></span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>招标文件答疑：<span lang="EN-US">

                    <asp:TextBox ID="Txt_P3" Width="150" runat="server" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" />
                </span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>投标截止\开标时间：<span lang="EN-US">
                    <asp:TextBox ID="Txt_NKBSJ" runat="server" CssClass="easyui-datetimebox"></asp:TextBox>
                  
                </span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>开标地点：<span lang="EN-US">

                    <asp:TextBox ID="Txt_NKBDD" Width="500" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" /></span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>投标有效期：<span lang="EN-US">
                    
                    开标之日起<asp:TextBox ID="Txt_P4" Width="50" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" />天</span></span>
            </p>

            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>投标保证金：<span lang="EN-US">
                    <asp:TextBox ID="Txt_P5" Width="50" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" />
                    标的总价2%以内（石化内部企业免收）</span></span>
            </p>
            <p class="MsoNormal" style='line-height: 150%'>
                <span style='line-height: 150%; font-family: 宋体'>投标文件份数：<span lang="EN-US">
                    
                    正本<asp:TextBox ID="Txt_P6" Width="50" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" />份；
                    副本<asp:TextBox ID="Txt_P7" Width="50" runat="server" value="" Style="border-bottom: black 1px solid; border-top-style: none; border-right-style: none; border-left-style: none; background-color: transparent;" />份。</span></span>
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

