<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DemoForm.aspx.cs" Inherits="Enterprise.UI.Web.Modules.Demo.DemoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
 <div data-options="region:'north',split:false,border:false"  style="padding:0px; overflow:hidden;" >
    <%--导航条开始--%>
            <div class="vDaohangtiaoHolder module">
                <div class="vDaohangtiao">
                    <ul>
                        <li class="first">
                            <a href="/"><%=Trans("首页") %></a>
                        </li>
                        <li><%=Trans("办公事务") %></li>
                        <li class="last"><%=Trans("客户管理") %>
                        </li>
                    </ul>
                </div>
            </div>
    <%--end--%>
    <%--权限按钮开始--%>
           <div id="main-tool">
               <%--自定义按钮--%>
               <%--<a href="#" class="easyui-linkbutton" iconCls="icon-add">发布</a>--%>
               <%--end--%>
               <Ent:HeadMenuWeb ID="HeadMenu1" runat="server">
               </Ent:HeadMenuWeb>
            </div>
    <%--end--%>    
    </div>
    <div data-options="region:'center'">
         <div id="contents" class="ssec-form">
        <div class="ssec-group ssec-group-hasicon">
            <div class="icon-form"></div>
            <span><%=Trans("用户信息") %></span>
        </div>
        <%--表单构建开始--%>   
        <%--两列排列方式--%>    
        <ul>
            <li class="ssec-label">标签Label:</li>
            <li>
                <div>
                <asp:TextBox ID="t_Id" runat="server"></asp:TextBox>
                </div>
            </li>
            <%--隔开--%>
            <li style="width:30px"></li>
            <li class="ssec-label">标签Label:</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </div>
            </li>
        </ul>
        <%--1列排列方式--%>    
        <ul>
            <li class="ssec-label">1列排列第一列:</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
            </li>           
        </ul>
        <%--必填项验证--%>    
        <ul>
            <li class="ssec-label">必填项(*):</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="easyui-validatebox" required="true" missingMessage="必填项" ></asp:TextBox>
                </div>
            </li>           
        </ul>
        <%--数字验证--%>    
        <ul>
            <li class="ssec-label">数字验证(*):</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox4" runat="server" CssClass="easyui-numberbox"></asp:TextBox>
                </div>
            </li>           
        </ul>
         <%--数字长度验证--%>    
        <ul>
            <li class="ssec-label">数字长度验证(*):</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox5" runat="server" CssClass="easyui-numberbox"  validType="length[0,2]" invalidMessage="不能超过2个字符！"></asp:TextBox>
                </div>
            </li>           
        </ul>
        <%--字符长度验证--%>    
        <ul>
            <li class="ssec-label">字符长度验证(*):</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox8" runat="server" CssClass="easyui-validatebox"  validType="length[0,2]" invalidMessage="不能超过2个字符！"></asp:TextBox>
                </div>
            </li>           
        </ul>
        <%--字符长度验证--%>    
        <ul>
            <li class="ssec-label">小数最大值、最小值、位数验证(*):</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox9" runat="server" CssClass="easyui-numberbox"  min="5.5" max="20" precision="2" invalidMessage="2！"></asp:TextBox> 最大值20 最小值5.5 小数位数2位
                </div>
            </li>           
        </ul>
        <%--邮箱验证--%>    
        <ul>
            <li class="ssec-label">邮箱验证(*):</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox6" runat="server" CssClass="easyui-numberbox"  validType="email"  invalidMessage="必须是邮箱！"></asp:TextBox>
                </div>
            </li>           
        </ul>
        <%--日期验证--%>    
        <ul>
            <li class="ssec-label">日期验证(*):</li>
            <li>
                <div>
                <asp:TextBox ID="TextBox7" runat="server" CssClass="easyui-datebox" editable="false"></asp:TextBox>
                </div>
            </li>           
        </ul>
        <%--表单构建end--%>       
        <ul>           
            <li><div>
                <asp:LinkButton ID="BtnSave" runat="server" CssClass="easyui-linkbutton" iconCls="icon-save" OnClientClick="return $('#form1').form('validate');" OnClick="BtnSave_Click1">保存</asp:LinkButton></div>
            </li>
        </ul>
        </div>
            
    </div>    
</asp:Content>
