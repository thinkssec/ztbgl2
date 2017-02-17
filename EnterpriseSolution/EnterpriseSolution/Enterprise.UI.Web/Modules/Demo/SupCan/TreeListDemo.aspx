<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeListDemo.aspx.cs" ValidateRequest="false" 
    Inherits="Enterprise.UI.Web.Modules.Demo.SupCan.TreeListDemo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="/Resources/OA/easyui1.32/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="/Resources/SupCan/binary/dynaload.js?30" type="text/javascript"></script>
    <script type="text/ecmascript">
        function OnReady(id)  //Treelist抛给页面的事件
        {
            if (id == "AF") {
                //加装相对当前目录下的XML描述文档，创建Treelist
                document.AF.func("Build", "/Modules/Demo/SupCan/treelist/t1.xml");
                //document.AF.func("Build", "/Modules/Demo/SupCan/treelist/t3_1.xml");//多层表头
                //调用Load函数填充数据
                document.AF.func("Load", "/Modules/Demo/SupCan/SupCanDataHandler.ashx");///Modules/Demo/SupCan/SupCanDataHandler.ashx/Modules/Demo/SupCan/treelist/data1.txt
                //在第一列位置插入新列 
                document.AF.func("InsertCol", "0\r\nname=checked;isCheckboxOnly=true");
            }
        }
        function saveData() {
            var hd = $("#<%=HDData.ClientID%>");//document.getElementById("HDData");
            var data = document.AF.func("GetChangedXml", "level=1");
            hd.val(encodeURIComponent(data));
            alert(data + "\r\n" + hd.val());
            //hd.value = data;
            return true;
        }
        function deletechecked() 
        { 
            //删除符合表达式的行
            document.AF.func("DeleteRows", "checked=1");
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 100%;height:500px;" id="dAF">
            <script type="text/javascript">
                insertTreeList("AF", "");
            </script>
        </div>
        <asp:HiddenField ID="HDData" runat="server" ClientIDMode="Static" />
        <asp:Button ID="btnOk" runat="server" Text="保存" OnClientClick="return saveData();" OnClick="btnOk_Click" />
        <input id="Button1" type="button" value="删除选中行" onclick="deletechecked();" />
        <script type="text/javascript">
            var height1 = $(window).height();
            var height = height1 * 0.97;
            $("#dAF").height(height);
        </script>
    </form>
</body>
</html>
