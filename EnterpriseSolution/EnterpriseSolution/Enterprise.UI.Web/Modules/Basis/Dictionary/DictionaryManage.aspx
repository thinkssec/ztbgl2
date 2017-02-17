<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DictionaryManage.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Dictionary.DictionaryManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px;
        overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li><a href="DictionaryList.aspx">
                        <%=Trans("字典表") %></a></li>
                    <li class="last">
                        <%=Trans("操作") %>
                    </li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        <div data-options="region:'center'">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("字典表") %></span></div>
                <ul>
                    <li>
                        <div class="ssec-label">
                            <%=Trans("中文名称") %>：</div>
                    </li>
                    <li>
                        <div class="ssec-text small">
                            <asp:TextBox ID="tb_Zwmc" runat="server" CssClass="easyui-validatebox" required="true"></asp:TextBox></div>
                    </li>
                </ul>
                <ul>
                    <li>
                        <div class="ssec-label">
                            <%=Trans("语言") %>：</div>
                    </li>
                    <li>
                        <div class="ssec-text small">
                            <asp:DropDownList ID="tb_Language" runat="server">
                                <asp:ListItem Text="俄语" Value="ru"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li>
                        <div class="ssec-label">
                            <%=Trans("对应语言名称") %>：</div>
                    </li>
                    <li>
                        <div class="ssec-text small">
                            <asp:TextBox ID="tb_Dymc" runat="server" CssClass="easyui-validatebox" required="true"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <div class="ssec-group-bottom ssec-group-hasicon">
                    <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick"
                        OnClientClick="return checkForm();"><%=Trans("保存") %></asp:LinkButton></div>
            </div>
        </div>
</asp:Content>
