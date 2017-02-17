<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocumentEditAndView.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Document.DocumentEditAndView" ValidateRequest="false" %>

<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>
<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function checkForm() {
            var v = $('#form1').form('validate') && EHtmlEditor('<%=this.Tb_DOCOVERVIEW.HtmlId%>').validate();
            return v;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent">首页</a></li>
                    <li>知识库</li>
                    <li class="last">业务文档库</li>
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
        <asp:Panel ID="Panel_Edit" runat="server" Visible="false" Style="height: 460px">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form">
                    </div>
                    <span>业务文档知识库-操作面板</span>
                </div>
                <ul>
                    <li class="ssec-label">文档类别：</li>
                    <li>
                        <div>
                            <asp:DropDownList ID="Ddl_Leibie" runat="server" Width="156px" Height="21px"></asp:DropDownList>
                        </div>
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
                            <uc1:EHtmlEditor runat="server" ID="Tb_DOCOVERVIEW" Width="600" Height="200" MaxLength="1000" Required="true" Tools="full" invalidMessage="文档概述为必填项，且不能超过1000个字！" />
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
                    <%-- <li class="ssec-label">文档添加人:</li>
                    <li>
                        <div>

                            <asp:TextBox ID="Tb_DOCADDUSER" runat="server" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符！"></asp:TextBox>
                        </div>
                    </li>
                    <li style="width: 30px"></li>--%>
                    <li class="ssec-label">文档状态:</li>
                    <li>
                        <div>
                            <asp:DropDownList ID="Ddl_DOCSTATUS" runat="server">
                                <asp:ListItem Value="0">已存档</asp:ListItem>
                                <asp:ListItem Selected="True" Value="1">已转换</asp:ListItem>
                                <asp:ListItem Value="2">不开放</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </li>
                </ul>
                <ul>
                    <asp:LinkButton ID="LnkBtnEdit" CssClass="easyui-linkbutton" iconCls="icon-save" runat="server" OnClientClick="return checkForm();" OnClick="LnkBtnEdit_Click">保存</asp:LinkButton>
                </ul>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel_Detail" runat="server" Visible="false" Style="height: 460px">
            <div id="Div1" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form">
                    </div>
                    <span>业务文档知识库-浏览面板</span>
                </div>

                <table class="project-table" style="width: 100%">
                    <asp:Panel ID="Panel_XMID" runat="server" Visible="false">
                        <tr>
                            <td style="width: 120px;text-align:center;">项目名称</td>
                            <td>
                                <asp:Label ID="Lb_PROJMH" runat="server"></asp:Label></td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <td style="width: 120px;text-align:center;">文档名称</td>
                        <td>
                            <asp:Label ID="Lb_DOCNAME" runat="server"></asp:Label>
                            <br/><br/>
                            预览:<asp:Label ID="Lb_ZXLL" runat="server"></asp:Label>&nbsp;&nbsp;|
                            &nbsp;&nbsp;下载:<asp:Label ID="Lb_XZ" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 120px;text-align:center;">文档类别</td>
                        <td>
                            <asp:Label ID="Lb_LBBH" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;text-align:center;">存档日期</td>
                        <td>
                            <asp:Label ID="Lb_DOCSAVEDATE" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;text-align:center;">文档出处</td>
                        <td>
                            <asp:Label ID="Lb_DOCQUARRY" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;text-align:center;">文档作者</td>
                        <td>
                            <asp:Label ID="Lb_DOCWRITER" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;text-align:center;">文档添加人</td>
                        <td>
                            <asp:Label ID="Lb_DOCADDUSER" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;text-align:center;">文档状态</td>
                        <td>
                            <asp:Label ID="Lb_DOCSTATUS" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="width: 120px;text-align:center;">文档概述</td>
                        <td>
                            <asp:Label ID="Lb_DOCOVERVIEW" runat="server"></asp:Label></td>
                    </tr>
                </table>




                <%--                <ul>
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
                    <li class="ssec-label">文档出处:</li>
                    <li>
                        <div>
                            <asp:Label ID="Lb_DOCQUARRY" runat="server"></asp:Label>
                        </div>
                    </li>
                    </ul>
                <ul>
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
                    </ul>
                <ul>
                    <li class="ssec-label">文档状态:</li>
                    <li>
                        <div>
                            <asp:Label ID="Lb_DOCSTATUS" runat="server"></asp:Label>
                        </div>
                    </li>
                </ul>
                 <ul>
                    <%--<li class="ssec-label">上传附件:</li>--%>
                <%-- <li>
                        <div>
                            <asp:Label ID="Lb_ZXLL" runat="server"></asp:Label>
                        </div>
                    </li>
                     <li>
                        <div>
                            <asp:Label ID="Lb_XZ" runat="server"></asp:Label>
                        </div>
                    </li>
                </ul>--%>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
