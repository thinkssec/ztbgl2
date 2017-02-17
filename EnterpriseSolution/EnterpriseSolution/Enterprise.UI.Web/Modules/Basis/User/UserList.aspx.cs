using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis.Sys;


namespace Enterprise.UI.Web.Manage.User
{
    /// <summary>
    /// 用户列表显示页面
    /// </summary>
    public partial class List :Enterprise.Service.Basis.BasePage
    {
        protected int Id = (int)Utility.sink("Id", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        private SysRoleService roleSrv = new SysRoleService();
        private SysUserRoleService userRoleSrv = new SysUserRoleService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        /// <summary>
        /// 初始化页面数据
        /// </summary>
        private void OnStart()
        {
            CreateBT.AddButton("list.gif", "用户列表", "UserList.aspx", Utility.PopedomType.List, HeadMenu1);
            string url = "UserManage.aspx";
            if (Id != 0)
            {
                url += "?deptId=" + Id;
                CreateBT.AddButton(url, Utility.PopedomType.New, HeadMenu1);
            }          
            
            OnBindDepartMentTree();
            OnBindData();
        }

        #region "绑定用户列表"
        /// <summary>
        /// 绑定用户列表
        /// </summary>
        private void OnBindData()
        {
            SysUserService uSer = new SysUserService();
            var q = uSer.GetList().OrderBy(p => p.UORDERBY).ToList();
            if (Id != 0)
            {
                q = q.Where(p => p.DEPTID == Id).ToList();
            }
            else
            {
                q = q.Where(p => p.DEPTID == 1).ToList();
            }
            GridView1.DataSource = q;
            GridView1.DataBind();
        }

        /// <summary>
        /// 获取人员的所有角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        protected string GetRoles(int userId)
        {
            StringBuilder roles = new StringBuilder();
            //获取指定用户的所有角色信息
            List<SysUserRoleModel> userRoleList = userRoleSrv.GetList().Where(p=>p.USERID == userId).ToList();
            foreach (SysUserRoleModel uRole in userRoleList)
            {
                SysRoleModel roleM = roleSrv.GetList().FirstOrDefault(p => p.RID == uRole.ROLEID);
                if (roleM != null)
                {
                    roles.Append(roleM.RNAME + ",");
                }
            }
            return roles.ToString();
        }

        #endregion

        #region 绑定组织结构树列表

        /// <summary>
        /// 绑定部门列表
        /// </summary>
        private void OnBindDepartMentTree()
        {
            TreeView1.Nodes.Clear();
            SysDepartmentService ser = new SysDepartmentService();
            Bind_Tv(ser.GetList().ToList(), null, 0);
        }       
        
        /// <summary>
        /// 绑定TreeView（利用TreeNode）
        /// </summary>
        /// <param name="dt">部门列表</param>
        /// <param name="pNode">树节点</param>
        /// <param name="pId">上级节点ID</param>
        protected void Bind_Tv(List<SysDepartMentModel> dt, TreeNode pNode, int pId)
        {
            TreeNode tn;//建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中            
            List<SysDepartMentModel> relist = dt.Where(p => p.DPARENTID == pId).OrderBy(p => p.DORDERBY).ToList();//利用DataView将数据进行筛选，选出相同 父id值 的数据
            foreach (SysDepartMentModel row in relist)
            {
                tn = new TreeNode();//建立一个新节点（学名叫：一个实例）
                if (pNode == null)//如果为根节点
                {
                    tn.Value = row.DEPTID.ToString();//节点的Value值，一般为数据库的id值
                    tn.Text = string.Format("<a href=\"UserList.aspx?Id={0}\">{1}</a>", row.DEPTID, row.DNAME);//节点的Text，节点的文本显示
                    TreeView1.Nodes.Add(tn);//将该节点加入到TreeView中
                    Bind_Tv(dt, tn, row.DEPTID);//递归（反复调用这个方法，直到把数据取完为止）
                }
                else//如果不是根节点
                {
                    tn.Value = row.DEPTID.ToString();//节点Value值
                    tn.Text = string.Format("<a href=\"UserList.aspx?Id={0}\">{1}</a>", row.DEPTID, row.DNAME);//节点Text值
                    pNode.ChildNodes.Add(tn);//该节点加入到上级节点中
                    Bind_Tv(dt, tn, row.DEPTID);//递归
                }
            }
        }

        ///// <summary>
        ///// 绑定TreeView（利用TreeNodeCollection）
        ///// </summary>
        ///// <param name="tnc">TreeNodeCollection（TreeView的节点集合）</param>
        ///// <param name="pid_val">父id的值</param>
        ///// <param name="id">数据库 id 字段名</param>
        ///// <param name="pid">数据库 父id 字段名</param>
        ///// <param name="text">数据库 文本 字段值</param>
        //private void Bind_Tv(DataTable dt, TreeNodeCollection tnc, string pid_val, string id, string pid, string text)
        //{
        //    DataView dv = new DataView(dt);//将DataTable存到DataView中，以便于筛选数据
        //    TreeNode tn;//建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中
        //    //以下为三元运算符，如果父id为空，则为构建“父id字段 is null”的查询条件，否则构建“父id字段=父id字段值”的查询条件
        //    string filter = string.IsNullOrEmpty(pid_val) ? pid + " is null" : string.Format(pid + "='{0}'", pid_val);
        //    dv.RowFilter = filter;//利用DataView将数据进行筛选，选出相同 父id值 的数据
        //    foreach (DataRowView drv in dv)
        //    {
        //        tn = new TreeNode();//建立一个新节点（学名叫：一个实例）
        //        tn.Value = drv[id].ToString();//节点的Value值，一般为数据库的id值
        //        tn.Text = drv[text].ToString();//节点的Text，节点的文本显示
        //        tnc.Add(tn);//将该节点加入到TreeNodeCollection（节点集合）中
        //        Bind_Tv(dt, tn.ChildNodes, tn.Value, id, pid, text);//递归（反复调用这个方法，直到把数据取完为止）
        //    }
        //}
        #endregion


    }
}