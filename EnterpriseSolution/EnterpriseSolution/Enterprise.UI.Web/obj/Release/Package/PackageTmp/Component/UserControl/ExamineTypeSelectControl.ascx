<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ExamineTypeSelectControl.ascx.cs" 
    Inherits="Enterprise.UI.Web.Component.UserControl.ExamineTypeSelectControl" %>

<asp:TextBox ID="tbExamineMainType" runat="server" CssClass="easyui-combobox"></asp:TextBox>
<asp:TextBox ID="tbExamineSubType" runat="server" CssClass="easyui-combotree"></asp:TextBox>
<img id="Img_Loading" style="display:none;" alt="加载中" src="/Resources/Styles/images/loading2_16.gif" border="0" />
<asp:HiddenField ID="Hid_Bjdm" runat="server"></asp:HiddenField>
<script type="text/javascript">  

    var <%=tbExamineMainType.ClientID%>jsondata = <%=MainTypeJsonData%>;    
    var <%=tbExamineSubType.ClientID%>jsondata = <%=BjdmJsonData%>; 
    var <%=tbExamineMainType.ClientID%>selectvalue = '<%=MainTypeSelectValue%>';
    var <%=tbExamineSubType.ClientID%>selectvalue ='<%=SubTypeSelectValue%>';
    $('#<%=tbExamineMainType.ClientID%>').combobox({   
        data:<%=tbExamineMainType.ClientID%>jsondata,
        valueField: 'id',
        textField: 'text',
        disabled:<%=(!Enabled).ToString().ToLower()%>,
        editable:false,
        onSelect:function(rec){            
            var url = '/Component/UserControl/Json/ExamineTypeHandler.ashx?sjdm=' + rec.id + '&kind=<%=Kind%>';
            $('#<%=tbExamineSubType.ClientID%>').combotree('reload', url);
            $('#<%=tbExamineSubType.ClientID%>').combotree('setValue','');
            $('#Img_Loading').css("display","block");
        }
    });

    $('#<%=tbExamineSubType.ClientID%>').combotree({
        data: <%=tbExamineSubType.ClientID%>jsondata,
        valueField:'id',
        textField:'text',    
        disabled:<%=(!Enabled).ToString().ToLower()%>,
        required:<%=Required.ToString().ToLower()%>,
        multiple: true,        
        width: 300,
        onlyLeafCheck:false,
        editable:false,
        lines:true,
        onChange:function(o,n){
            //获取值
            var val= $('#<%=tbExamineSubType.ClientID%>').combotree('getValues');
            //同步到隐藏域
            $('#<%=Hid_Bjdm.ClientID%>').val(val);
            if (val.length > 1 && 
                confirm("您选择的设施类型有多个!需要批量导入到任务策划吗?")) {
                __doPostBack('ctl00$ProjectPH$BtnSave');
            }
        },
        onLoadSuccess:function(){
            $('#Img_Loading').css("display","none");
        },
        onShowPanel: function() {  
            $(this).combobox('panel').height(400); 
        }
    });

    $(function(){
        if(<%=tbExamineMainType.ClientID%>selectvalue != "")
            $('#<%=tbExamineMainType.ClientID%>').combobox('setValue',<%=tbExamineMainType.ClientID%>selectvalue);
        if(<%=tbExamineSubType.ClientID%>selectvalue != "")
            $('#<%=tbExamineSubType.ClientID%>').combotree('setValue',<%=tbExamineSubType.ClientID%>selectvalue);
    });
</script>