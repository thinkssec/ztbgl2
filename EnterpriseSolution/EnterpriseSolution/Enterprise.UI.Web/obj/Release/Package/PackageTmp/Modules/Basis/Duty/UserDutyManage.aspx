<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="UserDutyManage.aspx.cs"
    EnableEventValidation="true" Inherits="Enterprise.UI.Web.Manage.ZhiWu.UserZhiwuManage"
    MasterPageFile="~/Site.Master" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li class="last">
                        <%=Trans("职务信息") %></li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("职务信息")%></span>
            </div>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("名称")%>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Name" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("说明")%>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Remark" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
        </div>
        <div class="main-gridview">
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="UDID" AutoGenerateColumns="false"
                OnRowCommand="GridView1_OnRowCommand" Width="100%">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="30">
                        <ItemTemplate>
                            <img src="../../../Resources/Styles/_img/arrow_142.gif" alt="" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人员" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName((int)Eval("USERID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ItemStyle-Width="60">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton3" CommandName="mDelete" CommandArgument='<%#Container.DataItemIndex  %>'
                                OnClientClick="return confirm('确定要删除该人员？删除将无法恢复')" runat="server">删除</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <br />
        <asp:Panel ID="Pnl_Edit" runat="server" Visible="false">
            <table border="0" style="border: 0px;" align="left">
                <tr>
                    <td style="width: 80px;">人员
                    </td>
                    <td>
                        <uc1:UserSelectControl runat="server" ID="single_RcvUsers" Required="true" />
                        </td>
                    <%--<td>
                        <asp:DropDownList ID="tb_Dept" runat="server" AutoPostBack="true" OnSelectedIndexChanged="tb_Dept_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="tb_Dept" EventName="SelectedIndexChanged" />
                            </Triggers>
                            <ContentTemplate>
                                <asp:DropDownList ID="tb_User" runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>--%>
                    <td>
                        <div class="ssec-group-bottom ssec-group-hasicon">
                            <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" OnClick="Button1_OnClick">保存</asp:LinkButton>
                        </div>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
