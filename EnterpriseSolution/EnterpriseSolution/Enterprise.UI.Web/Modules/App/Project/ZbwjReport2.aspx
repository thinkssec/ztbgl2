<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false"
    CodeBehind="ZbwjReport2.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.ZbwjReport2" %>


<%@ Register Src="~/Component/UserControl/EDropDownList.ascx" TagPrefix="uc1" TagName="EDropDownList" %>
<%@ Register Src="~/Component/UserControl/UserSelectControl.ascx" TagPrefix="uc1" TagName="UserSelectControl" %>
<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>


<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Resources/OA/xheditor-1.1.14/xheditor-1.1.14-zh-cn.min.js"></script>
    <script>
        function checkForm() {
            var rpt = $('#ProjectPH_hid').val();
            var nd = $('#Ddl_KEY1').val();
            var lsh = $("[name='ctl00$ProjectPH$lb_KEY2']").val();
            var p = "/Component/BF/GetJcbgLsh.ashx?Rptid=" + rpt + "&Nd=" + nd + "&Lsh=" + lsh;
            var ccc = 0;
            $.ajax({
                type: "post", url: p, datatype: "text", async: false,
                success: function (result) {
                    ccc = result;
                }
            });
            if (ccc > 0) {
                alert("改编号被已经使用");
                return false;
            }
            return $('#form1').form('validate');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent">首页</a></li>
                    <li>招标文件编制</li>
                    <li class="last">招标文件补充说明</li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <asp:HiddenField ID="hid" runat="server" />
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>附件列表</span>
            </div>
        </div>
        <div class="main-gridview">
            <%--数据表格开始--%>
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="RPTID" AutoGenerateColumns="false" Width="100%">
                <Columns>

                    <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%#(Container.DataItemIndex + 1)%>
                        </ItemTemplate>
                        <HeaderStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="附件名">
                        <ItemTemplate>
                            <%#(string)Eval("RPTNAME")%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="SUBMITDATE" HeaderText="文件日期"></asp:BoundField>
                    <asp:TemplateField HeaderText="附件">
                        <ItemTemplate>
                            <%#Eval("ATTACHMENT").ToAttachHtmlByOne() %>
                        </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <%#GetCommandBtn(Container.DataItem)%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Panel ID="Pnl_Edit" runat="server" Visible="false">
            <div id="contents" class="ssec-form">
                <div class="ssec-group ssec-group-hasicon">
                    <div class="icon-form">
                    </div>
                    <span>上传附件-操作面板</span>
                </div>
                <ul>
                    <li class="ssec-label">附件名:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Txt_RPTNAME" runat="server" CssClass="easyui-validatebox" validType="length[0,50]" invalidMessage="不能超过50个字！"  Required="true" ></asp:TextBox>
                            
                        </div>
                    </li>
                </ul>

                <ul>
                    <li class="ssec-label">附件:</li>
                    <li>
                        <div>
                            <asp:HiddenField ID="Hid_RPTID" runat="server" ClientIDMode="Static" />
                            <uc1:PopWinUploadMuti runat="server" ID="Txt_ATTACHMENT" Muti="false" Required="true" />
                            <a href="#" onclick="javascript:$('#ProjectPH_Txt_RPTNAME').val($('#ProjectPH_Txt_ATTACHMENT_tb_UploadSingle_TextBox').val().substring(0,$('#ProjectPH_Txt_ATTACHMENT_tb_UploadSingle_TextBox').val().lastIndexOf('.')));">同步</a>
                        </div>
                    </li>
                </ul>


                <%-- 
                <ul>
                    <li class="ssec-label">批准人:</li>
                    <li>
                        <div>
                            <uc1:EDropDownList runat="server" Required="true" ID="Txt_APPROVER" DataUrl="/Component/UserControl/Json/GetHrZige.ashx?where=BGPZR" />
                        </div>
                    </li>
                </ul>
                --%>
                <ul>
                    <li class="ssec-label">备注:</li>
                    <li>
                        <div>
                            <asp:TextBox ID="Txt_MEMO" runat="server" Width="300" CssClass="easyui-validatebox" validType="length[0,100]" invalidMessage="不能超过100个字！"></asp:TextBox>
                        </div>
                    </li>
                </ul>
                <ul>
                    <li class="ssec-label"></li>
                    <li>
                        <div>
                            <asp:LinkButton ID="LinkButton1" CssClass="easyui-linkbutton" iconCls="icon-save" runat="server" OnClick="LinkButton1_Click" OnClientClick="return checkForm()&&showLoading();">提交</asp:LinkButton>
                        </div>
                    </li>
                </ul>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
