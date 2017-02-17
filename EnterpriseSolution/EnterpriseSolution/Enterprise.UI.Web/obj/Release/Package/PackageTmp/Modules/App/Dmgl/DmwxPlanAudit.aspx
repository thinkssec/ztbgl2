<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
    CodeBehind="DmwxPlanAudit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Dmgl.DmwxPlanAudit"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>地面维修计划申请
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent">首页</a></li>
                    <li>地面管理</li>
                    <li class="last">地面工程维修计划审核</li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <%--自定义按钮--%>
            <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
            <%--end--%>

        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("地面维修计划申请") %></span>
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
                        <asp:TextBox ID="Txt_MX" runat="server" CssClass="easyui-validatebox" Width="450" required="true" MaxLength="100" Height="50" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("工作量描述:")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_MS" runat="server" CssClass="easyui-validatebox" Width="450" required="true" MaxLength="100" Height="50" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("计划单价:")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PDJ" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="2" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("数量:")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PSL" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="0" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">

                    <%=Trans("合计:")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PAMOUNT" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="2" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("附件")%>：
                   
                </li>
                <li>
                    <%--<asp:Label runat="server" ID="tb_AFVIewNames"></asp:Label>--%>
                    <div runat="server" ID="Label1"></div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("计划开工日期")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PSTARTDATE" runat="server" CssClass="easyui-datebox"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">
                    <%=Trans("计划完工日期")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PENDDATE" runat="server" CssClass="easyui-datebox"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("当前状态")%>：
                    
                </li>
                <li>
                    <div>
                        <asp:Label ID="Lb_STATUS" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            

            <ul>
                <li class="ssec-label">&nbsp;              
                </li>
                <li>
                    <%-- <asp:Button ID="Button1" iconCls="icon-save" CssClass="easyui-linkbutton" 
                        runat="server" Text="保存" OnClick="BtnSave_OnClick" OnClientClick="return checkInputForm();"/>--%>


                    <asp:LinkButton ID="BtnSave" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnOk_OnClick" iconCls="icon-ok">通过</asp:LinkButton>
                    <asp:LinkButton ID="BtnAudit" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnCancle_OnClick" iconCls="icon-cancel">不通过</asp:LinkButton>
                  

                    <script type="text/javascript">
                        function checkInputForm() {
                            var v = $('#form1').form('validate');
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
