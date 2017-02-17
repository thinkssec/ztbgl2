<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterpriseAutoLogin.aspx.cs"
    Inherits="Enterprise.UI.Web.EnterpriseAutoLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript" src="/Resources/Scripts/jquery-1.7.2.min.js"></script> 
    <link rel="stylesheet" href="/Resources/Styles/css/miniindex.css" type="text/css" />
    <script language="vbscript" type="text/vbscript" id="clientEventHandlersVBS">
       <!--'从服务端获取SessionKey
        randomize(time)
        dim intnum
        dim strAccount 
        dim strSignature 
        Sub window_onload()   '服务器端代码，用于验证签名
            on error resume next
            intnum=Int(1000*rnd + 1)
            Set RTXCRoot = RTXAX.GetObject("KernalRoot")  ' 获取KernalRoot对象
            Set rtcData = RTXCRoot.Sign '获取签名，并把它赋给rtcData          
            strAccount = RTXCRoot.Account '获取用户帐号
            strSignature = rtcData.GetString("Sign") '获取rtcData对象的Sign 的内容，也就是用户签名
	        form1.user.value= strAccount
	        form1.sign.value = strSignature
            form1.timestamp.value = intnum
            If Err.Number <> 0 Then
                MsgBox "Error # " & CStr(Err.Number) & " " & Err.Description
                Err.Clear   ' Clear the error.
            Else
                'msgbox intnum
                form1.submit()
            End If
        end sub
        -->
    </script>
</head>
<body style="width: 91px; height: 240px;">
    <form name="form1" method="get" action="MiniLogin.aspx">
        <span style="display: none">用户名：
            <input type="text" name="user" id="user" />
            签&nbsp;&nbsp;名:
            <input type="text" name="sign" />
            <input type="text" name="LoginType" value="1" />
            <input type="text" name="timestamp"/>
        </span>
    </form>
    <div style="display:none;">
        <object id="RTXAX" data="data:application/x-oleobject;base64,fajuXg4WLUqEJ7bDM/7aTQADAAAaAAAAGgAAAA=="
            classid="clsid:5EEEA87D-160E-4A2D-8427-B6C333FEDA4D" VIEWASTEXT>
        </object>
    </div>
</body>
</html>
