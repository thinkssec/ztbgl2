<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProjectInfoView3.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.ProjectInfoView3"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/ProjectAuditUControl.ascx" TagPrefix="uc1" TagName="ProjectAuditUControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title>投标保证金确认
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
                    <li>投标管理</li>
                    <li class="last">
                        <%=Trans("投标保证金确认")%>
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
                <span><%=Trans("投标保证金确认") %></span>
            </div>
            <div>
                <%--<div class="icon-form"></div>--%>
                <table id="Tb_MENU" runat="server">
                    <tr>
                        <td width="40px">
                            &nbsp;
                        </td>
                        <td>
                            <uc1:PopWinUploadMuti runat="server" ID="Txt_SCFJ" Ext="Custom" Required="false" />
                        </td>
                        <td width="80px">
                            <asp:LinkButton ID="BtnSave" runat="server" ClientIDMode="Static" CssClass="easyui-linkbutton" iconCls="icon-save" OnClick="BtnSave_Click" OnClientClick="showLoading();">保存</asp:LinkButton>
                        </td>
                        <%--<td   width="100px">&nbsp;&nbsp;&nbsp;&nbsp;<a href='' class="easyui-linkbutton" id="H_Down" runat="server">下载</a>&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>--%>
                        <td   width="100px">
                        <a href='' class="easyui-linkbutton" id="H_Fj" runat="server" onclick="">查看附件</a>
                        <div id="openwin" class="easyui-window" style="width: 600px; height: 360px" title="附件信息" closed="true" modal="true"></div>
                    </td>
                        <td>&nbsp;
                        </td>
                        <%--<td width="100px" align="left">
                            <asp:LinkButton ID="Btn_UP" runat="server" ClientIDMode="Static" CssClass="easyui-linkbutton" iconCls="icon-save" OnClick="BtnSave_Up"  OnClientClick="showLoading();">上传</asp:LinkButton>
                        </td>--%>
                    </tr>
                </table>
                <asp:HiddenField ID="Hid_CKID" runat="server" />
                <asp:HiddenField ID="Hid_SMJ" runat="server" ClientIDMode="Static" />

            </div>
            <%--<ul id="UL_BZ" runat="server"  Visible="false">
                <li class="ssec-label">
                    <%=Trans("备注")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_BZ" runat="server" CssClass="easyui-validatebox large"
                            missingMessage="必填项" validType="length[0,250]" invalidMessage="不能超过250个字！"
                            Width="310" Height="100" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </li>
            </ul>--%>
            <ul>
                <li class="ssec-label">
                    <%=Trans("提交人/时间")%>：                    
                </li>
                <li>
                    <div>
                        <asp:Label ID="Lb_SUBMIT" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("项目名称")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PROJNAME" runat="server" CssClass="easyui-validatebox large"
                            required="true" missingMessage="必填项" validType="length[0,250]" invalidMessage="不能超过250个字！" Width="310px" Enabled="false"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("项目类型")%>：                    
                </li>
                <li>
                    <div>
                        <%--<asp:DropDownList ID="Ddl_KIND" runat="server">
                        <asp:ListItem Value="1">综合</asp:ListItem>
                        <asp:ListItem Value="2">物资</asp:ListItem>
                        <asp:ListItem Value="3">采购</asp:ListItem>        
                       </asp:DropDownList>--%>
                        <asp:RadioButtonList ID="Ddl_KIND" runat="server" RepeatDirection="Horizontal" Enabled="false">
                            <asp:ListItem Value="1">综合</asp:ListItem>
                            <asp:ListItem Value="2">物资</asp:ListItem>
                            <asp:ListItem Value="3">工程</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </li>

            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("招标方式")%>：                    
                </li>
                <li>
                    <div>
                        <%--<asp:DropDownList ID="Ddl_ZBFS" runat="server">
                        <asp:ListItem Value="1">公开招标</asp:ListItem>
                        <asp:ListItem Value="2">邀请招标</asp:ListItem>     
                       </asp:DropDownList>--%>

                        <asp:RadioButtonList ID="Rad_ZBFS" runat="server" RepeatDirection="Horizontal" Enabled="false">

                            <%-- <asp:ListItem Value="1">公开招标</asp:ListItem>--%>
                            <asp:ListItem Value="2">邀请招标</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </li>

            </ul>


            <ul>
                <li class="ssec-label">
                    <%=Trans("资金来源")%>：                    
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="Ddl_ZJLY" runat="server" Enabled="false">
                            <asp:ListItem Value="投资">投资</asp:ListItem>
                            <asp:ListItem Value="成本">成本</asp:ListItem>
                            <asp:ListItem Value="科研经费">科研经费</asp:ListItem>
                            <asp:ListItem Value="安保基金返还">安保基金返还</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>

            </ul>
            <ul>
                <li class="ssec-label">
                    <%=Trans("计划金额")%>：                    
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PROJINCOME" runat="server" CssClass="easyui-numberbox" min="0"
                            max="99999999" precision="4" invalidMessage="无效数字"  missingMessage="必选项"
                            Width="150px" Enabled="false"></asp:TextBox>（万元）
                    </div>
                </li>
            </ul>
            <%--<ul>
                <li class="ssec-label">
                    <%=Trans("安全检查人员")%>：                    
                </li>
                <li>
                    <div>
                        <uc1:MutiUserSelectControl runat="server" ID="muti_RcvUsers" Required="false" />
                    </div>

                </li>
            </ul>--%>
            <ul>
                <li class="ssec-label">

                    <%=Trans("拟开标时间")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_NKBSJ" runat="server" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("拟开标地点")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_NKBDD" runat="server" CssClass="easyui-validatebox large" validType="length[0,100]" invalidMessage="不能超过100个字！" Width="500px" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <%-- <ul>
                <li class="ssec-label">

                    <%=Trans("经办人")%>：

                </li>
                <li>
                    <div>
                        <asp:Label ID="Lb_SUBMITTER" runat="server"></asp:Label>
                    </div>

                </li>
            </ul>--%>

            <ul>
                <li class="ssec-label">

                    <%=Trans("联系电话")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PHONE" runat="server" CssClass="easyui-validatebox large" validType="length[0,20]" invalidMessage="不能超过20个字！" Width="150px" Enabled="false"></asp:TextBox>
                    </div>

                </li>
            </ul>


            <ul>
                <li class="ssec-label">

                    <%=Trans("项目内容")%>：
                    
                </li>
                <li>

                    <%--<asp:TextBox ID="Txt_PROJCONTENT" runat="server" CssClass="easyui-validatebox large" required="true"
                        missingMessage="必填项" validType="length[0,250]" invalidMessage="不能超过250个字！"
                        Width="510" Height="100" TextMode="MultiLine" Enabled="false"></asp:TextBox>--%>
                    <asp:Label ID="Lb_PROJCONTENT" runat="server"  Width="510"></asp:Label>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">服务商：
                </li>
                <li>
                    <div class="main-gridview">

                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" Width="100%" runat="server"
                            CssClass="GridViewStyle" DataKeyNames="FID" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemStyle Width="40" />
                                    <ItemTemplate>
                                        <%#(Container.DataItemIndex + 1)%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="服务商" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#Eval("CRMINFO") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#Eval("BZ") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="保证金" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="Ddl_BZJ" runat="server">
                                            <asp:ListItem Text="未缴纳" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="已缴纳" Value="1"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>

                    </div>
                </li>
            </ul>
        </div>
        <%--<asp:Panel ID="Pnl_Audit_Show" runat="server">
            <uc1:ProjectAuditUControl runat="server" ID="UC_Shenhe_Show" />
        </asp:Panel>--%>
    </div>

</asp:Content>
