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
    public partial class DeleteFile : System.Web.UI.Page
    {
        string filepath = (string)Utility.sink("filepath", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        string filename = (string)Utility.sink("filename", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filePatn_Txt.Text = string.IsNullOrEmpty(filepath) == true ? "" : filepath;
                hfilePath.Value = filepath;
                fileName_Txt.Text = hfileName.Value = filename;
            }
        }

        protected void delete_OnClick(object sender, EventArgs e)
        {
            filepath = FileHelper.RootFolder(hfilePath.Value);
            filename = hfileName.Value;
            filepath = filepath + Path.DirectorySeparatorChar + filename;
            
            try
            {
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                }
                #region "写入日志文件"
                //LogServices.WriteLog("操作 : 删除文件 ; 文件名称: " + filename);
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