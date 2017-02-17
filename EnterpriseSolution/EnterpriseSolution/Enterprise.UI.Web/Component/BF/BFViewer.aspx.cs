using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

using Enterprise.Service.Basis.Bf;
using Enterprise.Model.Basis.Bf;
using Enterprise.Component.BF;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Component.BF
{
    public partial class BFViewer : System.Web.UI.Page
    {
        /// <summary>
        /// 业务流发布管理--服务类
        /// </summary>
        private BfPublishService publishSrv = new BfPublishService();
        /// <summary>
        /// 运行表--服务类
        /// </summary>
        private BfRunningService runningSrv = new BfRunningService();
        /// <summary>
        /// 节点信息--服务类
        /// </summary>
        private BfNodesService nodeSrv = new BfNodesService();
        /// <summary>
        /// 业务流实例--服务类
        /// </summary>
        private BfInstancesService instanceSrv = new BfInstancesService();
        /// <summary>
        /// 业务流发布MODEL
        /// </summary>
        protected BfPublishModel PublishModel;
        /// <summary>
        /// 已运行的节点ID集合
        /// </summary>
        protected List<string> RunNodeIdLst = new List<string>();
        /// <summary>
        /// 已运行的路径集合
        /// </summary>
        protected List<string> RunPathLst = new List<string>();
        /// <summary>
        /// 实例ID
        /// </summary>
        protected string InstanceId;

        protected void Page_Load(object sender, EventArgs e)
        {

            //接收参数
            InstanceId = Request["InstanceId"];

            if (string.IsNullOrEmpty(InstanceId))
            {
                Response.Write("参数不全");
                Response.End();
            }

            //必须提供实例ID
            List<BfRunningModel> runningList = runningSrv.GetListByInstanceId(InstanceId).OrderBy(p => p.BF_RUNID).ToList();
            BfRunningModel running = runningList.FirstOrDefault();
            if (running != null)
            {
                PublishModel = publishSrv.GetList().
                    Where(p => p.BF_ID == running.BfInstance.BF_ID && p.BF_VERSION == running.BfInstance.BF_VERSION)
                    .FirstOrDefault();
                if (PublishModel == null)
                {
                    Response.Write("查询数据不正确");
                    Response.End();
                }

                //获取节点信息
                foreach (BfRunningModel runModel in runningList)
                {
                    if (!RunNodeIdLst.Contains(runModel.BfFlowpath.BF_NODEID))
                    {
                        RunNodeIdLst.Add(runModel.BfFlowpath.BF_NODEID);
                        //保存线的两端
                        RunPathLst.Add(runModel.BfFlowpath.BF_NODEID + "-" + runModel.BfFlowpath.BF_NEXTNODE);
                    }
                    if (!RunNodeIdLst.Contains(runModel.BfFlowpath.BF_NEXTNODE))
                    {
                        RunNodeIdLst.Add(runModel.BfFlowpath.BF_NEXTNODE);
                        //保存线的两端
                        RunPathLst.Add(runModel.BfFlowpath.BF_NODEID + "-" + runModel.BfFlowpath.BF_NEXTNODE);
                    }
                }
            }
            else
            {
                //特殊情况处理，如果没有运行信息，则显示当前的所有节点为灰色
                BfInstancesModel instanceModel = instanceSrv.GetModelById(InstanceId);
                if (instanceModel != null)
                {
                    PublishModel = publishSrv.GetList().
                    Where(p => p.BF_ID == instanceModel.BF_ID && p.BF_VERSION == instanceModel.BF_VERSION)
                    .FirstOrDefault();
                }
            }

            if (PublishModel == null)
            {
                Response.Write("查询数据不正确");
                Response.End();
            }
        }
    }
}