<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserManage.aspx.cs" Inherits="Enterprise.UI.Web.Manage.User.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Resources/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Resources/uploadify/jquery.uploadify.min.js"></script>
     <%--<script type="text/javascript">
         function checkForm() {
             var v = $('#form1').form('validate');
            return v && confirm("您确定要提交吗?");
        }
    </script>--%>
    <script type="text/javascript">
        $(function () {
            //'fileTypeDesc': '',
            $('#file_upload').uploadify({
                'buttonText': '<%=Trans("请选择文件") %>',
                'swf': '../../../Resources/uploadify/uploadify.swf',
                'uploader': '../../../Resources/uploadify/uploadifyImg.ashx',
                'cancelImg': '../../../Resources/uploadify/cancel.png',
                'removeCompleted': true,
                'hideButton': true,
                'auto': true,
                'multi': false,
                'queueID': 'upload-queue',
                'fileSizeLimit': '50KB',
                'fileTypeExts': '*.jpg;*.png;*.gif;*.bmp',
                'onUploadError': function (file, errorCode, errorMsg, errorString) {
                    $.messager.alert(errorCode, errorMsg, 'error');
                },
                'onQueueComplete': function (queueData) {
                    if (queueData.uploadsSuccessful > 0) {
                        $.messager.alert('Success', '上传文件成功!', 'info');
                    }
                },
                'onUploadSuccess': function (file, data, response) {
                    $("#MainPH_Hid_Signature").val(data);
                    $("#MainPH_img_Signature").attr("src", data);
                }
            });
        });
        $.extend($.fn.validatebox.defaults.rules, {
            ip: {
                //验证IP地址 
                validator: function(value, param){
                    var re = /^\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}$/;
                    return re.test(value);  
                }, 
                message: 'IP地址格式不正确'
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <div data-options="region:'north',split:false,border:false" style="padding: 0px; overflow: hidden;">
        <div class="vDaohangtiaoHolder module">
            <div class="vDaohangtiao">
                <ul>
                    <li class="first"><a href="/index.aspx">
                        <%=Trans("首页") %></a> </li>
                    <li>
                        <%=Trans("系统管理") %></li>
                    <li><a href="UserList.aspx">
                        <%=Trans("用户信息") %></a></li>
                    <li class="last">
                        <%=Trans("操作") %>
                    </li>
                </ul>
            </div>
        </div>
        <div id="main-tool">
            <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
            </Ent:HeadMenuWeb>
        </div>
    </div>
    <div data-options="region:'center'">
        <div id="contents" class="ssec-form">
            <div class="ssec-group ssec-group-hasicon">
                <img src="../../../Resources/easyui1.2.6/themes/icons/application.png" alt="" /><span><%=Trans("用户信息") %></span>
            </div>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("姓名") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Name" runat="server" CssClass="easyui-validatebox" required="true" validType="length[0,30]" invalidMessage="不能超过30个字符！"></asp:TextBox>
                    </div>
                </li>
                <li style="width: 30px;"></li>
                <li>
                    <div class="ssec-label">
                        <%=Trans("所属部门") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:DropDownList ID="tb_Dept" runat="server">
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("登录帐号") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Label ID="lb_LoginName" runat="server" Width="147px" Visible="false"></asp:Label>
                        <asp:TextBox ID="tb_LoginName" runat="server" CssClass="easyui-validatebox" required="true" validType="length[0,50]" invalidMessage="不能超过50个字符！"></asp:TextBox>
                    </div>
                </li>
                <li style="width: 30px;"></li>
                <li>
                    <div class="ssec-label">
                        <%=Trans("关系隶属部门")%>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:DropDownList ID="tb_Affiliation" runat="server">
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("出生日期") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Birthday" runat="server" CssClass="easyui-datebox"></asp:TextBox>
                    </div>
                </li>
                <li style="width: 30px;"></li>
                 <li>
                    <div class="ssec-label">
                        职务信息：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Duty" runat="server" CssClass="easyui-validatebox" validType="length[0,100]" invalidMessage="不能超过100个字符！"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("手机") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Hw" runat="server" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符！"></asp:TextBox>
                    </div>
                </li>
                <li style="width: 30px;"></li>
                <li>
                    <div class="ssec-label">
                        <%=Trans("办公电话") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Gn" runat="server" CssClass="easyui-validatebox" validType="length[0,25]" invalidMessage="不能超过25个字符！"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("电子邮箱") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Others" runat="server" Width="200px"></asp:TextBox>
                    </div>
                </li>
                <%-- 
                <li style="width: 30px;"></li>
                <li>
                    <div class="ssec-label">
                        <%=Trans("电子邮箱") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_Sipc" runat="server"></asp:TextBox>
                    </div>
                </li>
                --%>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("IP地址") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_UIP" runat="server" CssClass="easyui-validatebox" validType="ip"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("状态设置") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-text small">
                        <asp:DropDownList ID="ddl_uStatus" runat="server">
                            <asp:ListItem Text="正常登录" Value="0"></asp:ListItem>
                            <asp:ListItem Text="禁止登录" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("性别") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-label small">
                        <asp:DropDownList ID="tb_Sex" runat="server">
                            <asp:ListItem Text="男" Value="男"></asp:ListItem>
                            <asp:ListItem Text="女" Value="女"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("显示序号") %>：
                    </div>
                </li>
                <li>
                    <div class="ssec-label small">
                        <asp:TextBox ID="tb_UORDERBY" runat="server" Style="width: 30px;" CssClass="easyui-numberbox"
                            MaxLength="4"></asp:TextBox>
                    </div>
                </li>
            </ul>
            <%-- 
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("组织机构考核系统") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_USYSTEM1" runat="server" Width="200px"></asp:TextBox>多个账号以","号分隔
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("全员绩效考核系统") %>：</div>
                </li>
                <li>
                    <div>
                        <asp:TextBox ID="tb_USYSTEM2" runat="server" Width="200px"></asp:TextBox>多个账号以","号分隔
                    </div>
                </li>
            </ul>
            --%>
            <ul>
                <li>
                    <div class="ssec-label">
                        <%=Trans("我的签名") %>：
                    </div>
                </li>
                <li>
                    <div>
                        <asp:Image ID="img_Signature" runat="server" AlternateText="未有签名" Height="30px" Width="90px" />
                    </div>
                </li>
                <li style="width: 30px;"></li>
                <li>
                    <div>
                        <input id="file_upload" type="file" name="Filedata" />
                        <asp:HiddenField ID="Hid_Signature" runat="server" />
                    </div>
                </li>
            </ul>
            <ul>
                <li>
                    <div id="upload-queue">
                    </div>
                </li>
                <li></li>
            </ul>
            <ul>
                <li>
                    <div>
                        <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" iconCls="icon-save"
                            OnClick="BtnSave_OnClick" OnClientClick="return ( $('#form1').form('validate'));">保存</asp:LinkButton>
                    </div>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
