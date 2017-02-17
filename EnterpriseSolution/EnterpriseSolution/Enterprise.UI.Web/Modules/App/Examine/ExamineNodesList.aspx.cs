using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Control;
using Enterprise.Model.App.Examine;
using Enterprise.Service.Basis;
using Enterprise.Service.App.Examine;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.App.Examine
{
    /// <summary>
    /// 业务流程节点管理页面
    /// </summary>
    public partial class ExamineNodesList : BasePage
    {
        /// <summary>
        /// 初始化参数
        /// </summary>
        ExamineNodesService nodeSrv = new ExamineNodesService();
        /// <summary>
        /// 业务类型Id
        /// </summary>
        int kindId = (int)Utility.sink("KINDID", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);

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
            if (kindId == 0) kindId = 3;
            //新增，只能由项目负责人操作
            //CreateBT.AddButton("new.gif", "新增", "ExamineNodesList.aspx?Cmd=New&KINDID=" + kindId, Utility.PopedomType.List, HeadMenu1);
        }

        /// <summary>
        /// 绑定数据控件
        /// </summary>
        private void OnBindData()
        {
            TreeView1.Nodes.Clear();
            var list = nodeSrv.GetListByKindId(kindId);
            TreeNode root = new TreeNode();
            root.Text = "业务节点";
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
            //业务类型
            ExamineKindService kindSrv = new ExamineKindService();
            IList<ExamineKindModel> kindLst = kindSrv.GetTreeList();
            Ddl_KINDID.DataSource = kindLst;
            Ddl_KINDID.DataTextField = "KINDNAME";
            Ddl_KINDID.DataValueField = "KINDID";
            Ddl_KINDID.DataBind();
            Ddl_KINDID.SelectedValue = kindId.ToRequestString();
        }

        /// <summary>
        /// 绑定TreeView（利用TreeNode）
        /// </summary>
        /// <param name="nodeLst">节点数据集合</param>
        /// <param name="pNode">当前父节点</param>
        /// <param name="parentNodeBH">父节点编号</param>
        private void Bind_Tv(IList<ExamineNodesModel> nodeLst, TreeNode pNode, string parentNodeBH)
        {
            TreeNode tn;//建立TreeView的节点（TreeNode），以便将取出的数据添加到节点中 
            IList<ExamineNodesModel> subLst;
            if (parentNodeBH == "00")
            {
                //取根节点下的第一级子节点
                subLst = nodeLst.Where(p => p.NODEBH.Length == 2).OrderBy(p => p.NODEBH).ToList();
            }
            else
            {
                //取父节点下的一级子节点
                subLst = nodeLst.Where(p => p.NODEBH.StartsWith(parentNodeBH) && 
                    p.NODEBH.Length == parentNodeBH.Length + 2).OrderBy(p => p.NODEBH).ToList();
            }
            foreach (ExamineNodesModel row in subLst)
            {
                tn = new TreeNode();//建立一个新节点
                tn.Value = row.NODEBH;//节点Value值
                tn.Text = ((row.KEYNODE == 1)?"★":"") + row.NODENAME;//节点Text值
                tn.ToolTip = "NODECODE=" + row.NODECODE + ",NODEBH=" + row.NODEBH;
                switch (row.NODESTATUS)
                {
                    case 0:
                        tn.Text += "(⊙)";
                        break;
                    case 1:
                        tn.Text += "(√)";
                        break;
                    case 2:
                        tn.Text += "(×)";
                        break;
                }
                pNode.ChildNodes.Add(tn);//该节点加入到上级节点中
                Bind_Tv(nodeLst, tn, row.NODEBH);//递归
            }
        }

        /// <summary>
        /// 清空值
        /// </summary>
        private void clearV()
        {
            Hid_NODEBH.Value = "";
            Txt_ADDDATE.Text = "";
            Txt_NODEBH.Text = "";
            Txt_NODECODE.Text = "";
            Txt_NODEICON.Text = "";
            Txt_NODENAME.Text = "";
            Txt_NODEPARAM.Text = "";
            Txt_NODEPATH.Text = "";
            Txt_NODEVALUE.Text = "";
            Txt_WEBURL.Text = "";
            Txt_WEBPARAM.Text = "";
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
            ExamineNodesModel nodeM = (ExamineNodesModel)CommonTool.GetFormDataToModel(typeof(ExamineNodesModel), cont);
            nodeM.DB_Option_Action = WebKeys.InsertAction;
            nodeSrv.Execute(nodeM);
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
            ExamineNodesModel nodeM = (ExamineNodesModel)CommonTool.GetFormDataToModel(typeof(ExamineNodesModel), cont);
            nodeM.DB_Option_Action = WebKeys.UpdateAction;
            nodeSrv.Execute(nodeM);
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
            var q = nodeSrv.GetListByKindId(kindId).FirstOrDefault(p=>p.NODEBH == TreeView1.SelectedValue);
            if (q != null)
            {
                ContentPlaceHolder cont = Page.Controls[0].FindControl("MainPH") as ContentPlaceHolder;
                CommonTool.SetModelDataToForm(q, cont, "Txt_", true);
                CommonTool.SetModelDataToForm(q, cont, "Ddl_", true);
                CommonTool.SetModelDataToForm(q, cont, "Rdl_", true);
                Hid_NODEBH.Value = q.NODEBH;
            }
            else
            {
                Txt_NODECODE.Text = "K" + Ddl_KINDID.SelectedValue + "N";
                Txt_NODEBH.Text = "01";
            }
        }

        /// <summary>
        /// 业务类型选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Ddl_KINDID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("ExamineNodesList.aspx?KINDID=" + Ddl_KINDID.SelectedValue, true);
        }

        /// <summary>
        /// 上升调整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void UpBtn_Click(object sender, EventArgs e)
        {
            //与其上一个节点互换
            var list = nodeSrv.GetListByKindId(kindId);
            //当前节点
            ExamineNodesModel nodeM = list.FirstOrDefault(p=>p.NODEBH == Hid_NODEBH.Value);
            if (nodeM != null)
            {
                int index = list.IndexOf(nodeM);
                if (index > 0 && index < (list.Count - 1))
                {
                    //上一个节点
                    ExamineNodesModel nodeUpModel = list[index - 1];
                    if (nodeUpModel != null)
                    {
                        //互换
                        ExamineNodesModel tempUpM = CommonTool.Clone(nodeUpModel) as ExamineNodesModel;
                        nodeUpModel = CommonTool.Clone(nodeM) as ExamineNodesModel;
                        nodeUpModel.NODECODE = tempUpM.NODECODE;
                        nodeUpModel.NODEBH = tempUpM.NODEBH;
                        nodeUpModel.DB_Option_Action = WebKeys.UpdateAction;
                        nodeSrv.Execute(nodeUpModel);

                        ExamineNodesModel tempM = CommonTool.Clone(nodeM) as ExamineNodesModel;
                        nodeM = CommonTool.Clone(tempUpM) as ExamineNodesModel;
                        nodeM.NODECODE = tempM.NODECODE;
                        nodeM.NODEBH = tempM.NODEBH;
                        nodeM.DB_Option_Action = WebKeys.UpdateAction;
                        nodeSrv.Execute(nodeM);
                    }
                }
            }

            OnBindData();
            clearV();
        }

        /// <summary>
        /// 下降调整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DownBtn_Click(object sender, EventArgs e)
        {
            //与其下一个节点互换
            var list = nodeSrv.GetListByKindId(kindId);
            //当前节点
            ExamineNodesModel nodeM = list.FirstOrDefault(p => p.NODEBH == Hid_NODEBH.Value);
            if (nodeM != null)
            {
                int index = list.IndexOf(nodeM);
                if (index > 0 && index < (list.Count -1))
                {
                    //下一个节点
                    ExamineNodesModel nodeDownModel = list[index + 1];
                    if (nodeDownModel != null)
                    {
                        //互换
                        ExamineNodesModel tempDownM = CommonTool.Clone(nodeDownModel) as ExamineNodesModel;
                        nodeDownModel = CommonTool.Clone(nodeM) as ExamineNodesModel;
                        nodeDownModel.NODECODE = tempDownM.NODECODE;
                        nodeDownModel.NODEBH = tempDownM.NODEBH;
                        nodeDownModel.DB_Option_Action = WebKeys.UpdateAction;
                        nodeSrv.Execute(nodeDownModel);

                        ExamineNodesModel tempM = CommonTool.Clone(nodeM) as ExamineNodesModel;
                        nodeM = CommonTool.Clone(tempDownM) as ExamineNodesModel;
                        nodeM.NODECODE = tempM.NODECODE;
                        nodeM.NODEBH = tempM.NODEBH;
                        nodeM.DB_Option_Action = WebKeys.UpdateAction;
                        nodeSrv.Execute(nodeM);
                    }
                }
            }

            OnBindData();
            clearV();
        }

        #endregion

    }
}