<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProjectRegister5.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.ProjectRegister5"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title>立项申请 
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent"><%=Trans("首页") %></a></li>
                    <li>项目管理</li>
                    <li class="last">
                        <%=Trans("立项申请")%>
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
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("填写立项申请") %></span>
                <asp:HiddenField ID="Hid_CKID" runat="server" />
            </div>
            <ul>
                <li class="ssec-label">

                    <%=Trans("发起人员")%>：

                </li>
                <li>
                    <div>
                        <asp:Label ID="Lb_SUBMITTER" runat="server"></asp:Label>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("项目名称")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PROJNAME" runat="server" CssClass="easyui-validatebox large"
                            required="true" missingMessage="必填项" validType="length[0,250]" invalidMessage="不能超过250个字！" Width="310px"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("项目类型")%>：                    
                </li>
                <li>
                    <div>
                        <%--<asp:DropDownList ID="Ddl_KIND" runat="server">
                        <asp:ListItem Value="1">综合</asp:ListItem>
                        <asp:ListItem Value="2">物资</asp:ListItem>
                        <asp:ListItem Value="3">采购</asp:ListItem>        
                       </asp:DropDownList>--%>
                        <asp:RadioButtonList ID="Ddl_KIND" runat="server" RepeatDirection="Horizontal" >
                            <asp:ListItem Value="3"  Selected="True">工程</asp:ListItem>
                            <asp:ListItem Value="1" Enabled="false">综合</asp:ListItem>
                            <asp:ListItem Value="2" Enabled="false">物资</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </li>

            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("组织方式")%>：                    
                </li>
                <li>
                    <div>
                        招标：&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        谈判：
                        <asp:RadioButtonList ID="Rad_ZBFS" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">公开招标</asp:ListItem>
                            <asp:ListItem Value="2">邀请招标&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                &nbsp;&nbsp;
                            </asp:ListItem>
                            <asp:ListItem Value="3">竞争性谈判</asp:ListItem>
                            <asp:ListItem Value="4">独家谈判</asp:ListItem>
                            <asp:ListItem Value="5">网上询比价</asp:ListItem>
                            <asp:ListItem Value="6">竞标</asp:ListItem>
                            <asp:ListItem Value="7">竞价</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </li>

            </ul>


            <ul>
                <li class="ssec-label">
                    <%=Trans("资金来源")%>：                    
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="Ddl_ZJLY" runat="server">
                            <asp:ListItem Value="投资">投资</asp:ListItem>
                            <asp:ListItem Value="成本">成本</asp:ListItem>
                            <asp:ListItem Value="科研经费">科研经费</asp:ListItem>
                            <asp:ListItem Value="安保基金返还">安保基金返还</asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:TextBox ID="Txt_ZJBZ" runat="server" Width="200"></asp:TextBox>--%>
                    </div>
                </li>

            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("计划金额")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PROJINCOME" runat="server" CssClass="easyui-numberbox" min="0"
                            max="99999999" precision="4" invalidMessage="无效数字"  missingMessage="必选项"
                            Width="150px"></asp:TextBox>（万元）
                        <asp:DropDownList id="Ddl_ZJBZ" runat="server" ClientIDMode="Static" >
                            <asp:ListItem Value="" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="据实结算" ></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <%--<ul>
                <li class="ssec-label">

                    <%=Trans("拟开标时间")%>：

                </li>
                <li>
                    <div>
                         <asp:TextBox ID="Txt_NKBSJSTR" runat="server"></asp:TextBox>
                         </div>

                </li>
            </ul>--%>
            <ul>
                <li class="ssec-label">

                    <%=Trans("时间及地点")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_NKBDD" runat="server" CssClass="easyui-validatebox large" validType="length[0,100]" invalidMessage="不能超过100个字！" Width="510px"></asp:TextBox>
                    </div>

                </li>
            </ul>
            

            <ul>
                <li class="ssec-label">

                    <%=Trans("联系电话")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PHONE" runat="server" CssClass="easyui-validatebox large" validType="length[0,20]" invalidMessage="不能超过20个字！" Width="150px"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("审核人员")%>：
                    
                </li>
                <li>
                    <div>
                        <%--<uc1:UserSelectControl runat="server" ID="single_RcvUsers" Required="true" />--%>
                        <asp:DropDownList ID="Txt_SHR" runat="server" Required="true" CssClass="easyui-combobox" Width="153" data-options="editable:false"></asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("项目内容")%>：
                    
                </li>
                <li>

                    <asp:TextBox ID="Txt_PROJCONTENT" runat="server" CssClass="easyui-validatebox large" required="true"
                        missingMessage="必填项" validType="length[0,400]" invalidMessage="不能超过400个字！"
                        Width="510" Height="100" TextMode="MultiLine"></asp:TextBox>
                </li>
            </ul>
            <ul style="display:none">
                <li class="ssec-label">

                    <%=Trans("申请理由")%>：
                    
                </li>
                <li>

                    <asp:TextBox ID="Txt_SQLY" runat="server" CssClass="easyui-validatebox large"
                        missingMessage="必填项" validType="length[0,2000]" invalidMessage="不能超过250个字！"
                        Width="510" Height="100" TextMode="MultiLine"></asp:TextBox>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">选取服务商：
                </li>
                <li>
                    <div class="main-gridview">

                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" Width="100%" runat="server"
                            CssClass="GridViewStyle" OnRowDataBound="GridView1_RowDataBound" DataKeyNames="FID">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemStyle Width="40" />
                                    <ItemTemplate>
                                        <%#(int)Eval("STATUS")==-2?"新增":(Container.DataItemIndex + 1)+""%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="服务商" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="Ddl_WTDW" ClientIDMode="Static" runat="server" CssClass="easyui-combobox"
                                            Width="300px" data-options="panelWidth: 400,loader: myloader,mode: 'remote',valueField: 'id',textField: 'name',onSelect:sle,formatter: formatItem">
                                        </asp:DropDownList>
                                        <input type="hidden" id="HID_WTDW" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="T_MEMO" runat="server" Width="200"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#GetCommandBtn((string)Eval("FID")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                        <script>
                            var myloader = function (param, success, error) {
                                var hid = $("input[FID='" + $(this).attr("FID") + "']");
                                var DepId = hid.val();
                                var q = param.q || '';
                                var o = $(this);
                                //if (q.length <= 1) { return false }
                                $.ajax({
                                    url: '/Component/UserControl/Json/GetFws.ashx',
                                    dataType: 'json',
                                    mothod: 'post',
                                    //data: {
                                    //    //featureClass: "P",
                                    //    style: "full",
                                    //    maxRows: 20,
                                    //    name_startsWith: q
                                    //},
                                    data: { q: q },
                                    success: function (data) {

                                        //alert(DepId);
                                        var items = $.map(data, function (item) {
                                            //var distext = "【" + item.text1 + "】【" + item.text2 + "】";
                                            var distext = "【" + item.text2 + "】";
                                            return { id: item.id, name: item.text, text: distext };
                                        });    //执行loader的success方法 
                                        success(items);
                                        if (DepId != "") {
                                            o.combobox("setValue", DepId);
                                        }
                                    },
                                    error: function () {
                                        error.apply(this, arguments);
                                    }
                                });
                            }
                            function formatItem(row) {
                                var s = '<span style="font-weight:bold;">' + row.name + '</span>' +
                                        '<span style="color:#888">' + row.text + '</span>';
                                return s;
                            }
                            var sle = function (rec) {

                                var hid = $("input[FID='" + $(this).attr("FID") + "']");
                                hid.val(rec.id);
                            }
                        </script>
                    </div>
                </li>
            </ul>



            <ul>
                <li class="ssec-label">&nbsp;              
                </li>
                <li>
                    <asp:LinkButton ID="LinkButton2" type="submit" runat="server" OnClientClick="return checkInputForm1()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnNew_OnClick" iconCls="icon-add">新增服务商</asp:LinkButton>
                    <asp:LinkButton ID="BtnSave" type="submit" runat="server" OnClientClick="return checkInputForm1()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick" iconCls="icon-save">临时保存</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" type="submit" runat="server" OnClientClick="return checkInputForm()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnRecv_OnClick" iconCls="icon-ok">提交审核</asp:LinkButton>

                    <script type="text/javascript">
                        //function checkInputForm() {
                        //    var v = $('#form1').form('validate');
                        //    return v && confirm("您确定要提交吗?");
                        //}

                        function checkInputForm() {
                            var i1 = $('#Txt_PROJINCOME').val() == null || $('#Txt_PROJINCOME').val() == "";
                            var i2 = $('#Ddl_ZJBZ').val() == "" || $('#Ddl_ZJBZ').val() == null;
                            if (i1 && i2) {
                                $('#Txt_PROJINCOME').validatebox({ required: true });
                                //return false;
                            } else $('#Txt_PROJINCOME').validatebox({ required: false });
                            var v = $('#form1').form('validate');
                            return v && confirm("您确定要提交吗?");
                        }


                        function checkInputForm1() {
                            var i1 = $('#Txt_PROJINCOME').val() == null || $('#Txt_PROJINCOME').val() == "";
                            var i2 = $('#Ddl_ZJBZ').val() == "" || $('#Ddl_ZJBZ').val() == null;
                            //alert(i1 && i2);
                            //document.write(i1+" "+i2+"  ");
                            if (i1 && i2) {
                                $('#Txt_PROJINCOME').validatebox({ required: true });
                                //return false;
                            } else {
                                $('#Txt_PROJINCOME').validatebox({ required: false });
                            }
                            var v = $('#form1').form('validate');
                            return v;
                        }
                        window.onerror = function () {
                            return true;
                        }
                    </script>
                </li>
            </ul>

        </div>
    </div>

</asp:Content>
