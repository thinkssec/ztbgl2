<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/Common/EntDisk/MainPage.Master" AutoEventWireup="true"
    CodeBehind="DeleteFile.aspx.cs" Inherits="Enterprise.UI.Web.Modules.EntDisk.DeleteFile" %>

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
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("位置")%>：
                                </th>
                                <td>
                                    <asp:Label ID="filePatn_Txt" runat="server"></asp:Label><asp:HiddenField ID="hfilePath" runat="server" />
                                </td>
                            </tr>    
                            <tr>
                                <th>
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("文件名")%>：
                                </th>
                                <td>
                                    <asp:Label ID="fileName_Txt" runat="server"></asp:Label><asp:HiddenField ID="hfileName" runat="server" />
                                </td>
                            </tr>                            
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div class="ft bdr-c-dark bg-cont" style="margin-left: 100px;">
            <div class="opt">
                <asp:ImageButton ID="delete" runat="server" ImageUrl="Content/Img/ok.jpg" OnClick="delete_OnClick" />
            </div>
        </div>
    </div>
</asp:Content>
