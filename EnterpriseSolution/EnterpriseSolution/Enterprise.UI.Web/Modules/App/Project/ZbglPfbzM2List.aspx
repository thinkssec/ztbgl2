<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master"
    AutoEventWireup="true" CodeBehind="ZbglPfbzM2List.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglPfbzM2List"  ValidateRequest="false" %>

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
                    <li>评标标准维护</li>
                    <li class="last">评分模板引用</li>
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
                <span>评分模板</span>
            </div>
        </div>
        <div class="main-gridview">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="MID"
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
                    <asp:TemplateField HeaderText="模板名称">
                        <ItemTemplate>
                            <a href="ZbglPfbzM2Edit.aspx?MID=<%#(string)Eval("MID")%>&ProjectId=<%#ProjectId %>"><%#(string)Eval("MNAME")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="说明" DataField="BZ">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("MID"))%>
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
                    <span>评分模板-操作面板</span>
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

                <ul>
                    <li class="ssec-label">模板名称:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="t_MNAME"  CssClass="easyui-validatebox large" validType="length[0,50]" 
                                invalidMessage="不能超过50个字！" runat="server" Width="200px" required="true"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">备注:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="t_BZ" runat="server" CssClass="easyui-validatebox" validType="length[0,150]" invalidMessage="小于150字！" Width="300" Height="100"  TextMode="MultiLine"></asp:TextBox>
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

