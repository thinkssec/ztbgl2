<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
    CodeBehind="ZyglWgysEdit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Zygl.ZyglWgysEdit"
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
                'fileTypeExts': '*.*',
                'onUploadError': function (file, errorCode, errorMsg, errorString) {
                    $.messager.alert(errorCode, errorMsg, 'error');
                },
                'onQueueComplete': function (queueData) {
                    if (queueData.uploadsSuccessful > 0) {
                        $.messager.alert('Success', '上传文件成功!', 'info');
                    }
                },
                'onUploadSuccess': function (file, data, response) {
                    var dddd = $("span[ckdid='" + pid + "']");
                    var gggg = $("a[ckdid='" + pid + "FJ']");
                    dddd.html(file.name);
                    
                    gggg.attr("href",data);
                    var eeee = $("input[ckdid='" + pid + "']");
                    var ffff = $("input[ckdid='" + pid + "FJMC']");
                    eeee.val(data);
                    ffff.val(file.name);
                    //document.getElementById('Img_Key1').src = data;
                    //$("#Hid_ZSYYJ").val(data);
                }
            });
        }
    </script>
    <title>完工验收  
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx">
                        <%=Trans("首页")%></a> </li>
                    <li>作业管理</li>
                    <li class="last">
                        <%=Trans("完工验收")%>
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
                <span>作业信息</span>
            </div>
            <ul>
                <li class="ssec-label">
                    <asp:HiddenField ID="Hid_CKID" runat="server" />
                    <asp:HiddenField ID="Hid_ZID" runat="server" />
                    <%=Trans("井号")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_JH" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("施工内容")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_SGNR" runat="server" Enabled="false"></asp:TextBox>
                    </div>
                </li>

            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("实际开工日期")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_STARTDATE" runat="server" CssClass="easyui-datebox" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("计划完成日期")%>：
                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PENDDATE" runat="server" CssClass="easyui-datebox" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("实际完工日期")%>：(<span style="color: red; font-weight: bold;">*</span>)

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_ENDDATE" runat="server" CssClass="easyui-datebox" ></asp:TextBox>
                    </div>

                </li>
            </ul>
            
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("施工单位")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_SGDW" runat="server"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("施工现场描述")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_SGXCMS" runat="server" Width="400" Height="100" TextMode="MultiLine"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>总计</span>
            </div>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("预计费用总计")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_YJFYZJ" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("其中") %></span>
            </div>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("劳务费")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_LWF" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("井下材料") %></span>
            </div>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("油管")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_YG" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("抽油杆")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_CYG" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("泵")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_BENG" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("封隔器")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_FGQ" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("其它")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_QT" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>其它</span>
            </div>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("射孔费")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_SKF" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("测压费")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_CYF" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("化工料")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_HGL" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("找水费")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_ZSF" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">
                    
                    <%=Trans("技术服务")%>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_JSFW" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4"></asp:TextBox>
                    </div>

                </li>
            </ul>
             <ul>
                <li class="ssec-label">
                    <%=Trans("附件")%>：                   
                </li>
                <li>
                    <uc1:PopWinUploadMuti runat="server" ID="tb_AFVIewNames" Ext="Office" Required="false" />
                   <%-- <asp:Label runat="server" ID="tb_AFVIewNames"></asp:Label>--%>
                </li>
            </ul>
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>其他专项费用：</span>
            </div>
            <ul>

                <li >
                    <div class="main-gridview">
                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" Width="100%" runat="server"
                            CssClass="GridViewStyle"  OnRowDataBound="GridView1_RowDataBound" DataKeyNames="QID" >
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemStyle Width="60" />
                                    <ItemTemplate>
                                        <%#(int)Eval("STATUS")==-2?"新增费用":(Container.DataItemIndex + 1)+""%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                        
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="费用名称" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                       <asp:DropDownList ID="MC" runat="server">
                                           <asp:ListItem Value="专项测试费用">专项测试费用</asp:ListItem>
                                           <asp:ListItem Value="长效费用">长效费用</asp:ListItem>
                                           <asp:ListItem Value="防偏磨费用">防偏磨费用</asp:ListItem>
                                           <asp:ListItem Value="其他">其他</asp:ListItem>
                                       </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="金额" ItemStyle-HorizontalAlign="Left">
                                    <ItemStyle Width="100" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="Txt_JE" runat="server" CssClass="easyui-numberbox" Width="150"  min="0" percision="4"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="Txt_BZ" runat="server" Width="100"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="附件">
                                    <ItemTemplate>
                                        <%--<asp:Label ID="Lb_Key1" runat="server" ClientIDMode="Static"/>
                                        <asp:Label ID="Lb_Key2" runat="server" ClientIDMode="Static" Visible="false"/>--%>
                                        <a id="Lb_Key2" runat="server" target="_blank"><asp:Label ID="Lb_Key1" runat="server" ClientIDMode="Static"/></a>
                                        <asp:Label ID="Lb_Btn" runat="server" ></asp:Label>
                                        <input type="hidden" id="Hid_Key1" runat="server" name="Hid_Key1" name1="Hid_Key1"/>
                                        <input type="hidden" id="Hid_Key2" runat="server" name="Hid_Key2" name1="Hid_Key2"/>

                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <%#(int)Eval("STATUS")==-2?"":GetCommandBtn((String)Eval("QID")) %>
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
           
            <%--<ul>
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
            </ul>--%>
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
                            var aryyy2 = $("input[name1='Hid_Key2']");
                            //var eeee = $("input[ckdid='" + pid + "']");

                            $.each(aryyy, function (i, n) {
                                var img = $("a[ckdid='" + $(n).attr('ckdid') + "FJ']");
                                //alert(img[0].href);
                                if (img[0])
                                    n.value = img[0].href;
                                //alert(n.value);
                            });

                            $.each(aryyy2, function (i, n) {
                                var img = $("span[ckdid='" + $(n).attr('ckdid').replace('FJMC', '') + "']");
                                //alert(img[0] + "  " + $(n).attr('ckdid').replace('FJMC', ''));
                                if (img[0])
                                    n.value = img[0].innerHTML;
                                //alert(n.value);
                            });
                            var v = $('#form1').form('validate');
                            return v && confirm("您确定要提交吗?");
                        }
                        function checkInputForm1() {
                            var aryyy = $("input[name1='Hid_Key1']");
                            var aryyy2 = $("input[name1='Hid_Key2']");
                            //var eeee = $("input[ckdid='" + pid + "']");

                            $.each(aryyy, function (i, n) {
                                var img = $("a[ckdid='" + $(n).attr('ckdid') + "FJ']");
                                //alert(img[0].href);
                                if(img[0])
                                    n.value = img[0].href;
                                //alert(n.value);
                            });

                            $.each(aryyy2, function (i, n) {
                                var img = $("span[ckdid='" + $(n).attr('ckdid').replace('FJMC','') + "']");
                                //alert(img[0] + "  " + $(n).attr('ckdid').replace('FJMC', ''));
                                if (img[0])
                                    n.value = img[0].innerHTML;
                                //alert(n.value);
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
