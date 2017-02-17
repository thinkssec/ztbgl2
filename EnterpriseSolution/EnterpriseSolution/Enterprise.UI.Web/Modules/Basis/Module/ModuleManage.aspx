<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ModuleManage.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Module.ModuleManage" %>

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
                    <li><a href="ModuleIndex.aspx">
                        <%=Trans("模块管理") %></a></li>
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
    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("模块管理") %></span>
            </div>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("编码") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_Code" runat="server"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("名称") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_Name" runat="server"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("链接地址") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_Url" runat="server" Text="#" Width="500"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("WEB映射地址") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_WebUrl" runat="server" Text="" Width="400"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("WEB映射地址参数") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_WebParam" runat="server" Text="" Width="200"></asp:TextBox>注：WEB映射地址必须以“/SSEC/”起头，不能用点号
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("系统外链接") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:DropDownList ID="tb_Single" runat="server">
                            <asp:ListItem Text="否" Value="0"></asp:ListItem>
                            <asp:ListItem Text="是" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                        (*是则不允许有下级菜单，直接根据链接地址转向外部)
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("链接目标") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:DropDownList ID="tb_Target" runat="server">
                            <asp:ListItem Text="默认" Value="mainframe"></asp:ListItem>
                            <asp:ListItem Text="_blank" Value="_blank"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("是否显示") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:DropDownList ID="tb_Show" runat="server">
                            <asp:ListItem Text="是" Value="0"></asp:ListItem>
                            <asp:ListItem Text="否" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("图标样式") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_MIMAGE" runat="server" Text="" Width="100"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div>
                        <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick">保存</asp:LinkButton>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
