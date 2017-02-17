<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="zjdf.aspx.cs" Inherits="Enterprise.UI.Web.Mobile.zjdf" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <!-- content start -->
    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">专家打分</strong> / <small>唱标顺序&nbsp;&nbsp;<span class="am-badge am-badge-warning"><%=fws.PX %></span></small></div>
        </div>

        <ul class="am-avg-sm-1 am-avg-md-1 am-margin am-padding am-text-left admin-content-list ">
            <li>
                <div class="admin-task-meta">公司简介</div>
                <div class="admin-task-bd">
                    <%=crm.CRMNAME %>
                </div>
            </li>
        </ul>

        <div class="am-g">
            <div class="am-u-sm-12">
                <table class="am-table am-table-bd am-table-striped admin-content-table">
                    <thead>
                        <tr>
                            <th nowrap>项目</th>
                            <th nowrap>评标分项</th>
                            <th nowrap>分值</th>
                            <th nowrap>评分标准</th>
                            <th nowrap>得分</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            int i = 0;
                            foreach (var m in pL)
                            {
                                i++;
                            
                        %>
                        <tr>

                            <td><%=m.XMMC %></td>
                            <td><%=m.PBFX%> </td>
                            <td><span class="am-badge am-badge-success"><%=m.FZ %></span></td>
                            <td><%=m.PFBZ %></td>
                            <td><input type="number" name="Txt_PF"  style="width:35px"   min="0" max="<%=m.FZ %>"
                                value="<%=m.PF %>" onblur="inspect(this);">
                                <input type="hidden" name="Hid_BZID" value="<%=m.BZID %>" />

                            </td>
                        </tr>
                        <%
                            }
                        %>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="am-margin">
            <asp:LinkButton ID="Btn_SAVE" runat="server" class="am-btn am-btn-primary am-btn-xs"  OnClick="Btn_SAVE_Click"  OnClientClick="$('#my-modal-loading').modal();">临时保存</asp:LinkButton>
            <asp:LinkButton ID="Btn_PRE" runat="server" class="am-btn am-btn-primary am-btn-xs" OnClick="Btn_PRE_Click"  OnClientClick="$('#my-modal-loading').modal();">转到上一家</asp:LinkButton>
            <asp:LinkButton ID="Btn_NEXT" runat="server" class="am-btn am-btn-primary am-btn-xs" OnClick="Btn_NEXT_Click"  OnClientClick="$('#my-modal-loading').modal();">转到下一家</asp:LinkButton>
<%--            <button type="button" class="am-btn am-btn-primary am-btn-xs">临时保存</button>
            <button type="button" class="am-btn am-btn-primary am-btn-xs">转到上一家</button>
            <button type="button" class="am-btn am-btn-primary am-btn-xs">转到下一家</button>--%>
          </div>
    </div>

    <!-- content end -->
    <script>
        function inspect(obj) {

            if (obj) {

                var value = parseInt(obj.value);

                if (value > obj.max) {

                    obj.value = obj.max;
                    //if (obj.setSelectionRange) {

                    //    obj.setSelectionRange(0, obj.value.length);

                    //    obj.focus();

                    //} else if (obj.createTextRange) {

                    //    var rng = obj.createTextRange();

                    //    rng.select();

                    //    obj.focus();

                    //}

                } else if (value < obj.min) {
                    obj.value = obj.min;
                }

            }

        }


        //function checkInputForm1() {
        //    var v = $('#form1').form('validate');
        //    return v;
        //}
        //var checkvalue = function (e) {

        //    var el = e.target;

        //    var isvalid = el.checkValidity();

        //    if (isvalid) {

        //        el.className = "";

        //        el.parentElement.getElementsByTagName("input")[0].className = "";

        //    } else {

        //        el.className = "error";

        //        el.parentElement.getElementsByTagName("input")[0].className = "error";

        //    }

        //    e.stopPropagation();

        //    e.preventDefault();

        //}

        ////定义表单验证方法

        //function invalidHandler(evt) {

        //    checkvalue(evt);

        //}

        //function loadDemo() {

        //    var myform = document.getElementById("form1");

        //    //注册表单的oninvlid事件

        //    myform.addEventListener("invalid", invalidHandler, true);

        //    for (var i = 0; i < myform.elements.length - 1; i++) {

        //        //注册表单元素的onchange事件，优化用户体验

        //        myform.elements[i].addEventListener("change", checkvalue, false);

        //    }

        //}

        ////在页面初始化事件（onload）时注册的自定义事件

        //window.addEventListener("load", loadDemo, false);
        </script>
</asp:Content>
