<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SuperviseProcessDetailsManage.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Common.Supervise.SuperviseProcessDetailsManage" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Resources/Styles/css/ssec-form.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first">
                        <a href="/">首页</a>
                    </li>
                    <li class="last">事务督办
                    </li>
                </ul>
            </div>
        </div>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
                <Ent:HeadMenuButtonItem ButtonIcon="back.gif" ButtonName="返回" ButtonUrl="SuperviseIndex.aspx"
                    ButtonPopedom="List" ButtonUrlType="Href" />
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <%--end--%>
    <div data-options="region:'center'">

        <div style="padding: 10px; font-size: 14px;">
            <p><span><%=Trans("事务标题")%>：</span><%=InfoModel.DBBT %></p>
            <p><span><%=Trans("事务内容")%>：</span><%=InfoModel.DBNR %></p>
        </div>

        <div class="main-gridview">
            <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" OnRowDataBound="gv_RowDataBound" Width="100%" OnSelectedIndexChanged="gv_SelectedIndexChanged" DataKeyNames="DBID,BLRID,YQSBSJ">
                <Columns>
                    <asp:BoundField DataField="BLRID" HeaderText="负责人">
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="YQSBSJ" HeaderText="要求上报时间">
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="DQJD" HeaderText="当前进度%">
                        <ItemStyle Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="BZ" HeaderText="备注" ItemStyle-HorizontalAlign="Left" HtmlEncode="False">
                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                    </asp:BoundField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Select" Text="修改" CssClass="easyui-linkbutton" iconCls="icon-edit"></asp:LinkButton>
                        </ItemTemplate>
                        <ControlStyle CssClass="easyui-linkbutton" />
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="DBID" HeaderText="督办ID" Visible="False" />
                </Columns>
                <SelectedRowStyle BackColor="#BEF5FA" />
            </asp:GridView>
        </div>

        <table class="ssec-table" cellpadding="10" runat="server" id="edittable" visible="false">
            <tr>
                <td>进度%</td>
                <td style="height: 80px;">
                    <asp:HiddenField ID="ff" runat="server" ClientIDMode="Static" />
                    <div style="padding: 10px;">
                        <div id="ss" style="padding: 20px;"></div>
                    </div>
                </td>
            </tr>
            <tr>
                <td>说明</td>
                <td>
                    <uc1:EHtmlEditor runat="server" ID="tb_bz" Tools="full" Width="650" Height="200" Required="true" invalidMessage="说明是必填项" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:LinkButton ID="LBtn_Save" runat="server" Text="保存" CssClass="easyui-linkbutton" OnClick="LBtn_Save_Click" OnClientClick="return checkInputForm();"></asp:LinkButton></td>
            </tr>
        </table>
    </div>
    <script type="text/javascript">
        function checkInputForm() {
            var v = $('#form1').form('validate') && EHtmlEditor('<%=tb_bz.HtmlId%>').validate();
            return v && confirm("您确定要提交吗?");
        }
        window.onerror = function () {
            return true;
        }
    </script>
    <script type="text/javascript">
        $(function () {
            $('#ss').slider({
                mode: 'h',
                value: $('#ff').val(),
                showTip: true,
                rule: [0, '|', 25, '|', 50, '|', 75, '|', 100],
                tipFormatter: function (value) {
                    return value + '%';
                },
                onChange: function (value) {
                    $('#ff').attr('value', value);
                }
            });
        });
    </script>
</asp:Content>
