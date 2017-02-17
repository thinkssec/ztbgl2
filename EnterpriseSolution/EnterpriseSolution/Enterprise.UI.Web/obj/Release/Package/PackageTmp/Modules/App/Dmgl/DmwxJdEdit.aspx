<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
    CodeBehind="DmwxJdEdit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Dmgl.DmwxJdEdit"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title>发布公文  
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
                    <li>地面管理</li>
                    <li class="last">
                        <%=Trans("工程进度填报")%>
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
                    <%=Trans("项目类别1")%>：                    
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="Ddl_PKIND1" runat="server" Enabled="false">
                            <asp:ListItem Value="重点施工项目">重点施工项目</asp:ListItem>
                            <asp:ListItem Value="一般施工项目">一般施工项目</asp:ListItem>
                            <asp:ListItem Value="应急项目">应急项目</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("项目类别2")%>：                    
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="Ddl_PKIND2" runat="server" Enabled="false">
                            <asp:ListItem Value="地面-站、库">地面-站、库</asp:ListItem>
                            <asp:ListItem Value="地面-管线">地面-管线</asp:ListItem>
                            <asp:ListItem Value="地面-电力线路维修">地面-电力线路维修</asp:ListItem>
                            <asp:ListItem Value="地面-房屋">地面-房屋</asp:ListItem>
                            <asp:ListItem Value="地面-道路">地面-道路</asp:ListItem>
                            <asp:ListItem Value="地面-其他">地面-其他</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("明细类别:")%>：(<span style="color: red; font-weight: bold;">*</span>)

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_MX" runat="server" CssClass="easyui-validatebox" Width="450" MaxLength="100" Height="50" TextMode="MultiLine"  Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("工作量描述:")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_MS" runat="server" CssClass="easyui-validatebox" Width="450" MaxLength="100" Height="50" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("施工单位:")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_SGDW" runat="server" CssClass="easyui-validatebox" Width="150" required="true" MaxLength="100" ></asp:TextBox>
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
                            CssClass="GridViewStyle"  OnRowDataBound="GridView1_RowDataBound" DataKeyNames="JID" >
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemStyle Width="60" />
                                    <ItemTemplate>
                                        <%#(int)Eval("STATUS")==-2?"新增记录":(Container.DataItemIndex + 1)+""%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="填报日期">
                                    <%--<ItemStyle Width="120px" />--%> 
                                    <ItemTemplate>
                                        <asp:TextBox ID="T_JTIME" runat="server" CssClass="easyui-datebox" editable="true"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="施工进度" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:TextBox ID="T_DETAIL" runat="server" Width="300"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#GetCommandBtn((string)Eval("JID")) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                 </li>
            </ul>
            <ul >
                <li class="ssec-label">

                    <%=Trans("实际开工日期")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_STARTDATE" runat="server" CssClass="easyui-datebox" required="true"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul >
                <li class="ssec-label">

                    <%=Trans("计划完成日期")%>：<span style="color: red; font-weight: bold;">*</span>

                </li>
                <li >
                    <div>
                        <asp:TextBox ID="Txt_PENDDATE" runat="server" CssClass="easyui-datebox" required="true"></asp:TextBox>
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

                                    <asp:LinkButton ID="LinkButton2" type="submit" runat="server" OnClientClick="return checkInputForm1();"
                        CssClass="easyui-linkbutton" OnClick="BtnNew_OnClick" iconCls="icon-add">新增记录</asp:LinkButton>
                    <asp:LinkButton ID="BtnSave" type="submit" runat="server" OnClientClick="return checkInputForm1();"
                        CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick" iconCls="icon-save">保存</asp:LinkButton>
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
