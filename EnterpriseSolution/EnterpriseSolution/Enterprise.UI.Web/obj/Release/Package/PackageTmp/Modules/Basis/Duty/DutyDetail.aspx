<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DutyDetail.aspx.cs" Inherits="Enterprise.UI.Web.Modules.ZhiWu.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../../Resources/Styles/css/ssec-form.css" />
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
    <div id="contents" class="ssec-form">
        <div class="ssec-group ssec-group-hasicon">
            <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("职务信息") %></span></div>
        <ul>
            <li>
                <div class="ssec-label">
                    <%=Trans("名称")%>：</div>
            </li>
            <li>
                <div>
                    <asp:Label ID="lb_Name" runat="server"></asp:Label></div>
            </li>
        </ul>
        <ul>
            <li>
                <div class="ssec-label">
                    <%=Trans("说明")%>：</div>
            </li>
            <li>
                <div>
                    <asp:Label ID="lb_Remark" runat="server"></asp:Label></div>
            </li>
        </ul>
    </div>
        </div>
</asp:Content>
