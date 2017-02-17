<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglTbrsx.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglTbrsx"  ValidateRequest="false" enableEventValidation="false"%>

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
                    <li class="last">投标人唱标顺序</li>
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
                    <td width="80px">
                        <asp:LinkButton ID="LinkButton1" runat="server" ClientIDMode="Static" CssClass="easyui-linkbutton" iconCls="icon-save" OnClick="BtnSave_Click" OnClientClick="showLoading();">保存</asp:LinkButton>
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
                <span>投标人唱标顺序表</span>
            </div>

            <asp:HiddenField ID="Hid_SMJ" runat="server" ClientIDMode="Static" />
        </div>
        <div class="main-gridview">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="FID"
                AllowPaging="True" PageSize="20" AutoGenerateColumns="False" Width="100%"
                OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle Width="40" />
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="投标单位">
                        <ItemTemplate>
                            <%#Enterprise.Service.App.Crm.CrmInfoService.GetCrmName(Eval("CRMINFO").ToRequestString())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="唱标顺序">
                        <ItemStyle Width="60" />
                        <ItemTemplate>
                            <asp:TextBox ID="Txt_PX"  runat="server" CssClass="easyui-numberbox" min="1" max="20"
                                 precision="0" invatddMessage="只能是数字！" required="true" Width="50"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
        function v(){

            return $('#form1').form('validate');
        }
        </script>
    <%--end--%>
</asp:Content>

