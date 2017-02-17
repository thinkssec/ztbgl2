﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/Common/EntDisk/MainPage.Master" AutoEventWireup="true" CodeBehind="FolderInfo.aspx.cs" Inherits="Enterprise.UI.Web.Modules.EntDisk.FolderInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link href="Content/Css/global.css" type="text/css" rel="Stylesheet" />
    <link href="Content/Css/skin_blue.css" type="text/css" rel="Stylesheet" />
    <link href="Content/Css/style.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
<div id="dvMsgbox" style="display: block;" class="gSys-msg">
        <div style="" class="cont bdr-c-dark">
            <div class="gSys-inner-netfolder">
                <div class="gSys-body edit">
                    <table class="g-table-optcomm">
                        <tbody>
                            <tr>
                                <th>
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("文件名")%>：
                                </th>
                                <td>
                                    <asp:TextBox ID="fName_Txt" runat="server"></asp:TextBox><asp:HiddenField ID="hfName_Txt"
                                        runat="server" />
                                    <asp:HiddenField ID="hfPath_Txt" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("备注")%>：
                                </th>
                                <td>
                                    <textarea onfocus="if(this.innerHTML == '暂未添加'){this.innerHTML = '';}" class="txt-info"
                                        rows="3" cols="50" id="fileMemo">暂未添加</textarea>
                                </td>
                            </tr>
                            <tr>
                                <th>
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("文件数")%>：
                                </th>
                                <td>
                                    <%=fNum %>
                                </td>
                            </tr>
                            <%-- <tr>
                                <th>
                                    文件夹大小：
                                </th>
                                <td>
                                    
                                </td>
                            </tr>--%>
                            <tr>
                                <th>
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("所在位置")%>：
                                </th>
                                <td>
                                    <%= fPath%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="ft bdr-c-dark bg-cont" style="margin-left: 100px;">
            <div class="opt">
                <asp:ImageButton ID="btnMsgOk" runat="server" ImageUrl="Content/Img/ok.jpg" OnClick="btnMsgOk_OnClick" />                
            </div>
        </div>
    </div>
</asp:Content>
