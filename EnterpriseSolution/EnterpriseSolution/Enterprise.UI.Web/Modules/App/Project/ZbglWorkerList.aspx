<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglWorkerList.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglWorkerList"  ValidateRequest="false" %>

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
                    <li>组建评标委员会</li>
                    <li class="last">指定工作/监督人</li>
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
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>工作/监督人</span>
            </div>
        </div>
        <div class="main-gridview">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="ZID"
                AllowPaging="True" PageSize="20" AutoGenerateColumns="False" Width="100%"
                OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName (Eval("PERSONID").ToInt())%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="类别">
                        <ItemTemplate>
                            <%#Eval("LB")==null?"":(Eval("LB").ToInt()==5?"工作人员":(Eval("LB").ToInt()==6?"监督人员":""))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="电话">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserModelByUserId(Eval("PERSONID").ToInt()).UGNPHONE %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("ZID"))%>
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

                        <%=Trans("人员")%>：
                    
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

