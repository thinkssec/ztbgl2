<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" 
    CodeBehind="DmwxPlanSum.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Dmgl.DmwxPlanSum" %>

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
                    <li class="last">地面维修申请汇总</li>
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
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>地面维修计划表</span>
            </div>
        </div>    
 
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
                        <ItemStyle HorizontalAlign="Left" />              
                        <ItemTemplate>
                            <asp:Label ID="hz" runat="server"></asp:Label>
                            <asp:TextBox ID="memoT1" runat="server" Width="300" Height="20"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="维修工作量描述">                       
                        <ItemTemplate>
                            <asp:TextBox ID="memoT2" runat="server" Width="300" Height="20"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="工程预算">
                        <ItemStyle Width="80px" /> 
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label ID="hzamount" runat="server"></asp:Label>
                            <asp:TextBox ID="Txt_Amount" runat="server" myyyy="costdetail" CssClass="easyui-numberbox" min="0" max="999999" precision="2" invatddMessage="只能是数字！" required="true" Width="80"></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">                       
                        <ItemTemplate>

                            <asp:TextBox ID="memoT3" runat="server" Width="300" Height="20"></asp:TextBox>
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
                    plain="false" OnClick="btn_cancelselect_Click"></asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" CssClass="easyui-linkbutton"  iconCls="icon-save" runat="server" OnClick="LinkButton3_Click"   OnClientClick="return checkInputForm();">临时保存</asp:LinkButton>&nbsp;&nbsp;
                <asp:LinkButton ID="btn_audit" runat="server" Text="提交" CssClass="easyui-linkbutton" iconCls="icon-ok"
                    plain="false" OnClick="btn_audit_Click" OnClientClick="return confirm('您确定要提交审核吗?');"></asp:LinkButton>
            </div>
        </asp:Panel>
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>地面维修计划审核表</span>
            </div>
        </div>
        <div class="main-gridview">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="PID" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:TemplateField HeaderText="序号">                        
                        <ItemTemplate>
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
                        <ItemStyle Width="80px" /> 
                        <ItemTemplate>
                            <%#Eval("PAMOUNT") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <%#GetStatus(Eval("PID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">                       
                        <ItemTemplate>
                            <%#Eval("BZ") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>     
        </div>  

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

