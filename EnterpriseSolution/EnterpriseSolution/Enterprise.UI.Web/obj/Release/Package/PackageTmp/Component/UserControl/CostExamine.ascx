<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CostExamine.ascx.cs" Inherits="Enterprise.UI.Web.Component.UserControl.CostExamine" %>
<asp:TextBox ID="TextBox1" runat="server" CssClass="easyui-combotree" Width="312px"></asp:TextBox>
<script>
    $('#<%=TextBox1.ClientID%>').combotree({
        editable: false,
        url: '/Component/UserControl/Json/CostExamine.ashx<%=((!string.IsNullOrEmpty(ProjId))?("?projid="+ProjId):"")%>',
        valueField: 'id',
        textField: 'text',
        required:<%=Required.ToString().ToLower()%>,
        onLoadSuccess:function(){
            $('#Img_Loading').css("display","none");
        },
        onBeforeLoad:function(){
            $('#Img_Loading').css("display","block");
        }
        });

    $(function(){
        $('#<%=TextBox1.ClientID%>').combotree('setValue','<%=Text%>');
    })

</script>
<img id="Img_Loading" style="display:none;" alt="加载中" src="/Resources/Styles/images/loading2_16.gif" border="0" />