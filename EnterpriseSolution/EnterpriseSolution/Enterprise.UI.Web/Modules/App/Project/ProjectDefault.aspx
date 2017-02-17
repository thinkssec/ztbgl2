<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDefault.aspx.cs" 
    Inherits="Enterprise.UI.Web.Modules.App.Project.ProjectDefault" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>项目运行</title> 
    <%--IE Mode -- %>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <%--icon--%>              
    <link rel="stylesheet" href="/Resources/OA/easyui1.32/themes/icon.css">             
    <%--default--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/default/easyui.css" title="default"/> 
    <link rel="Stylesheet" href="/Resources/OA/site_skin/default/site.main.css" title="default"/>  
    
    
    <%--green--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/green/easyui.css" title="green"/>
    <link rel="Stylesheet" href="/Resources/OA/site_skin/green/site.main.css" title="green"/>        
     
   <%-- metro--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/metro/easyui.css" title="metro"/> 
    <link rel="Stylesheet" href="/Resources/OA/site_skin/metro/site.main.css" title="metro"/>        

    <%--bootstrap--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/bootstrap/easyui.css" title="bootstrap"/> 
    <link rel="Stylesheet" href="/Resources/OA/site_skin/bootstrap/site.main.css" title="bootstrap"/>        

    <%--gray--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/gray/easyui.css" title="gray"/> 
    <link rel="Stylesheet" href="/Resources/OA/site_skin/gray/site.main.css" title="gray"/>        

    <%--script--%>  
    <script type="text/javascript" src="/Resources/OA/jquery/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/easyui1.32/jquery.easyui.min.js"></script>  
    <script type="text/javascript" src="/Resources/OA/easyui1.32/locale/easyui-lang-zh_CN.js"></script> 

    <script type="text/javascript" src="/Resources/OA/site_skin/scripts/Base.js"></script>
    <script type="text/javascript" src="/Resources/OA/site_skin/scripts/Common.js"></script>      
    <%--switch--%>
    <script type="text/javascript" src="/Resources/OA/site_skin/scripts/switch.js"></script> 
    <%--Editor--%>

    <script type="text/javascript" lang="ja">
        var treedata = '/Component/UserControl/Json/projectrunningTree.ashx?ProjectId=<%=ProjectId%>';
        var index = 0;
         function addTab(url, title) {

             var tab = $('#main').tabs('getTab',1); 

             if(tab!=null)
             {
                 $('#main').tabs('close',tab.panel('options').title);
             }
            $('#main').tabs('add', {
                title: title,
                content: "<iframe Scrolling=\"yes\" Frameborder=\"0\" Src=\"" + url + "\" Style=\"width:100%;height:98%;\"></iframe>",
                iconCls: 'icon-project7',
                closable: false
            });
           }
        function refresh() {
            var currTab = $('#main').tabs('getSelected'); //获得当前tab
            if (currTab) {
                var url = $(currTab.panel('options').content).attr('src');
                var title = currTab.panel('options').title;
                $('#main').tabs('close', title);
                addTab(url, title);
            }
        }
        $(function () {
            addTab('/Modules/App/Project/ProjectView.aspx?ProjectId=<%=ProjectId %>&Day=<%=DateTime.Now.ToShortDateString()%>', '项目动态');
            //addTab('/Modules/App/Project/ProjectInfo.aspx?ProjectId=<%=ProjectId %>','项目信息');
        })
        function ShowProgress() {
            //var pId = "<%//=ProjectId%>";
            //alert(pId);
            $('#progressWinDiv').window('open');
            //$('#progressWinDiv').html("<iframe Scrolling=\"yes\" Frameborder=\"0\" Src=\"\" Style=\"width:98%;height:97%;\"></iframe>");
            //openwin('progressWinDiv', 'ProjectProgress.aspx?ProjectId=' + pId);
        }
        $(function () {
            $('#progressTable').treegrid({
                title: '',
                iconCls: 'icon-ok',
                width: 565,
                height: 450,
                rownumbers: true,
                animate: true,
                collapsible: true,
                fitColumns: true,
                url: 'ProjectProgressHandler.ashx?ProjectId=<%=ProjectId %>',
                idField: 'id',
                treeField: 'name',
                showFooter: true,
                rowStyler: function (row) {
                    if (row.name == "总进度") {
                        return 'background:#ccffff;color:#000000';
                    }
                },
                columns: [[
	                { field: 'name', title: '节点名称', width: 260 },
					{ field: 'progress', title: '当前进度', width: 220,
					    formatter: function (value) {
					        if (value || value == '0') {
					            var s = '<div style="width:100%;background:#fff;border:1px solid #ccc">' +
						    			'<div style="width:' + value + '%;background:#99ff00">' + value + '%</div></div>';
					            //alert("tempV==" + tempV + "," + ss.length + "," + ss[0]);
					            return s;
					        } else {
					            return '';
					        }
					    }
					}
                ]],
                onLoadSuccess: function () {
                    $.ajax({
                        type: "post",
                        url: "/Modules/App/Project/ProjectProgressHandler.ashx?ProjectId=<%=ProjectId %>&ShowPV=1",
                        datatype: "text",
                        async: true,
                        success: function (result) {
                            //重新加载进度值
                            //alert(result);
                            $('#progressDiv').progressbar('setValue', result);
                        }
                    });
                },
                onDblClickRow: function () {
                    $('#progressWinDiv').window('close');
                }
	        });
        });
    </script>
</head>
<body  class="easyui-layout">           
    <div data-options="region:'north',border:false" style="height:42px;padding:5px;" class="projectdefaultbg">
        <div class="projectdefault-topleft">
            <span class="projectdefault-name">项目名称：<%=ProjectModel.PROJNAME %>&nbsp;&nbsp;&nbsp;&nbsp;</span>
            <span class="projectdefault-manager">项目负责人：<%=Enterprise.Service.Basis.Sys.SysUserService.GetUserName(ProjectModel.ProjectManager) %></span>
        </div>
        <div class="projectdefault-topright">
            <a href="#" onclick="addTab('ProjectContentChange.aspx?ProjectId=<%=ProjectId%>', '项目变更')" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-projectp1'">项目变更</a> 
            <a href="#" onclick="addTab('ProjectIncomeList.aspx?ProjectId=<%=ProjectId%>', '项目收入')" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-projectp2'">项目收入</a> 
            <a href="#" onclick="addTab('ProjectCost.aspx?ProjectId=<%=ProjectId%>', '项目成本')" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-projectp3'">项目成本</a>
            <a href="#" onclick="addTab('ProjectCommunication.aspx?ProjectId=<%=ProjectId%>', '沟通记录')" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-projectp4'">沟通记录</a>
            <a href="#" onclick="addTab('../../Common/EntDisk/ProjectTemplateList.aspx', '标准模版')" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-projectp5'">标准模版</a>
        </div>
        
    </div>
	<div data-options="region:'west',split:true,title:'项目运行'" style="width:210px;padding:10px;">
        <ul id="ProjectRunningTree" class="easyui-tree" data-options="url:treedata,animate:true,lines:true,onClick: function (node) 
            {if (node.attributes.url != '#' && node.attributes.url != '') {  
                         addTab(node.attributes.url, node.text);
                     }}"></ul>
	</div>
    <div data-options="region:'center',title:''">
                <div  id="main" class="easyui-tabs" style="width:99%;height:auto;padding:0px;"	data-options="iconCls:'icon-save',collapsible:false,minimizable:false,maximizable:false,fit:true,closable:false,tools:'#tab-tools',border:false"  >
            <!--工作区-->            
    </div>
        <div id="tab-tools" style="border-right:none; border-top:none;">  
         <a href="javascript:void(0)"  class="easyui-linkbutton" plain="true" data-options="plain:true,iconCls:'icon-reload'" onclick="refresh()"></a>           
    </div>
    </div>
	<div data-options="region:'south',border:false" style="height:40px;padding:10px; overflow:hidden;" class="projectdefaultbg">
        <div style="float:left; padding-top:4px;">项目进度：</div><div id="progressDiv" class="easyui-progressbar" style="width:300px;cursor:pointer;color:red; text-decoration:underline;" data-options="value:0" onclick="ShowProgress();">
        </div>
        <%-- 进度显示窗口 --%>
        <div id="progressWinDiv" data-options="title:'项目进度(双击可关闭)',collapsible:false,minimizable:false,maximizable:false,draggable:true,resizable:false,inline:false" class="easyui-window" style="width:578px;height:485px;overflow:hidden" closed="true" modal="true">
            
                <!--项目进度详单-->   
	            <table id="progressTable"></table>
           
        </div>
	</div>
</body>
</html>