<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="Enterprise.UI.Web.Modules.Basis.Bf.BfNodeRolesLst"
    CodeBehind="BfNodeRolesLst.aspx.cs" %>

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
                        <%=Trans("节点角色列表")%></li>
                </ul>
            </div>
        </div>
    </div>
    <div data-options="region:'center'">
        <div class="main-gridview">
            <div class="main-gridview-title">
                业务流:<asp:DropDownList ID="Ddl_BF_ID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Ddl_BF_ID_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;&nbsp;版本:
                <asp:DropDownList ID="Ddl_BF_VERSION" runat="server" AutoPostBack="true" OnSelectedIndexChanged="Ddl_BF_VERSION_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                AllowPaging="true" PageSize="15" AllowSorting="false" DataKeyNames="BF_ROLEID"
                CssClass="GridViewStyle" OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="BF_ID" HeaderText="业务流编号" />
                    <asp:BoundField HeaderText="节点名称" />
                    <asp:BoundField DataField="BF_NODEID" HeaderText="节点编号" />
                    <asp:BoundField DataField="BF_ROLENAME" HeaderText="角色名称" />
                    <asp:BoundField DataField="BF_ROLETYPE" HeaderText="角色类型" />
                    <asp:BoundField DataField="BF_OPERATIONTYPE" HeaderText="操作类型" />
                    <asp:BoundField DataField="BF_CLSID" HeaderText="方法名称" />
                    <asp:BoundField DataField="USERID" HeaderText="指定人员" Visible="false" />
                </Columns>
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
