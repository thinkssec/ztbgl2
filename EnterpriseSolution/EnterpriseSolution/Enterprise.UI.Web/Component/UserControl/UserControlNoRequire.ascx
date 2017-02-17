<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlNoRequire.ascx.cs" Inherits="Enterprise.UI.Web.Component.UserControl.UserControlNoRequire" %>

<asp:TextBox ID="tbDeptxt" runat="server" CssClass="easyui-combotree"></asp:TextBox>
<asp:TextBox ID="tbUsertxt" runat="server" CssClass="easyui-combobox"></asp:TextBox>
<script>  
    var <%=tbDeptxt.ClientID%>jsondata = <%=DeptJsonData%>;    
    var <%=tbUsertxt.ClientID%>jsondata = <%=UserJsonData%>; 
    var <%=tbDeptxt.ClientID%>selectvalue = '<%=DeptSelectValue%>';
    var <%=tbUsertxt.ClientID%>selectvalue ='<%=UserSelectValue%>';
    $('#<%=tbUsertxt.ClientID%>').combobox({   
        data:<%=tbUsertxt.ClientID%>jsondata,
        valueField: 'id',
        textField: 'text',
        disabled:<%=(!Enabled).ToString().ToLower()%>,
        required:<%=Required.ToString().ToLower()%>,
        editable:false
    });

    $('#<%=tbDeptxt.ClientID%>').combotree({
        editable:false, 
        data: <%=tbDeptxt.ClientID%>jsondata,
        valueField:'id',
        textField:'text',    
        disabled:<%=(!Enabled).ToString().ToLower()%>,
        onSelect:function(rec){            
            var url = '/Component/UserControl/Json/GetUser.ashx?deptid='+rec.id;
            $('#<%=tbUsertxt.ClientID%>').combobox('reload', url);
            $('#<%=tbUsertxt.ClientID%>').combobox('setValue','');
        }
    });
    
    

    $(function(){
        if( <%=tbDeptxt.ClientID%>selectvalue!="")
            $('#<%=tbDeptxt.ClientID%>').combotree('setValue',<%=tbDeptxt.ClientID%>selectvalue);
        if(<%=tbUsertxt.ClientID%>selectvalue!="")
            $('#<%=tbUsertxt.ClientID%>').combobox('setValue',<%=tbUsertxt.ClientID%>selectvalue);
    });

</script>

