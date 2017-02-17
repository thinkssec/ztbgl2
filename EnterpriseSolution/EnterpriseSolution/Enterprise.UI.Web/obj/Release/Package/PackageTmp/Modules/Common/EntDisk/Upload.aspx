<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/Common/EntDisk/MainPage.Master"
    AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="Enterprise.UI.Web.Modules.EntDisk.Upload" %>

<%@ Import Namespace="Enterprise.Component.Infrastructure" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" href="Content/Css/default.css" rel="Stylesheet" />
    <link href="Content/Css/global.css" type="text/css" rel="Stylesheet" />
    <link href="Content/Css/skin_blue.css" type="text/css" rel="Stylesheet" />
    <link href="Content/Css/style.css" rel="Stylesheet" type="text/css" />
    <link href="../../../Resources/uploadify/uploadify.css" rel="stylesheet" type="text/css" /> 
    <script src="../../../Resources/OA/jquery/jquery-1.8.0.min.js" type="text/javascript"></script>
    <script src="../../../Resources/uploadify/jquery.uploadify.min.js" type="text/javascript"></script>
    <%-- 
    <script type="text/javascript" src="Script/swfupload.js"></script>
    <script type="text/javascript" src="Script/swfupload.queue.js"></script>
    <script type="text/javascript" src="Script/fileprogress.js"></script>
    <script type="text/javascript" src="Script/handlers.js"></script>
    --%>
    <script type="text/javascript">
        function dgClose() {
            parent.$('#w').window('close');
            parent.location.reload();
        }
        $(function () {
            //上传
            $('#file_upload').uploadify({
                'buttonText': '请选择文件',
                'swf': '../../../Resources/uploadify/uploadify.swf',
                'uploader': '../../../Resources/uploadify/uploadify.ashx?path=<%=FileHelper.Encrypt(filePath) %>',
                'cancelImg': '../../../Resources/uploadify/cancel.png',
                'removeCompleted': true,
                'hideButton': true,
                'auto': true,
                'multi': true,
                'queueID': 'upload-queue',
                'fileTypeDesc': 'ALL Files',
                'fileSizeLimit': '500000KB',
                'fileTypeExts': '*.jpg;*.gif;*.bmp;*.jpeg;*.png;*.rar;*.zip;*.pdf;*.doc;*.docx;*.xls;*.xlsx;*.ppt;*.pptx;*.txt;',
                'onUploadError': function (file, errorCode, errorMsg, errorString) {
                    //$.messager.alert(errorCode, errorMsg, 'error');
                },
                'onQueueComplete': function (queueData) {
                    //if (queueData.uploadsSuccessful > 0) {
                    //    //$.messager.alert('Success', '上传文件成功!', 'info');
                    //}
                },
                'onUploadSuccess': function (file, data, response) {
                    //$("#divStatus").html(file.name + " OK.");
                }
            });

        });
    </script>
    <style type="text/css">
        .btnC
        {
            height: 30px;
            border: 1px solid #808080;
            width: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div style="margin: 5px 0 0 5px;">
        位置:<asp:Label ID="fPath_Txt" runat="server"></asp:Label>
    </div>
    <div class="fieldset flash" id="upload-queue" style="width: 420px; margin-top: 20px;">
        <span class="legend">上传队列</span>
    </div>
    <div id="divStatus">
    </div>
    <div style="margin-left: 10px;">
        <input id="file_upload" type="file" name="Filedata" /><input type="button" value="上传完成" onclick="dgClose();" class="btnC" />
        <%-- 
        <span id="spanButtonPlaceHolder"></span>&nbsp;<input id="btnCancel" type="button"
            value="取消所有上传" onclick="swfu.cancelQueue();" disabled="disabled" />
        --%>
    </div>
    <%-- 
    <script type="text/javascript">
        var swfu;
        window.onload = function () {
            var settings = {
                flash_url: "/Modules/Common/EntDisk/Script/Swf/swfupload.swf",
                upload_url: "/Modules/Common/EntDisk/Content/Ashx/Upload.ashx?path=<%=FileHelper.Encrypt(filePath) %>",
                post_params: { "ASPSESSID": "<%=Session.SessionID %>" },
                file_size_limit: "100 MB",
                file_types: "*.*",
                file_types_description: "所有文件",
                file_upload_limit: 100,
                file_queue_limit: 0,
                custom_settings: {
                    progressTarget: "fsUploadProgress",
                    cancelButtonId: "btnCancel"
                },
                debug: false,

                // Button settings
                button_image_url: "/Modules/Common/EntDisk/Content/Img/XPButtonNoText_160x22.png",
                button_width: "160",
                button_height: "22",
                button_placeholder_id: "spanButtonPlaceHolder",
                button_text: '点击浏览上传(&lt;100M)',
                button_text_style: ".button { font-family: Helvetica, Arial, sans-serif; font-size: 14pt; } .buttonSmall { font-size: 10pt; }",
                button_text_left_padding: 5,
                button_text_top_padding: 1,

                // The event handler functions are defined in handlers.js
                file_queued_handler: fileQueued,
                file_queue_error_handler: fileQueueError,
                file_dialog_complete_handler: fileDialogComplete,
                upload_start_handler: uploadStart,
                upload_progress_handler: uploadProgress,
                upload_error_handler: uploadError,
                upload_success_handler: uploadSuccess,
                upload_complete_handler: uploadComplete,
                queue_complete_handler: queueComplete	// Queue plugin event
            };

            swfu = new SWFUpload(settings);
        };
    </script>
    --%>
</asp:Content>
