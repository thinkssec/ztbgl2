<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EHtmlEditor.ascx.cs" Inherits="Enterprise.UI.Web.Component.UserControl.EHtmlEditor" %>
<asp:TextBox ID="tb_htmleditor" TextMode="MultiLine" runat="server"></asp:TextBox>
<script type="text/javascript">
    <%--
    var maxLength = parseInt("<%//=MaxLength%>");
    $.extend($.fn.validatebox.defaults.rules, {
        inputCheck: {
            validator: function (value, param) {
                if (value && value.length > maxLength) {
                    return false;
                }
                return true;
            }, 
            message: '<%//=ToolTipName%>输入内容不能超过<%//=MaxLength%>字!' 
        }
    }); 
    --%>
    $(function () {
        $('#<%=tb_htmleditor.ClientID%>').xheditor({
            upLinkUrl: "/Resources/OA/upload/upload.aspx",
            upLinkExt: "zip,rar,txt,pdf,docx,doc,xls,xlsc,ppt,pptx,avi,rmvb,wmv",
            upImgUrl: "/Resources/OA/upload/upload.aspx",
            upImgExt: "jpg,jpeg,gif,png,bmp",
            tools: '<%=ToolString.ToString()%>',
            skin: 'default',
            width: <%=Width%>,
            height: <%=Height%>,
            onUpload: <%=OnUpladFunc%>
        });
        $('#<%=tb_htmleditor.ClientID%>').attr('required', '<%=Required.ToString().ToLower() %>');
        $('#<%=tb_htmleditor.ClientID%>').attr('maxlength', '<%= MaxLength %>');
        $('#<%=tb_htmleditor.ClientID%>').attr('invalidMessage', '<%= invalidMessage %>');
        
    });
        <%--
            //完成对文本控件的检测
            function Check<%=tb_htmleditor.ClientID%>() {
                var maxLength = parseInt("<%=MaxLength%>");
                var required = "<%=Required.ToString().ToLower()%>";
                var editorID = "<%=tb_htmleditor.ClientID%>";
                var editorText = $("#" + editorID).val();
                if (required == "true" &&
                    (editorText == "" || editorText == "<p></p>")) {
                    $.messager.alert('系统提示', '‘<%=ToolTipName%>’输入内容不能为空!');
                    return false;
                }
                else if (editorText.length > maxLength) {
                    $.messager.alert('系统提示', '‘<%=ToolTipName%>’输入内容不能超过<%=MaxLength%>字!');
                    return false;
                }
                return true;
            }
            --%>
</script>
