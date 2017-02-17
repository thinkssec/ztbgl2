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
    public partial class FileInfo : System.Web.UI.Page
    {
        protected string fLength = "";

        protected DateTime fCraeteTime;

        protected DateTime fModifyTime;

        protected string fExt = "";

        protected string fPath = "";

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

            string _filepath =FileHelper.RootFolder(nodePath) + Path.DirectorySeparatorChar + filename;

            if (!Directory.Exists(_filepath))
            {
                if (File.Exists(_filepath))
                {
                    System.IO.FileInfo fi = new System.IO.FileInfo(_filepath);

                    fName_Txt.Text = fi.Name.Substring(0, fi.Name.LastIndexOf("."));

                    if (fi.Length >= 1024 * 1024)
                    {
                        fLength = string.Format("{0:N0}M", fi.Length / 1024 / 1024);
                    }
                    else if (fi.Length >= 1024 && fi.Length < 1024 * 1024)
                    {
                        fLength = string.Format("{0:N0}KB", fi.Length / 1024);
                    }
                    else
                    {
                        fLength = string.Format("{0:N0}B", fi.Length);
                    }
                    fExt = fi.Extension;
                    fCraeteTime = fi.CreationTime;
                    fModifyTime = fi.LastWriteTime;

                    hfExt_Txt.Value = fExt;
                }
            }

        }


        protected void btnMsgOk_OnClick(object sender, EventArgs e)
        {
            string newfName = fName_Txt.Text;
            string oldfName = hfName_Txt.Value;
            string oldfPath = hfPath_Txt.Value;
            string ext = hfExt_Txt.Value;

            if (newfName == oldfName)
            {
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterStartupScript(typeof(string), "TabJs", "<script language='javascript'>window.returnVal=true;window.parent.hidePopWin(true);</script>");
            }
            else
            {

                string nodePath = FileHelper.RootFolder(oldfPath);
                try
                {
                    if (Directory.Exists(nodePath))
                    {
                        if (File.Exists(nodePath + Path.DirectorySeparatorChar + oldfName))
                        {
                            File.Move(nodePath + Path.DirectorySeparatorChar + oldfName, nodePath + Path.DirectorySeparatorChar + newfName + ext);
                            #region "写入日志文件"
                            //LogServices.WriteLog("操作 : 修改文件名称 ; 旧文件名称: " + oldfName + "  新文件名称 : " + newfName);
                            #endregion
                            //Utility.Closedg(this.Page);
                            ScriptManager.RegisterClientScriptBlock(this.Page, Page.GetType(), "closeWin", "<script type='text/javascript'>parent.$('#w').window('close');parent.location.reload();</script>", false);
                        }
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