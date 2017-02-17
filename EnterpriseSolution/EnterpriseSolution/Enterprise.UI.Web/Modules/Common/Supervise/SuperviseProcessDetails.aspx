<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuperviseProcessDetails.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.Common.Supervise.SuperviseProcessDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>详情</title>
    <link rel="Stylesheet" href="/Resources/OA/site_skin/default/site.main.css" title="default" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="padding: 5px">
        <span>
            <%=Trans("事务内容")%>：</span><%=InfoModel.DBNR %>
    </div>
    <div class="main-gridview">
        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" OnRowDataBound="gv_RowDataBound"
            Width="100%">
            <Columns>
                <asp:BoundField DataField="BLRID" HeaderText="负责人"></asp:BoundField>
                <asp:BoundField DataField="YQSBSJ" HeaderText="要求上报时间"></asp:BoundField>
                <asp:BoundField DataField="DQJD" HeaderText="当前进度%"></asp:BoundField>
                <asp:BoundField DataField="BZ" HeaderText="说明" ItemStyle-HorizontalAlign="Left" HtmlEncode="false" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
