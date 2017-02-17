<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="Enterprise.UI.Web.Modules.Basis.Bf.BfNodesLst"
    CodeBehind="BfNodesLst.aspx.cs" %>

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
                        <%=Trans("流程节点列表")%></li>
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
                AllowPaging="false" AllowSorting="false" CssClass="GridViewStyle" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="BF_ID" HeaderText="业务流编号" />
                    <asp:BoundField DataField="BF_VERSION" HeaderText="业务流版本" />
                    <asp:BoundField DataField="BF_NODEID" HeaderText="当前节点编号" />
                    <asp:BoundField DataField="BF_NODENAME" HeaderText="节点名称" />
                    <asp:BoundField DataField="BF_NODETYPE" HeaderText="节点类型" />
                    <asp:BoundField DataField="BF_NODEDESC" HeaderText="节点描述" Visible="false" />
                    <asp:BoundField DataField="BF_FORM" HeaderText="节点对应表单" />
                    <asp:BoundField DataField="BF_FORWARD" HeaderText="是否支持回退" Visible="false" />
                    <asp:BoundField DataField="BF_COMMISSION" HeaderText="是否允许代办" Visible="false" />
                    <asp:BoundField DataField="BF_TIMELIMIT" HeaderText="办理时限" Visible="false" />
                    <asp:BoundField DataField="BF_PROGRESSVALUE" HeaderText="节点进度值" Visible="false" />
                    <asp:BoundField DataField="BF_DUTYOFFICER" HeaderText="节点操作人" />
                    <asp:BoundField DataField="BF_NOTIFIER" HeaderText="节点通知人" Visible="false" />
                    <asp:BoundField DataField="BF_REMINDWAY" HeaderText="消息提醒方式" Visible="false" />
                    <asp:BoundField DataField="BF_AUDITOPINION" HeaderText="缺省意见或结果" Visible="false" />
                    <asp:BoundField DataField="BF_EXTENDEDTREATMENT" HeaderText="超期处理方式" Visible="false" />
                    <asp:BoundField DataField="BF_KEYPOINT" HeaderText="是否为关键节点" Visible="false" />
                    <asp:BoundField DataField="BF_CONTROLPOINT" HeaderText="是否为进度异常控制点" Visible="false" />
                    <asp:BoundField DataField="BF_FLOWTYPE1" HeaderText="分支节点流转类型" Visible="false" />
                    <asp:BoundField DataField="BF_FLOWTYPE2" HeaderText="子流程节点流转类型" Visible="false" />
                    <asp:BoundField DataField="BF_FLOWTYPE3" HeaderText="汇合节点流转类型" Visible="false" />
                    <asp:BoundField DataField="SUB_BF_ID" HeaderText="子流程业务流ID" Visible="false" />
                    <asp:BoundField DataField="SUB_BF_VERSION" HeaderText="子流程业务流版本" Visible="false" />
                </Columns>
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            </asp:GridView>
            </div>
         <div class="main-gridview">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%"
                AllowPaging="false" AllowSorting="false" DataKeyNames="BF_PATHID" OnRowDataBound="GridView2_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="BF_ID" HeaderText="业务流编号" />
                    <asp:BoundField DataField="BF_VERSION" HeaderText="业务流版本" />
                    <asp:BoundField DataField="BF_NODEID" HeaderText="当前节点编号" />
                    <asp:BoundField DataField="BF_STARTNODE" HeaderText="开始节点编号" />
                    <asp:BoundField DataField="BF_PREVNODE" HeaderText="上一节点编号" Visible="false" />
                    <asp:BoundField DataField="BF_NEXTNODE" HeaderText="下一节点编号" />
                    <asp:BoundField DataField="BF_ENDNODE" HeaderText="结束节点编号" />
                    <asp:BoundField DataField="BF_PATHNAME" HeaderText="流转路径名称" />
                    <asp:BoundField DataField="BF_DEFAULTPATH" HeaderText="缺省流转路径" Visible="false" />
                </Columns>
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
