<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" 
    CodeBehind="DmwxPlanList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Dmgl.DmwxPlanList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
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
            <%=Trans("状态")%>：<asp:DropDownList ID="s_Type" runat="server">
                <asp:ListItem Text="完成" Value="1"></asp:ListItem>
                <asp:ListItem Text="在运行" Value="0"></asp:ListItem>
            </asp:DropDownList>
             时间:<asp:TextBox ID="Tb_SearchBegin" runat="server" CssClass="easyui-datebox" Width="90"/>
                <asp:TextBox ID="Tb_SearchEnd" runat="server" CssClass="easyui-datebox"  Width="90"/>
            <asp:LinkButton ID="Bt_Search" runat="server" Text="查询" CssClass="easyui-linkbutton"
                plain="false" OnClick="Bt_Search_OnClick"></asp:LinkButton>
        </div>
        
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="PID" 
                AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
 
                        <asp:TemplateField ItemStyle-Width="40" HeaderText="序号">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    <asp:TemplateField HeaderText="维修项目名称">
                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemTemplate>
                             <%#Eval("MX") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="维修工作量描述">
                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemTemplate>
                            <%#Eval("MS") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CREATETIME" HeaderText="发起时间" DataFormatString="{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="PAMOUNT" HeaderText="工程预算（元）"/>
                    <asp:BoundField DataField="PENDDATE" HeaderText="计划完成时间" DataFormatString="{0:yyyy-MM-dd}"/>
                    <asp:BoundField DataField="ENDDATE" HeaderText="完成时间" DataFormatString="{0:yyyy-MM-dd}"/>
                    
                    <asp:TemplateField HeaderText="状态">
                        
                        <ItemTemplate>
                            <%#GetStatus(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>   
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                        <ItemStyle HorizontalAlign="Center" Width="80px" />
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("PID")) %>
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
