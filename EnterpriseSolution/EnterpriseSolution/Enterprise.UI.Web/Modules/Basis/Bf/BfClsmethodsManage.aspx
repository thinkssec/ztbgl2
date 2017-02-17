<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="Enterprise.UI.Web.Modules.Basis.Bf.BfClsmethodsManage"
    CodeBehind="BfClsmethodsManage.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkform() {
            return $("#form1").form('validate');
        }
        function aa() {
            if (confirm('<%=Trans("您确定要删除数据") %>？')) {
                return true;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px;
        overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx" title="首页">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li>
                        <%=Trans("业务流管理") %></li>
                    <li class="last">
                        <%=Trans("角色获取方法")%></li>
                </ul>
            </div>
        </div>
    </div>
    <div data-options="region:'center'">
        <div class="main-gridview">
            <div class="main-gridview-title">
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                AllowPaging="True" PageSize="15" AllowSorting="false" OnPageIndexChanging="GridView1_PageIndexChanging"
                CssClass="GridViewStyle" OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:TemplateField HeaderText="选择">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                ImageUrl="../../../Resources/Styles/icon/select.gif" />
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="BF_CLSID" HeaderText="方法编号" />
                    <asp:BoundField DataField="BF_METHODDESC" HeaderText="方法说明" />
                    <asp:BoundField DataField="BF_METHOD" HeaderText="方法名称" />
                    <asp:BoundField DataField="BF_CLSNAME" HeaderText="类名称" />
                </Columns>
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" runat="server" class="popwin">
            <asp:HiddenField ID="Hid_BF_ID" runat="server" />
            <div id="Div1" class="easyui-panel" title="<%=Trans("操作")%>" icon="icon-save" collapsible="true"
                style="padding: 10px; background: #fafafa; overflow: hidden;">
                <table>
                    <tr>
                        <td>
                            <%=Trans("方法说明")%>
                        </td>
                        <td>
                            <asp:TextBox ID="Txt_BF_METHODDESC" runat="server" class="easyui-validatebox" required="true"
                                missingMessage="必填项" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=Trans("方法名称")%>
                        </td>
                        <td>
                            <asp:TextBox ID="Txt_BF_METHOD" runat="server" class="easyui-validatebox" required="true"
                                missingMessage="必填项" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=Trans("类名称")%>
                        </td>
                        <td>
                            <asp:TextBox ID="Txt_BF_CLSNAME" runat="server" class="easyui-validatebox" required="true"
                                missingMessage="必填项" Width="350px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:LinkButton ID="LnkBtn_Ins" runat="server" class="easyui-linkbutton" iconCls="icon-add"
                                OnClientClick="return checkform();" OnClick="LnkBtn_Ins_Click">添加</asp:LinkButton>
                            <asp:LinkButton ID="LnkBtn_Upd" runat="server" class="easyui-linkbutton" iconCls="icon-save"
                                OnClientClick="return checkform();" OnClick="LnkBtn_Upd_Click">修改</asp:LinkButton>
                            <asp:LinkButton ID="LnkBtn_Del" runat="server" class="easyui-linkbutton" iconCls="icon-remove"
                                OnClientClick="return aa();" OnClick="LnkBtn_Del_Click">删除</asp:LinkButton>
                            <asp:LinkButton ID="LnkBtn_Cancel" runat="server" class="easyui-linkbutton" iconCls="icon-back"
                                OnClick="LnkBtn_Cancel_Click">取消</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
