<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SuperviseIndex.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Common.Supervise.SuperviseIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function load_db(dbid) {
            //alert(dbid);
            $('#pWinDiv').window('open');
            $('#dbdetails').load("SuperviseProcessDetails.aspx?dbid=" + dbid);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/">首页</a>
                    </li>
                    <li class="last">事务督办
                    </li>
                </ul>
            </div>
        </div>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <%--自定义按钮--%>
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <%--end--%>
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <%--end--%>
    <div data-options="region:'center'">
        <div class="main-gridview">
            <div class="main-gridview-title">
                督办时间：<asp:TextBox ID="t_dbsj" runat="server" ClientIDMode="Static" CssClass="easyui-datebox"></asp:TextBox>
                督办内容：<asp:TextBox ID="t_dbnr" runat="server" ClientIDMode="Static"></asp:TextBox>
                &nbsp;<asp:LinkButton ID="lb_Query" runat="server" CssClass="easyui-linkbutton" iconcls="icon-search"
                    Text="搜索" OnClick="lb_Query_Click"></asp:LinkButton>
            </div>
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" OnRowDataBound="gv_RowDataBound"
                Width="100%" DataKeyNames="DBID">
                <Columns>
                    <asp:BoundField DataField="DBSJ" HeaderText="督办时间"></asp:BoundField>
                    <asp:BoundField DataField="DBBT" HeaderText="督办事务">
                        <ItemStyle Width="350px" HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="YQWCSJ" HeaderText="要求完成时间"></asp:BoundField>
                    <asp:BoundField DataField="FZLD" HeaderText="负责领导"></asp:BoundField>
                    <asp:BoundField HeaderText="进度" DataField="DBID"></asp:BoundField>
                    <asp:BoundField HeaderText="完成" DataField="DBID"></asp:BoundField>
                    <asp:BoundField HeaderText="进度上报" DataField="DBID" />
                </Columns>
            </asp:GridView>
        </div>
        <%-- 显示窗口 --%>
        <div id="pWinDiv" data-options="title:'详细信息',collapsible:false,minimizable:false,maximizable:false,draggable:true,resizable:true,inline:false" class="easyui-window" style="width: 500px; height: 300px; overflow: hidden" closed="true" modal="true">

            <!--详单-->
            <div id="dbdetails"></div>

        </div>
    </div>

</asp:Content>
