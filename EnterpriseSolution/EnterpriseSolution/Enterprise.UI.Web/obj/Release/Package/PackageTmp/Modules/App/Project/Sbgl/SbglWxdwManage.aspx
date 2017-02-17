<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true"
    CodeBehind="SbglWxdwManage.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.Sbgl.SbglWxdwManage"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnReady(id)  //Treelist抛给页面的事件
        {
            if (id == "AF") {
                //加装相对当前目录下的XML描述文档，创建Treelist
                document.AF.func("Build", "/Modules/App/Project/Sbgl/Xml/SbglWxdwHeader.xml");
                //调用Load函数填充数据
                document.AF.func("Load", "/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=WXDW");
                //在第一列位置插入新列 
                document.AF.func("InsertCol", "0\r\nname=checked;isCheckboxOnly=true");
            }
        }
        function saveData() {
            if (confirm("您确定要保存数据吗?")) {
                var hd = $("#<%=HDData.ClientID%>");
                var data = document.AF.func("GetChangedXml", "level=1");
                hd.val(encodeURIComponent(data));
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
                    <li class="last">维修厂家管理</li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始
        <div id="main-tool" style="height: 45px; vertical-align: central;">--%>
        <%--    <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>维修厂家列表</span>
            </div>
        </div>
        <div class="main-gridview">
            <div class="main-gridview-title">
                <asp:LinkButton ID="LnkBtn_Save" runat="server" class="easyui-linkbutton" iconCls="icon-save"
                    OnClientClick="return saveData();" OnClick="LnkBtn_Save_Click" plain="true">保存数据</asp:LinkButton>
                &nbsp;&nbsp;
                <asp:LinkButton ID="LnkBtn_Cancel" runat="server" class="easyui-linkbutton" iconCls="icon-cancel"
                    OnClientClick="deletechecked();return false;" plain="true">删除选中行</asp:LinkButton>
            </div>
            <%--数据表格开始--%>
            <asp:HiddenField ID="HDData" runat="server" ClientIDMode="Static" />
            <div style="width: 100%; height: 500px;" id="dAF">
                <script type="text/javascript">
                    insertTreeList("AF", "");
                </script>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var height1 = $(window).height();
        var height = height1 * 0.80;
        $("#dAF").height(height);
    </script>
</asp:Content>
