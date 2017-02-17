<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="zjdf2.aspx.cs" 
    Inherits="Enterprise.UI.Web.Mobile.zjdf2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <!-- content start -->
    <div class="admin-content">
        <div class="am-margin" data-am-sticky>
            <asp:LinkButton ID="Btn_SAVE" runat="server" class="am-btn am-btn-primary am-btn-xs"  OnClick="Btn_SAVE_Click" OnClientClick="$('#my-modal-loading').modal();">保存</asp:LinkButton>

          </div>
        <%--<div class="am-cf am-padding">
            <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">专家打分</strong> / <small>唱标顺序&nbsp;&nbsp;<span class="am-badge am-badge-warning"><%=fws.PX %></span></small></div>
        </div>--%>
        <ul class="am-avg-sm-1 am-avg-md-1 am-margin am-padding am-text-left admin-content-list " 
            <%--style="background-color:#ffd800" --%> <%--data-am-sticky--%> >
            <li>
                <%
                    string[] abc = new string []{ "A","B","C","D","E","F","G","H","I"};
                    int i = 0;
                                foreach (var fws in fwsL) { 
                                %>
                                <%--<div class="admin-task-meta"><%=abc[i] %></div>--%>
                                <div class="admin-task-bd">
                                    <%=abc[i] %>：<%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName(fws.CRMINFO) %>
                                </div>

                            <%
                                    i++;
                                }    
                                 %>
            </li>
        </ul>
        <div class="am-g">
            <div class="am-u-sm-12">
                <table class="am-table am-table-bd am-table-striped admin-content-table">
                    <thead>
                        <tr >
                            <th nowrap>项目</th>
                            <th nowrap>评标分项</th>
                            <th nowrap>分值</th>
                            <th nowrap>评分标准</th>
                            <%
                                for (int j = 0; j < i;j++ )
                                { 
                                %>
                                <th nowrap><%=abc[j] %></th>

                            <%
                                }    
                                 %>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            i = 0;
                            foreach (var m in pfbzL)
                            {
                                
                            
                        %>
                        <tr>

                            <td><pre><%=m.XMMC %></pre></td>
                            <td><pre><%=m.PBFX%> </pre></td>
                            <td><pre><%=m.PFBZ %></pre></td>
                            <td><span class="am-badge am-badge-success"><%=m.FZ %></span></td>
                            <%
                                
                                foreach (var fws in fwsL) {
                                    if (dic1.ContainsKey(fws.CRMINFO)) {
                                        Enterprise.Model.App.Project.ProjectZjpfModel zjpfM = dic1[fws.CRMINFO][i];
                                        %>
                                    <td><input type="number" name="Txt_PF"  style="width:35px"   min="0" max="<%=m.FZ %>"
                                        value="<%=zjpfM.PF %>" onblur="inspect(this);">
                                        <input type="hidden" name="Hid_BZID" value="<%=m.BZID+"*"+fws.CRMINFO %>" />
                                    </td>
                            <%
                                    }
                                %>
                            
                            <%
                                }
                                 %>


                        </tr>
                        <%
                                i++;
                            }
                        %>
                    </tbody>
                </table>
            </div>

            <div class="am-u-sm-12">
                <div class="am-panel am-panel-default">
                    <div class="am-panel-hd am-cf" data-am-collapse="{target: '#collapse-panel-1'}">项目简介<span class="am-icon-chevron-down am-fr"></span></div>
                    <div id="collapse-panel-1" class="am-panel-bd am-collapse am-in">
                        <ul class="am-list admin-content-task">

                            <li>
                                <div class="admin-task-meta">招标文件编号</div>
                                <div class="admin-task-bd">
                                    <%=project.PROJNUMBER %>
                                </div>

                            </li>
                            <li>
                                <div class="admin-task-meta">资金来源</div>
                                <div class="admin-task-bd">
                                    <%=project.ZJLY %>
                                </div>

                            </li>
                            <li>
                                <div class="admin-task-meta">计划金额</div>
                                <div class="admin-task-bd">
                                    <%=project.PROJINCOME %>
                                </div>

                            </li>
                            <li>
                                <div class="admin-task-meta">经办人</div>
                                <div class="admin-task-bd">
                                    <%=Enterprise.Service.Basis.Sys.SysUserService.GetUserName(project.SUBMITTER.Value) %>
                                </div>

                            </li>
                            <li>
                                <div class="admin-task-meta">项目内容</div>
                                <div class="admin-task-bd">
                                    <%=project.PROJCONTENT %>
                                </div>

                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="am-margin" data-am-sticky>
            <asp:LinkButton ID="Btn_SAVE" runat="server" class="am-btn am-btn-primary am-btn-xs"  OnClick="Btn_SAVE_Click" OnClientClick="$('#my-modal-loading').modal();">保存</asp:LinkButton>

          </div>--%>
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
