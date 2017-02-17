<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
    CodeBehind="SbglWxfytjList.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.Sbgl.SbglWxfytjList"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var yy = "<%=Ddl_Year.SelectedValue%>";
        var mm = "<%=Ddl_Month.SelectedValue%>";
        var bgdph = "<%=Txt_BGDPH.Text%>";
        function OnReady(id)  //Treelist抛给页面的事件
        {
            if (id == "AF") {
                //加装相对当前目录下的XML描述文档，创建Treelist
                document.AF.func("Build", "/Modules/App/Project/Sbgl/Xml/SbglYsbgdHeader2.xml");
                //调用Load函数填充数据
                document.AF.func("Load", "/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=SBWXYS&Y=" + yy + "&M=" + mm + "&ZT=1&PH=" + bgdph);
                //在第一列位置插入新列 
                //document.AF.func("InsertCol", "0\r\nname=checked;isCheckboxOnly=true");
                //不可编辑
                document.AF.func("SetProp", "editAble \r\n false");
                document.AF.func("DisableMenu", "insert \r\n true");
                document.AF.func("DisableMenu", "delete \r\n true");
                document.AF.func("DisableMenu", "deleteMore \r\n true");
                document.AF.func("HideCol", "GZLMS \r\n true");
                document.AF.func("HideCol", "YSYJBZ \r\n true");
            }
            $.ajax({
                type: "post",
                url: "/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=Chart_SBLX&Y=" + yy + "&M=" + mm,
                datatype: "text",
                async: true,
                success: function (result)
                {
                    document.AFChart1.func("AddSeries", result);
                }
            });
            $.ajax({
                type: "post",
                url: "/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=Chart_SYDW&Y=" + yy + "&M=" + mm,
                datatype: "text",
                async: true,
                success: function (result) {
                    document.AFChart2.func("AddSeries", result);
                }
            });
        }
        function OnEvent(id, Event, p1, p2, p3, p4) {
            if (id == 'AF') {
            }
        }
        function searchData() {
            yy = $("#<%=Ddl_Year.ClientID%>").val();
            mm = $("#<%=Ddl_Month.ClientID%>").val();
            bgdph = $("#<%=Txt_BGDPH.ClientID%>").val();
            //alert("yy==" + yy + ",mm==" + mm);
            OnReady("AF");
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
                document.AF.func("SetProp", "sort \r\n BGDPH a");	//排序
                //document.AF.func("SetColProp", "checked \r\n TreeCombine \r\n");
                document.AF.func("SetProp", "isTree \r\n false");
            }
            else {
                //树
                document.AF.func("SetProp", "curselmode \r\n row");
                document.AF.func("SetProp", "sort \r\n WXDW a");	//排序
                //document.AF.func("SetColProp", "checked \r\n TreeCombine \r\n auto,node");  //合并
                document.AF.func("SetProp", "isTree \r\n true");
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
                    <li class="last">维修费用统计</li>
                </ul>
            </div>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>维修费用统计</span>
            </div>
        </div>
        <div class="main-gridview">
            <div class="main-gridview-title">
                <asp:DropDownList ID="Ddl_Year" runat="server"></asp:DropDownList>&nbsp;&nbsp;
                <asp:DropDownList ID="Ddl_Month" runat="server"></asp:DropDownList>&nbsp;&nbsp;
                批号：<asp:TextBox ID="Txt_BGDPH" runat="server"></asp:TextBox>&nbsp;&nbsp;
                <asp:LinkButton ID="LnkBtn_Search" runat="server" class="easyui-linkbutton" iconCls="icon-search"
                    OnClientClick="searchData();return false;" plain="true">查询</asp:LinkButton>
                &nbsp;&nbsp;
                <%--<asp:LinkButton ID="LnkBtn_Save" runat="server" class="easyui-linkbutton" iconCls="icon-save"
                    OnClientClick="return saveData();" OnClick="LnkBtn_Save_Click" plain="true">保存数据</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton ID="LnkBtn_Scwxph" runat="server" class="easyui-linkbutton" iconCls="icon-ok"
                    OnClientClick="return getSelect();" plain="true" OnClick="LnkBtn_Scwxph_Click">生成维修批号</asp:LinkButton>
                &nbsp;&nbsp;--%>
                <%--<asp:LinkButton ID="LnkBtn_Cancel" runat="server" class="easyui-linkbutton" iconCls="icon-cancel"
                    OnClientClick="deletechecked();return false;" plain="true">删除选中行</asp:LinkButton>
                &nbsp;&nbsp;--%>
                <input id="Radio1" name="listtype" type="radio" onclick="setListType(2);" />树型&nbsp;&nbsp;
                <input id="Radio2" name="listtype" type="radio" checked="checked" onclick="setListType(1);" />列表
            </div>
            <%--数据表格开始--%>
            <asp:HiddenField ID="HDData" runat="server" ClientIDMode="Static" />
            <div style="width: 100%; height: 300px;" id="dAF">
                <script type="text/javascript">
                    insertTreeList("AF", "");
                </script>
            </div>
        </div>
        <div id="contents" class="ssec-form">
            <ul>
                <li style="width: 50%;">
                    <div>
                        <script>
                            insertChart('AFChart1', "bordercolor=#4499ff;borderWidth=2;borderRound=23;backcolor=#fff5ea,#f0e0d0", "300px")

                        </script> 
                    </div>
                </li>
                <li style="width: 50%;">
                    <div>
                        <script>
                            insertChart('AFChart2', 'bordercolor=#4499ff; borderWidth=2; borderRound=23;backcolor=#fff5ea,#f0e0d0',"300px");
                        </script>
                    </div>
                </li>
            </ul>
        </div>
    </div>
    <script type="text/javascript">
        var height1 = $(window).height();
        var height = height1 * 0.80;
        //$("#dAF").height(height);
    </script>

</asp:Content>
