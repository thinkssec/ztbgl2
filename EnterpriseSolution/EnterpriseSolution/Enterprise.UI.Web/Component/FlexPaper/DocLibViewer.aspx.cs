using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.App.Document;
using Enterprise.Service.App.Document;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Component.FlexPaper
{
    /// <summary>
    /// 文档库 PDF 查看器
    /// </summary>
    public partial class DocLibViewer : System.Web.UI.Page
    {
        /// <summary>
        /// 文档实例ID
        /// </summary>
        protected string cvtId = (string)Utility.sink("id", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// PDF转为SWF格式后的文件名称（含路径）
        /// </summary>
        protected string SwfFileName = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }

        /// <summary>
        /// 初始化数据内容
        /// </summary>
        private void OnStart()
        {
            DocumentConvertService docCvtSrv = new DocumentConvertService();
            DocumentDownloadsService docDownLoadSrv = new DocumentDownloadsService();
            var q = docCvtSrv.GetModelByCvtId(cvtId);
            if (q != null && q.DocumentProj != null)
            {
                if (!string.IsNullOrEmpty(q.CVTPATH)) 
                {
                    SwfFileName = q.CVTPATH;
                    //记录浏览的次数
                    DocumentDownloadsModel downModel = new DocumentDownloadsModel();
                    //20140314164832988	2C201CB156044D85ABF673EB5B1E20CC	::1	1	2014/3/14 16:48:32	1
                    downModel.ID = CommonTool.GetPkId();
                    downModel.DOCID = q.DocumentProj.DOCID;
                    downModel.IPADDR = Utility.GetIPAddress();
                    downModel.USERID = Utility.Get_UserId;
                    downModel.LOOKUPDATE = DateTime.Now;
                    downModel.USERNAME = SysUserService.GetUserName(Utility.Get_UserId);
                    downModel.DB_Option_Action = WebKeys.InsertAction;
                    docDownLoadSrv.Execute(downModel);
                }
                else
                {
                    Response.Write(string.Format("<script>alert('{0}');</script>", "文件名称不匹配！"));
                }
            }
            else
            {
                Response.Write(string.Format("<script>alert('{0}');</script>", "文件不存在！"));
            }
        }
    }
}