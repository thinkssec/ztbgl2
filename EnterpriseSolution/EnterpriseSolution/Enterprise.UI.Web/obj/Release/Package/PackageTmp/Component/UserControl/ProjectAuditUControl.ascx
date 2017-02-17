<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectAuditUControl.ascx.cs"
    Inherits="Enterprise.UI.Web.Component.UserControl.ProjectAuditUControl" %>
<div id="contents" class="ssec-form">
    <div class="ssec-group ssec-group-hasicon">
        <div class="icon-form">
        </div>
        <span>审核信息</span>
    </div>
    <asp:Repeater ID="Repeater1" runat="server"
        OnItemDataBound="Repeater1_ItemDataBound">
        <HeaderTemplate>
            <table class="project-table">
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td style="width: 120px">
                    <asp:Label ID="Lbl_Shr_Show" runat="server" Text="审核人"></asp:Label>
                </td>
                <td style="width: 550px">
                    <asp:Label ID="Lbl_Shr" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lbl_Shyj_Show" runat="server" Text="审核意见"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Lbl_Shyj" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Lbl_Shrq_Show" runat="server" Text="审核日期"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Lbl_Shrq" runat="server"></asp:Label>
                </td>
            </tr>
<%--            <tr runat="server" id="trscore">
                <td>
                    <asp:Label ID="Lbl_Zldf_Show" runat="server" Text="质量得分"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Lbl_Zldf" runat="server"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td colspan="2">&nbsp;</td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</div>
