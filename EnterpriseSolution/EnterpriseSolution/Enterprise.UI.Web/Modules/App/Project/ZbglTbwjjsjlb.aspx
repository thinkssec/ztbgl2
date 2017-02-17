<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglTbwjjsjlb.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglTbwjjsjlb" ValidateRequest="false" enableEventValidation="false"%>

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
                    <li class="last">投标文件接收记录表 </li>
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
        <div class=WordSection1 style='layout-grid:15.6pt'>

<p class=MsoTitle><a name="_Toc402171556"><span style='font-size:22.0pt;
font-family:宋体'>投标文件接收记录表</span></a></p>

<p class=MsoNormal align=center style='text-align:center'><b><span lang=EN-US
style='font-size:12.0pt'>&nbsp;</span></b></p>

<p class=MsoNormal style='line-height:150%'><span style='line-height:150%;
font-family:宋体'>招标项目名称：</span><span lang=EN-US style='line-height:150%;
font-family:宋体'><asp:Label ID="Lb_PNAME" runat="server" ></asp:Label></span><span lang=EN-US style='line-height:150%'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
style='line-height:150%;font-family:宋体'>招标文件编号：</span><span lang=EN-US
style='line-height:150%;font-family:宋体'><asp:Label ID="Lb_PNUMBER" runat="server" ></asp:Label></span></p>

<p class=MsoNormal style='line-height:150%'><span style='line-height:150%;
font-family:宋体'>开标地点：</span><span lang=EN-US style='line-height:150%;
font-family:宋体'><asp:Label ID="Lb_P001" runat="server" ></asp:Label></span><span lang=EN-US style='line-height:150%'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
style='line-height:150%;font-family:宋体'>截标时间：</span><span lang=EN-US
style='line-height:150%'>&nbsp; </span><span lang=EN-US style='line-height:
150%;font-family:宋体'><asp:Label ID="Lb_P002" runat="server" ></asp:Label> </span><span lang=EN-US style='line-height:
150%'>&nbsp;&nbsp;</span></p>

<table class=MsoNormalTable border=1 cellspacing=0 cellpadding=0 width=905
 style='width:678.75pt;border-collapse:collapse;border:none'>
 <tr style='height:44.15pt'>
  <td width=54 style='width:40.85pt;border:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:44.15pt'>
  <p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:宋体'>序号</span></p>
  </td>
  <td width=198 style='width:148.85pt;border:solid windowtext 1.0pt;border-left:
  none;padding:0cm 5.4pt 0cm 5.4pt;height:44.15pt'>
  <p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:宋体'>投标人</span></p>
  </td>
  <td width=151 style='width:4.0cm;border:solid windowtext 1.0pt;border-left:
  none;padding:0cm 5.4pt 0cm 5.4pt;height:44.15pt'>
  <p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:宋体'>时间</span></p>
  </td>
  <td width=161 style='width:120.5pt;border:solid windowtext 1.0pt;border-left:
  none;padding:0cm 5.4pt 0cm 5.4pt;height:44.15pt'>
  <p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:宋体'>投标文件数量</span></p>
  </td>
  <td width=104 style='width:77.95pt;border:solid windowtext 1.0pt;border-left:
  none;padding:0cm 5.4pt 0cm 5.4pt;height:44.15pt'>
  <p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:宋体'>密封情况</span></p>
  </td>
  <td width=113 style='width:3.0cm;border:solid windowtext 1.0pt;border-left:
  none;padding:0cm 5.4pt 0cm 5.4pt;height:44.15pt'>
  <p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:宋体'>其他情况说明</span></p>
  </td>
  <td width=123 style='width:92.15pt;border:solid windowtext 1.0pt;border-left:
  none;padding:0cm 5.4pt 0cm 5.4pt;height:44.15pt'>
  <p class=MsoNormal align=center style='text-align:center;line-height:12.0pt'><span
  style='font-family:宋体'>投标人代表签字</span></p>
  </td>
 </tr>
    <%
                    int i = 0;
                    foreach (var m in fwsL)
                    {
                        i++;
                %>
 <tr style='height:30.0pt'>
  <td width=54 style='width:40.85pt;border:solid windowtext 1.0pt;border-top:
  none;padding:0cm 5.4pt 0cm 5.4pt;height:30.0pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-family:宋体'><%=i %></span></p>
  </td>
  <td width=198 style='width:148.85pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:30.0pt'>
  <p class=MsoNormal align=left style='text-align:left'><span lang=EN-US
  style='font-family:宋体'><%=m.CRMNAME %></span></p>
  </td>
  <td width=151 style='width:4.0cm;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:30.0pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-family:宋体'>月<span lang=EN-US>&nbsp; </span>日<span lang=EN-US>&nbsp;
  </span>时<span lang=EN-US>&nbsp; </span>分</span></p>
  </td>
  <td width=161 style='width:120.5pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:30.0pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-family:宋体'>共<span lang=EN-US>&nbsp; </span>件</span></p>
  </td>
  <td width=104 style='width:77.95pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:30.0pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-family:宋体'>&nbsp;</span></p>
  </td>
  <td width=113 style='width:3.0cm;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:30.0pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-family:宋体'>&nbsp;</span></p>
  </td>
  <td width=123 style='width:92.15pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:30.0pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='color:red'>&nbsp;</span></p>
  </td>
 </tr>
 <%
                    } %>
</table>

<p class=MsoNormal><span style='font-family:宋体'>接收人： </span><span lang=EN-US>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span
style='font-family:宋体'>监督人： </span></p>

<p class=MsoNormal style='line-height:27.0pt'><span lang=EN-US
style='font-family:仿宋_GB2312;color:black;letter-spacing:-.2pt'>&nbsp;</span></p>

</div>

    </div>
    <script>
        function v() {

            return $('#form1').form('validate');
        }
    </script>
    <%--end--%>
</asp:Content>

