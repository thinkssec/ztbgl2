<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExamineKindList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Examine.ExamineKindList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent">首页</a></li>
                    <li>系统管理</li>
                    <li>参数配置</li>
                    <li class="last">业务类型管理</li>
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
            <%--数据表格开始--%>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="KINDID,KINDNAME"
                    AllowPaging="True" PageSize="20" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <%--    <asp:TemplateField HeaderText="序号">
                            <ItemTemplate>
                                <%#(Container.DataItemIndex+1)%>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="Txt_KINDID" runat="server" onfocus="set_Date(this)" Text='<%# Eval("KINDID")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="KINDID" runat="server" Text="类型ID"></asp:Label>
                            </HeaderTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Left" />
                            <ItemTemplate>
                                <asp:Label ID="Txt_KINDNAME" runat="server" onfocus="set_Date(this)" Text='<%# Eval("KINDNAME")%>'></asp:Label>
                            </ItemTemplate>
                            <HeaderTemplate>
                                <asp:Label ID="KINDNAME" runat="server" Text="类型名称"></asp:Label>
                            </HeaderTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="上级类型ID" DataField="PARENTID" />
                        <asp:BoundField HeaderText="层级顺序" DataField="KINDORDER" ItemStyle-HorizontalAlign="Left"/>
                        <asp:TemplateField HeaderText="业务归属部门">
                            <ItemTemplate>
                                 <%#Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName((int)Eval("DEPTID")) %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <%#GetCommandBtn(Eval("KINDID").ToString())%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>业务类型管理-操作</span>
                </div>
                <%--表单构建开始--%>
                <ul>
                    <li class="ssec-label">业务类型ID</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_KINDID" runat="server" required="true" CssClass="easyui-numberbox easyui-validatebox" min="0" max="1000" precision="0"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">类型名称</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_KINDNAME" runat="server" required="true" CssClass="easyui-validatebox" validType="length[0,50]" invalidMessage="不能超过50个字" missingMessage="必填项"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">上级类型ID</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_PARENTID" runat="server" CssClass="easyui-numberbox" min="0" max="1000" precision="0"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">层级顺序</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_KINDORDER" runat="server" required="true" CssClass="easyui-validatebox" validType="length[0,50]" invalidMessage="不能超过50个字符" missingMessage="不能超过50个字"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">业务归属部门</li>
                    <li>
                        <div>
                            <asp:DropDownList ID="Ddl_Dep" runat="server"></asp:DropDownList>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li>
                        <div>
                            <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" iconCls="icon-save" OnClientClick="return ( $('#form1').form('validate'));" OnClick="BtnSave_Click">保存</asp:LinkButton>
                        </div>
                    </li>
                </ul>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
