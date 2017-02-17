<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BFDesigner.aspx.cs" Inherits="Enterprise.UI.Web.Component.BF.BFDesigner" %>

<html xmlns:v="urn:schemas-microsoft-com:vml" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=5">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <title>业务流设计器</title>
    <link rel="stylesheet" type="text/css" href="themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="themes/icon.css" />
    <link href="css/flowPath.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="js/bf.logic.js"></script>
    <style type="text/css">
        v\:*
        {
            behavior: url(#default#VML);
        }
    </style>
</head>
<body class="easyui-layout bodySelectNone" id="body" onselectstart="return false;">
    <div id="title" region="north" split="true" border="false" title="工具栏" class="titleTool">
        <div id="message" class="message">
        </div>
        <div>
            <img alt="选择" title="选择" src="images/0.png" onclick="graphUtils.toSelect()" class="buttonStyle" />
            <img alt="合并" title="合并" src="images/1.png" onclick="graphUtils.toMerge()" class="buttonStyle" />
            <img alt="拆分" title="拆分" src="images/2.png" onclick="graphUtils.toSplit()" class="buttonStyle" />
            <img alt="置顶" title="置顶" src="images/4.png" onclick="graphUtils.toTop()" class="buttonStyle" />
            <img alt="置底" title="置底" src="images/3.png" onclick="graphUtils.toBottom()" class="buttonStyle" />
            <img alt="预览" title="预览" src="images/zoom.png" onclick="graphUtils.printView()" class="buttonStyle" />
            <img alt="撤销" title="撤销" src="images/back.png" onclick="graphUtils.undo();" class="buttonStyle" />
            <img alt="重做" title="重做" src="images/next.png" onclick="graphUtils.redo();" class="buttonStyle" />
            <img alt="保存" title="保存" src="images/save.png" onclick="BFHandler.ask();" class="buttonStyle" />
            <img alt="加载" title="加载" src="images/download_page.png" onclick="graphUtils.loadXml();"
                class="buttonStyle" />
            <img alt="清空" title="清空" src="images/trash.png" onclick="graphUtils.clearHtml();"
                class="buttonStyle" />
            <img alt="复制" title="复制" src="images/copy.png" onclick="graphUtils.copyNode();" class="buttonStyle" />
            <img alt="删除" title="删除" src="images/delete.png" onclick="graphUtils.removeNode();"
                class="buttonStyle" />
            <img alt="顶对齐" title="顶对齐" src="images/toTop.png" onclick="graphUtils.alignTop();"
                class="buttonStyle" />
            <img alt="水平居中" title="水平居中" src="images/toMiddleHeight.png" onclick="graphUtils.horizontalCenter();"
                class="buttonStyle" />
            <img alt="底对齐" title="底对齐" src="images/toBottom.png" onclick="graphUtils.bottomAlignment();"
                class="buttonStyle" />
        </div>
        <div class="formDiv">
            <form id="Form1" runat="server">
            版本<asp:DropDownList ID="Ddl_Version" runat="server" AutoPostBack="true">
            </asp:DropDownList>
            &nbsp;
            <asp:LinkButton ID="LnkBtn_Submit" runat="server" class="easyui-linkbutton" iconCls="icon-add"
                OnClick="LnkBtn_Submit_Click">升版</asp:LinkButton>&nbsp;&nbsp; <a href="#" class="easyui-linkbutton"
                    iconcls="icon-save" onclick="BFHandler.askSaveLayout();">保存布局</a>
            </form>
        </div>
    </div>
    <div id="leftContent" region="west" split="true" title="图元区" class="leftContent">
        <div class="easyui-accordion overflowHidden" fit="true" border="false">
            <div title="基本图形" style="overflow: hidden; background-color: #c7dbfc;">
                <div id="baseLine2" style="position: absolute; left: 20px; top: 30px !important;
                    top: 10px">
                    <div class="title">
                        折线1</div>
                    <img id="backGroundImg1" src="images/line3.png" class="nodeStyle" />
                </div>
                <div id="baseLine3" style="position: absolute; left: 60px; top: 30px !important;
                    top: 10px">
                    <div class="title">
                        折线2</div>
                    <img id="backGroundImg2" src="images/line2.png" class="nodeStyle" />
                </div>
                <div id="baseLine1" style="position: absolute; left: 20px; top: 70px !important;
                    top: 70px">
                    <div class="title">
                        直线</div>
                    <img id="backGroundImg3" src="images/line1.png" class="nodeStyle" />
                </div>
                <div id="baseMode4" divtype="mode" style="position: absolute; left: 60px; top: 70px !important;
                    top: 70px">
                    <div class="title">
                        开始节点</div>
                    <img id="backGroundImg4" src="images/wf/startNode.gif" class="nodeStyle" />
                </div>
                <div id="baseMode5" divtype="mode" style="position: absolute; left: 20px; top: 140px !important;
                    top: 140px">
                    <div class="title">
                        完成节点</div>
                    <img id="backGroundImg5" src="images/wf/endNode.gif" class="nodeStyle" />
                </div>
                <div id="baseMode6" divtype="mode" style="position: absolute; left: 60px; top: 140px !important;
                    top: 140px">
                    <div class="title">
                        子流程</div>
                    <img id="backGroundImg6" src="images/wf/subflowNode.gif" class="nodeStyle" />
                </div>
                <div id="baseMode3" divtype="mode" style="position: absolute; left: 20px; top: 200px !important;
                    top: 200px">
                    <div class="title">
                        汇合节点</div>
                    <img id="backGroundImg7" src="images/wf/joinNode.gif" class="nodeStyle" />
                </div>
                <div id="baseMode7" divtype="mode" style="position: absolute; left: 60px; top: 200px !important;
                    top: 200px">
                    <div class="title">
                        业务节点</div>
                    <img id="backGroundImg8" src="images/wf/processNode.gif" class="nodeStyle" />
                </div>
            </div>
            <div title="历史操作" class="flowImag">
                <div id="historyMessage" class="historyMessage">
                </div>
            </div>
        </div>
    </div>
    <div region="center" title="绘图区" id="contextBody" class="mapContext">
        <!-- Line 序号 -->
        <div id="showLineXH" class="message">
        </div>
        <!-- Line右键菜单 -->
        <div id="lineRightMenu" class="modeRight">
            <div class="modeRightTop">
            </div>
            <div class="modeRightDel" onmousemove="this.style.backgroundColor='#c5e7f6'" onclick="graphUtils.removeNode();"
                onmouseout="this.style.backgroundColor=''">
                <span class="menuSpan">删 除</span></div>
            <div class="modeRightPro" onmousemove="this.style.backgroundColor='#c5e7f6'" onclick="graphUtils.showLinePro();"
                onmouseout="this.style.backgroundColor=''">
                <span class="menuSpan">属 性</span></div>
            <div class="modeRightButtom">
            </div>
        </div>
        <!-- Mode右键菜单 -->
        <div id="rightMenu" class="modeRight">
            <div class="modeRightTop">
            </div>
            <div class="modeRightCopy" onmousemove="this.style.backgroundColor='#c5e7f6'" onclick="graphUtils.copyNode();"
                onmouseout="this.style.backgroundColor=''">
                <span class="menuSpan">复 制</span></div>
            <div class="modeRightDel" onmousemove="this.style.backgroundColor='#c5e7f6'" onclick="graphUtils.removeNode();"
                onmouseout="this.style.backgroundColor=''">
                <span class="menuSpan">删 除</span></div>
            <div class="modeRightPro" onmousemove="this.style.backgroundColor='#c5e7f6'" onclick="graphUtils.showModePro();"
                onmouseout="this.style.backgroundColor=''">
                <span class="menuSpan">属 性</span></div>
            <div class="modeRightButtom">
            </div>
        </div>
        <div id="topCross">
        </div>
        <div id="leftCross">
        </div>
    </div>
    <div region="east" split="true" title="属性区" class="history">
        <div style="padding: 5px; background: #fafafa;">
            <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-save" onclick="BFHandler.saveData();">
                保存</a> <a href="#" class="easyui-linkbutton" plain="true" iconcls="icon-cancel" onclick="BFHandler.cancel();">
                    取消</a>
        </div>
        <table id="tt">
        </table>
    </div>
    <div region="south" split="true" title="辅助区" class="auxiliaryArea">
        <!-- 小地图 -->
        <div id="smallMap">
        </div>
        <div id="mainControl">
            <div id="tab" class="control">
                <h3 id="h1" class="hclass" onclick="hOnMouseOver(this, '1')">
                    &nbsp;<img src="images/img1.png" style="vertical-align: middle;" />&nbsp;&nbsp;模型名称
                </h3>
                <div id="tab1" class="htabup">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="text-align: center; height: 25px;">
                                标题
                            </td>
                            <td colspan="7">
                                <input type="text" id="inputTitle" class="inputComm" style="width: 300px;"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 70px; text-align: center;">
                                内容
                            </td>
                            <td colspan="7">
                                <textarea rows="3" id="modeContent" class="contextArea"></textarea>
                            </td>
                        </tr>
                    </table>
                </div>
                <h3 id="h2" class="hclass" onclick="hOnMouseOver(this, '2')">
                    &nbsp;<img src="images/img2.png" style="vertical-align: middle;" />&nbsp;&nbsp;模型属性
                </h3>
                <div id="tab2" class="htab">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 70px; height: 25px; text-align: center;">
                                宽
                            </td>
                            <td>
                                <input type="text" id="inputWidth" class="inputComm" style="width: 50px;" />
                            </td>
                            <td style="width: 70px; text-align: center;">
                                高
                            </td>
                            <td>
                                <input type="text" id="inputHeight" class="inputComm" style="width: 50px;" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center;">
                                上边距
                            </td>
                            <td>
                                <input type="text" id="inputTop" class="inputComm" style="width: 50px;" />
                            </td>
                            <td style="text-align: center;">
                                左边距
                            </td>
                            <td>
                                <input type="text" id="inputLeft" class="inputComm" style="width: 50px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <h3 id="h3" class="hclass" onclick="hOnMouseOver(this, '3')">
                    &nbsp;<img src="images/img3.png" style="vertical-align: middle;" />&nbsp;&nbsp;模型背景</h3>
                <div id="tab3" class="htab">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 70px; text-align: center;">
                                背景图
                            </td>
                            <td colspan="6">
                                <input type="text" id="inputImgSrc" class="inputComm" style="width: 500px;" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div id="show" class="show">
            <div id="bfName" class="showItem" style="height: 24px;">
            </div>
            <div id="bfVersion" class="showItem">
            </div>
            <div id="lineCount" class="showItem">
            </div>
            <div id="modeCount" class="showItem">
            </div>
            <div id="contextCount" class="showItem">
            </div>
        </div>
    </div>
    <!-- 移动时的图象 -->
    <div id="moveBaseMode" class="moveBaseMode">
        <img id="moveBaseModeImg" src="images/Favourite.png" class="nodeStyle" />
    </div>
    <!--对话框-->
    <div id="prop" style="visibility: hidden;">
    </div>
    <!------------------对话窗口区---------------------->
    <div id="dialogDiv" title="设置操作" icon="icon-save" style="padding: 5px; width: 550px;
        height: 400px;">
        <div class="easyui-tabs" fit="true" border="false" id="tabsDiv">
            <div title="消息提醒" closable="false" style="padding: 5px;" fit="true">
                <div id="tabDiv1" style="display: none">
                    <fieldset>
                        <ul>
                            <li>
                                <input id="Chk_MSG" type="checkbox" />即时消息</li>
                            <li>
                                <input id="Chk_SMS" type="checkbox" />手机短信</li>
                            <li>
                                <input id="Chk_EMAIL" type="checkbox" />电子邮件</li>
                        </ul>
                    </fieldset>
                    <a href="#" class="easyui-linkbutton" iconcls="icon-ok" onclick="BFHandler.selectRemindWay();">
                        Ok</a>
                </div>
            </div>
            <div title="表单路径" closable="false" style="padding: 5px;" fit="true">
                <div id="tabDiv2" style="display: none">
                    <table id="formTable">
                    </table>
                    <input id="TxtFormPath" type="text" style="width: 350px; border: 1px solid red;" onkeydown="keyDownFactory.selectTxt(this,window.event);" />
                    <a href="#" class="easyui-linkbutton" iconcls="icon-ok" onclick="BFHandler.selectFormPath();">
                        Ok</a>
                </div>
            </div>
            <div title="人员选择" closable="false" style="padding: 5px;" fit="true">
                <div id="tabDiv3" style="display: none;">
                    <div id="Layer1" style="position: absolute; width: 170px; height: 280px; z-index: 1;
                        left: 10px; top: 10px; overflow: auto;">
                        <ul id="treeControl">
                        </ul>
                    </div>
                    <div id="Layer2" style="position: absolute; width: 320px; height: 280px; z-index: 1;
                        left: 190px; top: 10px; overflow: hidden;">
                        <table style="width: 100%; height: auto;" border="1" cellpadding="1" cellspacing="1">
                            <tr>
                                <td width="20%">
                                    指定人员
                                </td>
                                <td width="10%">
                                    <input id="BtnZdryAdd" type="button" value=">>" onclick="MethodHandler.zdryAdd();" />
                                    <input id="BtnZdryDel" type="button" value="<<" onclick="MethodHandler.zdryDel();" />
                                </td>
                                <td width="70%">
                                    <select id="SelZdry" style="width: 180px; height: 60px;" multiple="multiple">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    角色设定
                                </td>
                                <td colspan="2">
                                    <input id="TxtRoleName" type="text" />
                                    <select id="SelMethod" name="dept" style="width: 200px;">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    静态角色
                                </td>
                                <td>
                                    <input id="BtnJtjsAdd" type="button" value=">>" onclick="MethodHandler.jtjsAdd();" />
                                    <input id="BtnJtjsDel" type="button" value="<<" onclick="MethodHandler.jtjsDel();" />
                                </td>
                                <td>
                                    <select id="SelJtjs" style="width: 180px; height: 80px" multiple="multiple">
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    动态角色
                                </td>
                                <td>
                                    <input id="BtnDtjsAdd" type="button" value=">>" onclick="MethodHandler.dtjsAdd();" />
                                    <input id="BtnDtjsDel" type="button" value="<<" onclick="MethodHandler.dtjsDel();" />
                                </td>
                                <td>
                                    <select id="SelDtjs" style="width: 180px; height: 80px" multiple="multiple">
                                    </select>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="Layer3" style="position: absolute; width: 80px; height: 22px; z-index: 1;
                        left: 400px; top: 290px; overflow: hidden;">
                        <a href="#" class="easyui-linkbutton" iconcls="icon-ok" onclick="BFHandler.selectPersonRole();">
                            Ok</a>
                    </div>
                </div>
            </div>
            <div title="子流程" closable="false" style="padding: 5px;" fit="true">
                <div id="tabDiv4" style="display: none">
                    <table id="subflowpathTable">
                    </table>
                    <input id="TxtSubFlowpath" type="text" style="width: 350px; border: 1px solid red;" />
                    <a href="#" class="easyui-linkbutton" iconcls="icon-ok" onclick="BFHandler.selectSubFlowpath();">
                        Ok</a>
                </div>
            </div>
        </div>
    </div>
</body>
<!--JS-->
<script type="text/javascript" src="js/bf.core.js"></script>
<script type="text/javascript">

    CommonInfo.BF_ID = "<%=PublishModel.BF_ID %>";
    CommonInfo.BF_NAME = "<%=PublishModel.BfBase.BF_NAME %>";
    CommonInfo.BF_VERSION = "<%=PublishModel.BF_VERSION %>";

    var mainControl = $id("mainControl");
    mainControl.style.width = (document.body.offsetWidth - 412) + "px";

    var bgImg = "url(images/bg.gif)";
    var backColor = "#e0ecff";

    function hOnMouseOver(tagObj, index) {
        var h1 = $id("h1");
        var h2 = $id("h2");
        var h3 = $id("h3");
        var tab1 = $id("tab1");
        var tab2 = $id("tab2");
        var tab3 = $id("tab3");
        var setHClass = function (obj, colorValue, indexValue) {
            obj.style.background = colorValue;
            obj.style.zIndex = indexValue;
        }
        var setTagClass = function (obj, className) {
            obj.setAttribute("class", className);
            obj.setAttribute("className", className);

        }
        setHClass(h1, bgImg, "1");
        setHClass(h2, bgImg, "1");
        setHClass(h3, bgImg, "1");
        setTagClass(tab1, "htab");
        setTagClass(tab2, "htab");
        setTagClass(tab3, "htab");
        setHClass(tagObj, backColor, "3");
        setTagClass($id("tab" + index), "htabup");
    }

    jQuery(document).ready(function () {
        $id("h1").style.background = "#e0ecff";
        $id("h1").style.zIndex = "3";
        var global = com.xjwgraph.Global;
        graphUtils = com.xjwgraph.Utils.create({
            contextBody: 'contextBody',
            width: 1600,
            height: 1000,
            smallMap: 'smallMap',
            mainControl: 'mainControl',
            historyMessage: 'historyMessage',
            prop: 'prop'
        });
        graphUtils.nodeDrag($id("baseLine1"), true, 1);
        graphUtils.nodeDrag($id("baseLine2"), true, 2);
        graphUtils.nodeDrag($id("baseLine3"), true, 3);
        var modes = jQuery("[divType='mode']");
        var modeLength = modes.length;
        for (var i = 0; i < modeLength; i++) {
            graphUtils.nodeDrag(modes[i]);
        }
        document.body.onclick = function () {
            if (!stopEvent) {
                global.modeTool.clear();
            }
        }
        function countModule() {
            stopEvent = false;
            var lineCount = global.lineMap.size();
            var modeCount = global.modeMap.size();
            var contextCount = global.baseTool.contextMap.size();
            $id("lineCount").innerHTML = "线总数:" + lineCount;
            $id("modeCount").innerHTML = "模型数:" + modeCount;
            $id("contextCount").innerHTML = "区域数:" + contextCount;
            $id("bfName").innerHTML = "<br/><font color=red>" + CommonInfo.BF_NAME + "</font>";
            $id("bfVersion").innerHTML = "当前版本:" + CommonInfo.BF_VERSION;
        }
        document.onclick = function () {
            countModule();
        };
        document.onkeydown = KeyDown;

        //加载脚本
        <%if (!string.IsNullOrEmpty(PublishModel.BF_SCRIPT)) {%>
            var xmlText = '<%=PublishModel.BF_SCRIPT %>';
            graphUtils.loadTextXml(xmlText);
        <%} %>

        countModule();

        //对话窗口区
        $('#dialogDiv').dialog({
            resizable:true
		});
        $('#dialogDiv').dialog('close');
    });		
</script>
</html>
