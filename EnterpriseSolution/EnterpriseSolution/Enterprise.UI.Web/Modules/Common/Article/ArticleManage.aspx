<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ArticleManage.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Common.Article.ArticleManage"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title>发布新文章/title>
    
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
                    <li>办公事务</li>
                    <li><a href="ArticleList.aspx?ModuleId=<%=ModuleId %>">
                        <asp:Label ID="lb_MName" runat="server"></asp:Label></a></li>
                    <li class="last">
                        <%=Trans("操作")%>
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
                <span><%=Trans("发布信息") %></span>
            </div>
            <ul>
                <li class="ssec-label">
                    <%=Trans("部门/单位")%>：                    
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_Dept" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("发布人")%>：                    
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_User" runat="server"></asp:Label>
                    </div>
                </li>

            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("重要程度")%>：
                    
                </li>
                <li>
                    <div>
                        <asp:RadioButtonList ID="t_Type" runat="server" RepeatDirection="Horizontal" RepeatLayout="Table"
                            CssClass="checkbox">
                            <asp:ListItem Selected="True">普通</asp:ListItem>
                            <asp:ListItem>重要</asp:ListItem>
                            <asp:ListItem>非常重要</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("有效时间")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="t_Time" runat="server" CssClass="easyui-datebox"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("标题")%>：(<span style="color: red; font-weight: bold;">*</span>)

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="t_Title" runat="server" CssClass="easyui-validatebox" Width="450" required="true" MaxLength="100"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul style="display: none">
                <li class="ssec-label">

                    <%=Trans("标题")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li class="ssec-text large">
                    <div>
                        <asp:TextBox ID="t_TitleRu" runat="server" CssClass="ssec-text-field easyui-validatebox"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
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
                        <uc1:MutiUserSelectControl runat="server" ID="muti_RcvUsers" Required="false" />
                    </div>
                </li>
            </ul>
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


                    <asp:LinkButton ID="BtnSave" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick" iconCls="icon-save">保存</asp:LinkButton>

                    <script>
                        <%--function checkInputForm() {
                           
                           var v = $('#form1').form('validate');
                           var sss = EHtmlEditor('<%=t_Content.HtmlId%>').validate();
                           
                           return v&&sss;
                       }--%>
                    </script>

                    <script type="text/javascript">
                        function checkInputForm() {
                            var v = $('#form1').form('validate') && EHtmlEditor('<%=t_Content.HtmlId%>').validate();
                            return v && confirm("您确定要提交吗?");
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
