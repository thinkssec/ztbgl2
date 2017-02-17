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
    public partial class BFToView : System.Web.UI.Page
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
        }
    }
}