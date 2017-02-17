<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" 
    CodeBehind="DmwxPlanSp.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Dmgl.DmwxPlanSp" %>

<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/EDropDownList.ascx" TagPrefix="uc1" TagName="EDropDownList" %>
<%@ Import Namespace="Enterprise.Component.Infrastructure" %>
<%@ Import Namespace="Enterprise.Model.App.Project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .easyui-validatebox {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/" target="_parent">首页</a>
                    </li>
                    <li>地面管理</li>
                    <li class="last">地面维修申请列表</li>
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
            
 
        <div class="main-gridview">
            <asp:GridView ID="GridView3" runat="server" DataKeyNames="PID" AutoGenerateColumns="False" Width="100%" OnRowDataBound="GridView3_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="序号">                        
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_select" runat="server" />
                            <%#(Container.DataItemIndex+1) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="维修项目名称">                       
                        <ItemTemplate>
                            <%#Eval("MX") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="维修工作量描述">                       
                        <ItemTemplate>
                            <%#Eval("MS") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="工程预算">
                        <ItemTemplate>
                            <%#Eval("PAMOUNT") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">                       
                        <ItemTemplate>
                            <%#Eval("BZ") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="审核意见">                       
                        <ItemTemplate>
                            <asp:TextBox ID="memoT4" runat="server" Width="300" Height="20"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>     
        </div>  
        <asp:Panel ID="Pnl_Audit" runat="server" Visible="true">
            <div>
                <asp:LinkButton ID="btn_selectall" runat="server" Text="全选" CssClass="easyui-linkbutton"
                    plain="false" OnClick="btn_selectall_Click"></asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="btn_cancelselect" runat="server" Text="反选" CssClass="easyui-linkbutton"
                    plain="false" OnClick="btn_cancelselect_Click"></asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" CssClass="easyui-linkbutton"  iconCls="icon-ok" runat="server" OnClick="btn_ok_Click"   OnClientClick="return checkInputForm();">通过</asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="btn_audit" runat="server" Text="不通过" CssClass="easyui-linkbutton" iconCls="icon-cancel"
                    plain="false" OnClick="btn_cancle_Click" OnClientClick="return confirm('您确定要提交审核吗?');"></asp:LinkButton>
            </div>
        </asp:Panel>
        </div>   
           <script type="text/javascript">
               function checkInputForm() {
                   var v = $('#form1').form('validate');
                   return v;
               }
               window.onerror = function () {
                   return true;
               }
                    </script>
</asp:Content>

