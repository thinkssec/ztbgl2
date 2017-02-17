<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="VisitLogList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Basis.VisitLog.VisitLogList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx" title="首页">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li class="last">
                        <%=Trans("访问日志") %>
                    </li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
                <Ent:HeadMenuButtonItem ButtonName="访问日志" ButtonPopedom="List" ButtonUrl="VisitLogList.aspx"
                    ButtonUrlType="Href" />
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <div class="main-gridview">
            <div class="main-gridview-title">
            </div>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="VLID" AutoGenerateColumns="false"
                Width="100%" AllowPaging="false">
                <Columns>
                    <asp:TemplateField HeaderText="序号" ItemStyle-Width="30">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人员">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName((int)Eval("VLLOGINUSERID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="访问时间" DataField="VLLOGINTIME" />
                    <asp:BoundField HeaderText="访问ip地址" DataField="VLLOGINIP" />
                    <asp:BoundField HeaderText="Url地址" DataField="VLURL" ItemStyle-HorizontalAlign="Left" />
                </Columns>
            </asp:GridView>
            <%--<PagerSettings FirstPageText="首页" LastPageText="末页" NextPageText="下一页" PageButtonCount="5"
                    PreviousPageText="上一页" />--%>
            <Webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" PagingButtonSpacing="8px" OnPageChanged="AspNetPager1_PageChanged"
                ShowPageIndexBox="Always" SubmitButtonImageUrl="/Resources/OA/site_skin/images/go.jpg" ShowCustomInfoSection="Left" CustomInfoHTML="共%PageCount%页，共%RecordCount%条记录，每页%PageSize%条记录"
                SubmitButtonStyle="width:32px;height:22px;vertical-align:bottom" CustomInfoTextAlign="Left" UrlPaging="True" Width="100%" LayoutType="Table" ShowNavigationToolTip="true" UrlPageIndexName="pageindex">
            </Webdiyer:AspNetPager>
        </div>
    </div>
</asp:Content>
