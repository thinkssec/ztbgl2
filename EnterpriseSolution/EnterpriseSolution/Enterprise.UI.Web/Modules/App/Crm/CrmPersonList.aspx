<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="CrmPersonList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Crm.CrmPersonList"
    EnableEventValidation="false" ValidateRequest="false" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/">首页</a></li>
                    <li>专家管理</li>
                    <li class="last">专家库维护</li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div1" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>专家信息</span>
                <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="Btn_Excel_Click2" CssClass="LinkButton">导出Excel</asp:LinkButton>--%>
            </div>
        </div>
        <div class="main-gridview">
            <div class="main-gridview-title">
                <%--单位名称：
                <asp:DropDownList ID="ddl_dName" runat="server">
                </asp:DropDownList>--%>
                关键字：<asp:TextBox ID="tb_Name" runat="server"></asp:TextBox>
                <asp:LinkButton ID="Bt_Search" runat="server" Text="查询" CssClass="easyui-linkbutton"
                    plain="false" OnClick="Bt_Search_Click"></asp:LinkButton>
            </div>
            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="PERSONID"  CssClass="GridViewStyle"
                AllowPaging="True" PageSize="60" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1)%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="专家姓名">
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName((int)Eval("USRID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="联系电话" DataField="PHONE" />
                    <asp:TemplateField HeaderText="类别">
                        <ItemTemplate>
                            <%#Eval("LB")==null?"":((int)Eval("LB")==1?"技术类":"经营类")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="职务">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Eval("MOBILEPHONE")%>
                        </ItemTemplate>
                    </asp:TemplateField>
             <%--       <asp:BoundField HeaderText="职务" DataField="MOBILEPHONE"/>--%>
                     
                    <asp:BoundField HeaderText="职级" DataField="EMAIL" />
                    <%--  <asp:BoundField HeaderText="性别" DataField="SEX" />--%>
                    <%-- <asp:BoundField HeaderText="籍贯" DataField="HOMETOWN" />--%>
                    <%-- <asp:BoundField HeaderText="生日" DataField="BIRTHDAY" DataFormatString="{0:yyyy-MM-dd}" />--%>
                    <asp:TemplateField HeaderText="部门">
                        <ItemStyle HorizontalAlign="Left" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysDepartmentService.GetDepartMentName((int)Eval("DEPTID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField HeaderText="职务" DataField="DEPTDUTY" />--%>
                    <%-- <asp:BoundField HeaderText="毕业学校" DataField="SCHOOL" />--%>
                    <%-- <asp:BoundField HeaderText="地址" DataField="ADDRESS" />--%>
                    <%--<asp:BoundField HeaderText="邮政编码" DataField="POSTCODE" />--%>
                    <%--<asp:BoundField HeaderText="ID" DataField="PERSONID" />--%>
                    <asp:TemplateField ShowHeader="False">
                        <ItemStyle Width="60" />
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("PERSONID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>专家信息-操作面板</span>
                </div>
                <%--表单构建开始--%>
                <asp:HiddenField ID="tb_memberId" runat="server" />
                
                <ul>
                    <li class="ssec-label">

                        <%=Trans("选择专家")%>：
                    
                    </li>
                    <li>
                        <div>
                            <uc1:UserSelectControl runat="server" ID="User_SHR2"/>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">联系电话:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_PHONE" runat="server" CssClass="easyui-validatebox" validType="length[0,20]" invalidMessage="不能超过20个数字！"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">职务:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_MOBILEPHONE" runat="server" Width="300" CssClass="easyui-validatebox" validType="length[0,50]" invalidMessage="不能超过50个字符！"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">职级:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_DEPTDUTY" runat="server" Width="300"   CssClass="easyui-validatebox" validType="length[0,50]" ></asp:TextBox>
                            
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">专业技术资格:</li>
                    <li>
                        <div>
                            <%--<asp:TextBox ID="Tb_EMAIL" runat="server" CssClass="easyui-validatebox" validType="email" invalidMessage="必须是邮箱！"></asp:TextBox>--%>
                            <asp:DropDownList ID="Ddl_EMAIL" runat="server">
                                <asp:ListItem Value="高级工程师">高级工程师</asp:ListItem>
                                <asp:ListItem Value="注册招标师">注册招标师</asp:ListItem>
                                <asp:ListItem Value="高级经济师">高级经济师</asp:ListItem>
                                <asp:ListItem Value="高级会计师">高级会计师</asp:ListItem>
                                <asp:ListItem Value="高级政工师">高级政工师</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">状态:</li>
                    <li>
                        <div>
                            <asp:DropDownList ID="Ddl_Del" runat="server">
                                <asp:ListItem Text="启用" Value="0"  Selected="True"></asp:ListItem>
                                <asp:ListItem Text="停用" Value="1" ></asp:ListItem>
                            </asp:DropDownList>
                            <%--<asp:TextBox ID="Tb_SEX" runat="server" CssClass="easyui-validatebox"  validType="length[0,1]" invalidMessage="不能超过1个字！"></asp:TextBox>--%>
                        </div>
                    </li>
                </ul>
                <%--<ul>
                    <li class="ssec-label">生日:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_BIRTHDAY" runat="server" CssClass="easyui-datebox" editable="false"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">籍贯:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_HOMETOWN" runat="server" CssClass="easyui-validatebox" validType="length[0,50]" invalidMessage="不能超过50个字！" Width="300px"></asp:TextBox>
                        </div>
                    </li>
                </ul>--%>
                <%--<ul>
                    <li class="ssec-label">部门:</li>
                    <li>
                        <div class="ssec-text small">
                            <asp:DropDownList ID="tb_Dept" runat="server">
                            </asp:DropDownList>
                        </div>
                    </li>
                </ul>--%>
                <%--<ul style="display:none">
                    <li class="ssec-label">职务:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_DEPTDUTY" runat="server" CssClass="easyui-validatebox" validType="length[0,50]" invalidMessage="不能超过50个字！"></asp:TextBox>
                        </div>
                    </li>
                </ul>--%>
                <ul>
                    <li class="ssec-label">类别:</li>
                    <li>
                        <div>
                            <asp:DropDownList ID="Ddl_LB" runat="server">
                                <asp:ListItem Value="1">技术评委</asp:ListItem>
                                <asp:ListItem Value="2">经济评委</asp:ListItem>
                                <asp:ListItem Value="4">技术/经济</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                </ul>

                <ul>
                    <li class="ssec-label"></li>
                    <li>
                        <div>
                            <asp:RadioButtonList ID="Rd_SEX" runat="server">
                                <asp:ListItem Text="机关评委" Value="1"></asp:ListItem>
                                <asp:ListItem Text="基层评委" Value="0"></asp:ListItem>
                            </asp:RadioButtonList>
                            
                        </div>
                    </li>
                </ul>

                <ul>
                    <li class="ssec-label">
                        <%=Trans("优先级")%>：
                    </li>
                    <li>
                        <div>
                            <asp:TextBox ID="t_MAIN" runat="server" CssClass="easyui-numberbox" min="1" ClientIDMode="Static"
                                precision="0" invalidMessage="无效数字"  missingMessage="必选项"
                                Width="150px" ></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <%--<ul>
                    <li class="ssec-label">毕业学校:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_SCHOOL" runat="server" CssClass="easyui-validatebox" validType="length[0,50]" invalidMessage="不能超过50个字！" Width="300px"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">地址:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_ADDRESS" runat="server" CssClass="easyui-validatebox" validType="length[0,100]" invalidMessage="不能超过100个字！" Width="300px"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">邮政编码:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_POSTCODE" runat="server" CssClass="easyui-validatebox" validType="length[0,10]" invalidMessage="不能超过10个字符！"></asp:TextBox>
                        </div>
                    </li>
                </ul>--%>
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

