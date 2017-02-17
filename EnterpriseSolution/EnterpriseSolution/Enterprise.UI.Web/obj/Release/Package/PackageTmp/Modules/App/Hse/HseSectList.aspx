<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation = "false" AutoEventWireup="true" 
    CodeBehind="HseSectList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Hse.HseSectList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .LinkButton{
          padding-left:750px;
          /*float:right;*/
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px;
        overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent"><%=Trans("首页") %></a></li>
                    <li>Hse管理</li>
                    <li class="last">安全隐患整改</li>
                </ul> 
            </div>
        </div>
        <div id="main-tool">
            <%--自定义按钮--%>
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <%--end--%>
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <div class="main-gridview">
            <div class="main-gridview-title">
                检查级别：<asp:DropDownList ID="Ddl_Tongji" runat="server">
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="油田级">油田级</asp:ListItem>
                    <asp:ListItem Value="鲁明">鲁明</asp:ListItem>
                    <asp:ListItem Value="富林">富林</asp:ListItem>
                    <asp:ListItem Value="地方">地方</asp:ListItem>         
                   </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp; 起始日期：<asp:TextBox ID="Tb_SearchBegin" runat="server" CssClass="easyui-datebox" Width="90"/>&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Tb_SearchEnd" runat="server" CssClass="easyui-datebox" Width="90"/>
                <asp:LinkButton ID="BtnSearch" runat="server" CssClass="easyui-linkbutton" 
                    iconCls="icon-search" onclick="BtnSearch_Click">查询</asp:LinkButton>
            </div>
        <%--数据表格开始--%>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
            AllowPaging="True" PageSize="20" AllowSorting="false" OnPageIndexChanging="GridView1_PageIndexChanging"
            CssClass="GridViewStyle">
            <Columns>
                <asp:TemplateField HeaderText="序号">
                    <ItemTemplate>
                        <a href="/Modules/App/Hse/HseSectView.aspx?Cmd=View&CKID=<%#(string)Eval("CKID") %>"><%#(Container.DataItemIndex + 1)%>
                    </ItemTemplate>
                    <HeaderStyle Width="50px" />
                </asp:TemplateField>
                <asp:BoundField DataField="CLEVEL" HeaderText="检查级别"  />
                <asp:BoundField DataField="CTARGET" HeaderText="被检单位"  />
                <asp:TemplateField HeaderText="安全检查人">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserNameArray((string)Eval("CHECKER")) %>
                        </ItemTemplate>
                    </asp:TemplateField> 
                <asp:TemplateField HeaderText="隐患接受人">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName((int)Eval("RECIEVER")) %>
                        </ItemTemplate>
                    </asp:TemplateField> 
                <%--<asp:BoundField DataField="CHECKER" HeaderText="安全检查人员"  />--%>
                <asp:BoundField DataField="CDATE" HeaderText="检查日期" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField DataField="ENDDATE" HeaderText="限定完成日期" DataFormatString="{0:yyyy-MM-dd}" />
               <asp:BoundField DataField="COMPLETEDATE" HeaderText="实际完成时间" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:TemplateField HeaderText="状态">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <%#GetStatus(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>         
               <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#GetCommandBtn((string)Eval("CKID")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
        </asp:GridView>
        <%--end--%>
    </div>
    </div>
</asp:Content>
