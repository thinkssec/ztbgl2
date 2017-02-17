using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using Enterprise.Service.Basis.Bf;
using Enterprise.Model.Basis.Bf;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Component.BF
{
    public partial class BFDesigner : System.Web.UI.Page
    {

        /// <summary>
        /// 业务流发布管理--服务类
        /// </summary>
        private BfPublishService publishSrv = new BfPublishService();
        /// <summary>
        /// 业务流发布MODEL
        /// </summary>
        protected BfPublishModel PublishModel;
        private string bfId;
        private string bfVersion;

        protected void Page_Load(object sender, EventArgs e)
        {

            //接收参数
            bfId = Request["CUR_BFID"];
            bfVersion = Request["CUR_BFVER"];
            string ddlVersion = Request["Ddl_Version"];
            if (!string.IsNullOrEmpty(ddlVersion)) bfVersion = ddlVersion;

            if (string.IsNullOrEmpty(bfId) || string.IsNullOrEmpty(bfVersion))
            {
                Response.Write("参数不全");
                Response.End();
            }

            //必须提供业务流ID和版本参数
            List<BfPublishModel> publishList = publishSrv.GetList().Where(p => p.BF_ID == bfId).ToList();
            PublishModel = publishList.Find(p => p.BF_ID == bfId && p.BF_VERSION == int.Parse(bfVersion));
            if (PublishModel == null)
            {
                Response.Write("查询数据不正确");
                Response.End();
            }

            //绑定版本下拉控件
            Ddl_Version.Items.Clear();
            foreach (BfPublishModel m in publishList)
            {
                Ddl_Version.Items.Add(new ListItem(m.BF_VERSION.ToString(), m.BF_VERSION.ToString()));
            }
            Ddl_Version.SelectedValue = bfVersion;
            

        }

        /// <summary>
        /// 升版操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LnkBtn_Submit_Click(object sender, EventArgs e)
        {
            //1==业务流发布表
            List<BfPublishModel> publishList = publishSrv.GetList().Where(p => p.BF_ID == bfId).ToList();
            int maxVersion = publishList.Max(p => p.BF_VERSION);
            BfPublishModel maxPublishModel = publishList.Find(p => p.BF_ID == bfId && p.BF_VERSION == maxVersion);
            BfPublishModel pubModel = new BfPublishModel();
            pubModel.BF_ID = bfId;
            pubModel.BF_VERSION = maxVersion + 1;
            pubModel.BF_MODDATE = DateTime.Now;
            pubModel.BF_PUBSIGN = 0;
            pubModel.BF_STATUS = 1;
            pubModel.BF_SCRIPT = (maxPublishModel != null) ? maxPublishModel.BF_SCRIPT : "";//默认取当前最大版本的脚本
            pubModel.DB_Option_Action = WebKeys.InsertAction;
            publishSrv.Execute(pubModel);

            //2==业务流节点表
            BfNodesService nodeSrv = new BfNodesService();
            List<BfNodesModel> nodesList = nodeSrv.
                GetListById_Version(maxPublishModel.BF_ID, maxPublishModel.BF_VERSION).ToList();
            foreach (BfNodesModel node in nodesList)
            {
                node.BF_VERSION = maxVersion + 1;
                node.DB_Option_Action = WebKeys.InsertAction;
                nodeSrv.Execute(node);
            }

            //3==业务流角色表
            BfNoderolesService nodeRoleSrv = new BfNoderolesService();
            List<BfNoderolesModel> nodeRoleLst = nodeRoleSrv.
                GetListById_Version(maxPublishModel.BF_ID, maxPublishModel.BF_VERSION).ToList();
            foreach (BfNoderolesModel role in nodeRoleLst)
            {
                role.BF_ROLEID = CommonTool.GetPkId();
                role.BF_VERSION = maxVersion + 1;
                role.DB_Option_Action = WebKeys.InsertAction;
                nodeRoleSrv.Execute(role);
            }

            Response.Redirect(string.Format("BFDesigner.aspx?CUR_BFID={0}&CUR_BFVER={1}", bfId, pubModel.BF_VERSION));
            Response.End();
            
        }

    }
}