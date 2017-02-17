<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BFToView.aspx.cs" Inherits="Enterprise.UI.Web.Component.BF.BFToView" %>

<html xmlns:v="urn:schemas-microsoft-com:vml" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=5">
    <title>业务流查看器</title>
    <link rel="stylesheet" type="text/css" href="themes/default/easyui.css" />
    <link rel="stylesheet" type="text/css" href="themes/icon.css" />
    <link href="css/flowPath.css" type="text/css" rel="stylesheet" />
    <script type="text/javascript" src="js/jquery-1.6.min.js"></script>
    <script type="text/javascript" src="js/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="js/bf.logic.stable.js"></script>
    <style type="text/css">
        v\:*
        {
            behavior: url(#default#VML);
        }
    </style>
</head>
<body class="easyui-layout bodySelectNone" id="body" onselectstart="return false;">
   
    <div region="center" title="绘图区" id="contextBody" class="mapContext">
        <!-- Line 序号 -->
        <div id="showLineXH" class="message"></div>
        <!-- Line右键菜单 -->
        <div id="lineRightMenu" class="modeRight">
            <div class="modeRightTop">
            </div>
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
        <table id="tt">
        </table>
    </div>
    <div class="auxiliaryArea" style="visibility:hidden;">
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
                                <input type="text" id="inputTitle" class="inputComm" style="width: 300px;" />
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
    <div id="moveBaseMode" class="moveBaseMode" style="visibility:hidden;">
        <img id="moveBaseModeImg" src="images/Favourite.png" class="nodeStyle" />
    </div>
    <!--对话框-->
    <div id="prop" style="visibility: hidden;">
    </div>
    <div id="historyMessage" class="historyMessage" style="visibility:hidden;">
    </div>
</body>
<!--JS-->
<script type="text/javascript" src="js/bf.view.stable.js"></script>
<script type="text/javascript">

    CommonInfo.BF_ID = "<%=PublishModel.BF_ID %>";
    CommonInfo.BF_NAME = "<%=PublishModel.BfBase.BF_NAME %>";
    CommonInfo.BF_VERSION = "<%=PublishModel.BF_VERSION %>";

    jQuery(document).ready(function () {

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

        //加载脚本
        <%if (!string.IsNullOrEmpty(PublishModel.BF_SCRIPT)) {%>
            var xmlText = '<%=PublishModel.BF_SCRIPT %>';
            graphUtils.loadTextXml(xmlText);
        <%} %>
    });		
</script>
</html>