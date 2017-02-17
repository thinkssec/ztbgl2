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
    public partial class MoveSelect : System.Web.UI.Page
    {
        int typeId = (int)Utility.sink("typeId", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string filepath = FileHelper.Decrypt(Request.QueryString["filepath"]);
                string file = Request.QueryString["file"];

                hfilePath.Value = filepath;
                filePath_Txt.Text = string.Format("{0}", filepath);

                GetFiles(file);

                DataBindDrop();
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

        void DataBindDrop()
        {
            string path = "";
            if (typeId == 0)
            {
                path = "公共存储";
            }
            else if (typeId == 1)
            {
                path = string.Format("个人存储/{0}", Enterprise.Service.Basis.Sys.SysUserService.GetUserName(Utility.Get_UserId));
            }
            DataBindChildDrop(path, "");
        }

        void DataBindChildDrop(string filepath, string length)
        {
            string nodepath =FileHelper.RootFolder(filepath);
            if (Directory.Exists(nodepath))
            {
                string[] files = Directory.GetDirectories(nodepath);
                foreach (string file in files)
                {
                    ListItem li = new ListItem();
                    li.Text = length + HttpUtility.HtmlDecode("&nbsp;") + HttpUtility.HtmlDecode("&nbsp;") + HttpUtility.HtmlDecode("└") + Path.GetFileName(file);
                    li.Value = filepath + Path.DirectorySeparatorChar + Path.GetFileName(file);
                    Drop_FileList.Items.Add(li);
                    DataBindChildDrop(filepath + Path.DirectorySeparatorChar + Path.GetFileName(file), length + HttpUtility.HtmlDecode("&nbsp;") + HttpUtility.HtmlDecode("&nbsp;"));
                }
            }
        }

        protected void Move_OnClick(object sender, EventArgs e)
        {
            //删除文件或者文件夹
            string filepath = hfilePath.Value;
            string files = hfileName.Value;
            //新路径
            string newfilepath = Drop_FileList.SelectedValue;
            string oldfilepath = filepath;
            string[] file = files.Split(';');
            try
            {

                for (int i = 0; i < file.Length - 1; i++)
                {
                    string fpath =FileHelper.RootFolder( oldfilepath) + Path.DirectorySeparatorChar + file[i];

                    string npath =FileHelper.RootFolder( newfilepath) + Path.DirectorySeparatorChar + file[i];

                    if (Directory.Exists(fpath))
                    {
                        Directory.Move(fpath, npath);
                    }

                    if (File.Exists(fpath))
                    {
                        File.Move(fpath, npath);
                    }
                }

                #region "写入日志文件"
                //LogServices.WriteLog("操作 : 批量移动文件夹或者文件 ; 文件夹或文件名称: " + files + "; 目标文件夹: 网盘" + Drop_FileList.SelectedValue + "");
                //LogServices.WriteLog("操作 : 批量移动文件夹或者文件 ; 文件夹或文件名称: " + files);
                #endregion

                Utility.Closedg(this.Page);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}