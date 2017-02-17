<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DemoCombogrid.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.DemoCombogrid" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="/Resources/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/Resources/uploadify/jquery.uploadify.min.js"></script>
    <script charset="utf-8" src="/Resources/kindeditor-4.1.1/kindeditor.js" type="text/javascript"></script>
    <script charset="utf-8" src="/Resources/kindeditor-4.1.1/lang/zh_CN.js" type="text/javascript"></script>
    <script>
        function checkInputForm() {
            alert($('#Ddp_Person').combobox('getValue'));
            var Pid = $('#Ddp_Person').combobox('getValue');
           // var P = $('#<%=HiddenField1.ClientID%>').val(Pid);
            document.getElementById('HiddenField1').value = Pid;
            alert(document.getElementById('HiddenField1').value);
            return true;

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">

    <a href="#" onclick="alert($('#Ddp_Person').combobox('getValue'));">click</a>

    <%--<select id="Ddp_Info" class="easyui-combogrid" style="width: 250px;"
        data-options="panelWidth:600,idField:'id',textField:'text',
            url:'/Component/UserControl/Json/GetDWMC.ashx',
            columns:[[
                {field:'text',title:'客户单位名称',width:340},
                {field:'text1',title:'客户性质',width:100},
                {field:'text2',title:'客户维护人',width:100}
            ]]">
    </select>--%>

    <asp:DropDownList ID="Ddp_info" ClientIDMode="Static" runat="server" CssClass="easyui-combogrid" Width="300px"></asp:DropDownList>
    <%--<select id="" class="easyui-combogrid" style="width: 250px;"></select>--%>

    <asp:DropDownList ID="Ddp_Person" ClientIDMode="Static" runat="server" CssClass="easyui-combobox" Width="300px"></asp:DropDownList>
    <asp:HiddenField ID="HiddenField1" ClientIDMode="Static" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="return checkInputForm()" OnClick="Button1_Click" />
    <script>
        $('#Ddp_Person').combobox({
            //editable:false,
            valueField: "id",
            textField: "text",
            // url: '/Component/UserControl/Json/GetDWLianxiren.ashx',
            //onSelect: function () {
            //  alert( $('#Ddp_Person').combobox('getValue'));
            // }
            
        });
        $('#Ddp_info').combogrid({
            panelWidth: 800,
            panelHeight:400,
            editable:false,
            //value:'safds',//缺省值
            idField: "id",
            textField: "text",
            url: '/Component/UserControl/Json/GetDWMC.ashx',
            columns: [[
            { field: 'text', title: '客户单位名称', width: 350 },
            { field: 'text2', title: '客户性质', width: 80 },
            { field: 'text1', title: '单位地址', width: 370 }
            
            ]],
            onSelect: function () {
                var g = $('#Ddp_info').combogrid('grid');	// get datagrid object
                var r = g.datagrid('getSelected');
                //alert(r.id);
                //var r = this.datagrid('getSelected');
                var url = '/Component/UserControl/Json/GetDWLianxiren.ashx?DWID=' + r.id;
                //alert(rec.id);
                $('#<%=Ddp_Person.ClientID%>').combobox('reload', url);
                //$('#<%=Ddp_Person.ClientID%>').combobox('setValue', '');
            }
        });
    </script>

    <%--    <script>
        $(function () {
            alert('qqq');
            $("#Ddp_info").combogrid({
                panelWidth: 400,
                //value:'safds',//缺省值
                idField: "id",
                textField: "text",
                url: '/Component/UserControl/Json/GetDWMC.ashx',
                columns: [[
                { field: 'text', title: '客户单位名称', width: 340 },
                { field: 'text1', title: '客户性质', width: 100 },
                { field: 'text2', title: '客户维护人', width: 100 }
                ]]
            });
        });
        //重新加载数据源
        //function reload() {
        //    $('#Ddp_info').combogrid('grid').datagrid('reload');
        
    </script>--%>
</asp:Content>
