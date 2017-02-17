<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" EnableEventValidation="false" AutoEventWireup="true"
    CodeBehind="ProjectRunning.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.ProjectRunning" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .LinkButton {
            padding-left: 750px;
            /*float:right;*/
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent"><%=Trans("首页") %></a></li>
                    <li>招标管理</li>
                    <li class="last">招标项目运行</li>
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
                招标类别：<asp:DropDownList ID="Ddl_ZBFS" runat="server">
                    <asp:ListItem Value="">全部</asp:ListItem>
                    <asp:ListItem Value="1">公开招标</asp:ListItem>
                    <asp:ListItem Value="2">邀请招标</asp:ListItem>
                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp; 申请起始日期：<asp:TextBox ID="Tb_SearchBegin" runat="server" CssClass="easyui-datebox" Width="90" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="Tb_SearchEnd" runat="server" CssClass="easyui-datebox" Width="90" />
                <asp:LinkButton ID="BtnSearch" runat="server" CssClass="easyui-linkbutton"
                    iconCls="icon-search" OnClick="BtnSearch_Click">查询</asp:LinkButton>
            </div>
            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%"
                AllowPaging="True" PageSize="30" AllowSorting="false" OnPageIndexChanging="GridView1_PageIndexChanging"
                CssClass="GridViewStyle" DataKeyNames="PROJID">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex + 1)%>
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目名称">
                        <ItemTemplate>
                            <a href="/Modules/App/Project/ProjectInfoView.aspx?Lb=3&Cmd=Edit&PROJID=<%#(string)Eval("PROJID") %>"><%#Eval("PROJNAME")%></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PROJINCOME" HeaderText="计划金额" />
                    <%--
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
                    </asp:TemplateField> --%>
                    <%--<asp:BoundField DataField="CHECKER" HeaderText="安全检查人员"  />--%>
                    <asp:TemplateField HeaderText="经办人">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName( (int)Eval("SUBMITTER")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="申请时间">
                        <ItemStyle Width="100" />
                        <ItemTemplate>
                            <%#Eval("SUBMITDATE") %>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="发起部门">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName( (int)Eval("DEPTID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ZJLY" HeaderText="资金来源" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                        <ItemTemplate>
                            <%#GetStatus(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="批准编号">
                        <ItemTemplate>
                            <%#GetBh(Container.DataItem) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="招标文件" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="60" />
                        <ItemTemplate>
                            <%#GetFile((string)Eval("PROJID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField HeaderText="招标文件" ItemStyle-HorizontalAlign="Center">
                   <ItemStyle Width="60" />
                                    <ItemTemplate>
                                        <%#GetFile((string)Eval("PROJID")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>  --%>
                    <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Center">
                        <ItemStyle Width="70" />
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("PROJID")) %>
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
