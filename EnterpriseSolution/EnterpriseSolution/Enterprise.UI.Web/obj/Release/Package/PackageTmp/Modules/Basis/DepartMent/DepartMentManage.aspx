<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DepartMentManage.aspx.cs" Inherits="Enterprise.UI.Web.Manage.DepartMent.Edit" %>

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
                <li><a href="DepartMentList.aspx"><%=Trans("组织机构") %></a></li>
                <li class="last"><%=Trans("操作") %>
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
            <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("组织机构") %></span></div>
        <ul>
            <li>
                <div class="ssec-label">
                    <%=Trans("名称") %>：</div>
            </li>
            <li>
                <div class="ssec-text small">
                    <asp:TextBox ID="tb_Name" runat="server"></asp:TextBox></div>
            </li>
        </ul>
        <ul>
            <li>
                <div class="ssec-label">
                    <%=Trans("部门经理") %>：</div>
            </li>
            <li>
                <div class="ssec-text small">
                    <asp:DropDownList ID="tb_Manager" runat="server" class="easyui-combobox" style="width:260px;">
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
        <ul>
            <li>
                <div class="ssec-label">
                    <%=Trans("分管领导") %>：</div>
            </li>
            <li>
                <div class="ssec-text small">
                    <asp:DropDownList ID="tb_HeadManager" runat="server" class="easyui-combobox" style="width:260px;">
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
        <ul>
            <li>
                <div class="ssec-label">
                    <%=Trans("顺序号") %>：</div>
            </li>
            <li>
                <div class="ssec-text small">
                    <asp:TextBox ID="txt_Orderby" runat="server"></asp:TextBox>
                </div>
            </li>
        </ul>
        <ul>
            <li>
                <div class="ssec-label">
                    <%=Trans("上级部门") %>：</div>
            </li>
            <li>
                <div class="ssec-text small">
                    <asp:DropDownList ID="tb_HeadDepartment" runat="server">
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
        <ul>
            <li></li>
            <li>
            <asp:LinkButton ID="BtnSave" runat="server" iconCls="icon-save" CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick"><%=Trans("保存") %></asp:LinkButton>
            </li>
        </ul>

    </div>
        </div>
</asp:Content>
