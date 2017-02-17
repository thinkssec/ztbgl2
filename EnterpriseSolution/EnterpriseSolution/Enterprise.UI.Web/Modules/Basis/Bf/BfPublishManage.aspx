<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="Enterprise.UI.Web.Modules.Basis.Bf.BfPublishManage"
    CodeBehind="BfPublishManage.aspx.cs" %>

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
                        <%=Trans("版本发布管理")%></li>
                </ul>
            </div>
        </div>
    </div>
    <div data-options="region:'center'">
        <div class="main-gridview">
            <div class="main-gridview-title">
                业务流<asp:DropDownList ID="Ddl_BF_ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Ddl_BF_ID_SelectedIndexChanged">
                </asp:DropDownList>
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
                    <asp:BoundField DataField="BF_ID" HeaderText="业务流编号" />
                    <asp:BoundField HeaderText="业务流名称" />
                    <asp:BoundField DataField="BF_VERSION" HeaderText="业务流版本" />
                    <asp:BoundField DataField="BF_MODDATE" HeaderText="修改日期" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField HeaderText="发布情况" />
                    <asp:BoundField DataField="BF_PUBDATE" HeaderText="发布日期" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField HeaderText="当前状态" />
                    <asp:BoundField HeaderText="业务流脚本" />
                </Columns>
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" runat="server" class="popwin">
            <asp:HiddenField ID="Hid_BF_ID" runat="server" />
            <asp:HiddenField ID="Hid_BF_VERSION" runat="server" />
            <div id="Div1" class="easyui-panel" title="<%=Trans("操作")%>" icon="icon-save" collapsible="true"
                style="padding: 10px; background: #fafafa; overflow: hidden;">
                <table>
                    <tr>
                        <td>
                            <%=Trans("业务流名称和版本")%>
                        </td>
                        <td>
                            <asp:Label ID="Lbl_BF_NAME" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=Trans("发布标志")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="Ddl_BF_PUBSIGN" runat="server">
                                <asp:ListItem Value="1">已发布</asp:ListItem>
                                <asp:ListItem Value="0">未发布</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%=Trans("当前状态")%>
                        </td>
                        <td>
                            <asp:DropDownList ID="Ddl_BF_STATUS" runat="server">
                                <asp:ListItem Value="1">启用</asp:ListItem>
                                <asp:ListItem Value="0">废弃</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
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
