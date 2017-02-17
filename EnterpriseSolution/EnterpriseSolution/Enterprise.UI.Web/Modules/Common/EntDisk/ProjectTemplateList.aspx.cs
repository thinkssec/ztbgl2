using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using Enterprise.Component.Infrastructure;
using Enterprise.Model.Common.EntDisk;
using Enterprise.Service.Common.EntDisk;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.UI.Web.Modules.EntDisk
{
    /// <summary>
    /// 标准模板页面
    /// </summary>
    public partial class ProjectTemplateList : System.Web.UI.Page
    {
        /// <summary>
        /// 文件夹及文件列表
        /// </summary>
        protected List<FileModel> FileList = new List<FileModel>();
        /// <summary>
        /// sessionId
        /// </summary>
        protected string sid = (string)Utility.sink("sid", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        /// <summary>
        /// 显示路径
        /// </summary>
        protected string nav = "";
        /// <summary>
        /// 名称
        /// </summary>
        protected string FileName = "";
        /// <summary>
        /// 文件路径
        /// </summary>
        protected string FilePathName = "";
        /// <summary>
        /// 返回路径
        /// </summary>
        protected string BackFilePathName = "";
        /// <summary>
        /// 当前文件路径
        /// </summary>
        protected string CurrentFilePath = "";
        /// <summary>
        /// 文件路径
        /// </summary>
        protected string fid = (string)Utility.sink("fid", Utility.MethodType.Get, 0, 0, Utility.DataType.Str);
        protected int folderNum = 0;
        protected int fileNum = 0;
        /// <summary>
        /// 默认为为 0：标准模板
        /// </summary>
        protected int typeId = (int)Utility.sink("typeId", Utility.MethodType.Get, 0, 0, Utility.DataType.Int);
        protected string NavString = "";
        protected string rootFolder = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            rootFolder = fid;
            string fFolder = fid;
            if (!IsPostBack)
            {
                string _temp = "";
                if (typeId == 0)
                {
                    _temp = FileName = NavString = "标准模板";
                    if (string.IsNullOrEmpty(fid))
                    {
                        fid = FileHelper.RootFolder("标准模板");
                        rootFolder = "";
                        fFolder = NavString;
                    }
                }
                ProcessPath(rootFolder, _temp);
                GetNodes(fFolder);

                ///文件路径用来传值 故做url转换处理
                FilePathName = FileHelper.Encrypt(fFolder);
            }
        }

        /// <summary>
        /// 取得当前目录下的文件夹及文件
        /// </summary>
        /// <param name="filePath"></param>
        void GetNodes(string filePath)
        {
            List<FileModel> list = FileService.GetFolderNodes(filePath);
            folderNum = list.Count;
            list.AddRange(FileService.GetFileNodes(filePath));
            FileList = list;
            fileNum = list.Count - folderNum;
        }

        void ProcessPath(string filePath, string s)
        {
            string filePathUrl = "<a href=\"ProjectTemplateList.aspx?sid=" + sid + "&typeId=" + typeId + "&desc=true\">" + NavString + "</a>";
            if (!String.IsNullOrEmpty(filePath))
            {
                string[] paths = filePath.Split(Path.DirectorySeparatorChar);
                string pathName = "";
                for (int i = 1; i < paths.Length; i++)
                {
                    pathName += Path.DirectorySeparatorChar + paths[i];

                    if (i < paths.Length - 1)
                    {
                        filePathUrl += string.Format("&gt;&gt; <a href={0}>{1}</a>", "ProjectTemplateList.aspx?sid=gDUqrgIIBStBnjUqxsIIdoGGvouNVqCR&typeId=" + typeId + "&desc=true&fid=" + s + pathName, paths[i]);
                    }
                    else if (i == paths.Length - 1)
                    {
                        filePathUrl += string.Format("&gt;&gt; {0}", paths[i]);
                    }
                    if (i < paths.Length - 1)
                    {
                        BackFilePathName += Path.DirectorySeparatorChar + paths[i];
                    }
                }
                BackFilePathName = s + BackFilePathName;
                FileName = paths[paths.Length - 1];
            }
            nav = filePathUrl;
        }

        /// <summary>
        /// 检测当前用户是否有编辑权限
        /// </summary>
        /// <returns></returns>
        protected bool CheckPower(int v)
        {
            return SysUserPermissionService.CheckButtonPermission((Utility.PopedomType)v);
        }

    }
}