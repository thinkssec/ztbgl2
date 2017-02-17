<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ArticleDetail.aspx.cs"
    Inherits="Enterprise.UI.Web.Modules.Common.Article.ArticleDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ArticleShow</title>
    <%--IE Mode -- %>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <%--icon--%>
    <link rel="stylesheet" href="/Resources/OA/easyui1.32/themes/icon.css">
    <%--default--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/default/easyui.css" title="default" />
    <link rel="Stylesheet" href="/Resources/OA/site_skin/default/site.main.css" title="default" />


    <%--black--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/black/easyui.css" title="black" />
    <link rel="Stylesheet" href="/Resources/OA/site_skin/black/site.main.css" title="black" />

    <%-- metro--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/metro/easyui.css" title="metro" />
    <link rel="Stylesheet" href="/Resources/OA/site_skin/metro/site.main.css" title="metro" />

    <%--bootstrap--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/bootstrap/easyui.css" title="bootstrap" />
    <link rel="Stylesheet" href="/Resources/OA/site_skin/bootstrap/site.main.css" title="bootstrap" />

    <%--gray--%>
    <link rel="Stylesheet" href="/Resources/OA/easyui1.32/themes/gray/easyui.css" title="gray" />
    <link rel="Stylesheet" href="/Resources/OA/site_skin/gray/site.main.css" title="gray" />

    <%--script--%>
    <script type="text/javascript" src="/Resources/OA/jquery/jquery-1.8.0.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/easyui1.32/jquery.easyui.min.js"></script>
    <script type="text/javascript" src="/Resources/OA/easyui1.32/locale/easyui-lang-zh_CN.js"></script>
    <%--switch--%>
    <script type="text/javascript" src="/Resources/OA/site_skin/scripts/Base.js"></script>
    <script type="text/javascript" src="/Resources/OA/site_skin/scripts/Common.js"></script>
    <script type="text/javascript" src="/Resources/OA/site_skin/scripts/switch.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            showall();
            $.ajaxSetup({
                cache: false
            });
            var ajaxloding = '<div class="ajax">loading...</div>';
            setTimeout($('#qianshou').html(ajaxloding).load('/Modules/Common/Article/ArticleShow.aspx?Id=<%=Id %>&type=ok'), 1000);
            setTimeout($('#weiqianshou').html(ajaxloding).load('/Modules/Common/Article/ArticleShow.aspx?Id=<%=Id %>&type=no'), 1000);
        });

        function changesize(px) {
            $('#articlecontent').removeClass();
            $('#articlecontent').addClass('ssec-font-' + px);
        }

        function showQianshou() {
            $('#showResultWindow').window('open');
        }
        function showWeiQianshou() {
            $('#showWqsResultWindow').window('open');
        }

        function showcn() {
            $('#s_ru_and_cn').hide();
            $('#s_ru').hide();
            $('#s_cn').show();
        }

        function showru() {
            $('#s_ru_and_cn').hide();
            $('#s_ru').show();
            $('#s_cn').hide();
        }

        function showall() {
            $('#s_ru_and_cn').show();
            $('#s_ru').hide();
            $('#s_cn').hide();
        }
    </script>
    <style type="text/css">
        .ssec-font-s {
            font-size: 12px;
        }

        .ssec-font-m {
            font-size: 14px;
        }

        .ssec-font-l {
            font-size: 18px;
        }

        .titleColor {
            color: #1251a7;
        }
    </style>
</head>
<body style="background-image: url(/Resources/Styles/images/body_2.png); background-repeat: repeat-x;">
    <form id="form1" runat="server">
        <table width="100%" border="0">
            <tr>
                <td align="center" style="line-height: 40px;">
                    <span style="font-size: 18px; font-weight: bold;">
                        <asp:Label ID="lb_Title" runat="server" CssClass="titleColor"></asp:Label>
                    </span>
                </td>
            </tr>
        </table>
        <div style="padding-top: 20px;">
        </div>
        <table border="1" cellpadding="0" cellspacing="0" width="90%" align="center" style="background-color: white; grid-cell: inherit; border-collapse: collapse;">
            <tr>
                <td style="text-align: left;">
                    <table border="0" cellpadding="0" cellspacing="0" style="height: 36px; font-size: 14px; border-collapse: collapse; width: 100%">
                        <tr style="background-color: #c0d2ea; background-image: url(/Resources/Styles/images/artcilebg.gif); background-repeat: repeat-x;">
                            <td style="text-align: right;" class="auto-style1">
                                <%=Trans("部门/单位") %>：<asp:Label ID="lb_Dept" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <%=Trans("发布人") %>：<asp:Label ID="lb_User" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <%=Trans("发布日期") %>：<asp:Label ID="lb_CreateTime" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <%=Trans("字体大小") %>：<a href="#" onclick="changesize('s');"> <span>
                                <%=Trans("小") %></span></a><a href="#" onclick="changesize('m');"> <span>
                                    <%=Trans("中") %></span></a><a href="#" onclick="changesize('l');"> <span>
                                        <%=Trans("大") %></span></a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <%--【<a href="#" onclick="showcn();">中文</a>&nbsp;|&nbsp;
                            <a href="#" onclick="showru();">русский</a>
                            &nbsp;|&nbsp;<a href="#" onclick="showall();">ALL</a>】 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" id="articlecontent" width="100%">
                        <tr id="s_ru_and_cn" runat="server" clientidmode="Static">
                            <td style="width: 50%; height: 500px; padding: 10px;" valign="top" align="left">
                                <asp:Label ID="lb_Content" runat="server"></asp:Label>
                            </td>
                            <%--<td style="width: 50%; border-left: 1px solid #333; padding: 10px;" valign="top"
                            align="left">
                            <asp:Label ID="lb_ContentRu" runat="server"></asp:Label>
                        </td>--%>
                        </tr>
                        <tr runat="server" id="s_cn" clientidmode="Static">
                            <td style="width: 100%; height: 500px; padding: 10px;" valign="top" align="left">
                                <asp:Label ID="lb_Content0" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr runat="server" id="s_ru" clientidmode="Static">
                        <td style="width: 100%; height: 500px; padding: 10px;" valign="top" align="left">
                            <asp:Label ID="lb_ContentRu0" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" align="center">
                        <tr>
                            <td style="width: 120px; height: 28px; text-align: right; border-bottom: 1px solid #333333;">
                                <%=Trans("附件") %>：
                            </td>
                            <td style="border-bottom: 1px solid #333333; border-left: 1px solid #333333; padding-left: 5px;">
                                <asp:Label ID="lb_Files" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 28px; text-align: right; border-bottom: 1px solid #333333;">
                                <%=Trans("有效期") %>：
                            </td>
                            <td style="border-bottom: 1px solid #333333; border-left: 1px solid #333333; padding-left: 5px;"></td>
                        </tr>
                        <tr>
                            <td class="ttl" id="ok" style="cursor: pointer; height: 28px; text-align: right; border-bottom: 1px solid #333333;">
                                <%=Trans("已签收") %>：
                            </td>
                            <td style="border-bottom: 1px solid #333333; border-left: 1px solid #333333; padding-left: 5px;">
                                <div>
                                    <a href="#" onclick="showQianshou();">
                                        <img src="/Resources/Styles/icon/application_edit.png" alt=""
                                            style="cursor: pointer;" />&nbsp;<%=Trans("查看")%></a>
                                </div>
                                <div id="showResultWindow" class="easyui-window" title="<%=Trans("签收情况")%>" closed="true"
                                    modal="true" collapsible="false" maximizable="false" minimizable="false" style="width: 500px; height: 400px; padding: 10px;">
                                    <span id="qianshou"></span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td id="no" style="text-align: right; height: 28px" class="auto-style2">
                                <%=Trans("未签收") %>：
                            </td>
                            <td style="border-left: 1px solid #333333; padding-left: 5px;" class="auto-style3">
                                <div>
                                    <a href="#" onclick="showWeiQianshou();">
                                        <img src="/Resources/Styles/icon/application_error.png" alt=""
                                            style="cursor: pointer;" />&nbsp;<%=Trans("查看")%></a>
                                </div>
                                <div id="showWqsResultWindow" class="easyui-window" title="<%=Trans("未签收情况")%>" closed="true"
                                    modal="true" collapsible="false" maximizable="false" minimizable="false" style="width: 500px; height: 400px; padding: 10px;">
                                    <span id="weiqianshou"></span>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
