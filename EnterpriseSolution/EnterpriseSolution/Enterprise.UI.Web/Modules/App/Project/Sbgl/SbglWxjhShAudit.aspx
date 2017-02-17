<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/App/Project/Project.Master" AutoEventWireup="true" 
    CodeBehind="SbglWxjhShAudit.aspx.cs" Inherits="Enterprise.UI.Web.Modules.App.Project.Sbgl.SbglWxjhShAudit" 
    EnableEventValidation="false" %>

<%@ Register Src="~/Component/UserControl/ProjectAuditUControl.ascx" TagPrefix="uc1" TagName="ProjectAuditUControl" %>
<%@ Register Src="~/Component/UserControl/ProjectDoAuditUControl.ascx" TagPrefix="uc1" TagName="ProjectDoAuditUControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnReady(id)  //Treelist抛给页面的事件
        {
            if (id == "AF") {
                //加装相对当前目录下的XML描述文档，创建Treelist
                document.AF.func("Build", "/Modules/App/Project/Sbgl/Xml/SbglWxjhHeader.xml");
                //调用Load函数填充数据
                document.AF.func("Load", "/Modules/App/Project/Sbgl/SbglDataHandler.ashx?type=WXJHSH&PH=<%=wxph%>");
                //在第一列位置插入新列 
                //document.AF.func("InsertCol", "0\r\nname=checked;isCheckboxOnly=true");
                //不可编辑
                document.AF.func("SetProp", "editAble \r\n false");
            }
        }
        function OnEvent(id, Event, p1, p2, p3, p4) {
            if (id == 'AF') {
            }
        }
        function getSelect() {
            if (confirm("您确定要提请领导审核吗?")) {
                return true;
            }
            return false;
        }
        function setListType(v) {
            if (v == 1) {
                //列表
                document.AF.func("SetProp", "curselmode \r\n rows");
                document.AF.func("SetProp", "sort \r\n SBBH a");	//排序
                //document.AF.func("SetColProp", "checked \r\n TreeCombine \r\n");
                document.AF.func("SetProp", "isTree \r\n false");
            }
            else {
                //树
                document.AF.func("SetProp", "curselmode \r\n row");
                document.AF.func("SetProp", "sort \r\n SBLX a");	//排序
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
                    <li class="last">设备维修计划审核</li>
                </ul>
            </div>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="Div2" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <div class="icon-form"></div>
                <span>设备维修计划审核</span>
            </div>
        </div>
        <div class="main-gridview">
            <div class="main-gridview-title">
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
            <asp:Panel ID="Pnl_Audit_Show" runat="server">
                <uc1:ProjectAuditUControl runat="server" ID="UC_Shenhe_Show" />
            </asp:Panel>
            <asp:Panel ID="Pnl_Audit" runat="server" Visible="false">
                <uc1:ProjectDoAuditUControl runat="server" ID="UC_DoShenhe" />
                <div class="ssec-form">
                    <ul>
                        <li class="ssec-label"></li>
                        <li>
                            <div>
                                <asp:LinkButton ID="LnkBtnAudit" CssClass="easyui-linkbutton" iconCls="icon-save" runat="server" OnClick="LnkBtnAudit_Click">审核完成</asp:LinkButton>
                            </div>
                        </li>
                    </ul>
                </div>
            </asp:Panel>
        </div>
    </div>
    <script type="text/javascript">
        var height1 = $(window).height();
        var height = height1 * 0.80;
        //$("#dAF").height(height);
    </script>

</asp:Content>
