<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="HseSectEdit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Hse.HseSectEdit"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


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
                        <%=Trans("安全隐患整改")%>
                    </li>
                </ul>
            </div>
        </div>
        <%--end--%>
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
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("编辑") %></span>
                <asp:HiddenField ID="Hid_CKID" runat="server" />
            </div>
            <ul>
                <li class="ssec-label">
                    <%=Trans("受检单位")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_TARGET" runat="server"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("检查级别")%>：                    
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="Ddl_LEVEL" runat="server">
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
                        <uc1:MutiUserSelectControl runat="server" ID="muti_RcvUsers" Required="false" />
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
                        <uc1:UserSelectControl runat="server" ID="single_RcvUsers" Required="true" />
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("检查日期")%>：(<span style="color: red; font-weight: bold;">*</span>)

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_CDATE" runat="server" CssClass="easyui-datebox"></asp:TextBox>
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
                                        <asp:TextBox ID="T_CWHERE" runat="server" Width="100" Height="40" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="查出问题" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="T_DETAIL" runat="server" Width="200" Height="40" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="责任人" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="T_CHARGE" runat="server" Width="100" Height="40" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="T_MEMO" runat="server" Width="200" Height="40" TextMode="MultiLine"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#GetCommandBtn((string)Eval("CKDID")) %>
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
                        <asp:TextBox ID="Txt_ENDDATE" runat="server" CssClass="easyui-datebox"></asp:TextBox>
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
                    <uc1:PopWinUploadMuti runat="server" ID="tb_AFVIewNames" Ext="Office" Required="false" />
                </li>
            </ul>
            <ul>
                <li class="ssec-label">&nbsp;              
                </li>
                <li>
                    <%-- <asp:Button ID="Button1" iconCls="icon-save" CssClass="easyui-linkbutton" 
                        runat="server" Text="保存" OnClick="BtnSave_OnClick" OnClientClick="return checkInputForm();"/>--%>

                                    <asp:LinkButton ID="LinkButton2" type="submit" runat="server" OnClientClick="return checkInputForm1();"
                        CssClass="easyui-linkbutton" OnClick="BtnNew_OnClick" iconCls="icon-add">新增问题记录</asp:LinkButton>
                    <asp:LinkButton ID="BtnSave" type="submit" runat="server" OnClientClick="return checkInputForm1();"
                        CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick" iconCls="icon-save">保存</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnRecv_OnClick" iconCls="icon-ok">提交</asp:LinkButton>

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
