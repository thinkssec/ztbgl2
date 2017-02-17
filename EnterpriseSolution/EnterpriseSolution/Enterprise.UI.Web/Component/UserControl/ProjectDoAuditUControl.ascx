<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectDoAuditUControl.ascx.cs" 
    Inherits="Enterprise.UI.Web.Component.UserControl.ProjectDoAuditUControl" %>

<%@ Register Src="~/Component/UserControl/EHtmlEditor.ascx" TagPrefix="uc1" TagName="EHtmlEditor" %>
<%@ Register Src="~/Component/UserControl/PopWinUploadMuti.ascx" TagPrefix="uc1" TagName="PopWinUploadMuti" %>

<div id="content" class="ssec-form">
    <div class="ssec-group ssec-group-hasicon">
        <div class="icon-form">
        </div>
        <span>我的审核-操作面板</span>
    </div>
    <ul>
        <li class="ssec-label">我的审核意见:</li>
        <li>
            <div>
                <asp:RadioButtonList ID="Txt_CHECKRESULT" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="同意" Value="1" Selected="True"></asp:ListItem>
                    <%--<asp:ListItem Text="修改后同意" Value="2"></asp:ListItem>--%>
                    <asp:ListItem Text="不同意" Value="0"></asp:ListItem>
                </asp:RadioButtonList><br />
                <uc1:ehtmleditor runat="server" id="Txt_CHECKOPINION" width="500" height="180" MaxLength="500" tools="noUpload" ToolString="mini" required="true" invalidMessage="审核意见不能为空!且要少于500字!" />
            </div>
        </li>
    </ul>
   <%-- <ul>
        <li class="ssec-label">审核意见稿:</li>
        <li>
            <div>
                <uc1:PopWinUploadMuti runat="server" ID="Txt_CHECKATTCH" Muti="false" />
            </div>
        </li>
    </ul>
    <ul runat="server" id="trscore">
        <li class="ssec-label">质量得分:</li>
        <li>
            <div>
                <asp:TextBox ID="Txt_CHECKSCORE" runat="server" CssClass="easyui-numberbox" required="true" Text="100"
                    missingMessage="必填项" min="0" Max="100"></asp:TextBox>
            </div>
        </li>
    </ul>--%>
</div>
<script type="text/javascript">
    //校验当前页的输入项是否正确
    function checkInputForm() {
        try {
            var v = $('#form1').form('validate') &&
                EHtmlEditor('<%=MyOpinionHtmlId%>').validate();
            if (v) {
                //var resultRadio0 = $('#<%//=MyCheckResultId%>_0');//同意
                var resultRadio1 = $('#<%=MyCheckResultId%>_1');//修改同意
                var resultRadio2 = $('#<%=MyCheckResultId%>_2');//不同意
                var opinionVal = $('#<%=MyOpinionHtmlId%>').val();
                if (resultRadio1 && resultRadio2) {
                    if ((resultRadio1.attr("checked") == "checked" ||
                        resultRadio2.attr("checked") == "checked") && opinionVal.indexOf("审核通过") > -1)
                    {
                        //审核意见必须写
                        $.messager.alert('系统提示', "请详细填写审核意见!");
                        return false;
                    }
                }
                if (confirm('确认提交吗？')) {
                    return true;
                }
            }
        }
        catch (e) { }
        return false;
    }
</script>
