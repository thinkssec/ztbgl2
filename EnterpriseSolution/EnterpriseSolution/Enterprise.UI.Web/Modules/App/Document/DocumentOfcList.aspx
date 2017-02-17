<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentOfcList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Document.DocumentOfcList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/">首页</a>
                    </li>
                    <li>综合办公</li>
                    <li class="last"><asp:Label ID="lb_MName" runat="server"></asp:Label></li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <%--自定义按钮--%>
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <%--end--%>
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
    </Ent:HeadMenuWeb>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
    
     <div class="main-gridview">
         <div class="main-gridview-title">
            <%--显示有效通知的信息--%>
            <%=Trans("搜索")%>：<asp:DropDownList ID="s_Type" runat="server">
                <asp:ListItem Text="标题" Value="TITLE"></asp:ListItem>
                <asp:ListItem Text="内容" Value="CONTENT"></asp:ListItem>
            </asp:DropDownList>
            <%=Trans("关键字")%>：<asp:TextBox ID="s_Key" runat="server"></asp:TextBox>
            <asp:LinkButton ID="Bt_Search" runat="server" Text="搜索" CssClass="easyui-linkbutton"
                plain="false" OnClick="Bt_Search_OnClick"></asp:LinkButton>
        </div>
        
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="DOCID" 
                AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
 
                        <asp:TemplateField ItemStyle-Width="40" HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="标题">
                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemTemplate>
                             <%#GetURL(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发布部门/单位">
                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName((int)Eval("CREATEDEPT")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发布人">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName((int)Eval("CREATEUSER")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="签收人">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName((int)Eval("RECEVIEUSER")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="RELEASETIME" HeaderText="发布时间" DataFormatString="{0:yyyy-MM-dd}">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </asp:BoundField> 
                    <asp:TemplateField HeaderText="状态">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <%#GetStatus(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>                   
                </Columns>               
                <PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PageButtonCount="5"
                    PreviousPageText="上一页" />
                <PagerStyle CssClass="GridViewPagerStyle" />
            </asp:GridView>
        
    </div>
        </div>
</asp:Content>
