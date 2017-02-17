<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HseSectAudit3.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Hse.HseSectAudit3"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript" src="/Resources/OA/bootstrap/js/bootstrap.min.js"></script>--%>

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
                        <%=Trans("安全隐患整改审核")%>
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
                <span><%=Trans("单位安全承保员审核") %></span>
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
                            CssClass="GridViewStyle" DataKeyNames="CKDID" >
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
                                <asp:TemplateField HeaderText="整改情况" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#Eval("PRESENT") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="COMPLETEDATE" HeaderText="实际完成时间" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:TemplateField HeaderText="整改反馈照片">
                                    <ItemTemplate>
                                       <img Width="100" Height="60" src="<%#(string)Eval("FNAMES") %>"/>
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
            <ul >
                <li class="ssec-label">

                    <%=Trans("实际完成日期")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_COMPLETEDATE" runat="server" CssClass="easyui-datebox" Enabled="false"></asp:TextBox>
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
                        <uc1:UserSelectControl runat="server" ID="User_SHR1" Enabled="false"/>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("受检单位负责人审核意见：")%>：
                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_SH1CONTENT" runat="server" Width="300" Height="60" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("验收考核-单位安全员")%>：
                    
                </li>
                <li>
                    <div>
                        <uc1:UserSelectControl runat="server" ID="User_SHR2" Enabled="false"/>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("受检单位安全员审核意见：")%>：
                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_SH2CONTENT" runat="server" Width="300" Height="60" TextMode="MultiLine"  Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("验收考核-安全承保员")%>：
                    
                </li>
                <li>
                    <div>
                        <uc1:UserSelectControl runat="server" ID="User_SHR3" Enabled="false"/>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("受检安全承保员审核意见：")%>：
                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_SH3CONTENT" runat="server" Width="300" Height="60" TextMode="MultiLine" ></asp:TextBox>
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
                        CssClass="easyui-linkbutton" OnClick="BtnAuditPass_OnClick" iconCls="icon-ok">通过</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnAuditBack_OnClick" iconCls="icon-cancel">不通过</asp:LinkButton>
                    <script>
                        <%--function checkInputForm() {
                           
                           var v = $('#form1').form('validate');
                           var sss = EHtmlEditor('<%=t_Content.HtmlId%>').validate();
                           
                           return v&&sss;
                       }--%>
                    </script>

                    <script type="text/javascript">
                        function checkInputForm() {

                            var v = $('#form1').form('validate');
                            return v && confirm("您确定要提交吗?");
                        }
                        function checkInputForm1() {

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
