<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SuperviseEdit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Common.Supervise.SuperviseEdit"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/Resources/Styles/css/ssec-form.css" />
    <script type="text/javascript">
        function add_dbsj() {
            //t_sj
            var t = $('#t_sj').datebox('getValue');
            if (t != "") {
                var l = $("#ddl_dbsj option[value='" + t + "']").length;
                if (l == 0) {
                    $("#ddl_dbsj").append("<option value='" + t + "' selected='selected'>" + t + "</option>");
                }
            }
            var maxIndex = $("#ddl_dbsj option:last").attr("index");
            $("#ddl_dbsj ").val(t);
            load_db();
        }

        function load_db() {
            var t = $("select[id=ddl_dbsj] option").length;
            $('#db').html(" ( " + t + "  ) "); //显示选中了几个督办点
            set_dbsj_value();
        }

        function delete_dbsj() {
            var val = $("#ddl_dbsj option:selected").attr("value");
            $("#ddl_dbsj option[value='" + val + "']").remove();
            load_db();
        }

        function set_dbsj_value() {
            var t = $("select[id=ddl_dbsj] option").length;
            //设置督办时间点的隐藏域值 用逗号将所有时间点分隔 以便后台通过request.form获取
            var val = "";
            for (var i = 0; i < t; i++) {
                val += $("#ddl_dbsj").get(0).options[i].text + ",";
            }
            $('#db_dbsj_value').attr("value", val);
            //alert(val);
        }

        function getValues1() {
            //获取所有选中的节点的子节点
            var t = $('#db_users').combotree('tree');
            var node = t.tree('getChecked');
            if (node) {
                var children = t.tree('getChecked', node.target);
            } else {
                var children = t.tree('getChecked');
            }
            var s = '';
            for (var i = 0; i < children.length; i++) {
                var v = children[i].id.toString();
                if (v.indexOf("d-") < 0) {
                    s += children[i].id + ',';
                }
            }
            $('#db_users_value').attr('value', s);
            //开发时请注释alert
            //alert('选中的人员id:'+s);
            return s;
        }

        function getValues2() {
            var s = $('#db_lingdao').combotree('getValue');
            return s;
        }

        $(function () {
            //alert($('#db_users_value').val());
            //alert($('#db_users_value').val());
            load_db();
            $('#db_users').combotree({
                checkbox: true,
                multiple: true,
                required: true,
                width: 350,
                url: '/Modules/Basis/User/UserJson.aspx?selected=' + $('#db_users_value').val(),
                onChange: function (rec) {
                    $('#db_users_value').attr("value", getValues1());
                }

            });
            $('#db_lingdao').combotree({
                checkbox: true,
                multiple: false,
                width: 350,
                url: '/Modules/Basis/User/UserJson.aspx?selected=' + $('#db_lingdao_value').val(),
                onChange: function (rec) {
                    $('#db_lingdao_value').attr("value", getValues2());
                }

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx" title="首页">
                        <%=Trans("首页")%></a> </li>
                    <li class="last">
                        <%=Trans("事务督办")%>
                    </li>
                </ul>
            </div>
        </div>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <%--自定义按钮--%>
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <%--end--%>
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <asp:HiddenField ID="h_id" runat="server" />
            <table id="ssec-table" class="ssec-table" style="width: 100%;">
                <tr>
                    <td>
                        <%=Trans("标题") %>
                        <span style="color: red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="t_bt" runat="server" Width="500" CssClass="easyui-validatebox" required="true" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Trans("督办编号")%>
                    </td>
                    <td>
                        <asp:TextBox ID="t_dbbh" runat="server" MaxLength="25"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Trans("督办时间")%>
                        <span style="color: red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="t_dbsj" runat="server" CssClass="easyui-datebox" editable="false" required="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Trans("内容") %>
                        <span style="color: red">*</span>
                    </td>
                    <td style="vertical-align: top">
                        <uc1:EHtmlEditor runat="server" ID="t_Content" Tools="full" Width="650" Height="300" Required="true" invalidMessage="督办内容是必填项" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Trans("要求完成时间") %>
                        <span style="color: red">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="t_yqwcsj" runat="server" CssClass="easyui-datebox" editable="false" required="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Trans("督办时间点") %><span id="db" style="color: red"></span>
                    </td>
                    <td>
                        <asp:TextBox ID="t_sj" runat="server" CssClass="easyui-datebox" editable="false" ClientIDMode="Static"></asp:TextBox>&nbsp;&nbsp;
                    <a href="#" onclick="add_dbsj();" class="easyui-linkbutton" iconcls="icon-add">添加</a>&nbsp;&nbsp;
                    时间点：<asp:DropDownList ID="ddl_dbsj" runat="server" ClientIDMode="Static">
                    </asp:DropDownList>
                        &nbsp;&nbsp; <a href="#" onclick="delete_dbsj();" class="easyui-linkbutton" iconcls="icon-cancel">删除</a>&nbsp;&nbsp;
                    <asp:HiddenField ID="db_dbsj_value" runat="server" ClientIDMode="Static" />
                    </td>
                </tr>
                <tr id="ulQs" runat="server">
                    <td>
                        <div class="ssec-label">
                            <%=Trans("负责部门或人员")%>：
                        </div>
                    </td>
                    <td>
                        <asp:HiddenField ID="db_users_value" runat="server" ClientIDMode="Static" />
                        <asp:DropDownList ID="db_users" runat="server" class="easyui-combotree" ClientIDMode="Static">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%=Trans("负责领导") %>
                    </td>
                    <td>
                        <asp:HiddenField ID="db_lingdao_value" runat="server" ClientIDMode="Static" />
                        <asp:DropDownList ID="db_lingdao" runat="server" class="easyui-combotree" ClientIDMode="Static">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div style="padding-top: 5px;">
            <asp:LinkButton ID="Btn_Save" runat="server" CssClass="easyui-linkbutton" iconcls="icon-save"
                Text="保存" OnClientClick="return checkInputForm();"
                OnClick="Btn_Save_Click"></asp:LinkButton>
        </div>
    </div>
    <script type="text/javascript">
        //var hh = $(window).height();
        //$("#ssec-table").height(hh - 380);
        function checkInputForm() {
            var v = $('#form1').form('validate') && EHtmlEditor('<%=t_Content.HtmlId%>').validate();
            return v && confirm("您确定要提交吗?");
        }
        window.onerror = function () {
            return true;
        }
    </script>
</asp:Content>
