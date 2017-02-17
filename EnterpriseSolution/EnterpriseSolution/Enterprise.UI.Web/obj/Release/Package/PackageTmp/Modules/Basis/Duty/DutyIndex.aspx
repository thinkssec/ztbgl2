<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DutyIndex.aspx.cs" Inherits="Enterprise.UI.Web.Manage.ZhiWu.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false"  style="padding:0px; overflow:hidden;" >

    <div class="vDaohangtiaoHolder module">
        <div class="vDaohangtiao">
            <ul>
                <li class="first">
                    <a href="/index.aspx"><%=Trans("首页") %></a>
                </li>
                <li><%=Trans("系统管理") %></li>
                <li class="last"><%=Trans("职务信息") %></li>                
            </ul>
        </div>
    </div>
    <div id="main-tool">
    <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
    </Ent:HeadMenuWeb>
        </div>
        </div>
    <div data-options="region:'center'">
        <div class="main-gridview">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="DUTYID" AutoGenerateColumns="false"
        Width="100%">
        <Columns>
            <asp:TemplateField ItemStyle-Width="30">
                <ItemTemplate>
                    
                        <img src="../../../Resources/Styles/_img/arrow_142.gif" alt="" />
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField ItemStyle-Width="30" HeaderText="序号">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="名称" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="200">
                <ItemTemplate>
                    <a href="UserDutyManage.aspx?Id=<%#Eval("DUTYID") %>">
                        <%#Eval("DNAME")%></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DREMARK" HeaderText="说明" />
            <asp:TemplateField ItemStyle-Width="100" HeaderText="操作">
                <ItemTemplate>
                    <a href="DutyDetail.aspx?Id=<%#Eval("DUTYID") %>" class="easyui-linkbutton" iconCls="icon-edit" plain="true">
                      编辑</a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
            </div>
        </div>
</asp:Content>
