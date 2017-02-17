using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;
using System.IO;
using Enterprise.Model.Common.EntDisk;
namespace Enterprise.UI.Web.Modules.EntDisk
{
    public partial class FolderInfo : System.Web.UI.Page
    {
        protected string fLength = "";
        protected string fPath = "";
        protected int fNum = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fPath = FileHelper.Decrypt(Request.QueryString["filepath"]);
                string fileName = Request.QueryString["filename"];

                GetFileInfo(fPath, fileName);

                hfName_Txt.Value = fileName;
                hfPath_Txt.Value = fPath;
            }
        }

        void GetFileInfo(string filepath, string filename)
        {

            string nodePath = filepath;

            string _filepath =FileHelper.RootFolder( nodePath) + Path.DirectorySeparatorChar + filename;

            if (Directory.Exists(_filepath))
            {
                fName_Txt.Text = filename;

                List<FileModel> list = GetFileNodes(_filepath);
                fNum = list.Count;
            }
        }

        public static List<FileModel> GetFileNodes(string filePath)
        {
            List<FileModel> list = new List<FileModel>();

            string nodePath = filePath;
            if (Directory.Exists(nodePath))
            {
                string[] files = Directory.GetDirectories(nodePath);
                foreach (string file in files)
                {
                    FileModel model = new FileModel();
                    model.fileName = file;
                    model.fileLength = "";
                    model.fileCreateTime = DateTime.Now;
                    model.fileModifyTime = DateTime.Now;
                    model.fileType = 0;
                    list.Add(model);
                }

                files = Directory.GetFiles(nodePath);
                foreach (string file in files)
                {
                    FileModel model = new FileModel();
                    model.fileName = file;
                    model.fileLength = "";
                    model.fileCreateTime = DateTime.Now;
                    model.fileModifyTime = DateTime.Now;
                    model.fileType = 1;
                    list.Add(model);
                }

            }

            return list;
        }

        protected void btnMsgOk_OnClick(object sender, EventArgs e)
        {
            string sFolderName = fName_Txt.Text.Trim();
            string soldName = hfName_Txt.Value;
            string soldPath = hfPath_Txt.Value;
            if (sFolderName == soldName)
            {
                Utility.Closedg(this.Page);
            }
            else
            {
                string nodePath = FileHelper.RootFolder(soldPath);
                try
                {
                    if (Directory.Exists(nodePath))
                    {
                        Directory.Move(nodePath + Path.DirectorySeparatorChar + soldName, nodePath + Path.DirectorySeparatorChar + sFolderName);
                        #region "添加日志文件"
                        //LogServices.WriteLog("操作 : 修改文件夹名称 ; 旧文件夹名称: " + soldName + "  新文件夹名称 : " + sFolderName);
                        #endregion
                        //Utility.Closedg(this.Page);
                        ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "closeWin", "<script type='text/javascript'>parent.$('#w').window('close');parent.location.reload();</script>", false);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}