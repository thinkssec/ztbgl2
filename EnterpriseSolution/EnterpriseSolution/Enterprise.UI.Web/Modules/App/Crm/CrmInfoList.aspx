<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="CrmInfoList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Crm.CrmInfoList" EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/">首页</a></li>
                    <li>服务商管理</li>
                    <li class="last">服务商维护</li>
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
                <span>服务商信息</span>
            </div>
        </div>
        <div class="main-gridview">
            <div class="main-gridview-title">
                单位名称:
                <asp:TextBox ID="Txt_CRMNAME" runat="server"></asp:TextBox>
                <asp:LinkButton ID="Bt_Search" runat="server" Text="查询" CssClass="easyui-linkbutton"
                    plain="false" OnClick="Bt_Search_Click"></asp:LinkButton>
            </div>
            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="INFOID"
                AllowPaging="True" PageSize="30" OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="序号">
                        <ItemStyle Width="40" />
                        <ItemTemplate>
                            <%#(Container.DataItemIndex+1)%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="服务商名称" DataField="CRMNAME" />
                    <%--<asp:BoundField HeaderText="联络方式" DataField="CRMADDR" />--%>
                    <asp:BoundField HeaderText="编码" DataField="CRMSERIAL" />
                    <asp:BoundField HeaderText="企业性质" DataField="CRMPROPERTY">
                        <ItemStyle Width="60" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="附件">
                        <ItemStyle Width="250px" HorizontalAlign="Left"/> 
                        <ItemTemplate>
                            <%#Enterprise.Service.Common.Article.ArticleInfoService.ToAttachHtml2(Eval("FVIEWNAMES")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="客户类型" DataField="CRMKIND">
                        <ItemStyle Width="60" />
                    </asp:BoundField>--%>
                    <%--<asp:TemplateField HeaderText="客户维护人">
                        <ItemStyle Width="70" />
                        <ItemTemplate>
                            <%#Enterprise.Service.Basis.Sys.SysUserService.GetUserName((int)Eval("CRMUSER"))%>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                  <%--  <asp:BoundField HeaderText="添加日期" DataField="ADDDATE" DataFormatString="{0:yyyy-MM-dd}" />--%>
                    <asp:TemplateField HeaderText="操作">
                        <ItemStyle Width="60" />
                        <ItemTemplate>
                            <%#GetCommandBtn((string)Eval("INFOID"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form"></div>
                    <span>服务商信息-操作面板</span>
                </div>
                <%--表单构建开始--%>
                <ul>
                    <li class="ssec-label">服务商名称:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_CRMNAME" runat="server" CssClass="easyui-validatebox" required="true" validType="length[0,50]" invalidMessage="不能超过50个字！" Width="750px"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">联络方式:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_CRMADDR" runat="server" CssClass="easyui-validatebox" validType="length[0,50]" invalidMessage="不能超过50个字！" Width="750px"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">帐&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Txt_zhangh" runat="server" CssClass="easyui-validatebox"  Width="750px"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">税&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Txt_shuih" runat="server" CssClass="easyui-validatebox"  Width="750px"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul style="display:none">
                    <li class="ssec-label">客户编码:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_CRMSERIAL" runat="server" CssClass="easyui-validatebox"  validType="length[0,50]" Width="750px"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul style="display:none">
                    <li class="ssec-label">成员证书编号:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Txt_ZSBH" runat="server" CssClass="easyui-validatebox"  validType="length[0,50]" Width="750px"></asp:TextBox>
                        </div>
                    </li>
                </ul>

                <%--<ul >
                    <li class="ssec-label">委托人姓名:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Txt_KEY5" runat="server" CssClass="easyui-validatebox"  validType="length[0,50]" Width="100px"></asp:TextBox>
                        </div>
                    </li>
                </ul>

                <ul >
                    <li class="ssec-label">身份证号:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Txt_KEY6" runat="server" CssClass="easyui-validatebox"  validType="length[0,50]" Width="300px"></asp:TextBox>
                        </div>
                    </li>
                </ul>

                <ul >
                    <li class="ssec-label">电话:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Txt_KEY7" runat="server" CssClass="easyui-validatebox"  validType="length[0,50]" Width="100px"></asp:TextBox>
                        </div>
                    </li>
                </ul>--%>

                <ul>
                    <li class="ssec-label">单位性质:</li>
                    <li>
                        <div>
                            <asp:DropDownList ID="Ddl_CRMPROPERTY" runat="server">
                                <asp:ListItem Text="法人" Value="法人" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="其他组织" Value="其他组织"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                </ul>

                <%--<ul>
                    <li class="ssec-label">客户类型:</li>
                    <li>
                        <div>
                            <asp:DropDownList ID="Ddl_CRMKIND" runat="server">
                                <asp:ListItem Text="东营市内" Value="东营市内" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="山东省内" Value="东营市外"></asp:ListItem>
                                <asp:ListItem Text="山东省外" Value="东营市外"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                </ul>--%>
               <%-- <ul>
                    <li class="ssec-label">客户维护人:</li>
                    <li>
                        <div>
                            <uc1:UserSelectControl runat="server" ID="Ddl_CRMUSER" Required="false" />
                        </div>
                    </li>
                </ul>--%>
                <ul>
                    <li class="ssec-label">附&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;件:</li>
                    <li>
                        <div>
                            <uc1:PopWinUploadMuti runat="server" ID="Txt_SCFJ"  Ext="Custom" Required="false"  />
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label">添加日期:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Tb_ADDDATE" runat="server" CssClass="easyui-datebox" editable="false"></asp:TextBox>
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
