﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" 
    CodeBehind="SbglWxjhSQ.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.Sbgl.SbglWxjhSQ" 
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var yy = "<%=Ddl_Year.SelectedValue%>";
        var mm = "<%=Ddl_Month.SelectedValue%>";
        function OnReady(id)  //Treelist抛给页面的事件
        {
            if (id == "AF") {
                //加装相对当前目录下的XML描述文档，创建Treelist
                document.AF.func("Build", "/Modules/App/Project/Sbgl/Xml/SbglWxjhsqHeader.xml");
                //调用Load函数填充数据
                document.AF.func("Load", "/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=WXJHSQ&Y=" + yy + "&M=" + mm + "&ZT=0");
                //在第一列位置插入新列 
                document.AF.func("InsertCol", "0\r\nname=checked;isCheckboxOnly=true");
            }
            if (id == "AF2") {
                //加装相对当前目录下的XML描述文档，创建Treelist
                document.AF2.func("Build", "/Modules/App/Project/Sbgl/Xml/SbglWxjhsqHeader.xml");
                //调用Load函数填充数据
                document.AF2.func("Load", "/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=WXJHSQ&Y=" + yy + "&M=" + mm + "&ZT=1");
                //不可编辑
                document.AF2.func("SetProp", "editAble \r\n false");
            }
        }
        var colIdx = 0;
        function OnEvent(id, Event, p1, p2, p3, p4) {
            if (id == 'AF') {
                //演示取下拉选中行的其它列的内容 
                if (Event == "DropdownSelChanged") {
                    var h = document.AF.func("GetHandle", "SBBH");
                    var row = document.AF.func(h + "GetCurrentRow", "");
                    if (row != "") {
                        var sydw = document.AF.func(h + "GetCellData", row + "\r\n SYDW");//使用单位
                        var sblx = document.AF.func(h + "GetCellData", row + "\r\n SBLX");//设备类型
                        var ggxh = document.AF.func(h + "GetCellData", row + "\r\n GGXH");//规格型号
                        var clph = document.AF.func(h + "GetCellData", row + "\r\n CLPH");//车辆牌号
                        var azdd = document.AF.func(h + "GetCellData", row + "\r\n AZDD");//安装地点
                        document.AF.func("SetCellData", p1 + "\r\n SBSYDW \r\n" + sydw);
                        document.AF.func("SetCellData", p1 + "\r\n SBLX \r\n" + sblx);
                        document.AF.func("SetCellData", p1 + "\r\n GGXH \r\n" + ggxh);
                        document.AF.func("SetCellData", p1 + "\r\n CLXH \r\n" + clph);
                        document.AF.func("SetCellData", p1 + "\r\n AZDD \r\n" + azdd);
                    }
                    //alert(p1 + "," + p2 + "," + p3 + "," + p4 + ",");
                    //var sblx = document.AF.func("GetDropCellData", p1 + "\r\nSBLX"); //设备类型 
                    //var ggxh = document.AF.func("GetDropCellData", p1 + "\r\n" + p2 + "\r\n GGXH \r\n true"); //规格型号
                    //var clph = document.AF.func("GetDropCellData", p1 + "\r\n" + p2 + "\r\n CLPH \r\n true"); //车辆牌号
                    //var s = sblx + "," + ggxh + "," + clph;
                    //s = s.replace(/\r\n/g, "\\r\\n");
                    ////浮现提示(全局函数) 
                    //document.AF.func("msgFloat", s + "\r\nhold=5");
                }
            }
        }
        function searchData() {
            yy = $("#<%=Ddl_Year.ClientID%>").val();
            mm = $("#<%=Ddl_Month.ClientID%>").val();
            //alert("yy==" + yy + ",mm==" + mm);
            OnReady("AF");
            OnReady("AF2");
        }
        function saveData() {
            if (confirm("您确定要保存数据吗?")) {
                var hd = $("#<%=HDData.ClientID%>");
                var data = document.AF.func("GetChangedXml", "level=2");
                hd.val(encodeURIComponent(data));
                //alert(data);
                showLoading();
                return true;
            }
            return false;
        }
        function deletechecked() {
            //删除符合表达式的行
            document.AF.func("DeleteRows", "checked=1");
            showTopMsg("系统提示", "点击保存数据按钮才能生效!");
        }
        function setListType(v) {
            if (v == 1) {
                //列表
                document.AF.func("SetProp", "curselmode \r\n rows");
                document.AF.func("SetProp", "sort \r\n SBBH a");	//排序
                document.AF.func("SetColProp", "checked \r\n TreeCombine \r\n");
                document.AF.func("SetProp", "isTree \r\n false");
                document.AF2.func("SetProp", "curselmode \r\n rows");
                document.AF2.func("SetProp", "sort \r\n SBBH a");	//排序
                document.AF2.func("SetColProp", "checked \r\n TreeCombine \r\n");
                document.AF2.func("SetProp", "isTree \r\n false");
            }
            else {
                //树
                document.AF.func("SetProp", "curselmode \r\n row");
                document.AF.func("SetProp", "sort \r\n SBLX a");	//排序
                document.AF.func("SetColProp", "checked \r\n TreeCombine \r\n auto,node");  //合并
                document.AF.func("SetProp", "isTree \r\n true");
                document.AF2.func("SetProp", "curselmode \r\n row");
                document.AF2.func("SetProp", "sort \r\n SBLX a");	//排序
                document.AF2.func("SetColProp", "checked \r\n TreeCombine \r\n auto,node");  //合并
                document.AF2.func("SetProp", "isTree \r\n true");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ProjectPH" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/" target="_parent">首页</a></li>
                    <li>设备管理</li>
                    <li class="last">设备维修计划申请</li>
                </ul>
            </div>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>设备维修计划申请</span>
            </div>
        </div>
        <div class="main-gridview">
            <div class="main-gridview-title">
                <asp:DropDownList ID="Ddl_Year" runat="server"></asp:DropDownList>&nbsp;&nbsp;
                <asp:DropDownList ID="Ddl_Month" runat="server"></asp:DropDownList>&nbsp;&nbsp;
                <asp:LinkButton ID="LnkBtn_Search" runat="server" class="easyui-linkbutton" iconCls="icon-search"
                    OnClientClick="searchData();return false;" plain="true">查询</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton ID="LnkBtn_Save" runat="server" class="easyui-linkbutton" iconCls="icon-save"
                    OnClientClick="return saveData();" OnClick="LnkBtn_Save_Click" plain="true">保存数据</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton ID="LnkBtn_Cancel" runat="server" class="easyui-linkbutton" iconCls="icon-cancel"
                    OnClientClick="deletechecked();return false;" plain="true">删除选中行</asp:LinkButton>
                &nbsp;&nbsp;
                <input id="Radio1" name="listtype" type="radio" onclick="setListType(2);"/>树型&nbsp;&nbsp;
                <input id="Radio2" name="listtype" type="radio" checked="checked" onclick="setListType(1);"/>列表
            </div>
            <%--数据表格开始--%>
            <asp:HiddenField ID="HDData" runat="server" ClientIDMode="Static" />
            <div style="width: 100%; height: 250px;" id="dAF">
                <script type="text/javascript">
                    insertTreeList("AF", "");
                </script>
            </div>
        </div>
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form">
                </div>
                <span>审核通过列表</span>
            </div>
            <div style="width: 100%; height: 250px;" id="dAF2">
                <script type="text/javascript">
                    insertTreeList("AF2", "");
                </script>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var height1 = $(window).height();
        var height = height1 * 0.80;
        //$("#dAF").height(height);
    </script>

</asp:Content>
