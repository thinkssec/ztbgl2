<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DepartMentDetail.aspx.cs" Inherits="Enterprise.UI.Web.Manage.DepartMent.Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../../Resources/Styles/css/ssec-form.css" />
    <script type="text/javascript">
        function DelData(url) {
            if (confirm("您确定要进行删除操作吗?")) {
                window.location = url;
                return;
            }
            window.location.reload(true);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/index.aspx"><%=Trans("首页") %></a>
                    </li>
                    <li><%=Trans("系统管理") %></li>
                    <li><a href="DepartMentList.aspx"><%=Trans("组织机构") %></a></li>
                    <li class="last"><%=Trans("查看") %>
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
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("组织机构") %></span>
            </div>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("名称") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Name" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("部门经理") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Manager" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("分管领导") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_HeadManager" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("顺序号")%>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Orderby" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("上级部门")%>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_HeadDepartment" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
