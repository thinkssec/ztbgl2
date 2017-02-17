<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HseSectRecv.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Hse.HseSectRecv"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript" src="/Resources/OA/bootstrap/js/bootstrap.min.js"></script>--%>
    <link href="/Resources/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Resources/uploadify/jquery.uploadify.min.js"></script>
    <script type="text/javascript">
        $(function () {
            jQuery.ajaxSetup({ cache: false })
            //上传PDF附件

            
        });
        function doRender(pid) {
            $('#' + pid).uploadify({
                'buttonText': '请选择文件',
                'swf': '../../../Resources/uploadify/uploadify.swf',
                'uploader': '../../../Resources/uploadify/uploadify.ashx',
                'cancelImg': '../../../Resources/uploadify/cancel.png',
                'removeCompleted': true,
                'hideButton': true,
                'auto': true,
                'multi': true,
                'queueID': 'upload-queue',
                'fileTypeDesc': 'Pic Files',
                'fileSizeLimit': '50000KB',
                'fileTypeExts': '*.jpg;*.gif;*.bmp;*.jpeg;*.png',
                'onUploadError': function (file, errorCode, errorMsg, errorString) {
                    $.messager.alert(errorCode, errorMsg, 'error');
                },
                'onQueueComplete': function (queueData) {
                    if (queueData.uploadsSuccessful > 0) {
                        $.messager.alert('Success', '上传文件成功!', 'info');
                    }
                },
                'onUploadSuccess': function (file, data, response) {
                    var dddd = $("img[ckdid='" + pid + "']");
                    dddd.attr("src", data);
                    var eeee = $("input[ckdid='" + pid + "']");
                    eeee.val(data);
                    //document.getElementById('Img_Key1').src = data;
                    //$("#Hid_ZSYYJ").val(data);
                }
            });
        }
    </script>
    <title>发布公文  
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx">
                        <%=Trans("首页")%></a> </li>
                    <li>HSE管理</li>
                    <li class="last">
                        <%=Trans("安全隐患整改上报")%>
                    </li>
                </ul>
            </div>
        </div>

        <%--<div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>--%>

    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("上报") %></span>
                <asp:HiddenField ID="Hid_CKID" runat="server" />
            </div>
            <ul>
                <li class="ssec-label">
                    <%=Trans("受检单位")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_TARGET" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("检查级别")%>：                    
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="Ddl_LEVEL" runat="server"  Enabled="false">
                        <asp:ListItem Value="">全部</asp:ListItem>
                        <asp:ListItem Value="油田级">油田级</asp:ListItem>
                        <asp:ListItem Value="鲁明">鲁明</asp:ListItem>
                        <asp:ListItem Value="富林">富林</asp:ListItem>
                        <asp:ListItem Value="地方">地方</asp:ListItem>         
                       </asp:DropDownList>
                    </div>
                </li>

            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("安全检查人员")%>：                    
                </li>
                <li>
                    <div>
                        <asp:Label runat="server" ID="muti_RcvUsers" Enabled="false"></asp:Label>
                        
                        <%--<uc1:UserSelectControl runat="server" ID="single_RcvUsers" Required="true" />--%>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("隐患接受人员")%>：
                    
                </li>
                <li>
                    <div>
                        <uc1:UserSelectControl runat="server" ID="single_RcvUsers" Enabled="false"/>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("检查日期")%>：(<span style="color: red; font-weight: bold;">*</span>)

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_CDATE" runat="server" CssClass="easyui-datebox" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li  class="ssec-label">
                    安全问题记录：
                </li>
                <li >
                    <div class="main-gridview">
                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" Width="100%" runat="server"
                            CssClass="GridViewStyle"  OnRowDataBound="GridView1_RowDataBound" DataKeyNames="CKDID" >
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemStyle Width="60" />
                                    <ItemTemplate>
                                        <%#(int)Eval("STATUS")==-2?"新增记录":(Container.DataItemIndex + 1)+""%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                        
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="检查地点" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#Eval("CWHERE") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="查出问题" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle Width="100" />
                                    <ItemTemplate>
                                        <%#Eval("DETAIL") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="责任人" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                         <%#Eval("CHARGE") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                         <%#Eval("MEMO") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="完成时间">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Txt_COMPLETEDATE" runat="server" CssClass="easyui-datebox" editable="true" Width="90"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="整改情况" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Txt_PRESENT" runat="server" Width="100" Height="100" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="整改反馈照片">
                                    <ItemTemplate>
                                       <asp:Image ID="Img_Key1" runat="server" ClientIDMode="Static" Width="100" Height="60"/>
                                       <asp:Label ID="Lb_Btn" runat="server" ></asp:Label>
                                        <input type="hidden" id="Hid_Key1" runat="server" name="Hid_Key1" name1="Hid_Key1"/>
                                       <%-- <asp:HiddenField ID="Hid_Key1" runat="server" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:BoundField DataField="CWHERE" HeaderText="检查地点" />
                                <asp:BoundField DataField="DETAIL" HeaderText="查出问题"  />
                                <asp:BoundField DataField="CHARGE" HeaderText="责任人" />
                                <asp:BoundField DataField="MEMO" HeaderText="备注" />--%>
                            </Columns>

                        </asp:GridView>
                    </div>

                 </li>
            </ul>
            <ul >
                <li class="ssec-label">

                    <%=Trans("限定完成日期")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_ENDDATE" runat="server" CssClass="easyui-datebox" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <%--<ul>
                <li class="ssec-label">

                    <%=Trans("内容")%>：
                    
                </li>
                <li>
                    <uc1:EHtmlEditor runat="server" ID="t_Content" Tools="full" Width="630" Height="320" Required="true" invalidMessage="内容是必填项" />
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("签收人员")%>：
                    
                </li>
                <li>
                    <div>
                        <uc1:UserSelectControl runat="server" ID="single_RcvUsers" Required="true" />
                    </div>
                </li>
            </ul>--%>
            <ul>
                <li class="ssec-label">
                    <%=Trans("附件")%>：                   
                </li>
                <li>
                    <%--<uc1:PopWinUploadMuti runat="server" ID="tb_AFVIewNames" Ext="Office" Required="false" />--%>
                    <asp:Label runat="server" ID="tb_AFVIewNames"></asp:Label>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("验收考核-单位负责人")%>：
                    
                </li>
                <li>
                    <div>
                        <uc1:UserSelectControl runat="server" ID="User_SHR1"/>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("验收考核-单位安全员")%>：
                    
                </li>
                <li>
                    <div>
                        <uc1:UserSelectControl runat="server" ID="User_SHR2"/>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">&nbsp;              
                </li>
                <li>
                    <asp:LinkButton ID="BtnSave" type="submit" runat="server" OnClientClick="return checkInputForm1();"
                        CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick" iconCls="icon-save">保存</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnAudit_OnClick" iconCls="icon-ok">提交审核</asp:LinkButton>

                    <script>
                        <%--function checkInputForm() {
                           
                           var v = $('#form1').form('validate');
                           var sss = EHtmlEditor('<%=t_Content.HtmlId%>').validate();
                           
                           return v&&sss;
                       }--%>
                    </script>

                    <script type="text/javascript">
                        function checkInputForm() {
                            var aryyy = $("input[name1='Hid_Key1']");
                            //var eeee = $("input[ckdid='" + pid + "']");

                            $.each(aryyy, function (i, n) {
                                var img = $("img[ckdid='" + $(n).attr('ckdid') + "']");
                                n.value = img[0].src;
                            });
                            var v = $('#form1').form('validate');
                            return v && confirm("您确定要提交吗?");
                        }
                        function checkInputForm1() {
                            var aryyy = $("input[name1='Hid_Key1']");
                            //var eeee = $("input[ckdid='" + pid + "']");

                            $.each(aryyy, function (i, n) {
                                var img = $("img[ckdid='" + $(n).attr('ckdid') + "']");
                                n.value = img[0].src;
                            });
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
