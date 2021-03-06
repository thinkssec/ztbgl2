﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProjectAudit63.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.ProjectAudit63"
    ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/MutiUserSelectControl.ascx" TagPrefix="uc1" TagName="MutiUserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/ProjectAuditUControl.ascx" TagPrefix="uc1" TagName="ProjectAuditUControl" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title>立项申请审核
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
                    <li>谈判类项目管理</li>
                    <li class="last">
                        <%=Trans("立项申请审核")%>
                    </li>
                </ul>
            </div>
        </div>

    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("分管领导审核") %></span>
                <asp:HiddenField ID="Hid_CKID" runat="server" />
            </div>
            <ul>
                <li class="ssec-label">
                    <%=Trans("发起人/时间")%>：                    
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
                       <%--<asp:TextBox ID="Txt_PROJNAME" runat="server" CssClass="easyui-validatebox large"
                            required="true" missingMessage="必填项" validType="length[0,250]" invalidMessage="不能超过250个字！" Width="310px"></asp:TextBox>--%>
                       <asp:Label ID="Lb_PROJNAME" runat="server"></asp:Label>
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
                            <asp:ListItem Value="1" Selected="True">综合</asp:ListItem>
                            <asp:ListItem Value="2">物资</asp:ListItem>
                            <asp:ListItem Value="3">工程</asp:ListItem>    
                        </asp:RadioButtonList>
                    </div>
                </li>

            </ul>
            <%--<ul>
                <li class="ssec-label">
                    <%=Trans("招标方式")%>：                    
                </li>
                <li>
                    <div>
 

                        <asp:RadioButtonList ID="Rad_ZBFS" runat="server" RepeatDirection="Horizontal" Enabled="false">
                            
                            <asp:ListItem Value="2" Selected="True">邀请招标</asp:ListItem>   
                            <asp:ListItem Value="1">公开招标</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </li>

            </ul>--%>
           

            <ul>
                <li class="ssec-label">
                    <%=Trans("资金来源")%>：                    
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="Ddl_ZJLY" runat="server"  Enabled="false">
                            <asp:ListItem Value="投资">投资</asp:ListItem>
                            <asp:ListItem Value="成本">成本</asp:ListItem>
                            <asp:ListItem Value="科研经费">科研经费</asp:ListItem>
                            <asp:ListItem Value="安保基金返还">安保基金返还</asp:ListItem>
                       </asp:DropDownList>
                        <%--<asp:TextBox ID="Txt_ZJBZ" runat="server"></asp:TextBox>--%>
                        
                    </div>
                </li>

            </ul>
             <ul>
                <li class="ssec-label">
                    <%=Trans("计划金额")%>：                    
                </li>
                <li>
                    <div>
                        <%--<asp:TextBox ID="Txt_PROJINCOME" runat="server" CssClass="easyui-numberbox" min="0"
                            max="99999999" precision="4" invalidMessage="无效数字" required="true" missingMessage="必选项"
                            Width="150px"></asp:TextBox>--%>
                        <asp:Label ID="Lb_PROJINCOME" runat="server"></asp:Label>
                        （万元）<asp:Label ID="Lb_ZJBZ" runat="server"></asp:Label>
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
            <%--<ul>
                <li class="ssec-label">

                    <%=Trans("拟开标时间")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_NKBSJ" runat="server" CssClass="easyui-datetimebox" data-options="showSeconds:false"></asp:TextBox>
                    </div>

                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("拟开标地点")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_NKBDD" runat="server" CssClass="easyui-validatebox large" validType="length[0,100]" invalidMessage="不能超过100个字！" Width="500px"></asp:TextBox>
                    </div>

                </li>
            </ul>--%>
            <%--<ul>
                <li class="ssec-label">

                    <%=Trans("经办人")%>：

                </li>
                <li>
                    <div>
                        <asp:Label ID="Lb_SUBMITTER" runat="server"></asp:Label>
                    </div>

                </li>
            </ul>--%>

            <%--<ul>
                <li class="ssec-label">

                    <%=Trans("联系电话")%>：

                </li>
                <li>
                    <div>
                        <asp:TextBox ID="Txt_PHONE" runat="server" CssClass="easyui-validatebox large" validType="length[0,20]" invalidMessage="不能超过20个字！" Width="150px"></asp:TextBox>
                    </div>

                </li>
            </ul>--%>

            <%--<ul>
                <li class="ssec-label">

                    <%=Trans("审核人员")%>：
                    
                </li>
                <li>
                    <div>
                        <uc1:UserSelectControl runat="server" ID="single_RcvUsers" Required="true" />
                        <asp:Label ID="Lb_SHR" runat="server"></asp:Label>
                    </div>
                </li>
            </ul>--%>
             <ul>
                <li class="ssec-label">

                    <%=Trans("项目内容")%>：
                    
                </li>
                <li>
                   
                     <%--<asp:TextBox ID="Txt_PROJCONTENT" runat="server"  CssClass="easyui-validatebox large" required="true"
                          missingMessage="必填项" validType="length[0,2000]" invalidMessage="不能超过2000个字！"  
                         Width="510" Height="100" TextMode="MultiLine"  Enabled="false"></asp:TextBox>--%>
                    <asp:Label ID="Lb_PROJCONTENT" runat="server" Width="510"></asp:Label>
                </li>
            </ul>
            <ul>
                <li class="ssec-label">

                    <%=Trans("申请理由")%>：
                    
                </li>
                <li>

                    <%--<asp:TextBox ID="Txt_SQLY" runat="server" CssClass="easyui-validatebox large" required="true"
                        missingMessage="必填项" validType="length[0,2000]" invalidMessage="不能超过2000个字！"
                        Width="510" Height="100" TextMode="MultiLine"  Enabled="false"></asp:TextBox>--%>
                    <asp:Label ID="Lb_SQLY" runat="server" Width="510"></asp:Label>
                </li>
            </ul>
            <ul>
                <li  class="ssec-label">
                    对方单位：
                </li>
                <li >
                    <div class="main-gridview">

                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" Width="100%" runat="server"
                            CssClass="GridViewStyle"  DataKeyNames="FID" >
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemStyle Width="40" />
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                    <HeaderStyle Width="50px" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="服务商" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#Enterprise.Service.App.Crm.CrmInfoService.GetCrmName((string)Eval("CRMINFO")) %>
                                         </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="备注" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%#Eval("BZ") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                        
                    </div>
                 </li>
            </ul>
            <%--<ul>
                <li class="ssec-label">

                    <%=Trans("指定业务部门")%>：
                    
                </li>
                <li>
                    <asp:DropDownList ID="Ddl_YWBM" runat="server">
                        <asp:ListItem Value="132">经理办公室</asp:ListItem>
                        <asp:ListItem Value="133">党群工作部</asp:ListItem>
                        <asp:ListItem Value="134">生产运行部</asp:ListItem>
                        <asp:ListItem Value="135">工程管理部</asp:ListItem>
                        <asp:ListItem Value="136">管道保护部</asp:ListItem>
                        <asp:ListItem Value="137">安全环保部</asp:ListItem>
                        <asp:ListItem Value="138">人力资源部</asp:ListItem>
                        <asp:ListItem Value="139">计划经营部</asp:ListItem>
                        <asp:ListItem Value="140">财务资产部</asp:ListItem>
                        <asp:ListItem Value="141">物资装备部</asp:ListItem>
                        <asp:ListItem Value="143">压缩机管理部</asp:ListItem>
                        <asp:ListItem Value="144">CNG管理部</asp:ListItem>
                        <asp:ListItem Value="145">调控中心</asp:ListItem>

                        <asp:ListItem Value="146">科技信息部</asp:ListItem>
                        <asp:ListItem Value="243">经营管理部</asp:ListItem>
                    </asp:DropDownList>

                </li>
            </ul>--%>
           <asp:Panel ID="Pnl_Audit_Show" runat="server">
                <uc1:ProjectAuditUControl runat="server" ID="UC_Shenhe_Show" />
            </asp:Panel>
            <ul>
                <li class="ssec-label">
                    审核意见：                    
                </li>
                <li>
                   
                     <asp:TextBox ID="Txt_SHYJ" runat="server"  CssClass="easyui-validatebox large"
                          missingMessage="必填项" validType="length[0,250]" invalidMessage="不能超过250个字！"  
                         Width="310" Height="100" TextMode="MultiLine"></asp:TextBox>
                </li>
            </ul>

             <%--<ul id="ul_spr" runat="server">
                <li class="ssec-label">

                    <%=Trans("经营管理部审批人员")%>：
                    
                </li>
                <li>
                    <div>
                        <uc1:UserSelectControl runat="server" ID="UserSelectControl1" Required="true" />
                        <asp:DropDownList ID="Txt_SPR" runat="server" Required="true"  CssClass="easyui-combobox" Width="153" data-options="editable:false"></asp:DropDownList>
                    </div>
                </li>
            </ul>--%>
            <ul>
                <li class="ssec-label">&nbsp;              
                </li>
                <li>
                    <%--<asp:LinkButton ID="LinkButton2" type="submit" runat="server" OnClientClick="return checkInputForm1()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnNew_OnClick" iconCls="icon-add">新增服务商</asp:LinkButton>--%>
                    <asp:LinkButton ID="BtnSave" type="submit" runat="server" OnClientClick="return checkInputForm1()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnCancel_OnClick" iconCls="icon-cancel">审核不通过</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton1" type="submit" runat="server" OnClientClick="return checkInputForm1()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnOk_OnClick2" iconCls="icon-ok">审核通过</asp:LinkButton>
<%--                    <asp:LinkButton ID="LinkButton5" type="submit" runat="server" OnClientClick="return checkInputForm()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnOk_OnClick" iconCls="icon-ok">提交审批</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton3" type="submit" runat="server" OnClientClick="return checkInputForm1()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnCancel_OnClick" iconCls="icon-cancel"  Visible="false">审批不通过</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton4" type="submit" runat="server" OnClientClick="return checkInputForm()&&showLoading();"
                        CssClass="easyui-linkbutton" OnClick="BtnOk_OnClick2" iconCls="icon-ok" Visible="false">审批通过</asp:LinkButton>--%>

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
