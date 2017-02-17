<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DictionaryList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.Dictionary.DictionaryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px;
        overflow: hidden;">
    <div class="vDaohangtiaoHolder module">
        <div class="vDaohangtiao">
            <ul>
                <li class="first">
                    <a href="/index.aspx" title="首页"><%=Trans("首页") %></a>
                </li>
                <li><%=Trans("系统管理") %></li>
                <li class="last"><%=Trans("字典表") %>
                </li>
            </ul>
        </div>
    </div>
    <div id="main-tool">
    <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
        <Ent:HeadMenuButtonItem ButtonName="字典表" ButtonPopedom="List" ButtonUrl="DictionaryList.aspx" ButtonUrlType="Href" />
    </Ent:HeadMenuWeb>
    </div>
    </div>
    <div data-options="region:'center'">
         <div class="main-gridview">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width="100%" DataKeyNames="DID">
        <Columns>
            <asp:TemplateField HeaderText="序号" ItemStyle-Width="40">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="中文名称" DataTextField="ZWMC" DataNavigateUrlFields="DID" DataNavigateUrlFormatString="DictionaryDisp.aspx?Id={0}" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="45%"/>
            <%--<asp:BoundField HeaderText="所属组别" DataField="SSZB" />--%>
            <asp:BoundField HeaderText="语言" DataField="YZ" ItemStyle-Width="40"/>
            <asp:BoundField HeaderText="对应名称" DataField="DYMC"  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="45%"/>
        </Columns>
    </asp:GridView>
    </div>
    </div>
</asp:Content>
