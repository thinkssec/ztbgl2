<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RoleDetail.aspx.cs" Inherits="Enterprise.UI.Web.Manage.Role.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function openlist() {
            $('#rcv_users').window('open');
        }
        function closelist() {
            //关闭窗口
            $('#rcv_users').window('close');
            //获取所有选中的节点的子节点
            var node = $('#tt2').tree('getChecked');
            if (node) {
                var children = $('#tt2').tree('getChecked', node.target);
            } else {
                var children = $('#tt2').tree('getChecked');
            }
            var s = '';
            var c = 0;
            for (var i = 0; i < children.length; i++) {
                var v = children[i].id.toString();
                if (v.indexOf("d-") < 0) {
                    s += children[i].id + ',';
                    c++;
                }
            }
            $('#rcvuser_count').text(c);
            $('#rcv_users_value').attr('value', s);
            //开发时请注释alert
            //alert('选中的人员id:'+s);
        }
        $(function () {
            //初始化签收人个数
            //            var u = $('#rcv_users_value').val();
            //            if (u) {
            //                $('#rcvuser_count').text(u.split(',').length);
            //            }
            //            else
            $('#rcvuser_count').text(0);
            jQuery.ajaxSetup({ cache: false })
            $('#tt2').tree({
                lines: true,
                checkbox: true,
                url: '/Modules/Basis/User/UserJson.aspx?selected=' + $('#rcv_users_value').val(),
                onClick: function (node) {
                    $(this).tree('toggle', node.target);
                    //alert('you click '+node.text);
                },
                onContextMenu: function (e, node) {
                    e.preventDefault();
                    $('#tt2').tree('select', node.target);
                    $('#mm').menu('show', {
                        left: e.pageX,
                        top: e.pageY
                    });
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx" title="首页">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("角色管理") %></li>
                    <li class="last">
                        <%=Trans("角色权限") %>
                    </li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td height="25" align="right" width="160">
                    <%=Trans("角色名称")%>：
                </td>
                <td align="left">
                    <asp:Label ID="Role_Name" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td height="25" align="right">
                    <%=Trans("角色说明")%>：
                </td>
                <td align="left">
                    <asp:Label ID="Role_Remark" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div style="padding: 10px;">
            <div class="main-gridview">
                <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                    <asp:Repeater ID="Module_Main" runat="server" OnItemDataBound="Module_Main_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td colspan="9">
                                    <%# Eval("mName")%>
                                </td>
                            </tr>
                            <tr class="table_body" align="center">
                                <td width="25%" align="left">
                                    <%=Trans("栏目名称")%>
                                </td>
                                <td>
                                    <%=Trans("查看")%>
                                </td>
                                <td>
                                    <%=Trans("新增")%>
                                </td>
                                <td>
                                    <%=Trans("修改")%>
                                </td>
                                <td>
                                    <%=Trans("删除")%>
                                </td>
                                <td>
                                    <%=Trans("排序")%>
                                </td>
                                <td>
                                    <%=Trans("打印")%>
                                </td>
                                <td>
                                    <%=Trans("备用")%>A
                                </td>
                                <td>
                                    <%=Trans("备用")%>B
                                </td>
                            </tr>
                            <asp:Repeater ID="Module_Sub" runat="server" OnItemDataBound="Module_Sub_ItemDataBound">
                                <ItemTemplate>
                                    <tr class="table_none" align="center">
                                        <td align="left">&nbsp;&nbsp;└<%# Eval("mName")%>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="Lab2_Txt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="Lab4_Txt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="Lab8_Txt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="Lab16_Txt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="Lab32_Txt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="Lab64_Txt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="Lab128_Txt"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Literal runat="server" ID="Lab256_Txt"></asp:Literal>
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="Module_Sub1" runat="server" OnItemDataBound="Module_Sub1_OnItemDataBound">
                                        <ItemTemplate>
                                            <tr class="table_none" align="center">
                                                <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;└
                                                <%# Eval("mName")%>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="Lab22_Txt"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="Lab24_Txt"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="Lab28_Txt"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="Lab216_Txt"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="Lab232_Txt"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="Lab264_Txt"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="Lab2128_Txt"></asp:Literal>
                                                </td>
                                                <td>
                                                    <asp:Literal runat="server" ID="Lab2256_Txt"></asp:Literal>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                    </asp:Repeater>
                    <tr id="ButtonTr_End" visible="false" runat="server">
                        <td colspan="9" align="right">
                            <asp:Button ID="Button1" runat="server" CssClass="button2" Text="确定" OnClick="Button1_Click" />
                            <input id="Reset1" class="button2" type="reset" value="重填" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
            <tr>
                <td align="center">
                    <%=Trans("添加人员")%>
                </td>
                <td>
                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td width="160">
                                <asp:HiddenField ID="rcv_users_value" runat="server" ClientIDMode="Static" />
                                <%--签收列表--%>
                                <a href="#" onclick="openlist();" class="button">
                                    <%=Trans("人员列表")%></a> |
                                <%=Trans("已选择")%><span id="rcvuser_count"></span>
                                <%=Trans("人")%>
                            </td>
                            <td align="left">
                                <asp:Button ID="Button2" runat="server" Text="添加" CssClass="button2" OnClick="Button2_OnClick"
                                    OnClientClick="return confirm('确定要为人员设置改角色？')" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <%=Trans("拥有角色人员")%>
                </td>
                <td align="left">
                    <asp:Label ID="labelUser" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div id="rcv_users" class="easyui-window" closed="true" modal="true" title="<%=Trans("人员列表")%>"
            style="width: 320px; height: 400px;">
            <ul id="tt2">
            </ul>
            <a href="#" onclick="closelist();" class="easyui-linkbutton">
                <%=Trans("确定")%></a>
        </div>
    </div>
</asp:Content>
