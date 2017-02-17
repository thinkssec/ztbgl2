/*
* �ļ�����bf.min.js
* �ļ�������ҵ������ص�����ģ�����������
* �������ڣ�2012.12.17
* ˵����
*/
var ssec = {};
ssec.bf = {};
//��������
var CommonInfo = ssec.bf.CommonInfo = {
    BF_ID:"",//ҵ����ID
    BF_NAME:"",//ҵ��������
    BF_VERSION: 0,//ҵ�����汾
    BF_ROWINDEX:0//����������
};
//������
var BFHandler = ssec.bf.BFHandler = {
    //ѡ��1==��Ϣ���ѷ�ʽ
    selectRemindWay: function () {
        var rows = $('#tt').propertygrid('getRows');
        var msg = ($id('Chk_MSG').checked) ? "MSG," : "";
        var sms = ($id('Chk_SMS').checked) ? "SMS," : "";
        var email = ($id('Chk_EMAIL').checked) ? "EMAIL," : "";
        var v = msg + sms + email;
        if (v != "") {
            v = v.substring(0, v.length - 1);
            var row = rows[CommonInfo.BF_ROWINDEX];
            if (row.field == "REMINDWAY") {
                row.value = v;
                $('#tt').propertygrid('refreshRow', CommonInfo.BF_ROWINDEX);
                $('#dialogDiv').dialog('close');
            }
        }
    },
    //ѡ��2==��·��
    selectFormPath: function () {
        var rows = $('#tt').propertygrid('getRows');
        var row = rows[CommonInfo.BF_ROWINDEX];
        if (row.field == "FORM") {
            row.value = $('#TxtFormPath').val();
            $('#tt').propertygrid('refreshRow', CommonInfo.BF_ROWINDEX);
            $('#dialogDiv').dialog('close');
        }
    },
    //ѡ��3==��Աѡ��
    selectPersonRole: function () {
        var rows = $('#tt').propertygrid('getRows');
        var row = rows[CommonInfo.BF_ROWINDEX];
        var zdry = '', jtjs = '', dtjs = '', cmd = '';
        var nodeId, nodeName, nodeType, nodeDesc;
        if (row.field == "DUTYOFFICER" || row.field == "NOTIFIER") {
            if (row.field == "DUTYOFFICER") {
                cmd = "4";
            }
            else {
                cmd = "5";
            }
            var optLst = $id("SelZdry").options;
            $.each(optLst, function (i, opt) {
                zdry += opt.value + ",";
            });
            optLst = $id("SelJtjs").options;
            $.each(optLst, function (i, opt) {
                jtjs += opt.value + ",";
            });
            optLst = $id("SelDtjs").options;
            $.each(optLst, function (i, opt) {
                dtjs += opt.value + ",";
            });
            nodeDesc = zdry + "-" + jtjs + "-" + dtjs;
            row.value = ((nodeDesc == "--") ? "" : nodeDesc);
            $('#tt').propertygrid('refreshRow', CommonInfo.BF_ROWINDEX);
            $('#dialogDiv').dialog('close');
            $("#SelZdry").empty();
            $("#SelJtjs").empty();
            $("#SelDtjs").empty();
            $("#TxtRoleName").val('');
            $('#SelMethod').combogrid('clear');
            //��������ύ-----------------------------------------------------------------
            $.each(rows, function (i, row) {
                if (row.field == "NODEID") {
                    nodeId = row.value;
                }
                if (row.field == "NODENAME") {
                    nodeName = row.value;
                }
                if (row.field == "NODETYPE") {
                    nodeType = row.value;
                }
            });
            var _Param = "cmd=" + cmd;
            _Param += "&bfid=" + CommonInfo.BF_ID;
            _Param += "&bfversion=" + CommonInfo.BF_VERSION;
            _Param += "&nodeid=" + nodeId;
            _Param += "&nodename=" + nodeName;
            _Param += "&nodetype=" + nodeType;
            _Param += "&nodedesc=" + nodeDesc;
            _Param += "&random=" + Math.floor(Math.random() * 10000 + 1);
            //window.open("BFLoadHandler.ashx?" + _Param);
            $.ajax({
                type: "POST",
                dataType: "html",
                url: "BFLoadHandler.ashx",
                data: encodeURI(_Param),
                success: function (result) {
                    if (result == "" || result == "False") {
                        $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u4fdd\u5b58\u6570\u636e\u51fa\u9519', 'error');
                    }
                    else {
                        $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u6570\u636e\u4fdd\u5b58\u6210\u529f\uff01', 'info');
                    }
                }
            });
        }
    },
    //ѡ��4==������
    selectSubFlowpath: function () {
        var rows = $('#tt').propertygrid('getRows');
        var row = rows[CommonInfo.BF_ROWINDEX];
        if (row.field == "SUBBF") {
            row.value = $('#TxtSubFlowpath').val();
            $('#tt').propertygrid('refreshRow', CommonInfo.BF_ROWINDEX);
            $('#dialogDiv').dialog('close');
        }
    },
    //ѡ��������
    selcData: function (rowIndex, rowData) {
        //$.messager.alert('\u53cb\u60c5\u63d0\u793a', rowIndex + "," + rowData.name + "," + rowData.value, 'info');
        CommonInfo.BF_ROWINDEX = rowIndex;
        var rows = $('#tt').propertygrid('getRows');
        var nodeId, nodeName, nodeType;
        $.each(rows, function (i, row) {
            if (row.field == "NODEID") {
                nodeId = row.value;
            }
            if (row.field == "NODENAME") {
                nodeName = row.value;
            }
            if (row.field == "NODETYPE") {
                nodeType = row.value;
            }
        });
        var row = rows[rowIndex];
        //��Ϣ���ѷ�ʽ
        if (row.field == "REMINDWAY") {
            $('#dialogDiv').dialog('open');
            $('#tabsDiv').tabs('select', '\u6d88\u606f\u63d0\u9192');
            $("#tabDiv1").attr("style", "display:block;");
        }
        //��·��
        else if (row.field == "FORM") {
            var _Param = "cmd=3";
            _Param += "&bfid=" + CommonInfo.BF_ID;
            _Param += "&bfversion=" + CommonInfo.BF_VERSION;
            _Param += "&nodeid=" + nodeId;
            _Param += "&nodename=" + nodeName;
            _Param += "&nodetype=" + nodeType;
            _Param += "&random=" + Math.floor(Math.random() * 10000 + 1);
            //window.open('BFLoadHandler.ashx?' + encodeURI(_Param));
            $('#dialogDiv').dialog('open');
            $('#tabsDiv').tabs('select', '\u8868\u5355\u8def\u5f84');
            $("#tabDiv2").attr("style", "display:block;");
            $('#TxtFormPath').val(row.value);
            $('#formTable').treegrid({
                title: '\u8868\u5355\u9009\u62e9',
                iconCls: 'icon-save',
                width: '100%',
                height: '290',
                nowrap: false,
                rownumbers: true,
                animate: true,
                collapsible: true,
                url: 'BFLoadHandler.ashx?' + encodeURI(_Param),
                idField: 'code',
                treeField: 'code',
                frozenColumns: [[
	                { title: '\u6a21\u5757\u7f16\u7801', field: 'code', width: 160,
	                    formatter: function (value) {
	                        return '<span style="color:red">' + value + '</span>';
	                    }
	                }
				]],
                columns: [[
					{ field: 'name', title: '\u6a21\u5757\u540d\u79f0', width: 120 },
					{ field: 'addr', title: '\u6a21\u5757\u8def\u5f84', width: 270 }
				]],
                onClickRow: function (row) {
                    if (row && row.addr) {
                        $('#TxtFormPath').val(row.addr);
                    }
                }
                //                ,
                //                onLoadSuccess: function (row, data) {
                //                    //$('#formTable').treegrid('collapseAll');
                //                }
            });
        }
        //������
        else if (row.field == "SUBBF") {
            var _Param = "cmd=6";
            _Param += "&bfid=" + CommonInfo.BF_ID;
            _Param += "&bfversion=" + CommonInfo.BF_VERSION;
            _Param += "&nodeid=" + nodeId;
            _Param += "&nodename=" + nodeName;
            _Param += "&nodetype=" + nodeType;
            _Param += "&random=" + Math.floor(Math.random() * 10000 + 1);
            //window.open('BFLoadHandler.ashx?' + encodeURI(_Param));
            $('#dialogDiv').dialog('open');
            $('#tabsDiv').tabs('select', '\u5b50\u6d41\u7a0b');
            $("#tabDiv4").attr("style", "display:block;");
            $('#TxtSubFlowpath').val(row.value);
            $('#subflowpathTable').datagrid({
                title: '\u9009\u62e9\u5b50\u6d41\u7a0b',
                iconCls: 'icon-save',
                width: '100%',
                height: '290',
                nowrap: false,
                striped: true,
                collapsible: true,
                pageSize: 10, //ÿҳ��ʾ�ļ�¼������Ĭ��Ϊ10  
                pageList: [10, 20], //��������ÿҳ��¼�������б�  
                method: 'post',
                url: 'BFLoadHandler.ashx?' + encodeURI(_Param),
                remoteSort: false,
                idField: 'code',
                frozenColumns: [[
                    { field: 'name', title: '\u4e1a\u52a1\u6d41\u540d\u79f0', width: 140, sortable: false }
				]],
                columns: [
				[
	                { field: 'code', title: '\u4e1a\u52a1\u6d41\u7f16\u53f7', width: 80 },
					{ field: 'addr', title: '\u7248\u672c\u53f7', width: 80 },
					{ field: 'col4', title: '\u53d1\u5e03\u65e5\u671f', width: 100 }
				]],
                pagination: true,
                rownumbers: true,
                onClickRow: function (rowIndex, rowData) {
                    if (rowData) {
                        $('#TxtSubFlowpath').val(rowData.code + "-" + rowData.addr);
                    }
                    $('#subflowpathTable').datagrid('clearSelections');
                    $('#subflowpathTable').datagrid('selectRow', rowIndex);
                }
            });
        }
        //������ ֪ͨ��
        else if (row.field == "DUTYOFFICER" || row.field == "NOTIFIER") {
            var _Param = "bfid=" + CommonInfo.BF_ID;
            _Param += "&bfversion=" + CommonInfo.BF_VERSION;
            _Param += "&nodeid=" + nodeId;
            _Param += "&nodename=" + nodeName;
            _Param += "&nodetype=" + nodeType;
            _Param += "&nodedesc=" + row.field;
            _Param += "&random=" + Math.floor(Math.random() * 10000 + 1);
            //window.open('BFLoadHandler.ashx?' + encodeURI(_Param));
            $('#dialogDiv').dialog('open');
            $('#tabsDiv').tabs('select', '\u4eba\u5458\u9009\u62e9');
            $("#tabDiv3").attr("style", "display:block;");
            //��Ա��
            $('#treeControl').tree({
                checkbox: true,
                url: 'BFLoadHandler.ashx?cmd=1&' + encodeURI(_Param)
            });
            //window.open('BFLoadHandler.ashx?cmd=1&' + encodeURI(_Param));
            //�����б�
            $('#SelMethod').combogrid({
                panelWidth: 500,
                idField: 'code',
                textField: 'code',
                fitColumns: true,
                striped: true,
                editable: false,
                pagination: true, //�Ƿ��ҳ  
                rownumbers: true, //���  
                collapsible: false, //�Ƿ���۵���  
                fit: true, //�Զ���С  
                pageSize: 10, //ÿҳ��ʾ�ļ�¼������Ĭ��Ϊ10  
                pageList: [10, 20], //��������ÿҳ��¼�������б�  
                method: 'post',
                url: 'BFLoadHandler.ashx?cmd=0&' + encodeURI(_Param),
                columns: [[
					{ field: 'code', title: 'ID', width: 60 },
                    { field: 'col4', title: '\u65b9\u6cd5\u8bf4\u660e', width: 120 },
                    { field: 'addr', title: '\u65b9\u6cd5\u540d\u79f0', width: 140 },
					{ field: 'name', title: '\u7c7b\u540d\u79f0', width: 160 }
				]]
            });
            $("#SelZdry").empty();
            $("#SelJtjs").empty();
            $("#SelDtjs").empty();
            $("#TxtRoleName").val('');
            $('#SelMethod').combogrid('clear');
            //�ڵ��ɫ����
            _Param += "&cmd=2";
            $.ajax({
                type: "POST",
                dataType: "html",
                url: "BFLoadHandler.ashx",
                data: encodeURI(_Param),
                success: function (result) {
                    //˳��ָ����1,ָ����2|��̬��ɫ1,��̬��ɫ2|��̬��ɫ1,��̬��ɫ2
                    var roles = result.split("|");
                    for (var j = 0; j < roles.length; j++) {
                        var ss = roles[j].split(",");
                        if (ss.length > 1) {
                            for (var i = 1; i < ss.length; i++) {
                                if (ss[i] == "") continue;
                                switch (ss[0]) {
                                    case "ZDRY":
                                        $("#SelZdry").append("<option value='" + ss[i] + "'>" + ss[i].split("_")[0] + "</option>");
                                        break;
                                    case "JTJS":
                                        $("#SelJtjs").append("<option value='" + ss[i] + "'>" + ss[i].split("_")[0] + "</option>");
                                        break;
                                    case "DTJS":
                                        $("#SelDtjs").append("<option value='" + ss[i] + "'>" + ss[i].split("_")[0] + "</option>");
                                        break;
                                }
                            }
                        }
                    }
                }
            });
        }
    },
    ask: function () {
        //add by qw 2013.1.7 start ���Ӷ��������ӵ��ж�
        if (graphUtils.checkLine()) {
            $.messager.confirm('\u7cfb\u7edf\u63d0\u793a', '\u60a8\u786e\u5b9a\u8981\u6b63\u5f0f\u63d0\u4ea4\u5417?',
            function (r) {
                if (r) {
                    //��ʽ�ύ
                    graphUtils.saveXml();
                }
            });
        }
        else {
            $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u8bf7\u786e\u5b9a\u6bcf\u6761\u7ebf\u7684\u4e24\u7aef\u90fd\u5df2\u6b63\u786e\u8fde\u63a5!', 'info');
        }
        //end
    },
    toUni: function (s) {
        var uniStr = escape(s);
        uniStr = uniStr.replace(/%/g, "\\");
        return uniStr;
    },
    //ɾ��
    delData: function (modeId) {
        var d = com.xjwgraph.Global,
        c = d.modeMap,
        mTool = d.modeTool,
        b = c.get(modeId);
        var modeDiv = $id(b.id);
        var mIndex = mTool.getModeIndex(modeDiv);
        var nName = $id("title" + mIndex).innerHTML;
        //alert(b.type + "," + b.id + "," + CommonInfo.BF_VERSION + "," + mIndex + "," + nName);
        //�������ύ����
        var _Param = "cmd=delete";
        _Param += "&bfid=" + CommonInfo.BF_ID;
        _Param += "&bfversion=" + CommonInfo.BF_VERSION;
        _Param += "&nodeid=" + b.id;
        _Param += "&nodename=" + nName;
        _Param += "&nodetype=" + b.type;
        _Param += "&random=" + Math.floor(Math.random() * 10000 + 1);
        $.ajax({
            type: "POST",
            dataType: "html",
            url: "BFWebHandler.ashx",
            data: encodeURI(_Param),
            success: function (result) {
                $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u64cd\u4f5c\u6210\u529f', 'info');
                $('#tt').propertygrid({
                    width: 300,
                    height: 'auto',
                    showGroup: true,
                    showHeader: true,
                    scrollbarSize: 0
                });
            }
        });
    },
    //����
    saveData: function () {
        var obj = this;
        var rows = $('#tt').propertygrid('getRows');
        var rowData = "";
        var nodeId, nodeName, nodeType, nodeDesc;
        $.each(rows, function (i, row) {
            //alert(row.name + "," + row.value + ",==" + row.field);
            rowData += row.field + "," + row.value + "|";
            if (row.field == "NODEID") {
                nodeId = row.value;
            }
            if (row.field == "NODENAME") {
                nodeName = row.value;
            }
            if (row.field == "NODETYPE") {
                nodeType = row.value;
            }
            if (row.field == "NODEDESC") {
                nodeDesc = row.value;
            }
        });
        //alert(rowData);
        var _Param = "cmd=save";
        _Param += "&bfid=" + CommonInfo.BF_ID;
        _Param += "&bfversion=" + CommonInfo.BF_VERSION;
        _Param += "&nodeid=" + nodeId;
        _Param += "&nodename=" + nodeName;
        _Param += "&nodetype=" + nodeType;
        _Param += "&nodedesc=" + nodeDesc;
        _Param += "&rowdata=" + rowData;
        _Param += "&random=" + Math.floor(Math.random() * 10000 + 1);
        //alert(encodeURI(_Param));
        $.ajax({
            type: "POST",
            dataType: "html",
            url: "BFWebHandler.ashx",
            data: encodeURI(_Param),
            success: function (result) {
                $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u6570\u636e\u4fdd\u5b58\u6210\u529f\uff01', 'info');
            }
        });
    },
    //ֻ����XML---���ڳ�ʼ���ʱ
    askSaveLayout: function () {
        if (graphUtils.checkLine()) {
            $.messager.confirm('\u7cfb\u7edf\u63d0\u793a', '\u60a8\u786e\u5b9a\u53ea\u4fdd\u5b58\u5e03\u5c40\u811a\u672c\u5417?',
            function (r) {
                if (r) {
                    //�ύ
                    graphUtils.saveLayout();
                }
            });
        }
        else {
            $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u8bf7\u786e\u5b9a\u6bcf\u6761\u7ebf\u7684\u4e24\u7aef\u90fd\u5df2\u6b63\u786e\u8fde\u63a5!\u540c\u65f6\u6bcf\u4e2a\u8282\u70b9\u4e0a\u7684\u8fde\u63a5\u7ebf\u90fd\u6709\u552f\u4e00\u7684\u6570\u5b57\u6807\u8bc6\u30101~9\u3011', 'info');
        }
    },
    saveLayoutXML: function (xmlData) {
        var _Param = "cmd=savelayout";
        _Param += "&bfid=" + CommonInfo.BF_ID;
        _Param += "&bfversion=" + CommonInfo.BF_VERSION;
        _Param += "&xmldata=" + xmlData;
        _Param += "&random=" + Math.floor(Math.random() * 10000 + 1);
        //alert(encodeURI(_Param));
        $.ajax({
            type: "POST",
            dataType: "html",
            url: "BFWebHandler.ashx",
            data: encodeURI(_Param),
            success: function (result) {
                if (result == "" || result == "False") {
                    $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u4fdd\u5b58\u6570\u636e\u51fa\u9519', 'error');
                }
                else {
                    $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u6570\u636e\u4fdd\u5b58\u6210\u529f\uff01', 'info');
                }
            }
        });
    },
    //����XML���ݵ������
    saveXmlData: function (xmlData) {
        var _Param = "cmd=savexmldata";
        _Param += "&bfid=" + CommonInfo.BF_ID;
        _Param += "&bfversion=" + CommonInfo.BF_VERSION;
        _Param += "&xmldata=" + xmlData;
        _Param += "&random=" + Math.floor(Math.random() * 10000 + 1);
        //alert(encodeURI(_Param));
        $.ajax({
            type: "POST",
            dataType: "html",
            url: "BFWebHandler.ashx",
            data: encodeURI(_Param),
            success: function (result) {
                if (result == "" || result == "False") {
                    $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u4fdd\u5b58\u6570\u636e\u51fa\u9519', 'error');
                }
                else {
                    $.messager.alert('\u53cb\u60c5\u63d0\u793a', '\u6570\u636e\u4fdd\u5b58\u6210\u529f\uff01', 'info');
                }
            }
        });
    },
    //ȡ��
    cancel: function () {
        var rows = $('#tt').propertygrid('getRows');
        $.each(rows, function (i, row) {
            if (row.editor != undefined) {
                row.value = "";
                $('#tt').propertygrid('refreshRow', i);
                //alert("Name: " + row.editor + ", Value: " + row.value);
            }
        });
    }
};

//��Աѡ�񷽷�����
var MethodHandler = ssec.bf.MethodHandler = {
    //�ᶨ��Աѡ��
    zdryAdd: function () {
        var nodes = $('#treeControl').tree('getChecked');
        //var zdryObj = $id('SelZdry');
        for (var i = 0; i < nodes.length; i++) {
            //alert(nodes[i].text + "_" + nodes[i].id + "===" + nodes[i].id.indexOf("DEPT"));
            if (nodes[i].id.indexOf("DEPT") > -1) continue;
            $("#SelZdry option[value='" + nodes[i].text + "_" + nodes[i].id + "']").remove();
            //zdryObj.options[zdryObj.options.length] = new Option(nodes[i].text, nodes[i].id);
            $("#SelZdry").append("<option value='" + nodes[i].text + "_" + nodes[i].id + "'>" + nodes[i].text + "</option>"); //���һ��option
        }
    },
    //�ᶨ��Աɾ��
    zdryDel: function () {
        var optLst = $("#SelZdry").find("option:selected");
        $.each(optLst, function (i, opt) {
            $("#SelZdry option[value='" + opt.value + "']").remove();
        });
        //        var zdryObj = $id('SelZdry');
        //        for (var i = 0; i < zdryObj.options.length; i++) {
        //            var opt = zdryObj.options[i];
        //            if (opt.selected) {
        //            }
        //        }
    },
    //��̬��ɫ���
    jtjsAdd: function () {
        var roleName = $("#TxtRoleName").val();
        var methodName = $('#SelMethod').combogrid('getValue');
        if (roleName && methodName) {
            $("#SelJtjs option[text='" + roleName + "']").remove();
            $("#SelJtjs").append("<option value='" + roleName + "_" + methodName + "'>" + roleName + "</option>");
        }
    },
    //��̬��ɫɾ��
    jtjsDel: function () {
        var optLst = $("#SelJtjs").find("option:selected");
        $.each(optLst, function (i, opt) {
            $("#SelJtjs option[value='" + opt.value + "']").remove();
        });
    },
    //��̬��ɫ���
    dtjsAdd: function () {
        var roleName = $("#TxtRoleName").val();
        var methodName = $('#SelMethod').combogrid('getValue');
        if (roleName && methodName) {
            $("#SelDtjs option[text='" + roleName + "']").remove();
            $("#SelDtjs").append("<option value='" + roleName + "_" + methodName + "'>" + roleName + "</option>");
        }
    },
    //��̬��ɫɾ��
    dtjsDel: function () {
        var optLst = $("#SelDtjs").find("option:selected");
        $.each(optLst, function (i, opt) {
            $("#SelDtjs option[value='" + opt.value + "']").remove();
        });
    }
};

//������д���
window.onerror = function (e) {
    //alert(e);
    return true;
};

////�ڵ�MODEL
//var NodeModel = ssec.bf.NodeModel = {
//		BF_NODEID : "",//��ǰ�ڵ���	varchar                        
//		BF_ID : "",//ҵ����ID	varchar		             
//		BF_VERSION : 0,//ҵ�����汾	int				      
//		BF_NODENAME : "",//�ڵ�����	varchar 		       
//		BF_NODETYPE : "",//�ڵ�����	varchar				        
//		BF_NODEDESC : "",	//�ڵ�����	varchar		             
//		BF_FORM : "",//�ڵ��Ӧ��	varchar					          
//		BF_FORWARD : 0,//�Ƿ�֧�ֻ���	int				           
//		BF_COMMISSION : 0,//�Ƿ��������	int		          
//		BF_TIMELIMIT : 0,//����ʱ��	int		             
//		BF_PROGRESSVALUE : 0, //�ڵ����ֵ	int     
//		BF_DUTYOFFICER : "",//�ڵ������	varchar	         
//		BF_NOTIFIER : "",//�ڵ�֪ͨ��	varchar				           
//		BF_REMINDWAY : "",//��Ϣ���ѷ�ʽ:SMS MSG EMAIL	varchar			          
//		BF_AUDITOPINION : "",//ȱʡ�������	varchar	        
//		BF_EXTENDEDTREATMENT : 0, //���ڴ���ʽ:0=������  1=������һ�ڵ�  2=ת�����˴���	int     
//		BF_KEYPOINT : 0,	//�Ƿ�Ϊ�ؼ��ڵ�	int		         
//		BF_CONTROLPOINT : 0,	//�Ƿ�Ϊ�����쳣���Ƶ�	int         
//		BF_FLOWTYPE1 : 1,//��֧�ڵ���ת����:0=���� 1=��ѡһ	int		        
//		BF_FLOWTYPE2 : 0, //�����̽ڵ���ת����:1=����ģʽ 0=����ģʽ	int        
//		BF_FLOWTYPE3 : 1//��Ͻڵ���ת����:0=�ȴ����з�֧��ת���� 1=�ȴ�һ����֧��ת����	int
//	};