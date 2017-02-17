<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserShow.aspx.cs" Inherits="Enterprise.UI.Web.Modules.User.UserShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                    <li class="first"><a href="/index.aspx">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li><a href="UserList.aspx">
                        <%=Trans("用户信息") %></a>
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
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("用户信息") %></span>
            </div>
            <table class="ssec-table" style="width: 100%;">
                <tr>
                    <td style="width: 150px">
                        <div class="ssec-label blue">
                            <%=Trans("姓名") %>
                        ：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Name" runat="server"></asp:Label><br />
                        <asp:Image ID="img_Signature" runat="server" Visible="false" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label  blue">
                            <%=Trans("帐号") %>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_LoginName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label  blue">
                            <%=Trans("性别") %>
                        ：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Sex" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label  blue">
                            <%=Trans("所属部门") %>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Dept" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label  blue">
                            <%=Trans("关系隶属部门")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Affiliation" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <div class="ssec-label  blue">
                            职务信息：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Duty" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label  blue">
                            <%=Trans("出生日期") %>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_BirthDay" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label blue">
                            <%=Trans("手机") %>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Hw" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label  blue">
                            <%=Trans("办公电话") %>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Gn" runat="server"></asp:Label>
                    </td>
                </tr>
                <%-- 
            <tr>
                <td>
                    <div class="ssec-label blue">
                        <%=Trans("sipc电子邮箱") %>
                        ：</div>
                </td>
                <td>
                    <asp:Label ID="lb_Sipc" runat="server"></asp:Label>
                </td>
            </tr>
                --%>
                <tr>
                    <td>
                        <div class="ssec-label blue">
                            <%=Trans("电子邮箱") %>
                        ：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Others" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label blue">
                            <%=Trans("IP地址") %>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_UIP" runat="server"></asp:Label>
                    </td>
                </tr>
                <%-- 
                <tr>
                <td>
                    <div class="ssec-label blue">
                        <%=Trans("组织机构考核系统")%>：</div>
                </td>
                <td>
                    <asp:Label ID="lb_USystem1" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <div class="ssec-label blue">
                        <%=Trans("全员绩效考核系统")%>：</div>
                </td>
                <td>
                    <asp:Label ID="lb_USystem2" runat="server"></asp:Label>
                </td>
            </tr>
                --%>
                <tr>
                    <td>
                        <div class="ssec-label blue">
                            <%=Trans("显示序号") %>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Orderby" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
