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
namespace Enterprise.UI.Web.Manage.DepartMent
{
    public partial class Edit : Enterprise.Service.Basis.BasePage
    {

        /// <summary>
        /// 机构ID
        /// </summary>
        int Id = (int)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        private void OnStart()
        {
            OnCommand();
            OnBindUser();
            OnBindDept();
            OnBindData();
        }

        private void OnCommand()
        {
            if (Cmd == "Edit")
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "DepartMentDetail.aspx?Id=" + Id, Utility.PopedomType.List, HeadMenu1);
            }
            else
            {
                CreateBT.AddButton("back.gif", Trans("返回"), "DepartMentList.aspx" + ((Id > 0 && string.IsNullOrEmpty(Cmd)) ? "?Id=" + Id : ""), Utility.PopedomType.List, HeadMenu1);
            }
        }

        private void OnBindUser()
        {
            SysUserService uService = new SysUserService();
            var list = uService.GetList();
            tb_Manager.DataSource = list;
            tb_Manager.DataTextField = "UNAME";
            tb_Manager.DataValueField = "USERID";
            tb_Manager.DataBind();
            tb_Manager.Items.Insert(0, new ListItem("请选择...", "0"));

            tb_HeadManager.DataSource = list;
            tb_HeadManager.DataTextField = "UNAME";
            tb_HeadManager.DataValueField = "USERID";
            tb_HeadManager.DataBind();
            tb_HeadManager.Items.Insert(0, new ListItem("请选择...", "0"));
        }

        #region 绑定组织机构

        private void OnBindDept()
        {
            SysDepartmentService deptSrv = new SysDepartmentService();
            List<SysDepartMentModel> allDeptLst = deptSrv.GetList().OrderBy(p => p.DORDERBY).ToList();
            tb_HeadDepartment.Items.Clear();
            bindDeptByTree(allDeptLst, 0, 0);
            tb_HeadDepartment.Items.Insert(0, new ListItem("海检中心", "0"));
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
                tb_HeadDepartment.Items.Add(item);
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
            SysDepartmentService ser = new SysDepartmentService();
            if (Cmd == "Edit" || Cmd == "Delete")
            {
                var q = ser.GetList().Where(p => p.DEPTID == Id).FirstOrDefault();
                if (q == null) return;
                if (Cmd == "Edit")
                {
                    tb_Name.Text = q.DNAME;
                    txt_Orderby.Text = q.DORDERBY.ToString();
                    ListItem department = tb_HeadDepartment.Items.FindByValue(q.DPARENTID.ToString());
                    if (department != null)
                        department.Selected = true;
                    ListItem limanager = tb_Manager.Items.FindByValue(q.DMANAGER.ToString());
                    if (limanager != null)
                        limanager.Selected = true;
                    ListItem liheadermanager = tb_HeadManager.Items.FindByValue(q.DHEADERMANAGER.ToString());
                    if (liheadermanager != null)
                        liheadermanager.Selected = true;

                }
                else if (Cmd == "Delete")
                {
                    string _note = "操作成功";
                    q.DB_Option_Action = "Delete";
                    try
                    {
                        ser.Execute(q);
                        RtxServiceEntry.RTXDeleteDept(this.Page, q.DNAME);
                        //SysDictionaryService.TranslateTo(q.DNAME, Utility.LanguageType.ru)
                    }
                    catch (Exception ex)
                    {
                        _note = ex.Message;
                    }
                    Utility.ShowMsg(this.Page, "OK", Trans(_note), "DepartMentList.aspx" + ((Id > 0 && string.IsNullOrEmpty(Cmd)) ? "?Id=" + Id : ""));
                }
            }
            else if (Id > 0)
            {
                //顺序号
                txt_Orderby.Text = (ser.GetMaxDepartmentOrderBy(Id) + 1).ToString();
                //上级部门
                ListItem department = tb_HeadDepartment.Items.FindByValue(Id.ToString());
                if (department != null)
                    department.Selected = true;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BtnSave_OnClick(object sender, EventArgs e)
        {
            string _note = "操作成功";
            string oName = "";
            try
            {
                SysDepartmentService ser = new SysDepartmentService();
                SysDepartMentModel entity = new SysDepartMentModel();
                if (string.IsNullOrEmpty(Cmd))
                {
                    entity.DB_Option_Action = "Insert";
                    entity.DORDERBY = (entity.DORDERBY == 0) ? ser.GetMaxDepartmentOrderBy(entity.DPARENTID) + 1 : entity.DORDERBY;
                }
                else if (Cmd == "Edit")
                {
                    entity = ser.GetList().Where(p => p.DEPTID == Id).FirstOrDefault();
                    if (entity.DORDERBY != txt_Orderby.Text.ToInt())
                    {
                        entity.DORDERBY = entity.DORDERBY;
                    }
                    entity.DB_Option_Action = "Update";
                    oName = entity.DNAME;
                }
                entity.DORDERBY = (int)Utility.sink(txt_Orderby.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                entity.DNAME = (string)Utility.sink(tb_Name.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Str);
                entity.DMANAGER = (int)Utility.sink(tb_Manager.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                entity.DHEADERMANAGER = (int)Utility.sink(tb_HeadManager.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                entity.DPARENTID = (int)Utility.sink(tb_HeadDepartment.UniqueID, Utility.MethodType.Post, 0, 0, Utility.DataType.Int);
                if (entity.DPARENTID > 0)
                {
                    entity.DDEPTH = 1;
                }

                ser.Execute(entity);


                #region "通知腾讯通进行用户更改"
                string parentDeptName = "";
                if (entity.DPARENTID > 0)
                {
                    //提取上级部门
                    parentDeptName = SysDepartmentService.GetDepartMentName(entity.DPARENTID);
                    //parentDeptName = parentDeptName + SysDictionaryService.TranslateTo(parentDeptName, Utility.LanguageType.ru);
                }
                if (entity.DB_Option_Action == "Insert")
                {
                    RtxServiceEntry.RTXAddDept(this.Page, entity.DNAME, parentDeptName);
                    //+SysDictionaryService.TranslateTo(entity.DNAME, Utility.LanguageType.ru)
                }
                else if (entity.DB_Option_Action == "Update")
                {
                    string oldDeptName = string.Empty;
                    string newDeptName = string.Empty;
                    if (!string.IsNullOrEmpty(parentDeptName) && entity.DPARENTID > 0)
                    {
                        //有上级单位时
                        //旧名称
                        oldDeptName = oName;//parentDeptName + "\\" + 
                            //+SysDictionaryService.TranslateTo(oName, Utility.LanguageType.ru);
                        //新名称
                        newDeptName = entity.DNAME;//parentDeptName + "\\" +
                            //+SysDictionaryService.TranslateTo(entity.DNAME, Utility.LanguageType.ru);
                    }
                    else
                    {
                        //旧名称
                        oldDeptName = oName;// +SysDictionaryService.TranslateTo(oName, Utility.LanguageType.ru);
                        //新名称
                        newDeptName = entity.DNAME;// +SysDictionaryService.TranslateTo(entity.DNAME, Utility.LanguageType.ru);
                    }
                    //修改
                    RtxServiceEntry.RTXModifyDept(this.Page, oldDeptName, newDeptName);
                }
                #endregion
            }
            catch (Exception ex)
            {
                _note = ex.Message;
            }
            Utility.ShowMsg(this.Page, "OK", Trans(_note), "DepartMentList.aspx" + ((Id > 0 && string.IsNullOrEmpty(Cmd)) ? "?Id=" + Id : ""));
        }

    }
}