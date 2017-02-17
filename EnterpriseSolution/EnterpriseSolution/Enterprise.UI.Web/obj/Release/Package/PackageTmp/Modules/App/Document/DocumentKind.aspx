<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentKind.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Document.DocumentKind" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkInputForm() {
            var v = $('#form1').form('validate');
            return v;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/Index.aspx">首页</a> </li>
                    <li>知识库</li>
                    <li>业务文档库</li>
                    <li class="last">操作
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
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>文档库类别管理</span>
            </div>
        </div>
        <div class="main-gridview">
            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="20" AutoGenerateColumns="False"
                Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound"
                DataKeyNames="LBBH">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <asp:Label ID="Txt_LBBH" runat="server" onfocus="set_Date(this)" Text='<%# Eval("LBBH")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:Label ID="LBBH" runat="server" Text="类别编号"></asp:Label>
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="LBMC" HeaderText="类别名称" />
                    <asp:BoundField DataField="LBXH" HeaderText="类别序号" />
                    <asp:BoundField DataField="SJBH" HeaderText="上级代码编号" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("LBBH"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div id="Div1" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>业务文档库类别管理-操作面板</span>
                </div>
                <ul>
                    <li>
                        <div class="ssec-label">
                            类别编号：
                        </div>
                    </li>
                    <li>
                        <div>
                            <asp:TextBox ID="tb_LBBH" runat="server" CssClass="easyui-validatebox" Required="true" validType="length[0,25]" invalidMessage="不能超过25个字符"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li>
                        <div class="ssec-label">
                            类别名称：
                        </div>
                    </li>
                    <li>
                        <div>
                            <asp:TextBox ID="tb_Name" runat="server" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符！"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li>
                        <div class="ssec-label">
                            类别序号:
                        </div>
                    </li>
                    <li>
                        <div>
                            <asp:TextBox ID="tb_LBXH" runat="server" CssClass="easyui-numberbox"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li>
                        <div class="ssec-label">
                            上级名称:
                        </div>
                    </li>
                    <li>
                        <div>
                            <asp:TextBox ID="tb_SJBH" runat="server" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符！"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li></li>
                    <li>
                        <asp:LinkButton ID="BtnSave" icon-Cls="icon-save" runat="server" CssClass="easyui-linkbutton" OnClientClick="return checkInputForm();"
                            OnClick="BtnSave_OnClick">保存</asp:LinkButton></li>
                </ul>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
