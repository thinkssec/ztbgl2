<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Index.aspx.cs" Inherits="Enterprise.UI.Web.Modules.EntDisk.Index" %>

<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Enterprise.Model.Common.EntDisk" %>
<%@ Import Namespace="Enterprise.Service.Common.EntDisk" %>
<%@ Import Namespace="System.IO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/Css/global.css" type="text/css" rel="Stylesheet" />
    <link href="Content/Css/skin_blue.css" type="text/css" rel="Stylesheet" />
    <link href="Content/Css/style.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript">
        //第二种普通函数式调用
        function opdg(stitle, surl) {
            easyui_dialog(stitle, surl);
        }
        function easyui_dialog(stitle, surl) {
            $('#w').window({
                width: 480,
                height: 400,
                modal: true
            });
            $('#w').window("open");
            $('#wifm').attr('src', surl);
        }
    </script>
    <script lang="javascript" type="text/javascript">
        function ShowDiv(id) {
            $("#tr_" + id).attr("style", "background-color: rgb(255, 255, 220);");
            $("#" + id).addClass("oprt txt-link");
            $("#" + id).show();
        }

        function HideDiv(id) {
            $("#tr_" + id).attr("style", "background-color: rgb(255, 255, 255);");
            $("#" + id).hide();
        }

        function DeleteOption() {
            var check = $("input:checked");
            var actor_config = "";           //定义变量
            check.each(function (i) {        //循环拼装被选中项的值
                actor_config += $(this).val() + '|';
            });
            opdg('删除选中文件', '/Modules/Common/EntDisk/DeleteSelect.aspx?filepath=<%=FilePathName %>&file=' + actor_config);
        }

        function MoveOption() {
            var check = $("input:checked");
            var actor_config = "";               //定义变量
            check.each(function (i) {        //循环拼装被选中项的值
                actor_config += $(this).val() + '|';
            });
            opdg('移动选中文件', '/Modules/Common/EntDisk/MoveSelect.aspx?filepath=<%=FilePathName %>&typeId=<%=typeId%>&file=' + actor_config);
        }
    </script>
    <style type="text/css">
        .current {
            background-color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <%--导航条开始--%>
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/">首页</a></li>
                    <li>办公事务</li>
                    <li>存储空间</li>
                    <li class="last">
                        <a href="Index.aspx">[公共存储]</a><a href="#">&nbsp;&nbsp;|&nbsp;&nbsp;</a>
                        <a href="Index.aspx?typeId=1">[个人存储]</a>
                    </li>
                </ul>
            </div>
        </div>
        <%--end--%>
        <%--权限按钮开始--%>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
        <%--end--%>
    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <%-------------------具体内容----------------------%>
            <div class="gNetfolder">
                <div class="g-title-1">
                    <h2>
                        <%=FileName %></h2>
                    <span class="txt-info">
                        <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("共")%><%=folderNum %><%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("个")%><%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("文件夹")%>
                        <%=fileNum %><%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("个")%><%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("文件")%>
                    </span>
                </div>
                <div class="path">
                    <a>
                        <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("路径")%></a>：
                        <span class="txt-info"><%=nav %></span>
                </div>
                <div class="g-toolbar">
                    <div class="btngrp">
                        <%if (CheckPower(4))
                          {%>
                        <a class="btn btn-dft txt-b" onclick='opdg("上传文件","/Modules/Common/EntDisk/Upload.aspx?filepath=<%=FilePathName %>")'
                            href="#"><span>
                                <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("上传")%></span></a>
                        <%} %>
                    </div>
                    <div class="btngrp">
                        <%if (CheckPower(4))
                          {%>
                        <a onclick="opdg('新建文件夹','/Modules/Common/EntDisk/CreateFolder.aspx?filepath=<%=FilePathName %>')"
                            class="btn btn-dft" href="#"><span>
                                <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("新建文件夹")%></span></a>
                        <%} %>
                    </div>
                    <div class="btngrp">
                        <%if (CheckPower(16))
                          {%>
                        <a onclick="DeleteOption();" class="btn btn-dft btn-dft-gl" href="#"><span>
                            <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("删除")%></span></a>
                        <%} %>
                        <%if (CheckPower(8))
                          {%>
                        <a onclick="MoveOption();" class="btn btn-dft btn-dft-gr" href="#"><span>
                            <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("移动")%></span></a>
                        <%} %>
                    </div>
                </div>
                <div style="" class="gNetfolder-list" id="divList">
                    <table class="g-table-comm">
                        <thead>
                            <tr>
                                <th class="wd0"></th>
                                <th class="wd1 ckb"></th>
                                <th class="wd2">
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("文件名")%>
                                </th>
                                <th class="wd3">
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("大小")%>
                                </th>
                                <th class="wd5">
                                    <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("时间")%><b class="ico ico-list-down"></b>
                                </th>
                            </tr>
                        </thead>
                        <%if (!String.IsNullOrEmpty(rootFolder))
                          { %>
                        <tbody class="back">
                            <tr>
                                <td class="wd0"></td>
                                <td class="wd1 ckb"></td>
                                <td colspan="3">
                                    <a href="Index.aspx?sid=<%=sid %>&typeId=<%=typeId %>&amp;desc=true&amp;fid=<%=BackFilePathName %>">
                                        <b class="ico ico-back"></b>
                                        <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("返回上级")%></a>
                                </td>
                            </tr>
                        </tbody>
                        <%} %>
                        <tbody id="listBody">
                            <%List<FileModel> list = FileList; %>
                            <%foreach (FileModel file in list)
                              {
                                  Guid gId = Guid.NewGuid();
                            %>
                            <tr id="tr_<%=gId %>" style="background-color: rgb(255, 255, 255);" onmousemove="javascript:ShowDiv('<%=gId %>');"
                                onmouseout="javascript:HideDiv('<%=gId %>');">
                                <td class="wd0"></td>
                                <td class="wd1 ckb">
                                    <input type="checkbox" id="chk_<%=gId %>" value="<%=Enterprise.Component.Infrastructure.FileHelper.Encrypt(Path.GetFileName(file.fileName)) %>"
                                        class="checkbox" />
                                </td>
                                <td class="wd2">
                                    <%=Enterprise.Component.Infrastructure.FileHelper.GetFileIco("ext"+Path.GetExtension(file.fileName) )%>
                                    <%if (file.fileType == 0)
                                      { %>
                                    <a class="name" href="Index.aspx?sid=<%=sid %>&typeId=<%=typeId %>&amp;desc=true&amp;fid=<%=FilePathName+Path.DirectorySeparatorChar+Path.GetFileName(file.fileName) %>">
                                        <%=Path.GetFileName(file.fileName)%></a> <span title="undefined" class="txt-info">(<%=FileService.GetAllNodesCount(FilePathName+Enterprise.Component.Infrastructure.FileHelper.Encrypt(Path.DirectorySeparatorChar+Path.GetFileName(file.fileName))) %>)</span>
                                    <span id="<%=gId %>" style="display: none;">[
                                        <%if (CheckPower(8))
                                          {%>
                                        <a href="#" onclick="opdg('文件夹详情','/Modules/Common/EntDisk/FolderInfo.aspx?filepath=<%=FilePathName %>&filename=<%=Enterprise.Component.Infrastructure.FileHelper.Encrypt( Path.GetFileName(file.fileName)) %>');">
                                            <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("改名")%></a>
                                        <%} %>|
                                <%if (CheckPower(16))
                                  {%><a href="#" onclick="opdg('删除文件夹','/Modules/Common/EntDisk/DeleteFolder.aspx?filepath=<%=FilePathName %>&filename=<%=Enterprise.Component.Infrastructure.FileHelper.Encrypt(Path.GetFileName(file.fileName)) %>');">
                                      <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("删除")%></a><%} %>
                                ]</span>
                                    <%}
                                      else
                                      { %>
                                    <%=Path.GetFileName(file.fileName)%>
                                    <span id="<%=gId %>" style="display: none;">[ <a href="Content/Ashx/FileDownload.ashx?path=<%=FilePathName %>&url=<%=Enterprise.Component.Infrastructure.FileHelper.Encrypt(Path.GetFileName(file.fileName)) %>">
                                        <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("下载")%></a> |
                                <%if (CheckPower(8))
                                  {%>
                                        <a href="#" onclick="opdg('文件详情','/Modules/Common/EntDisk/FileInfo.aspx?filepath=<%=FilePathName %>&filename=<%=Enterprise.Component.Infrastructure.FileHelper.Encrypt(Path.GetFileName(file.fileName)) %>');">
                                            <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("改名")%></a>
                                        <%} %>
                                |
                                <%if (CheckPower(16))
                                  {%>
                                        <a href="#" onclick="opdg('删除文件','/Modules/Common/EntDisk/DeleteFile.aspx?filepath=<%=FilePathName %>&filename=<%=Enterprise.Component.Infrastructure.FileHelper.Encrypt(Path.GetFileName(file.fileName)) %>');">
                                            <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("删除")%></a><%} %>
                                ]</span>
                                    <%} %>
                                </td>
                                <%if (file.fileType == 0)
                                  { %>
                                <td class="wd3">
                                    <%=FileService.GetFileLength(FileService.GetFloderLength(FilePathName, Path.GetFileName(file.fileName)))%>
                                </td>
                                <td class="wd5"></td>
                                <%}
                                  else if (file.fileType == 1)
                                  {
                                      var fi = FileService.GetFileInfo(FilePathName, Path.GetFileName(file.fileName));%>
                                <td class="wd3">
                                    <%=FileService.GetFileLength(fi.Length)%>
                                </td>
                                <td class="wd5">
                                    <%=fi.CreationTime %>
                                </td>
                                <%} %>
                            </tr>
                            <%} %>
                        </tbody>
                    </table>
                </div>
                <div class="g-toolbar">
                    <div class="btngrp">
                        <%if (CheckPower(4))
                          {%>
                        <a class="btn btn-dft txt-b" onclick='opdg("上传文件","/Modules/Common/EntDisk/Upload.aspx?filepath=<%=FilePathName %>")'
                            href="#"><span>
                                <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("上传")%></span></a>
                        <%} %>
                    </div>
                    <div class="btngrp">
                        <%if (CheckPower(4))
                          {%>
                        <a onclick="opdg('新建文件夹','/Modules/Common/EntDisk/CreateFolder.aspx?filepath=<%=FilePathName %>')"
                            class="btn btn-dft" href="#"><span>
                                <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("新建文件夹")%></span></a>
                        <%} %>
                    </div>
                    <div class="btngrp">
                        <%if (CheckPower(16))
                          {%>
                        <a onclick="DeleteOption();" class="btn btn-dft btn-dft-gl" href="#"><span>
                            <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("删除")%></span></a><%-- <a onclick="fWpPatchDel();" class="btn btn-dft btn-dft-gc" href="javascript:fGoto()">
                        <span>删 除</span></a> <a onclick="fWpSendFile();" class="btn btn-dft btn-dft-gc" href="javascript:fGoto()">
                            <span>发 送</span></a> --%>
                        <%} %>
                        <%if (CheckPower(8))
                          {%>
                        <a onclick="MoveOption();" class="btn btn-dft btn-dft-gr" href="#"><span>
                            <%=Enterprise.Service.Basis.Sys.SysDictionaryService.TransTo("移动")%></span></a>
                        <%} %>
                    </div>
                </div>
            </div>
            <div id="w" class="easyui-window" title="Storage Space" data-options="iconCls:'icon-save'"
                closed="true" style="width: 700px; height: 350px; padding: 5px; overflow: hidden">
                <iframe id="wifm" frameborder="0" scrolling="no" width="700px" height="370px"></iframe>
            </div>
        </div>
    </div>
</asp:Content>
