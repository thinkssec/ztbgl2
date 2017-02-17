<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MutiUserSelectControl.ascx.cs" Inherits="Enterprise.UI.Web.Component.UserControl.MutiUserSelectControl" %>
<div id="display_usersName" runat="server"  style="display:none;padding:5px;background-color:#e8f3fa;line-height:23px" ></div>
<asp:TextBox ID="tb_Muti" runat="server"></asp:TextBox>
&nbsp;<a href="#" onclick="<%=tb_Muti.ClientID%>clearComboTree('<%=tb_Muti.ClientID%>')" style="text-decoration:underline">清除</a>
&nbsp;/&nbsp;<a href="#" onclick="<%=tb_Muti.ClientID%>loadUserByZhiwu()" style="text-decoration:underline">按职务</a>
&nbsp;/&nbsp;<a href="#" onclick="<%=tb_Muti.ClientID%>loadUserByDept()" style="text-decoration:underline">按部门</a>&nbsp;/&nbsp;
<asp:HiddenField ID="tb_Muti_Value" runat="server"></asp:HiddenField>
<span id="display_usersCount" runat="server" style="cursor:pointer;"></span>

<script>   
    
    $(function(){   
        
        $('#<%=tb_Muti.ClientID%>').combotree({
            url: '/Component/UserControl/Json/GetUserTree.ashx',
            required: <%=Required.ToString().ToLower()%>,
            multiple: <%=Muti.ToString().ToLower()%>,        
            width: 300,
            onlyLeafCheck:false,
            editable:false,
            lines:true,
            onChange:function(o,n){
                //更新value隐藏域                
                <%=tb_Muti.ClientID%>syncSelectValue(n);                 
            },
            onCheck: function(e, node){                
                <%=tb_Muti.ClientID%>showUsersName();
            }

        });    
        //设置初始值
        var mutivalue = '<%=Value%>';
        if(mutivalue!=''){
            $('#<%=tb_Muti.ClientID%>').combotree('setValues',mutivalue.split(','));
        }      
        //为人数增加toggle属性
        $('#<%=display_usersCount.ClientID %>').click(function(){$('#<%=display_usersName.ClientID%>').toggle('slow');});
        //getSelectedUsers();
    });
    function <%=tb_Muti.ClientID%>syncSelectValue(){
        //获取值
        var val= $('#<%=tb_Muti.ClientID%>').combotree('getValues'); 
        //正则匹配
        //var re = /\bd-\b/;    
        var arrayObj = new Array();
        for(var i=0;i<val.length;i++){                        
            if(val[i].indexOf("d")==0)
            {              
                //需要Base库支持
                arrayObj.push(val[i]);
            }               
        }
        for(var i=0;i<arrayObj.length;i++)
        {
            val.remove(arrayObj[i]);
        }
        //同步到隐藏域
        $('#<%=tb_Muti_Value.ClientID%>').val(val);
        //设置已选人数        
        $('#<%=display_usersCount.ClientID%>').html('<span style="color:red;text-decoration:underline" >已选 '+val.length+' 人</span>');  
    }

    //清除所选
    function <%=tb_Muti.ClientID%>clearComboTree(id){    
        $('#'+id).combotree('clear');
    }    
    //向人员面板追加选项
    function <%=tb_Muti.ClientID%>showUsersName(){   
        $('#<%=display_usersName.ClientID%>').html($('#<%=tb_Muti.ClientID%> ').combotree('getText'));       
    }

    function <%=tb_Muti.ClientID%>loadUserByZhiwu()
    {
        <%=tb_Muti.ClientID%>clearComboTree('<%=tb_Muti.ClientID%>');
        $('#<%=tb_Muti.ClientID%>').combotree('reload','/Component/UserControl/Json/GetUserTree.ashx?zhiwu=1');
    }

    function <%=tb_Muti.ClientID%>loadUserByDept()
    {
        <%=tb_Muti.ClientID%>clearComboTree('<%=tb_Muti.ClientID%>');
        $('#<%=tb_Muti.ClientID%>').combotree('reload','/Component/UserControl/Json/GetUserTree.ashx');
    }
        
</script>