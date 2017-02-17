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
    public partial class DeleteSelect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filepath = FileHelper.Decrypt(Request.QueryString["filepath"]);
                string file = Request.QueryString["file"];

                hfilePath.Value = filepath;
                filePath_Txt.Text = string.Format("{0}", filepath);
                //fileName_Txt.Text = file;
                GetFiles(file);
            }
        }

        void GetFiles(string files)
        {
            string[] file = files.Split('|');

            string filepath = "";

            for (int i = 0; i < file.Length; i++)
            {
                if (file[i] != "" && file[i] != "checkAll")
                {
                    filepath += file[i] + ";";
                }
            }
            fileName_Txt.Text = hfileName.Value = filepath;
        }

        protected void delete_OnClick(object sender, EventArgs e)
        {
            //删除文件或者文件夹
            string filepath = hfilePath.Value;
            string files = hfileName.Value;

            string nodepath = FileHelper.RootFolder(filepath);

            string[] file = files.Split(';');
            for (int i = 0; i < file.Length - 1; i++)
            {
                string fpath = nodepath + Path.DirectorySeparatorChar + file[i];
                if (Directory.Exists(fpath))
                {
                    Directory.Delete(fpath, true);
                }

                if (File.Exists(fpath))
                {
                    File.Delete(fpath);
                }
            }
            #region "写入日志文件"
            //LogServices.WriteLog("操作 : 批量删除文件夹或者文件 ; 文件夹或文件名称: " + files);
            #endregion
            //Utility.Closedg(this.Page);
            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "closeWin", "<script type='text/javascript'>parent.$('#w').window('close');parent.location.reload();</script>", false);
        }
    }
}