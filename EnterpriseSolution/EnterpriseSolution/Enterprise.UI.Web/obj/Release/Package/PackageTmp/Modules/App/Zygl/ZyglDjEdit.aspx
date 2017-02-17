<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
    CodeBehind="ZyglDjEdit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Zygl.ZyglDjEdit"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>作业开工申请
    </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">

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
                <span><%=Trans("作业开工申请") %></span>
            </div>
            <ul>
                <li class="ssec-label">
                    <%=Trans("井号")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_JH" runat="server" CssClass="easyui-validatebox" required="true" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">
                    <%=Trans("区块")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_DYQK" runat="server" CssClass="easyui-validatebox" required="true" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">
                    <%=Trans("层位")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_CW" runat="server" CssClass="easyui-validatebox" required="true" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">
                    <%=Trans("上次作业日期")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_LASTDATE" runat="server" CssClass="easyui-datebox" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("上次施工内容")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_LSGNR" runat="server" CssClass="easyui-validatebox" required="true" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("生产周期")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_SCZQ" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="2" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">
                    <%=Trans("本次作业原因")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_ZYYY" runat="server" CssClass="easyui-validatebox" Width="450" required="true" MaxLength="100" Height="50" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">
                    <%=Trans("施工内容")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_SGNR" runat="server" CssClass="easyui-validatebox" required="true" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>

            <ul>
                <li class="ssec-label">
                    <%=Trans("作业类别")%>：                    
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="Ddl_ZYFL" runat="server" Enabled="false">
                            <asp:ListItem Value="措施">措施</asp:ListItem>
                            <asp:ListItem Value="维护">维护</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("措施类别")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_CSLB" runat="server" CssClass="easyui-validatebox" required="true" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>
            

            <ul>
                <li class="ssec-label">

                    <%=Trans("预算金额(万元):")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_YSE" runat="server" CssClass="easyui-numberbox" Width="150" required="true" min="0" percision="4" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("计划开工日期")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PSTARTDATE" runat="server" CssClass="easyui-datebox" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>

            <ul>
                <li class="ssec-label">
                    <%=Trans("计划完工日期")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PENDDATE" runat="server" CssClass="easyui-datebox" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("附件")%>：
                   
                </li>
                <li>
                    <asp:Label runat="server" ID="Lb_FL"></asp:Label>                    </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("实际开工日期")%>：
                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_STARTDATE" runat="server" CssClass="easyui-datebox"  ></asp:TextBox>
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
                        CssClass="easyui-linkbutton" OnClick="BtnSave_OnClick" iconCls="icon-save">保存</asp:LinkButton>
                    <asp:LinkButton ID="BtnAudit" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnOk_OnClick" iconCls="icon-ok">提交</asp:LinkButton>
                  

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
