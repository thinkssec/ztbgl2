<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TodoIndex.aspx.cs" Inherits="Enterprise.UI.Web.TodoIndex" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../../Styles/css/ssec-form.css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $.ajaxSetup({ cache: false });
            $.ajax({
                type: "post",
                url: "Component/BF/BFLoadHandler.ashx?TypeId=1",
                datatype: "text",
                async: true,
                success: function (result) {
                    setTimeout($("#uList").html(result), 3000);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div class="vDaohangtiaoHolder module">
        <div class="vDaohangtiao">
            <ul>
                <li class="first"><a href="/index.aspx" title="首页">
                    <%=Trans("首页")%></a> </li>
                <li class="last">
                    <%=Trans("待办事务")%>
                </li>
            </ul>
        </div>
    </div>
    <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
    </Ent:HeadMenuWeb>
    <div id="Div1" class="easyui-panel" title="<%=Trans("我的待办事务")%>" icon="icon-tip"
        collapsible="true" style="padding: 10px; overflow: hidden;">
        <div id="uList" style="font-size: 14px;">
        </div>
        <!--table id="uList" style="font-size:14px; ">
        </table-->
    </div>
</asp:Content>
