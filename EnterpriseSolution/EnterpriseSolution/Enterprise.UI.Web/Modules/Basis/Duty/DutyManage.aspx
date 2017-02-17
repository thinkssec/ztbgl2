<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DutyManage.aspx.cs" Inherits="Enterprise.UI.Web.Manage.ZhiWu.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px;
        overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/Index.aspx">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li><a href="Index.aspx">
                        <%=Trans("职务信息") %></a></li>
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
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("职务信息") %></span></div>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("名称") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Name" runat="server"></asp:TextBox></div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("说明") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Remark" runat="server"></asp:TextBox></div>
                </li>
            </ul>
            <ul>
                <li></li>
                <li>
                    <asp:LinkButton ID="BtnSave" icon-Cls="icon-save" runat="server" CssClass="easyui-linkbutton"
                        OnClick="BtnSave_OnClick">保存</asp:LinkButton></li>
            </ul>
        </div>
    </div>
</asp:Content>
