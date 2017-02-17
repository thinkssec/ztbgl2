<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" 
    MasterPageFile="~/Blank.Master" CodeBehind="UIIndexTabSet.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Ui.UIIndexTabSet" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        .uiIndexTabSet ul {
        }

        .uiIndexTabSet li {
            list-style: none;
            float: left;
            overflow: hidden;
            text-align: left;
            line-height: 23px;
            padding: 0;
            padding-top: 2px;
            padding-bottom: 2px;
        }
    </style>
    <script type="text/javascript">
        //添加选项到我的图表列表内
        function chartInsert() {
            var optLst = $("#MainPH_SelChart").find("option:selected");
            $.each(optLst, function (i, opt) {
                //在SelMyChart中查找是否已存在，如果不存在才能添加
                var isExist = false;
                var myOptLst = $("#MainPH_SelMyChart option");
                $.each(myOptLst, function (j, myOpt) {
                    if (myOpt.value == opt.value) {
                        isExist = true;
                    }
                });
                if (!isExist) {
                    $("#MainPH_SelMyChart").append("<option value='" + opt.value + "'>" + opt.text + "</option>"); //添加一项option
                }
            });
        }
        //移除我的图表列表内的选项
        function chartRemove() {
            var optLst = $("#MainPH_SelMyChart").find("option:selected");
            $.each(optLst, function (i, opt) {
                $("#MainPH_SelMyChart option[value='" + opt.value + "']").remove();
            });
        }
        //调整图表顺序--上升
        function chartUp() {
            var myOptLst = $("#MainPH_SelMyChart option");
            $.each(myOptLst, function (j, myOpt) {
                if (myOpt.selected && j > 0) {
                    //和上一个元素互换
                    var prevOpt = myOptLst[j - 1];
                    var t = prevOpt.text;
                    var v = prevOpt.value;
                    prevOpt.text = myOpt.text;
                    prevOpt.value = myOpt.value;
                    myOpt.text = t;
                    myOpt.value = v;
                    $("#MainPH_SelMyChart option[value='" + prevOpt.value + "']").attr("selected", true);
                    return;
                }
            });
        }
        //调整图表顺序--下降
        function chartDown() {
            var myOptLst = $("#MainPH_SelMyChart option");
            $.each(myOptLst, function (j, myOpt) {
                if (myOpt.selected && j < myOptLst.length - 1) {
                    //和上一个元素互换
                    var nextOpt = myOptLst[j + 1];
                    var t = nextOpt.text;
                    var v = nextOpt.value;
                    nextOpt.text = myOpt.text;
                    nextOpt.value = myOpt.value;
                    myOpt.text = t;
                    myOpt.value = v;
                    //$("#MainPH_SelMyChart option[value='" + nextOpt.value + "']").attr("selected", true);
                    return;
                }
            });
        }
        //保存用户图表设置
        function SaveUserCharts() {
            var userChartIndexs = "";
            var optLst = $("#MainPH_SelMyChart option");
            $.each(optLst, function (i, opt) {
                userChartIndexs += opt.value + ",";
            });
            if (userChartIndexs == "")
                return false;
            alert("len==" + optLst.length + "==" + userChartIndexs);
            $("#MainPH_Hid_SelectTab").val(userChartIndexs);
            return true;
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainPH" runat="server">
    <div id="contents" class="ssec-form">
        <div class="ssec-group ssec-group-hasicon">
            <div class="icon-form"></div>
            <span>选择您要在首页显示的Tab标签</span>
        </div>
        <div>
            <table border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <asp:ListBox ID="SelChart" Width="180" Height="170" SelectionMode="Multiple" runat="server"></asp:ListBox>
                    </td>
                    <td>
                        <input id="BtnChartAdd" type="button" value=">>" onclick="chartInsert();" />
                        <input id="BtnChartDel" type="button" value="<<" onclick="chartRemove();" />
                    </td>
                    <td>
                        <asp:ListBox ID="SelMyChart" Width="180" Height="170" SelectionMode="Single" runat="server"></asp:ListBox>
                    </td>
                    <td>
                        <input id="BtnChartUp" type="button" value="↑" onclick="chartUp();" />
                        <input id="BtnChartDown" type="button" value="↓" onclick="chartDown();" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:HiddenField ID="Hid_SelectTab" runat="server" />
                        <asp:Button ID="btn_save" Text="保存" runat="server" CssClass="button2" OnClientClick="return SaveUserCharts();" OnClick="btn_save_Click" />&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

