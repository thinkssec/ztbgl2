<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="DocumentOfcRecv.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Document.DocumentOfcRecv" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <ul>
                        <li class="first"><a href="/index.aspx" title="首页">
                            <%=Trans("首页")%></a> </li>
                        <li class="last">
                            <%=Trans("公文签收")%>
                        </li>
                    </ul>
            </div>
        </div>

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
                <span><%=Trans("公文明细") %></span>
            </div>

            <table class="ssec-table" style="width: 100%">
                <tr>
                    <td class="ssec-label">
                        <div>
                            <%=Trans("部门/单位")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Dept" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("发布人")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_User" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("标题")%>：<span style="color: red; font-weight: bold;">*</span>
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Title" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top;">

                        <%=Trans("内容")%>：
                        
                    </td>
                    <td>
                        <asp:Label ID="lb_Content" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("附件")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="lb_Files" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        <div class="ssec-label">
                            <%=Trans("签收人")%>：
                        </div>
                    </td>
                    <td>
                        <asp:Label ID="Lb_Rcv" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br/>
            
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span><%=Trans("填写承办要求") %></span>
            </div>
             <ul>
                <li class="ssec-label">

                    <%=Trans("承办要求")%>：
                    
                </li>
                 <li>
                     <asp:TextBox ID="Txt_REQUIREMENT" runat="server" Width="300" Height="50" TextMode="MultiLine"></asp:TextBox>
                     </li>
             </ul>
             <ul>
                <li class="ssec-label">

                    <%=Trans("要求完成日期")%>：
                    
                </li>
                 <li>
                     <asp:TextBox ID="t_Time" runat="server" CssClass="easyui-datebox"></asp:TextBox>
                     </li>
             </ul>
             <ul>
                <li class="ssec-label">

                    <%=Trans("承办人")%>：
                    
                </li>
                 <li>
                     <uc1:UserSelectControl runat="server" ID="single_ORGANIZER" Required="true" />
                     </li>
             </ul>
             <ul>
                <li class="ssec-label">&nbsp;              
                </li>
                <li>
                    <%-- <asp:Button ID="Button1" iconCls="icon-save" CssClass="easyui-linkbutton" 
                        runat="server" Text="保存" OnClick="BtnSave_OnClick" OnClientClick="return checkInputForm();"/>--%>


                    <asp:LinkButton ID="LinkButton1" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnRecv_OnClick" iconCls="icon-save">只签收</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" type="submit" runat="server" OnClientClick="return checkInputForm();"
                        CssClass="easyui-linkbutton" OnClick="BtnToOrgn_OnClick" iconCls="icon-save">承办提交</asp:LinkButton>

                    <script type="text/javascript">
                        function checkInputForm() {
                            var v = $('#form1').form('validate');
                            return v;
                            //return v && confirm("您确定要签收吗?");
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
