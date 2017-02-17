<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
    CodeBehind="ZyglGxEdit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Zygl.ZyglGxEdit"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title> 
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
                    <li>工序明细提报</li>
                    <li class="last">
                        <%=Trans("施工进度填报")%>
                    </li>
                </ul>
            </div>

        </div>
        <div id="main-tool">
            <%--自定义按钮--%>
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <%--end--%>
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
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

                    <%=Trans("井号:")%>：(<span style="color: red; font-weight: bold;">*</span>)

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_JH" runat="server" CssClass="easyui-validatebox"    Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul >
                <li class="ssec-label">

                    <%=Trans("实际开工日期")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_STARTDATE" runat="server" CssClass="easyui-datebox" required="true"  Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">

                    <%=Trans("计划完成日期")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_PENDDATE" runat="server" CssClass="easyui-datebox" required="true"  Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li  class="ssec-label">
                    工序明细：
                </li>
                <li >
                    <div class="main-gridview">
                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" Width="100%" runat="server"
                            CssClass="GridViewStyle"   DataKeyNames="SGXH" >
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemStyle Width="40" />
                                    <ItemTemplate>
                                        <%# Eval("SGXH")%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="填报日期">
                                    <ItemStyle Width="60" />
                                    <ItemTemplate>
                                        <%# Eval("RQ")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="工序名称">
                                    <ItemStyle Width="100" />
                                    <ItemTemplate>
                                        <%# Eval("GXMC")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="工序简述">
                                    <ItemStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <%# Eval("GXJS")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>

                        </asp:GridView>
                    </div>
                 </li>
            </ul>
            

          
            <ul>
                <li class="ssec-label">&nbsp;              
                </li>
                <li> 
                    <asp:LinkButton ID="LinkButton1" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnRecv_OnClick" iconCls="icon-ok">完工</asp:LinkButton>

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
