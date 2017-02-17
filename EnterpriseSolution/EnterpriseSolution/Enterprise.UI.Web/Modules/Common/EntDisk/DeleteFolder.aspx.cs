using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Enterprise.Component.Infrastructure;
namespace Enterprise.UI.Web.Modules.EntDisk
{
    public partial class DeleteFolder : System.Web.UI.Page
    {
        string filepath = "";
        string filename = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                filepath = Request.QueryString["filepath"];
                filename = Request.QueryString["filename"];

                filePatn_Txt.Text = string.Format("{0}", filepath);
                hfilePath.Value = filepath;
                fileName_Txt.Text = hfileName.Value = filename;


            }
        }

        protected void delete_OnClick(object sender, EventArgs e)
        {
            filepath = hfilePath.Value;
            filename = hfileName.Value;

            string nodePath = FileHelper.RootFolder(filepath);

            if (Directory.Exists(nodePath + Path.DirectorySeparatorChar + filename))
            {
                try
                {
                    Directory.Delete(nodePath + Path.DirectorySeparatorChar + filename, true);

                    #region "写入日志文件"
                    //LogServices.WriteLog("操作 : 删除文件夹 ; 文件夹名称: " + filename);
                    #endregion
                    //Utility.Closedg(this.Page);
                    ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "closeWin", "<script type='text/javascript'>parent.$('#w').window('close');parent.location.reload();</script>", false);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
    }
}