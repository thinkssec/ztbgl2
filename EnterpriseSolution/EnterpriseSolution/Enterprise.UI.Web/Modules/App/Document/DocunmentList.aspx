<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocunmentList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Document.DocunmentList" %>

<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Import Namespace="Enterprise.Component.Infrastructure" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #top {
            /*top: 10px;*/
            position: absolute;
        }

        #logo {
            margin-left: 20px;
            float: left;
            display: block;
        }

        #searchdiv {
            margin-top: 10px;
            margin-left: 35px;
            float: left;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent"><%=Trans("首页") %></a></li>
                    <li>知识库</li>
                    <li class="last">业务文档库</li>
                </ul>
            </div>
        </div>
        <div id="main-tool" style="height: 50px">
            <div id="top" sizcache="0" sizset="0">
                <div id="logo" sizcache="0" sizset="0">
                    <a href="DocunmentList.aspx">
                        <img alt="文档库" src="../../../Resources/OA/site_skin/default/img/DocPic.jpg" border="0" /></a>
                </div>
                <div id="searchdiv">
                    文档类别:
                <asp:DropDownList ID="Ddl_Kind" runat="server"></asp:DropDownList>
                    名称：<asp:TextBox ID="s_Key" runat="server"></asp:TextBox>
                    <asp:LinkButton ID="Bt_Search" runat="server" Text="查询" CssClass="easyui-linkbutton"
                        plain="false" OnClick="Bt_Search_Click"></asp:LinkButton>
                </div>
            </div>
            <div>
                <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
                </Ent:HeadMenuWeb>
            </div>

        </div>
    </div>
    <div data-options="region:'center'">
        <div class="easyui-layout" style="height: 550px; border: none">
            <div data-options="region:'west',split:true" style="width: 180px;">
                <span style="top: 50px; margin-top: 100px"></span>
                <asp:TreeView ID="TreeView1" runat="server" ImageSet="Inbox" BorderWidth="0px" CssClass="TreeviewStyle" ShowLines="True" />
            </div>
            <div data-options="region:'center'" style="padding: 5px">
                <div class="main-gridview">
                    <%--<div class="main-gridview-title">
                        <%-- 项目类型:
                <asp:DropDownList ID="Ddl_Kind" runat="server"></asp:DropDownList>--%>
                    <%-- 项目名称：<asp:TextBox ID="s_Key" runat="server"></asp:TextBox>
                        <asp:LinkButton ID="Bt_Search" runat="server" Text="查询" CssClass="easyui-linkbutton"
                            plain="false" OnClick="Bt_Search_Click"></asp:LinkButton>
                    </div>--%>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="15" AutoGenerateColumns="False"
                        Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="DOCID,LBBH">
                        <Columns>
                            <asp:TemplateField HeaderText="序号">
                                <ItemTemplate>
                                    <%#(Container.DataItemIndex+1) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="项目名称">
                                <ItemTemplate>
                                    <%#Enterprise.Service.App.Project.ProjectInfoService.GetProjectName((string)Eval("PROJID")) %>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="文档名称" HeaderStyle-Width="240px">
                                <ItemTemplate>
                                    <a style="text-decoration: underline;" href="DocumentEditAndView.aspx?Cmd=View&DId=<%#Eval("DOCID") %>" target="_self"><%#Eval("DOCNAME") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="文档类别">
                                <ItemTemplate>
                                    <%#Enterprise.Service.App.Document.DocumentKindService.GetKindName((string)Eval("LBBH")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="附件">
                                <ItemTemplate>
                                    <%#Eval("DOCPATH").ToAttachHtmlByOne() %>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField HeaderText="文档作者" DataField="DOCWRITER" />
                            <asp:BoundField DataField="DOCSAVEDATE" HeaderText="存档日期" DataFormatString="{0:yyyy-MM-dd}" />
                            <asp:TemplateField HeaderText="文档状态">
                                <ItemTemplate>
                                    <%#Enterprise.Service.App.Document.DocumentProjService.GetDOCSTATUS((int)Eval("DOCSTATUS")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%#GetCommandBtn((string)Eval("DOCID"),(string)Eval("LBBH"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <%-- <asp:Panel ID="Panel_Edit" runat="server" Visible="false">
                    <div id="contents" class="ssec-form">
                        <div class="ssec-group ssec-group-hasicon">
                            <div class="icon-form">
                            </div>
                            <span>业务文档知识库-操作面板</span>
                        </div>
                        <ul>
                            <li class="ssec-label">项目ID：</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Tb_PROJID" runat="server" required="true" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符" Width="150px"></asp:TextBox>
                                </div>
                            </li>
                            <li style="width: 30px"></li>
                            <li class="ssec-label">类别编号：</li>
                            <li>
                                <div>
                                    <asp:DropDownList ID="Ddl_Leibie" runat="server" Width="86px"></asp:DropDownList>
                                    <%-- <asp:TextBox ID="Tb_PROJMH" runat="server" required="true" missingMessage="必填项" CssClass="easyui-validatebox" validType="length[0,100]" invalidMessage="不能超过25个字符" Width="150px"></asp:TextBox>--%>
                <%-- </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">文档名称：</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Tb_DOCNAME" runat="server" required="true" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符" Width="150px"></asp:TextBox>
                                </div>
                            </li>
                            <li style="width: 30px"></li>
                            <li class="ssec-label">存档日期:</li>
                            <li>
                                <div>
                                    <asp:TextBox ID="Tb_DOCSAVEDATE" runat="server" CssClass="easyui-datebox" editable="false" required="true"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">文档概述:</li>
                            <li>
                                <div>
                                    <uc1:EHtmlEditor runat="server" ID="Tb_DOCOVERVIEW" Width="600" Height="200" MaxLength="1000" Required="true" Tools="full" invalidMessage="内容描述为必填项，且不能超过1000个字！" />
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">上传附件:</li>
                            <li>
                                <div>
                                    <uc1:PopWinUploadMuti runat="server" ID="Tb_DOCPATH" Required="false" Muti="false" />
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">文档出处:</li>
                            <li>
                                <div>

                                    <asp:TextBox ID="Tb_DOCQUARRY" runat="server" CssClass="easyui-validatebox" validType="length[0,100]" invalidMessage="不能超过100个字符！"></asp:TextBox>
                                </div>
                            </li>
                            <li style="width: 30px"></li>
                            <li class="ssec-label">文档作者:</li>
                            <li>
                                <div>

                                    <asp:TextBox ID="Tb_DOCWRITER" runat="server" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符！"></asp:TextBox>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">文档添加人:</li>
                            <li>
                                <div>

                                    <asp:TextBox ID="Tb_DOCADDUSER" runat="server" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符！"></asp:TextBox>
                                </div>
                            </li>
                            <li style="width: 30px"></li>
                            <li class="ssec-label">文档状态:</li>
                            <li>
                                <div>
                                    <asp:DropDownList ID="Ddl_DOCSTATUS" runat="server">
                                        <asp:ListItem Selected="True" Value="0">已存档</asp:ListItem>
                                        <asp:ListItem Value="1">已转换</asp:ListItem>
                                        <asp:ListItem Value="2">不开放</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <asp:LinkButton ID="LnkBtnEdit" CssClass="easyui-linkbutton" iconCls="icon-save" runat="server" OnClientClick="return checkInputForm();" OnClick="LnkBtnEdit_Click">保存</asp:LinkButton>
                        </ul>
                    </div>
                </asp:Panel>--%>
                <%--<asp:Panel ID="Panel_Detail" runat="server" Visible="false">
                    <div id="Div1" class="ssec-form">
                        <div class="ssec-group ssec-group-hasicon">
                            <div class="icon-form">
                            </div>
                            <span>业务文档知识库-浏览面板</span>
                        </div>
                        <ul>
                            <li class="ssec-label">项目ID：</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_PROJMH" runat="server"></asp:Label>
                                </div>
                            </li>
                            <li style="width: 30px"></li>
                            <li class="ssec-label">类别编号：</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_LBBH" runat="server"></asp:Label>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">文档名称：</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_DOCNAME" runat="server"></asp:Label>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">存档日期:</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_DOCSAVEDATE" runat="server"></asp:Label>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">文档概述:</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_DOCOVERVIEW" runat="server"></asp:Label>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">上传附件:</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_FJ" runat="server"></asp:Label>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">文档出处:</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_DOCQUARRY" runat="server"></asp:Label>
                                </div>
                            </li>
                            <li style="width: 30px"></li>
                            <li class="ssec-label">文档作者:</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_DOCWRITER" runat="server"></asp:Label>
                                </div>
                            </li>
                        </ul>
                        <ul>
                            <li class="ssec-label">文档添加人:</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_DOCADDUSER" runat="server"></asp:Label>
                                </div>
                            </li>
                            <li style="width: 30px"></li>
                            <li class="ssec-label">文档状态:</li>
                            <li>
                                <div>
                                    <asp:Label ID="Lb_DOCSTATUS" runat="server"></asp:Label>
                                </div>
                            </li>
                        </ul>
                    </div>
                </asp:Panel>--%>
            </div>
        </div>
    </div>
</asp:Content>
