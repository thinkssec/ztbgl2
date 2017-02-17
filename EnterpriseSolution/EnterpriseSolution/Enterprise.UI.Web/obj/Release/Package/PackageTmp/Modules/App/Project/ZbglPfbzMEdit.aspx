<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="ZbglPfbzMEdit.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglPfbzMEdit"  ValidateRequest="false" %>

<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/EDropDownList.ascx" TagPrefix="uc1" TagName="EDropDownList" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>

<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent"><%=Trans("首页") %></a></li>
                    <li>评标管理</li>
                    <li class="last">评分模板管理</li>
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
                <span>评分模板明细</span>
            </div>
        </div>
        <div class="main-gridview">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="BZID"
                AllowPaging="True" PageSize="20" AutoGenerateColumns="False" Width="100%"
                OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="项目名称">
                        <ItemTemplate>
                            <%#Enterprise.Service.App.Project.ProjectHalfService.GetProjectName((string)Eval("PROJID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:BoundField HeaderText="项目名称" DataField="XMMC"></asp:BoundField>
                    <asp:BoundField HeaderText="评标分项" DataField="PBFX"></asp:BoundField>
                    <asp:TemplateField HeaderText="评分标准">
                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="400"/>
                        <ItemTemplate>
                            <%#Eval("PFBZ") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="分值" DataField="FZ"></asp:BoundField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("BZID"))%>
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
                    <span>评分标准-操作面板</span>
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
                    <li class="ssec-label">项目:</li>
                    <li>
                        <div>
                            <asp:HiddenField ID="Hid_MID" runat="server" />
                            <asp:DropDownList ID="Ddl_XMMC" runat="server">

                                <asp:ListItem Value="技术部分">技术部分</asp:ListItem>
                                <asp:ListItem Value="商务部分">商务部分</asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="tb_HalfName"  CssClass="easyui-validatebox large" validType="length[0,100]" 
                                invalidMessage="不能超过100个字！" runat="server" Width="300px" required="true"></asp:TextBox>--%>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">评标分项:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="t_PBFX"  CssClass="easyui-validatebox large" validType="length[0,100]" 
                                invalidMessage="不能超过100个字！" runat="server" Width="300px" required="true"></asp:TextBox>
                        </div>
                    </li>
                </ul>

                 <ul>
                    <li class="ssec-label">
                        <%=Trans("分值")%>：
                    </li>
                    <li>
                        <div>
                            <asp:TextBox ID="t_FZ" runat="server" CssClass="easyui-numberbox" min="0" ClientIDMode="Static"
                                precision="2" invalidMessage="无效数字" required="true" missingMessage="必选项"
                                Width="150px" ></asp:TextBox>
                        </div>
                    </li>
                </ul>

                <%--邮箱验证--%>
                <ul>
                    <li class="ssec-label">评分标准:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="t_PFBZ" runat="server" CssClass="easyui-validatebox" validType="length[0,300]" invalidMessage="小于300字！" Width="400" Height="200"  required="true" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">排序:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="t_XH" runat="server" CssClass="easyui-numberbox" min="0"
                                max="100" precision="0" invalidMessage="无效数字" required="true" missingMessage="必选项"
                                Width="50px" ></asp:TextBox>
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

