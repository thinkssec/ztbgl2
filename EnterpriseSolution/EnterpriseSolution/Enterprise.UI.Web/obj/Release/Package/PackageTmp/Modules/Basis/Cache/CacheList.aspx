<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CacheList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Cache.CacheList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <li class="last">
                        <%=Trans("缓存管理") %>
                    </li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
                <Ent:HeadMenuButtonItem ButtonPopedom="List" ButtonUrl="CacheList.aspx?Cmd=Reload"
                    ButtonUrlType="Href" />
                <Ent:HeadMenuButtonItem ButtonPopedom="Delete" ButtonUrl="SysState.aspx"
                    ButtonUrlType="Href" />
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <div class="main-gridview">
            <div class="main-gridview-title">
                数据表名称:
                <asp:TextBox ID="Txt_TABLENAME" runat="server"></asp:TextBox>
                <asp:LinkButton ID="Bt_Search" runat="server" Text="查询" CssClass="easyui-linkbutton"
                    plain="false" OnClick="Bt_Search_Click"></asp:LinkButton>
            </div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="CACHENAME" AutoGenerateColumns="false" 
                AllowPaging="false" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="序号" ItemStyle-Width="40">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="数据用户" DataField="USERNAME" />
                    <asp:BoundField HeaderText="数据表名" DataField="TABLENAME" />
                    <asp:HyperLinkField HeaderText="缓存名称" DataTextField="CACHENAME" DataNavigateUrlFields="CACHENAME"
                        DataNavigateUrlFormatString="CacheDisp.aspx?Id={0}" />
                    <asp:TemplateField HeaderText="触发器状态" ItemStyle-Width="200">
                        <ItemTemplate>
                            <%#ShowTriggerStatus(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
