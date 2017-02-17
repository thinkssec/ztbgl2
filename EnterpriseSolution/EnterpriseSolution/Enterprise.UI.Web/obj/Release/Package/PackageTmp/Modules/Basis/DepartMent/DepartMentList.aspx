<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DepartMentList.aspx.cs" Inherits="Enterprise.UI.Web.Manage.DepartMent.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
<div data-options="region:'north',split:false,border:false"  style="padding:0px; overflow:hidden;" >
    <div class="vDaohangtiaoHolder module">
        <div class="vDaohangtiao">
            <ul>
                <li class="first">
                    <a href="/index.aspx" title="首页"><%=Trans("首页") %></a>
                </li>                
                <li><%=Trans("系统管理") %></li>         
                <li class="last"><%=Trans("组织机构") %>
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
    <div class="main-gridview">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="DeptId" AutoGenerateColumns="false"
        Width="100%" OnRowDataBound="GridView1_OnRowDataBound">
        <Columns>
            <asp:TemplateField ItemStyle-Width="30">
                <ItemTemplate>                  
                    <img src="../../../Resources/Styles/_img/arrow_142.gif" alt="" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="40" HeaderText="序号">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataTextField="dName" HeaderText="名称" DataNavigateUrlFields="DeptId" 
                DataNavigateUrlFormatString="DepartMentList.aspx?Id={0}" ItemStyle-HorizontalAlign="Left" />
            <asp:TemplateField HeaderText="排序" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60" Visible="false">
                <ItemTemplate>
                    <a href="DepartMentList.aspx?dId=<%#Eval("DeptId") %>&Action=Up">
                        <img src="../../Manage/Common/img/up.gif" title="上移" alt="" border="0" /></a>&nbsp;&nbsp;<a
                            href="DepartMentList.aspx?dId=<%#Eval("DeptId") %>&Action=Down"><img src="../../Manage/Common/img/down.gif"
                                title="下移" alt="" border="0" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width="80" HeaderText="操作">
                <ItemTemplate>
                    <a href="DepartMentDetail.aspx?Id=<%#Eval("DeptId") %>" class="easyui-linkbutton" iconCls="icon-edit" plain="true">
                        <%=Trans("编辑") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    </div>
    </div>
</asp:Content>
