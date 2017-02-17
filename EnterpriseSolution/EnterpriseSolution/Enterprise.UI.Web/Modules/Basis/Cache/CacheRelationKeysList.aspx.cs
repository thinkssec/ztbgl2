using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.Basis.Sys;
using Enterprise.Service.Basis;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.Basis.Cache
{
    /// <summary>
    /// 缓存关联项维护页面
    /// </summary>
    public partial class CacheRelationKeysList : BasePage
    {
        
        SysCacheService cacheSrv = new SysCacheService();//缓存管理服务类
        SysCacherelationService cRelationSrv = new SysCacherelationService();//缓存关联项管理服务类
        string cacheName = (string)Utility.sink("CacheName", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);//参数

        /// <summary>
        /// 页面加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            OnCommand();
            if (!IsPostBack)
            {
                OnConditon();
                OnBindData();
            }
        }

        /// <summary>
        /// 绑定权限
        /// </summary>
        private void OnCommand()
        {
            //新增，只能由项目负责人操作
            //CreateBT.AddButton("new.gif", "新增", "ExamineNodesList.aspx?Cmd=New&KINDID=" + kindId, Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 绑定数据控件
        /// </summary>
        private void OnBindData()
        {
            TreeView1.Nodes.Clear();
            var list = cRelationSrv.GetList();
            TreeNode root = new TreeNode();
            root.Text = "缓存项";
            root.Value = "00";
            TreeView1.Nodes.Add(root);
            Bind_Tv(list, root, "00");
            TreeView1.ExpandAll();
        }

        /// <summary>
        /// 绑定条件
        /// </summary>
        private void OnConditon()
        {

        }

        /// <summary>
        /// 绑定TreeView（利用TreeNode）
        /// </summary>
        /// <param name="nodeLst">节点数据集合</param>
        /// <param name="pNode">当前父节点</param>
        /// <param name="parentNodeBH">父节点编号</param>
        private void Bind_Tv(IList<SysCacherelationModel> nodeLst, TreeNode pNode, string parentNodeBH)
        {
            IList<SysCacheModel> oneGradeNodeLst = cacheSrv.GetList();
            IList<SysCacherelationModel> secondGradeNodeLst;
            foreach(var parentNode in oneGradeNodeLst) {
                TreeNode oneTreeNode = new TreeNode();//一级节点
                oneTreeNode.Value = parentNode.CACHENAME;
                oneTreeNode.Text = parentNode.CACHENAME;
                oneTreeNode.ToolTip = string.Format("{0},{1},{2}", parentNode.CACHEDESCRIBE, 
                    parentNode.USERNAME, parentNode.TABLENAME);
                pNode.ChildNodes.Add(oneTreeNode);
                //提取二级节点
                secondGradeNodeLst = nodeLst.Where(p=>p.CACHENAME == parentNode.CACHENAME).ToList();
                foreach (SysCacherelationModel row in secondGradeNodeLst)
                {
                    TreeNode tn = new TreeNode();//建立一个新节点
                    tn.Value = row.CACHEID;//节点Value值
                    tn.Text = row.INFLCACHENAME;
                    switch (row.ISVALID)
                    {
                        case "0"://无效标志
                            tn.Text += "(×)";
                            break;
                    }
                    oneTreeNode.ChildNodes.Add(tn);//该节点加入到上级节点中
                }
            }
        }

        /// <summary>
        /// 清空值
        /// </summary>
        private void clearV()
        {
            Hid_CACHEID.Value = "";
            Txt_CACHENAME.Text = Txt_INFLCACHENAME.Text = "";
        }

        #region 事件处理区

        /// <summary>
        /// 添加按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
            //装配MODEL
            SysCacherelationModel nodeM = (SysCacherelationModel)CommonTool.GetFormDataToModel(typeof(SysCacherelationModel), cont);
            nodeM.DB_Option_Action = WebKeys.InsertAction;
            nodeM.CACHEID = CommonTool.GetGuidKey();
            cRelationSrv.Execute(nodeM);
            OnBindData();
            clearV();
        }

        /// <summary>
        /// 更新按钮事件
        /// </summary>
        /// <returns></returns>
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
            //装配MODEL
            SysCacherelationModel nodeM = (SysCacherelationModel)CommonTool.GetFormDataToModel(typeof(SysCacherelationModel), cont);
            nodeM.DB_Option_Action = WebKeys.UpdateAction;
            cRelationSrv.Execute(nodeM);
            OnBindData();
            clearV();
        }

        /// <summary>
        /// 选择节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            var q = cRelationSrv.GetList().FirstOrDefault(p => p.CACHEID == TreeView1.SelectedValue);
            if (q != null)
            {
                ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
                CommonTool.SetModelDataToForm(q, cont, "Txt_", true);
                CommonTool.SetModelDataToForm(q, cont, "Rdl_", true);
                Hid_CACHEID.Value = q.CACHEID;
                AddBtn.Visible = false;
                BtnSave.Visible = true;
            }
            else
            {
                Hid_CACHEID.Value = TreeView1.SelectedValue;
                Txt_CACHENAME.Text = TreeView1.SelectedValue;
                AddBtn.Visible = true;
                BtnSave.Visible = false;
            }
        }

        /// <summary>
        /// 删除节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DelBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Hid_CACHEID.Value))
            {
                SysCacherelationModel delM = new SysCacherelationModel();
                delM.CACHEID = Hid_CACHEID.Value;
                delM.DB_Option_Action = WebKeys.DeleteAction;
                cRelationSrv.Execute(delM);
            }
            OnBindData();
            clearV();
        }

        /// <summary>
        /// 同步操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ReloadBtn_Click(object sender, EventArgs e)
        {
            MyCacheManager.LoadCacheRelationshipKeys();
            OnBindData();
            clearV();
        }

        #endregion

    }
}