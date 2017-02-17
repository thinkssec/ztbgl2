<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="TodoIndexBox.aspx.cs" Inherits="Enterprise.UI.Web.TodoIndexBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/Default.aspx"><%=Trans("首页")%></a> </li>
                    <li class="last">
                        <asp:Label ID="lb_MName" runat="server"></asp:Label>
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
        <div id="Div1" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>我的待办箱</span>
            </div>
        </div>
        <div class="main-gridview">
            <div class="main-gridview-title">
                <%=Trans("日期")%>：<asp:TextBox ID="Txt_SENDTIME" runat="server" CssClass="easyui-datebox"></asp:TextBox>
                &nbsp;&nbsp;<%=Trans("状态")%>：<asp:DropDownList ID="Ddl_ISREAD" runat="server"></asp:DropDownList>
                &nbsp;&nbsp;标题：<asp:TextBox ID="Txt_MSGTITLE" runat="server"></asp:TextBox>
                &nbsp;&nbsp;<asp:LinkButton ID="Bt_Search" runat="server" Text="搜索" CssClass="easyui-linkbutton"
                    plain="false" OnClick="Bt_Search_OnClick"></asp:LinkButton>
            </div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="BF_MSGID" CssClass="GridViewStyle"
                AutoGenerateColumns="False" Width="100%" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="40" HeaderText="序号">
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_select" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="消息标题">
                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemTemplate>
                            <%#GetUrl(Eval("BF_MSGTITLE"), Eval("BF_MSGTEXT"), (int)Eval("BF_ISREAD")) %>
                        </ItemTemplate>
                        <ItemStyle Wrap="False" HorizontalAlign="Left" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发送人">
                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemTemplate>
                            <%#Eval("BF_SENDERNAME")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="BF_SENDTIME" HeaderText="接收日期" DataFormatString="{0:yyyy-MM-dd}">
                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="消息状态">
                        <ItemStyle HorizontalAlign="Center" Wrap="true" />
                        <ItemTemplate>
                            <%#GetStatus((string)Eval("BF_MSGID"), (int)Eval("BF_ISREAD"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="GridViewRowStyle" />
                <HeaderStyle CssClass="GridViewHeaderStyle" />
                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                <RowStyle CssClass="GridViewRowStyle" />
                <PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PageButtonCount="5"
                    PreviousPageText="上一页" />
                <PagerStyle CssClass="GridViewPagerStyle" />
            </asp:GridView>
        </div>
        <div>
            <asp:LinkButton ID="btn_selectall" runat="server" Text="全选" CssClass="easyui-linkbutton"
                plain="false" OnClick="btn_selectall_Click"></asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btn_cancelselect" runat="server" Text="取消全选" CssClass="easyui-linkbutton"
                plain="false" OnClick="btn_cancelselect_Click"></asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="btn_lock" runat="server" Text="删除" CssClass="easyui-linkbutton"
                plain="false" OnClick="btn_lock_Click" OnClientClick="return confirm('您确定要删除选中的消息吗?');"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
