<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="admin-index.aspx.cs" Inherits="Enterprise.UI.Web.Mobile.admin_index" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainPH" runat="server">
    <!-- content start -->
    <div class="admin-content">

        <div class="am-cf am-padding">
            <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">项目概况</strong><%-- / <small><%=project.PROJNAME %></small>--%></div>
            &nbsp;&nbsp;&nbsp;<button type="button" class="am-btn am-btn-warning" onclick="$('#my-modal-loading').modal();document.location='zjdf2.aspx?ProjectId=<%=ProjectId %>'"> 开始评分</button>
        </div>

        <ul class="am-avg-sm-2 am-avg-md-2 am-margin am-padding am-text-center admin-content-list ">
            <%--<li><a href="#" class="am-text-success"><span class="am-icon-btn am-icon-file-text"></span>
                <br />
                评标项目<br />
                2300</a></li>--%>
            <li><a href="#fws" class="am-text-warning"><span class="am-icon-btn am-icon-briefcase"></span>
                <br />
                投标单位<br />
                <%=fwsL.Count %></a></li>

            <li><a href="#pwhcy" class="am-text-secondary"><span class="am-icon-btn am-icon-user-md"></span>
                <br />
                评委会成员<br />
                <%=pszjL.Count %></a></li>
        </ul>

        <div class="am-g">
            <div class="am-u-sm-12">
                <table class="am-table am-table-bd am-table-striped admin-content-table" id="fws">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>投标方</th>
                            <th>唱标顺序</th>
                            <th>得分</th>
                            <th>总分</th>
                            <th>名次</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%
                            int i = 0;
                            foreach (var m in fwsL)
                            {
                                i++;
                            
                        %>
                        <tr>
                            <td><%=i %></td>
                            <td><%=Enterprise.Service.App.Crm.CrmInfoService.GetCrmName(m.CRMINFO) %></td>
                            <td><a href="#"><%=m.PX %></a></td>
                            <td><span class="am-badge am-badge-success"><%=m.KEY4 %></span></td>
                            <td><span class="am-badge am-badge-success"><%=m.KEY3 %></span></td>
                            <td><span class="am-badge am-badge-success"><%=m.KEY2 %></span></td>
                            <td>
                                <div class="am-dropdown" data-am-dropdown>
                                    <button class="am-btn am-btn-default am-btn-xs am-dropdown-toggle" data-am-dropdown-toggle><span class="am-icon-cog"></span><span class="am-icon-caret-down"></span></button>
                                
                                    <ul class="am-dropdown-content">
                                        <li><a href="zjdf.aspx?ProjectId=<%=ProjectId %>&CrmInfo=<%=m.CRMINFO %>">打分</a></li>
                                        <%--<li><a href="#">2. 查看</a></li>--%>
                                        <%--
                                        <li><a href="#">3. 删除</a></li>--%>
                                    </ul>
                                </div>
                            </td>
                        </tr>
                        <%
                            }
                        %>
                    </tbody>
                </table>
            </div>
        </div>

        <div class="am-g">
            <div class="am-u-md-6">
                <div class="am-panel am-panel-default">
                    <div class="am-panel-hd am-cf" data-am-collapse="{target: '#collapse-panel-1'}">项目简介<span class="am-icon-chevron-down am-fr"></span></div>
                    <div id="collapse-panel-1" class="am-panel-bd am-collapse am-in">
                        <ul class="am-list admin-content-task">

                            <li>
                                <div class="admin-task-meta">招标文件编号</div>
                                <div class="admin-task-bd">
                                    <%=project.PROJNUMBER %>
                                </div>

                            </li>
                            <li>
                                <div class="admin-task-meta">资金来源</div>
                                <div class="admin-task-bd">
                                    <%=project.ZJLY %>
                                </div>

                            </li>
                            <li>
                                <div class="admin-task-meta">计划金额</div>
                                <div class="admin-task-bd">
                                    <%=project.PROJINCOME %>
                                </div>

                            </li>
                            <li>
                                <div class="admin-task-meta">经办人</div>
                                <div class="admin-task-bd">
                                    <%=Enterprise.Service.Basis.Sys.SysUserService.GetUserName(project.SUBMITTER.Value) %>
                                </div>

                            </li>
                            <li>
                                <div class="admin-task-meta">项目内容</div>
                                <div class="admin-task-bd">
                                    <%=project.PROJCONTENT %>
                                </div>

                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="am-u-md-6">
                <div class="am-panel am-panel-default" id="pwhcy">
                    <div class="am-panel-hd am-cf" data-am-collapse="{target: '#collapse-panel-4'}">评委会成员<span class="am-icon-chevron-down am-fr"></span></div>
                    <div id="collapse-panel-4" class="am-panel-bd am-collapse am-in">
                        <ul class="am-list admin-content-task">
                            <%
                                foreach (var m in pszjL)
                                { 
                            
                            %>
                            <li>
                                <div class="admin-task-bd">
                                    <%=Enterprise.Service.Basis.Sys.SysUserService.GetUserName(Int32.Parse( m.PERSONID)) %>
                                    <%
                                    if (m.STATUS == 0) { 
                                        %>
                                    <%--<span class="am-badge am-badge-success">完成打分</span>--%>
                                    <%
                                    }
                                    else { 
                                    %>
                                    <%--<span class="am-badge am-badge-danger">正在打分</span>--%>
                                    <%
                                    }    
                                    if (m.ROLE == "1")
                                    { 
                                    %>
                                    <span class="am-badge am-badge-secondary">组长</span>
                                    <%
                                    }
                                    %>
                                </div>
                            </li>
                            <%
                                }
                            %>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- content end -->
</asp:Content>
