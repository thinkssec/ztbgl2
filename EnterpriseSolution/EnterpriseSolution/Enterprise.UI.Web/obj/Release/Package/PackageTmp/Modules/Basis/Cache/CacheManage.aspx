<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CacheManage.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Cache.CacheManage" %>

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
                    <li><a href="CacheList.aspx">
                        <%=Trans("缓存管理") %></a></li>
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
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("缓存管理") %></span></div>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("缓存名称") %>：</div>
                </li>
                <li>
                    <div class="ssec-text">
                        <asp:TextBox ID="tb_Hcmc" runat="server" Columns="40" CssClass="easyui-validatebox"
                            required="true"></asp:TextBox></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("数据用户") %>：</div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_User" runat="server" CssClass="easyui-validatebox" required="true"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("数据表名") %>：</div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_Sjmc" runat="server" CssClass="easyui-validatebox" required="true"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("描述说明") %>：</div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:TextBox ID="tb_Describe" runat="server" Width="500"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <div class="ssec-group-bottom ssec-group-hasicon">
                <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick"
                    OnClientClick="return checkForm();"><%=Trans("保存") %></asp:LinkButton></div>
        </div>
    </div>
</asp:Content>
