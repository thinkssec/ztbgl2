using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;
using Enterprise.Component.Cache;
namespace Enterprise.Service.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysDepartmentService.cs
    /// 功能描述: 业务逻辑层-部门数据处理
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysDepartmentService
    {
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISysDepartMentData dal = new SysDepartMentData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysDepartMentModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 返回数据集合
        /// 按顺序号排序，并根据单位层级显示单位名称
        /// </summary>
        /// <returns></returns>
        public IList<SysDepartMentModel> GetTreeList()
        {
            return dal.GetTreeList();
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysDepartMentModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 根据ID获取部门信息MODEL
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public SysDepartMentModel DepartmentDisp(int deptId)
        {
            return dal.GetModelById(deptId);
        }

        /// <summary>
        /// 获取目录下最大排序号
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public int GetMaxDepartmentOrderBy(int parentId)
        {
            var q = GetList().Where(p => p.DEPTID == parentId).FirstOrDefault();
            if (q != null)
            {
                return q.DORDERBY.ToInt();
            }
            return 0;
        }

        /// <summary>
        /// 获取一个部门的所有子部门列表
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public List<SysDepartMentModel> GetChildList(int deptId)
        {
            List<SysDepartMentModel> list = new List<SysDepartMentModel>();
            var q = GetList().Where(p => p.DPARENTID == deptId);
            if (q.Count()>0)
            {
                foreach (var t in q)
                {
                    list.Add(t);
                    list.AddRange(GetChildList(t.DEPTID));
                }
            }
            return list;            
        }


        //new by zy 2014.5.29
        /// <summary>
        /// 获取列表中可统计的单位及其子部门， 并绑定下拉菜单
        /// </summary>
        public List<ListItem> GetZhiDingDep(int[] tjDept)
        {
            List<ListItem> list = new List<ListItem>();
            list.Clear();
            foreach (var item in tjDept)
            {
                ListItem li = new ListItem();
                //SysDepartMentModel model = new SysDepartMentModel();
                SysDepartMentModel q = GetList().Where(p => p.DEPTID == item).FirstOrDefault();
                    //q.DNAME="|-"+q.DNAME;
                //model.DNAME = "|-" + q.DNAME;
                //model.DEPTID = q.DEPTID;
                //model.DPARENTID = q.DPARENTID;
                li.Text = "|-" + q.DNAME;
                li.Value = q.DEPTID.ToRequestString();
                list.Add(li);
               
                GetChildList(item, list);
            }


            return list;
        }


        /// <summary>
        /// 获取一个部门的所有子部门列表,并将其添加到指定的list中
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public List<ListItem> GetChildList(int deptId, List<ListItem> list)
        {
            var q = GetList().Where(p => p.DPARENTID == deptId);
            if (q.Count() > 0)
            {
                foreach (var t in q)
                {
                    ListItem li = new ListItem();
                    li.Value = t.DEPTID.ToRequestString();
                    li.Text = "|---" + t.DNAME;
                    //t.DNAME="|--"+t.DNAME;
                    list.Add(li);
                    //list.AddRange(GetChildList(t.DEPTID));
                }
            }
            return list;
        }


        public string GetZhiDingDeptFromCache_Key = "Enterprise.Service.Basis.Sys.SysDepartmentService.GetZhiDingDeptFromCache";
        
        //将指定部门及其下属部门的数据写入缓存
        public List<ListItem> GetZhiDingDeptFromCache(int[] deptId)
        {
            //Enterprise.Service.Basis.Sys.SysDepartmentService.GetZhiDingDeptFromCache114_115_116
            List<ListItem> list = (List<ListItem>)CacheHelper.GetCache(GetZhiDingDeptFromCache_Key+deptId.ToJoin('_'));
            if (list == null)
            {
                list = GetZhiDingDep(deptId);
                CacheHelper.Add(GetZhiDingDeptFromCache_Key, list);
            }
            return list;
        }

        ///end

        #region 静态方法区

        /// <summary>
        /// 是否为部门或子公司管理者
        /// (部门经理或子公司总经理)
        /// </summary>
        /// <param name="deptId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool IsManager(int deptId, int userId)
        {
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.GetList().Where(p => p.DEPTID == deptId).FirstOrDefault();
            if (q != null)
            {
                return (q.DMANAGER == userId || q.DHEADERMANAGER == userId);
            }
            return false;
        }

        /// <summary>
        /// 返回部门名称
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public static string GetDepartMentName(int deptId)
        {
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.GetList().Where(p => p.DEPTID == deptId).FirstOrDefault();
            if (q != null)
            {
                //if (q.DPARENTID > 0)
                //{
                //    return GetDepartMentName(q.DPARENTID) + "->" + q.DNAME;
                //}
                //else
                //{
                //    return q.DNAME;
                //}
                return q.DNAME;
            }
            return "";
        }


        /// <summary>
        /// 根据ID获取部门信息MODEL
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public static int GetDeptManagerUserId(int deptId)
        {
            SysDepartmentService dService = new SysDepartmentService();
            SysDepartMentModel deptModel = dService.DepartmentDisp(deptId);
            return ((deptModel != null) ? deptModel.DMANAGER.ToInt() : 0);
        }

        /// <summary>
        /// 获取指定部门(子公司)的经理(总经理)
        /// </summary>
        /// <param name="deptId">部门名称</param>
        /// <returns></returns>
        public static int GetDepartmentManager(string deptName)
        {
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.GetList().Where(p => p.DNAME == deptName).FirstOrDefault();
            if (q != null)
            {
                return q.DMANAGER.ToInt();
            }
            return 0;
        }


        /// <summary>
        /// 检测子公司是否存在子部门的情况
        /// </summary>
        /// <returns></returns>
        public static bool CheckSubCompanyHasDepts(string deptName)
        {
            bool isHas = false;

            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.GetList().Where(p => p.DNAME == deptName).FirstOrDefault();
            if (q != null)
            {
                isHas = (dService.GetList().Where(p => p.DPARENTID == q.DEPTID).Count() > 0) ? true : false;
            }

            return isHas;
        }


        /// <summary>
        /// 返回最顶级部门名称
        /// </summary>
        /// <param name="deptId">部门编号</param>
        /// <returns></returns>
        public static string GetParentDepartMentName(int deptId)
        {
            SysDepartmentService dService = new SysDepartmentService();
            var q = dService.GetList().Where(p => p.DEPTID == deptId).FirstOrDefault();
            if (q != null)
            {
                if (q.DPARENTID > 0)
                {
                    var parent = dService.GetList().Where(p => p.DEPTID == q.DPARENTID).FirstOrDefault();
                    if (parent != null)
                    {
                        return parent.DNAME;
                    }
                }
                return q.DNAME;
            }
            return "";
        }


        /// <summary>
        /// 绑定部门下拉菜单
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindDepartMentDropDownList(DropDownList ddl)
        {
            SysDepartmentService dService = new SysDepartmentService();
            IList<SysDepartMentModel> list = dService.GetTreeList();
            ddl.DataSource = list;
            ddl.DataTextField = "DNAME";
            ddl.DataValueField = "DEPTID";
            ddl.DataBind();
            //ddl.Items.Insert(0, new ListItem("海检中心", "0"));
        }

        /// <summary>
        /// 绑定业务部门
        /// </summary>
        /// <param name="ddl"></param>
        public static void BindDepartMentDropDownListOnlyBussiness(DropDownList ddl)
        {
            ddl.Items.Insert(0, new ListItem("海检中心", "0"));
            ddl.Items.Add(new ListItem("发证检验部", "144"));            
            ddl.Items.Add(new ListItem("产品认可部", "145"));
            ddl.Items.Add(new ListItem("无损检测部", "146"));
            ddl.Items.Add(new ListItem("西北工程处", "152")); 
        }
       

        #endregion

    }
}
