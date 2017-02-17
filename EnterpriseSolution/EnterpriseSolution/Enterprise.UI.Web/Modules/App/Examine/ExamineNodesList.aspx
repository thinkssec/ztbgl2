<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ExamineNodesList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Examine.ExamineNodesList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkForm() 
        {
            var nodeBH = "<%=Hid_NODEBH.ClientID%>";
            var isOk = $('#form1').form('validate');
            if (isOk) {
                var v = $('#' + nodeBH).val();
                //if (v == null || v == "") {
                //    alert("请先选择一个节点!");
                //    return false;
                //}
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
                    <li>参数配置</li>
                    <li class="last">业务模块节点管理</li>
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
                <span>业务模块节点管理</span>
            </div>
        </div>
        <div class="main-gridview-title">
            业务类型：<asp:DropDownList ID="Ddl_KINDID" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="Ddl_KINDID_SelectedIndexChanged">
            </asp:DropDownList>
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
                            <li class="ssec-label">节点编码:</li>
                            <li>
                                <div>
                                    <asp:HiddenField ID="Hid_NODEBH" runat="server" />
                                    <asp:TextBox ID="Txt_NODECODE" runat="server" CssClass="easyui-validatebox"
                                         required="true" missingMessage="必填项" validType="length[0,50]" invalidMessage="不能超过50个字符！"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">节点编号:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_NODEBH" runat="server" CssClass="easyui-validatebox"
                                         required="true" missingMessage="必填项" validType="length[0,50]" invalidMessage="不能超过50个字符！"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">节点名称:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_NODENAME" runat="server" CssClass="easyui-validatebox"
                                         required="true" missingMessage="必填项" validType="length[0,25]" invalidMessage="不能超过25个字！"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">是否关键节点:</li>
                            <li>
                                <div>
                                    <asp:RadioButtonList ID="Rdl_KEYNODE" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Text="是" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">节点路径:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_NODEPATH" runat="server" CssClass="easyui-validatebox" 
                                        validType="length[0,200]" invalidMessage="不能超过200个字符！" Width="360px">
                                    </asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">WEB映射路径:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_WEBURL" runat="server" CssClass="easyui-validatebox" 
                                        validType="length[0,200]" invalidMessage="不能超过200个字符！" Width="360px">
                                    </asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">WEB路径参数:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_WEBPARAM" runat="server" CssClass="easyui-validatebox" 
                                        validType="length[0,100]" invalidMessage="不能超过100个字符！" Width="260px">
                                    </asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">动作参数:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_NODEPARAM" runat="server" CssClass="easyui-validatebox" 
                                        validType="length[0,50]" invalidMessage="不能超过50个字符！"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">节点图标:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_NODEICON" runat="server" CssClass="easyui-validatebox" 
                                        validType="length[0,200]" invalidMessage="不能超过200个字符！"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">节点状态:</li>
                            <li>
                                <div>
                                    <asp:RadioButtonList ID="Rdl_NODESTATUS" runat="server" 
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Text="不可见" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="可见" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="废弃" Value="2"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">节点权值(0-100):</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_NODEVALUE" runat="server" CssClass="easyui-numberbox" min="0" max="100" precision="0" invalidMessage="只能输入数字!"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">添加日期:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Txt_ADDDATE" runat="server" CssClass="easyui-datebox" editable="false" required="true"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label"></li>
                            <li>
                                <div>
                                    <asp:LinkButton ID="AddBtn" CssClass="easyui-linkbutton" OnClientClick="return checkForm();" iconCls="icon-add" runat="server" OnClick="AddBtn_Click">添加</asp:LinkButton>
                                    <asp:LinkButton ID="BtnSave" CssClass="easyui-linkbutton" OnClientClick="return checkForm();" iconCls="icon-save" runat="server" OnClick="BtnSave_Click">更新</asp:LinkButton>
                                    <asp:LinkButton ID="UpBtn" CssClass="easyui-linkbutton" iconCls="icon-up" OnClientClick="return checkForm();" runat="server" OnClick="UpBtn_Click">上升</asp:LinkButton>
                                    <asp:LinkButton ID="DownBtn" CssClass="easyui-linkbutton" iconCls="icon-down" OnClientClick="return checkForm();" runat="server" OnClick="DownBtn_Click">下降</asp:LinkButton>
                                </div>
                            </li>
                        </ul>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
