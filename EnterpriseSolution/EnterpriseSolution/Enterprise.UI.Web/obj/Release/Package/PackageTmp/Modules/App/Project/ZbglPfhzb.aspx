<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglPfhzb.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglPfhzb" ValidateRequest="false" EnableEventValidation="false"%>

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
                    <li class="last">评分汇总表</li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div1" class="ssec-form">
            <div id="Div1">
               <table>
                <tr>
                    <td><uc1:PopWinUploadMuti runat="server" ID="Txt_SCFJ"  Ext="Custom" Required="false"  />
                    </td>
                    <td width="160px">
                        <asp:LinkButton ID="LinkButton1" runat="server" ClientIDMode="Static" CssClass="easyui-linkbutton" iconCls="icon-save" OnClick="BtnSave_Click" OnClientClick="showLoading();">关闭评标环节</asp:LinkButton>
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
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>评分汇总</span>
            </div>

            <asp:HiddenField ID="Hid_SMJ" runat="server" ClientIDMode="Static" />
        </div>
        <div class="main-gridview">
            <div>
                <table class="table-box" cellspacing="1" id="ProjectPH_GridView1" style="border-width: 0px; width: 100%;">
                    <tr class="table_title" align="center">
                        <th scope="col" rowspan="2">投标人 </th>
                        <th scope="col" colspan="<%=zjL.Count %>">评委个人评分(点击姓名下载评委评分表)</th>
                        <th scope="col" rowspan="2">评委会综合得分</th>
                        <th scope="col" rowspan="2">名次</th>
                    </tr>
                    <tr>
                        <%
                            foreach (var m in zjL)
                            { 
                        %>
                        <th scope="col">
                            <a href="<%=ImageStoragePath+m.PROJID+"/"+m.PERSONID+"评委评分表"+fwsL.Count+".doc" %>" target="_blank">
                            <%=Enterprise.Service.Basis.Sys.SysUserService.GetUserName(m.PERSONID.ToInt()) %></a></th>

                        <%
                            }
                        %>
                    </tr>
                    <% 
                        foreach (var m in fwsL)
                        {
                    %>
                    <tr class="row" align="center" style="height: 28px;">
                        <td style="width: 60px;"><%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName( m.CRMINFO) %>
                        </td>
                        <%
                            foreach (var n in zjL)
                            {
                                if (dic.ContainsKey(n.PERSONID + m.CRMINFO))
                                {
                        %>
                        <td><%=dic[n.PERSONID + m.CRMINFO] %>
                        </td>
                        <%
                                }
                                else
                                { 
                        %>
                        <td>0
                        </td>
                        <%
                                }
                        %>
                            
                        <%
                            }
                        %>
                        <td><%=dic.ContainsKey("20000"+m.CRMINFO)?dic["20000"+m.CRMINFO]+"":"" %>
                        </td>
                        <td><%=dic.ContainsKey("10000"+m.CRMINFO)?dic["10000"+m.CRMINFO]+"":"" %>
                        </td>
                    </tr>
                    <%
                        }
                    %>
                </table>

            </div>
        </div>
        <%--end--%>
        <%--编辑数据开始--%>
        <asp:Panel ID="p1" runat="server" Visible="false">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>添加-操作面板</span>
                </div>
                <%--表单构建开始--%>
                <%--                <ul>
                    <li class="ssec-label">项目名称:</li>
                    <li>
                        <div>
                            <asp:Label ID="lb_ProjectName" runat="server"></asp:Label>
                        </div>
                    </li>
                </ul>--%>
                <%--1列排列方式--%>
                <ul>
                    <li class="ssec-label">类别:</li>
                    <li>
                        <div>
                            <asp:DropDownList ID="Ddl_LB" runat="server">

                                <asp:ListItem Value="5">工作人员</asp:ListItem>
                                <asp:ListItem Value="6">监督人员</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="tb_HalfName"  CssClass="easyui-validatebox large" validType="length[0,100]" 
                                invalidMessage="不能超过100个字！" runat="server" Width="300px" required="true"></asp:TextBox>--%>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">

                        <%=Trans("审核人员")%>：
                    
                    </li>
                    <li>
                        <div>
                            <uc1:UserSelectControl runat="server" ID="single_RcvUsers" Required="true" />
                        </div>
                    </li>
                </ul>


                <%--表单构建end--%>
                <ul>
                    <li>
                        <div>
                            <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" iconCls="icon-save" OnClientClick="return v();" OnClick="BtnSave_Click">保存</asp:LinkButton>
                        </div>
                    </li>
                </ul>
            </div>
        </asp:Panel>
    </div>
    <script>
        function v() {

            return $('#form1').form('validate');
        }
    </script>
    <%--end--%>
</asp:Content>

