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
    public partial class CreateFolder : System.Web.UI.Page
    {
        string filepath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filepath = FileHelper.Decrypt(Request.QueryString["filepath"]);
                filePatn_Txt.Text = string.Format("{0}", filepath);
                hfilePath.Value = filepath;
            }
        }
        protected void Ok_OnClick(object sender, EventArgs e)
        {
            filepath = hfilePath.Value;
            string sName = fName.Text.Trim();
            string nodePath = FileHelper.RootFolder(filepath);
            if (Directory.Exists(nodePath))
            {
                try
                {
                    Directory.CreateDirectory(nodePath + Path.DirectorySeparatorChar + sName);
                    #region "写入日志文件"
                    //LogServices.WriteLog("操作 : 新建文件夹 ; 文件夹名称: " + sName);
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