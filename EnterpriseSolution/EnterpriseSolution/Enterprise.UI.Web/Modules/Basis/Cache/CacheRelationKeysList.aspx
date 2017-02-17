<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CacheRelationKeysList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Cache.CacheRelationKeysList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkForm() 
        {
            var nodeBH = "<%=Hid_CACHEID.ClientID%>";
            var isOk = $('#form1').form('validate');
            if (isOk) {
                var v = $('#' + nodeBH).val();
                if (v == null || v == "") {
                    alert("请先选择一个节点!");
                    return false;
                }
            }
            return isOk;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent">首页</a></li>
                    <li>系统管理</li>
                    <li>缓存管理</li>
                    <li class="last">缓存关联项管理</li>
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
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>缓存关联项</span>
            </div>
        </div>
        <div class="main-gridview-title">
        </div>
        <table>
            <tr>
                <td style="width: 300px; vertical-align: top; padding-left: 10px;">
                    <asp:TreeView ID="TreeView1" runat="server" ImageSet="Inbox" BorderWidth="0px" CssClass="TreeviewStyle" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" BackColor="#FF6666" />
                    </asp:TreeView>
                </td>
                <td style="width: 640px; vertical-align: top;">
                    <div id="contents" class="ssec-form">
                        <ul>
                            <li class="ssec-label">主缓存名称:</li>
                            <li>
                                <div>
                                    <asp:HiddenField ID="Hid_CACHEID" runat="server" />
                                    <asp:TextBox ID="Txt_CACHENAME" runat="server" CssClass="easyui-validatebox" Width="350"
                                         required="true" missingMessage="必填项" validType="length[0,100]" invalidMessage="不能超过100个字符！"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">关联缓存项:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_INFLCACHENAME" runat="server" CssClass="easyui-validatebox" Width="350"
                                         required="true" missingMessage="必填项" validType="length[0,100]" invalidMessage="不能超过100个字符！"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">有效标志:</li>
                            <li>
                                <div>
                                    <asp:RadioButtonList ID="Rdl_ISVALID" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label"></li>
                            <li>
                                <div>
                                    <asp:LinkButton ID="AddBtn" CssClass="easyui-linkbutton" OnClientClick="return checkForm();" iconCls="icon-add" runat="server" OnClick="AddBtn_Click">添加</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="BtnSave" CssClass="easyui-linkbutton" OnClientClick="return checkForm();" iconCls="icon-save" runat="server" OnClick="BtnSave_Click">更新</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="DelBtn" CssClass="easyui-linkbutton" OnClientClick="return checkForm();" iconCls="icon-cancel" runat="server" OnClick="DelBtn_Click">删除</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="ReloadBtn" CssClass="easyui-linkbutton" iconCls="icon-reload" runat="server" OnClick="ReloadBtn_Click" >同步</asp:LinkButton>
                                    <%--<asp:LinkButton ID="UpBtn" CssClass="easyui-linkbutton" iconCls="icon-up" OnClientClick="return checkForm();" runat="server" OnClick="UpBtn_Click">上升</asp:LinkButton>
                                    <asp:LinkButton ID="DownBtn" CssClass="easyui-linkbutton" iconCls="icon-down" OnClientClick="return checkForm();" runat="server" OnClick="DownBtn_Click">下降</asp:LinkButton>--%>
                                </div>
                            </li>
                        </ul>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
