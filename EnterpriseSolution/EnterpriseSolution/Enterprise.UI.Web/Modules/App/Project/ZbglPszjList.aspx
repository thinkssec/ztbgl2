<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" 
    CodeBehind="ZbglPszjList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.ZbglPszjList"
    EnableEventValidation="false" ValidateRequest="false" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Import Namespace="Enterprise.Component.Infrastructure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        
        <%--end--%>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        
        <div class="main-gridview">
            <div class="main-gridview-title">
                <asp:LinkButton ID="Bt_Search" runat="server" Text="随机抽取专家" CssClass="easyui-linkbutton"
                    plain="false" OnClick="Bt_Search_Click" Visible="false" OnClientClick="showLoading();"></asp:LinkButton>
            </div>
            <div  class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>技术评委:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    机关评委—<asp:TextBox ID="Txt_X" runat="server"  CssClass="easyui-numberbox" min="1" max="9" ClientIDMode="Static"
                                precision="0" invalidMessage="无效数字" missingMessage="必选项"
                                Width="50px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    基层评委—<asp:TextBox ID="Txt_X2" runat="server"  CssClass="easyui-numberbox" min="1" max="9" ClientIDMode="Static"
                                precision="0" invalidMessage="无效数字" missingMessage="必选项"
                                Width="50px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton3" runat="server" Text="重新抽取" OnClick="Bt_Search_Click3" OnClientClick="showLoading();" Visible="false"></asp:LinkButton>
                </div>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="Btn_Excel_Click2" CssClass="LinkButton">导出Excel</asp:LinkButton>--%>
            </div>
            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ZID"  CssClass="GridViewStyle"
                AllowPaging="True" PageSize="30" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle Width="60" />
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1)%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <%--<asp:BoundField HeaderText="专家姓名" DataField="PERSONNAME" />--%>
                        
                    <asp:TemplateField HeaderText="专家姓名">
                        <ItemStyle Width="120" />
                        <ItemTemplate>
                            <%#Eval("PERSONNAME")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部门">
                        <ItemStyle Width="200" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName((int)Eval("DEPTID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="电话">

                        <ItemTemplate>
                             <%#Enterprise.Service.App.Crm.CrmPersonService.getModel (Eval("PERSONID").ToInt()).PHONE %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="角色">
                        <ItemStyle Width="60" />
                        <ItemTemplate>
                            <%#Eval("ROLE")==null?"评委会成员":((string)Eval("ROLE")=="1"?"评委会组长":"评委会成员")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemStyle Width="90" />
                        <ItemTemplate>
                            <%#GetCommandBtn2((string)Eval("ZID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div  class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>经济评委:</span>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    机关评委—<asp:TextBox ID="Txt_Y" runat="server"  CssClass="easyui-numberbox" min="1" max="9" ClientIDMode="Static"
                                precision="0" invalidMessage="无效数字"  missingMessage="必选项"
                                Width="50px"></asp:TextBox>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="Btn_Excel_Click2" CssClass="LinkButton">导出Excel</asp:LinkButton>--%>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                基层评委—<asp:TextBox ID="Txt_Y2" runat="server"  CssClass="easyui-numberbox" min="1" max="9" ClientIDMode="Static"
                                precision="0" invalidMessage="无效数字"  missingMessage="必选项"
                                Width="50px"></asp:TextBox>
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;       
                    <asp:LinkButton ID="LinkButton2" runat="server" Text="重新抽取" OnClick="Bt_Search_Click2" OnClientClick="showLoading();" Visible="false"></asp:LinkButton>
                </div>
            </div>
            <%--数据表格开始--%>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ZID"  CssClass="GridViewStyle"
                AllowPaging="True" PageSize="30" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                         <ItemStyle Width="60" />
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1)%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="专家姓名">
                        <ItemStyle Width="120" />
                        <ItemTemplate>
                            <%#Eval("PERSONNAME")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="部门">
                        <ItemStyle Width="200" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName((int)Eval("DEPTID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="电话">
                        
                        <ItemTemplate>
                             <%#Enterprise.Service.App.Crm.CrmPersonService.getModel (Eval("PERSONID").ToInt()).PHONE %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="角色">
                        <ItemStyle Width="60" />
                        <ItemTemplate>
                            <%#Eval("ROLE")==null?"评委会成员":((string)Eval("ROLE")=="1"?"评委会组长":"评委会成员")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemStyle Width="90" />
                        <ItemTemplate>
                            <%#GetCommandBtn2((string)Eval("ZID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div  class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>需求评委</span>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="Btn_Excel_Click2" CssClass="LinkButton">导出Excel</asp:LinkButton>--%>
                </div>
            </div>
            <%--数据表格开始--%>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="ZID"  CssClass="GridViewStyle"
                AllowPaging="True" PageSize="30" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1)%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField HeaderText="专家姓名" DataField="PERSONNAME" />

                    <asp:TemplateField HeaderText="部门">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName((int)Eval("DEPTID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="电话">
                        <ItemStyle Width="80" />
                        <ItemTemplate>
                              <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserModelByUserId(Eval("PERSONID").ToInt()).UGNPHONE %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="角色">
                        <ItemStyle Width="60" />
                        <ItemTemplate>
                            <%#Eval("ROLE")==null?"评委会成员":((string)Eval("ROLE")=="1"?"评委会组长":"评委会成员")%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemStyle Width="90" />
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("ZID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>添加需求评委</span>
                </div>
                <%--表单构建开始--%>
                <asp:HiddenField ID="tb_memberId" runat="server" />
                
                <ul>
                    <li class="ssec-label">

                        <%=Trans("需求评委")%>：
                    
                    </li>
                    <li>
                        <div>
                            <uc1:UserSelectControl runat="server" ID="User_SHR2"/>
                        </div>
                    </li>
                </ul>
                <%--<%--表单构建end--%>
                <ul>
                    <li>
                        <div>
                            <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" iconCls="icon-save" OnClientClick="return ( $('#form1').form('validate'))&&showLoading();" OnClick="BtnSave_Click">保存</asp:LinkButton>
                        </div>
                    </li>
                </ul>
            </div>
        </asp:Panel>
    </div>
</asp:Content>

