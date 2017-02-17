using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;
using Enterprise.Component.Message;
namespace Enterprise.UI.Web.Manage.User
{
    public partial class Manage : Enterprise.Service.Basis.BasePage
    {
        int Id = (int)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        int DeptId = (int)Utility.sink("deptId", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            CreateBT.AddButton("back.gif", Trans("返回"), "UserList.aspx?Id=" + DeptId, Utility.PopedomType.List, Utility.UrlType.Href, HeadMenu1);
            ////绑定部门下拉列表
            //SysDepartmentService.BindDepartMentDropDownList(tb_Dept);
            OnBindDept();
            OnBindAffDept();
            OnBindData();
        }


        #region 绑定组织机构

        /// <summary>
        /// 绑定隶属关系的组织机构
        /// </summary>
        private void OnBindAffDept()
        {
            SysDepartmentService deptSrv = new SysDepartmentService();
            List<SysDepartMentModel> allDeptLst = deptSrv.GetList().OrderBy(p => p.DORDERBY).ToList();
            //tb_Dept.Items.Clear();
            tb_Affiliation.Items.Clear();
            bindAffDeptByTree(allDeptLst, 0, 0);
            //tb_Dept.Items.Insert(0, new ListItem("FIOC", "0"));
            //tb_Affiliation.Items.Insert(0, new ListItem("海检中心", "0"));
        }

        /// <summary>
        /// 提取指定部门下的所有子部门（递归）
        /// </summary>
        /// <param name="deptLst">所有部门集合</param>
        /// <param name="parentId">上级部门ID</param>
        /// <param name="tierCount">当前层级</param>
        private void bindAffDeptByTree(List<SysDepartMentModel> deptLst, int parentId, int tierCount)
        {
            List<SysDepartMentModel> subDeptLst = deptLst.Where(p => p.DPARENTID == parentId).OrderBy(p => p.DORDERBY).ToList();
            foreach (SysDepartMentModel model in subDeptLst)
            {
                ListItem item = new ListItem((getBlankSpace(tierCount) + model.DNAME), model.DEPTID.ToString());
                //tb_Dept.Items.Add(item);
                tb_Affiliation.Items.Add(item);
                bindAffDeptByTree(deptLst, model.DEPTID, tierCount + 1);
            }
        }

        /// <summary>
        /// 绑定组织机构
        /// </summary>
        private void OnBindDept()
        {
            SysDepartmentService deptSrv = new SysDepartmentService();
            List<SysDepartMentModel> allDeptLst = deptSrv.GetList().OrderBy(p => p.DORDERBY).ToList();
            tb_Dept.Items.Clear();
            //tb_Affiliation.Items.Clear();
            bindDeptByTree(allDeptLst, 0, 0);
            //tb_Dept.Items.Insert(0, new ListItem("海检中心", "0"));
            //tb_Affiliation.Items.Insert(0, new ListItem("FIOC", "0"));
        }

        /// <summary>
        /// 提取指定部门下的所有子部门（递归）
        /// </summary>
        /// <param name="deptLst">所有部门集合</param>
        /// <param name="parentId">上级部门ID</param>
        /// <param name="tierCount">当前层级</param>
        private void bindDeptByTree(List<SysDepartMentModel> deptLst, int parentId, int tierCount)
        {
            List<SysDepartMentModel> subDeptLst = deptLst.Where(p => p.DPARENTID == parentId).OrderBy(p => p.DORDERBY).ToList();
            foreach (SysDepartMentModel model in subDeptLst)
            {
                ListItem item = new ListItem((getBlankSpace(tierCount) + model.DNAME), model.DEPTID.ToString());
                tb_Dept.Items.Add(item);
                //tb_Affiliation.Items.Add(item);
                bindDeptByTree(deptLst, model.DEPTID, tierCount + 1);
            }
        }

        /// <summary>
        /// 产生空格
        /// </summary>
        /// <param name="cou"></param>
        /// <returns></returns>
        private string getBlankSpace(int cou)
        {
            string s = "├";
            for (int i = 0; i < cou; i++)
            {
                s += "─";
            }
            return s;
        }

        #endregion

        private void OnBindData()
        {
            if (Id != 0)
            {
                SysUserService uService = new SysUserService();
                var q = uService.GetList().Where(p => p.USERID == Id).FirstOrDefault();
                if (q != null)
                {
                    if (Cmd == "Edit")
                    {
                        ////add by qw 2013.4.15 用户可以修改自己的信息 2013.6.26 放弃
                        //if (q.USERID == userModel.USERID || userModel.ULOGINNAME == "admin")
                        //{                            
                        //}
                        ////end
                        tb_Name.Text = q.UNAME;
                        tb_LoginName.Text = lb_LoginName.Text = q.ULOGINNAME;
                        tb_LoginName.Visible = false;
                        lb_LoginName.Visible = true;
                        //所在部门
                        ListItem lidept = tb_Dept.Items.FindByValue(q.DEPTID.ToString());
                        if (lidept != null)
                        {
                            lidept.Selected = true;
                        }
                        //关系隶属部门
                        ListItem affdept = tb_Affiliation.Items.FindByValue(q.UAFFILIATION.ToString());
                        if (affdept != null)
                        {
                            affdept.Selected = true;
                        }
                        ListItem li = tb_Sex.Items.FindByValue(q.USEX);
                        if (li != null)
                        {
                            li.Selected = true;
                        }
                        ///员工职务信息实际存储在数据库里对应的是登陆密码这个字段
                        tb_Duty.Text = q.ULOGINPASS.ToRequestString();
                        tb_Birthday.Text = q.UBIRTHDAY.ToShortDateString();
                        tb_Hw.Text = q.UHWPHONE;
                        tb_Gn.Text = q.UGNPHONE;
                        tb_UIP.Text = q.UIP;
                        //tb_Sipc.Text = q.SIPCEMAIL;
                        tb_Others.Text = q.OTHEREMAIL;
                        //ListItem lilang = this.tb_DefaultLanguage.Items.FindByValue(q.UDEFAULTLANGUAGE);
                        //if (lilang != null)
                        //    lilang.Selected = true;
                        ddl_uStatus.SelectedValue = q.USTATUS.ToString();
                        tb_UORDERBY.Text = q.UORDERBY.ToString();
                        //提取签名信息
                        SysUserindividService individSrv = new SysUserindividService();
                        SysUserindividModel userIndivid = individSrv.GetModelById(q.USERID);
                        if (userIndivid != null && !string.IsNullOrEmpty(userIndivid.SIGNPIC))
                        {
                            img_Signature.ImageUrl = userIndivid.SIGNPIC;
                            img_Signature.Visible = true;
                        }
                        //add by qw 2013.9.9 start
                        //tb_USYSTEM1.Text = q.USYSTEM1;
                        //tb_USYSTEM2.Text = q.USYSTEM2;
                        //end
                    }
                    //else if (Cmd == "Restore")
                    //{
                    //    string _note = "密码重置成功，重置后密码与帐户一致，请登录后进行修改！";
                    //    try
                    //    {
                    //        RtxServiceEntry.RTXModifyUser(this.Page, q.ULOGINNAME);
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        _note = ex.Message;
                    //    }
                    //    Utility.ShowMsg(this.Page, "OK", Trans(_note), "UserList.aspx?Id=" + q.DEPTID);
                    //}
                    else if (Cmd == "Delete")
                    {
                        string _note = "操作成功";
                        q.DB_Option_Action = WebKeys.DeleteAction;
                        try
                        {
                            uService.Execute(q);
                            //RtxServiceEntry.RTXDeleteUser(this.Page, q.ULOGINNAME);
                        }
                        catch (Exception ex)
                        {
                            _note = ex.Message;
                        }
                        Utility.ShowMsg(this.Page, "OK", Trans(_note), "UserList.aspx?Id=" + q.DEPTID);
                    }
                }
            }
            else
            {
                //所在部门
                ListItem lidept = tb_Dept.Items.FindByValue(DeptId.ToString());
                if (lidept != null)
                {
                    lidept.Selected = true;
                }
                //关系隶属部门
                ListItem affdept = tb_Affiliation.Items.FindByValue(DeptId.ToString());
                if (affdept != null)
                {
                    affdept.Selected = true;
                }
            }
        }

        protected void BtnSave_OnClick(object sender, EventArgs e)
        {

            string _note = "操作成功";
            //int deptId = 0;
            try
            {
                SysUserService uService = new SysUserService();
                SysUserModel entity = new SysUserModel();
                int odeptId = 0;
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = "Insert";
                    entity.UORDERBY = 0;// uService.GetMaxUserOrderBy(Id) + 1;
                    entity.ULOGINNAME = (string)Utility.sink(tb_LoginName.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                }
                else if (Cmd == "Edit")
                {
                    entity = uService.GetList().Where(p => p.USERID == Id).FirstOrDefault();
                    entity.DB_Option_Action = "Update";
                    odeptId = entity.DEPTID;
                }
                entity.UNAME = (string)Utility.sink(tb_Name.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.DEPTID = (int)Utility.sink(tb_Dept.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                entity.UAFFILIATION = (int)Utility.sink(tb_Affiliation.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                entity.USEX = (string)Utility.sink(tb_Sex.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.UBIRTHDAY = (DateTime)Utility.sink(tb_Birthday.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Date);
                entity.UHWPHONE = (string)Utility.sink(tb_Hw.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.UGNPHONE = (string)Utility.sink(tb_Gn.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                //entity.SIPCEMAIL = (string)Utility.sink(tb_Sipc.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.OTHEREMAIL = (string)Utility.sink(tb_Others.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.UADMIN = 0;
                entity.UIP = tb_UIP.Text;
                //entity.USYSTEM1 = (string)Utility.sink(tb_USYSTEM1.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                //entity.USYSTEM2 = (string)Utility.sink(tb_USYSTEM2.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.USTATUS = int.Parse(ddl_uStatus.SelectedValue);
                //entity.UDEFAULTLANGUAGE = (string)Utility.sink(tb_DefaultLanguage.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.UDEFAULTLANGUAGE = Utility.LanguageType.zhcn.ToString();//缺省为中文
                entity.UORDERBY = (int)Utility.sink(tb_UORDERBY.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                entity.ULOGINPASS = (string)Utility.sink(tb_Duty.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                uService.Execute(entity);

                //add by qw 2013.7.4 start 保存签名信息
                SysUserindividService individSrv = new SysUserindividService();
                SysUserindividModel userIndivid = new SysUserindividModel();
                userIndivid.USERID = SysUserService.GetUserId(entity.ULOGINNAME);
                userIndivid.SIGNPIC = Hid_Signature.Value;
                userIndivid.DB_Option_Action = WebKeys.InsertOrUpdateAction;
                individSrv.Execute(userIndivid);
                //end

                ////mod by qw 2013.7.30 start
                ////将部门转为汉字+俄文的形式，如："SPC子公司ТОО "СПК"->地面建设部Отдел обустройства"
                //string newDeptName = SysDepartmentService.GetDepartMentName(entity.DEPTID);
                //string[] newDepts = newDeptName.Split("->".ToCharArray());
                //if (newDepts != null)
                //{
                //    newDeptName = string.Empty;
                //    foreach (string s in newDepts)
                //    {
                //        if (string.IsNullOrEmpty(s))
                //            continue;
                //        newDeptName += s + "\\";//SysDictionaryService.TranslateTo(s, Utility.LanguageType.ru)
                //    }
                //}
                //newDeptName = newDeptName.TrimEnd("\\".ToCharArray());
                ////newDeptName = newDeptName + SysDictionaryService.TranslateTo(newDeptName, Utility.LanguageType.ru);
                //if (entity.DB_Option_Action == "Insert")
                //{
                //    RtxServiceEntry.RTXAddUser(this.Page, entity.ULOGINNAME, entity.UNAME, entity.USEX, entity.UHWPHONE, entity.OTHEREMAIL, entity.UGNPHONE, newDeptName);
                //}
                //else if (entity.DB_Option_Action == "Update")
                //{
                //    if (odeptId != entity.DEPTID)
                //    {
                //        string oldDeptName = SysDepartmentService.GetDepartMentName(odeptId);
                //        string[] oldDepts = oldDeptName.Split("->".ToCharArray());
                //        if (oldDepts != null)
                //        {
                //            oldDeptName = string.Empty;
                //            foreach (string s in oldDepts)
                //            {
                //                if (string.IsNullOrEmpty(s))
                //                    continue;
                //                oldDeptName += s + "\\";//SysDictionaryService.TranslateTo(s, Utility.LanguageType.ru) +
                //            }
                //        }
                //        oldDeptName = oldDeptName.TrimEnd("\\".ToCharArray());
                //        //oldDeptName = oldDeptName + SysDictionaryService.TranslateTo(oldDeptName, Utility.LanguageType.ru);
                //        RtxServiceEntry.RTXModifyUserDept(this.Page, entity.ULOGINNAME, oldDeptName, newDeptName);
                //    }
                //    RtxServiceEntry.RTXModifyUserInfo(this.Page, entity.ULOGINNAME, entity.UNAME, entity.USEX, entity.UHWPHONE, entity.OTHEREMAIL, entity.UGNPHONE);
                //}
                ////end
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", Trans(_note), "UserList.aspx?Id=" + DeptId);
        }
    }
}