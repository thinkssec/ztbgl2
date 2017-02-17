<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    ValidateRequest="false" CodeBehind="Helper.aspx.cs" Inherits="Enterprise.UI.Web.Help.Helper" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../Resources/Styles/css/ssec-form.css" />
    <link rel="stylesheet" type="text/css" href="../Resources/Styles/css/gridview.css" />
    <style type="text/css">
    .VideoTD 
    {
        text-align:left;
        padding:10px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div class="vDaohangtiaoHolder module">
        <div class="vDaohangtiao">
            <ul>
                <li class="first"><a href="/Index.aspx" title="首页">
                    <%=Trans("首页")%></a> </li>
                <li class="last">
                    <%=Trans("系统帮助")%>
                </li>
            </ul>
        </div>
    </div>
    <hr />
    <br />
    <div class="linkswrapper table-box">
        <table style="width: 100%; padding: 10px;">
            <tr align="center">
                <td>
                    <b>用户手册（PDF）</b>
                </td>
            </tr>
            <tr>
                <td>
                    1、&nbsp;<img alt="" src="../Resources/Common/filetype/pdf.gif" />RTX客户端安装手册&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<a href="../Component/FlexPaper/PdfViewer.aspx?swfFn=RTXzhcn" target="_blank">在线查看</a>|<a href="../Component/FlexPaper/PdfViewer.aspx?swfFn=RTXru" target="_blank">смотреть</a>]&nbsp;&nbsp;&nbsp;&nbsp;[<a href="RTX_中文_readme.pdf" target="_blank">下载</a>|<a href="RTX_русский_readme.pdf" target="_blank">скачать</a>]
                </td>
            </tr>
            <tr>
                <td>
                    2、&nbsp;<img alt="" src="../Resources/Common/filetype/pdf.gif" />协同平台用户手册&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[<a href="../Component/FlexPaper/PdfViewer.aspx?swfFn=FIOC" target="_blank">在线查看</a>|<a href="../Component/FlexPaper/PdfViewer.aspx?swfFn=FIOC" target="_blank">смотреть</a>]&nbsp;&nbsp;&nbsp;&nbsp;[<a href="FIOC协同平台用户手册.pdf" target="_blank">下载</a>|<a href="FIOC协同平台用户手册.pdf" target="_blank">скачать</a>]
                </td>
            </tr>
            <tr align="center">
                <td>
                    <b>操作视频演示</b>
                </td>
            </tr>
            <tr align="center">
                <td>
                    <table style="width: 98%;padding:15px; text-align:center;">
                        <tr>
                            <td width="10%">
                                1&nbsp;
                            </td>
                            <td width="25%" class="VideoTD">
                                通知公告&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/tongzhi/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/tongzhi/tongzhi.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td width="10%">
                                8&nbsp;
                            </td>
                            <td width="25%" class="VideoTD">
                                公共事务&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/gonggongshiwu/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/gonggongshiwu/gonggongshiwu.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td width="10%">
                                &nbsp;
                            </td>
                            <td width="25%" class="VideoTD">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                2&nbsp;
                            </td>
                            <td class="VideoTD">
                                会议管理&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/huiyi/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/huiyi/huiyi.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                9&nbsp;
                            </td>
                            <td class="VideoTD">
                                个人事务&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/gerenshiwu/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/gerenshiwu/gerenshiwu.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="VideoTD">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                3&nbsp;
                            </td>
                            <td class="VideoTD">
                                公文管理&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/gongwenguanli/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/gongwenguanli/gongwenguanli.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                10&nbsp;
                            </td>
                            <td class="VideoTD">
                                业务管理&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/yewuxitong/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/yewuxitong/yewuxitong.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="VideoTD">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                4&nbsp;
                            </td>
                            <td class="VideoTD">
                                公文流转&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/gongwenliuzhuan/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/gongwenliuzhuan/gongwenliuzhuan.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                11&nbsp;
                            </td>
                            <td class="VideoTD">
                                人力资源&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/renliziyuan/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/renliziyuan/renliziyuan.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="VideoTD">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                5&nbsp;
                            </td>
                            <td class="VideoTD">
                                差旅管理&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/chuchai/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/chuchai/chuchai.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                12&nbsp;
                            </td>
                            <td class="VideoTD">
                                系统管理&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/xitongguanli/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/xitongguanli/xitongguanli.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="VideoTD">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                6&nbsp;
                            </td>
                            <td class="VideoTD">
                                事务督办&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/shiwuduban/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/shiwuduban/shiwuduban.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="VideoTD">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="VideoTD">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                7&nbsp;
                            </td>
                            <td class="VideoTD">
                                企业文化&nbsp;&nbsp;&nbsp;&nbsp;
                                [<a href='video/qiyewenhua/index.html' target='_blank'><img alt="" src="../Resources/Common/filetype/swf.gif" /></a>&nbsp;|&nbsp;<a href='video/qiyewenhua/qiyewenhua.mp4' target='_blank'><img alt="" src="../Resources/Common/filetype/avi.gif" /></a>]
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="VideoTD">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td class="VideoTD">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
