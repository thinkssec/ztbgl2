using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Enterprise.Model.Common.EntDisk;
using Enterprise.Component.Infrastructure;
namespace Enterprise.Service.Common.EntDisk
{
    /// <summary>
    /// 文件相关服务类
    /// </summary>
    public class FileService
    {
        /// <summary>
        /// 取得当前目录下的文件夹及文件数
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static int GetAllNodesCount(string filePath)
        {
            filePath = FileHelper.Decrypt(filePath);
            return GetAllNodes(filePath).Count;
        }

        /// <summary>
        /// 取得当前路径下的所有文件夹或文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<FileModel> GetAllNodes(string filePath)
        {
            List<FileModel> list = GetFolderNodes(filePath);
            list.AddRange(GetFileNodes(filePath));
            return list;
        }


        /// <summary>
        /// 取得当前路径下的所有文件夹
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public static List<FileModel> GetFolderNodes(string filePath)
        {
            List<FileModel> list = new List<FileModel>();
            string nodePath = FileHelper.RootFolder(filePath);
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
            }
            return list;
        }

        /// <summary>
        /// 取得当前路径下的所有文件
        /// </summary>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        public static List<FileModel> GetFileNodes(string filePath)
        {
            List<FileModel> list = new List<FileModel>();

            string nodePath = FileHelper.RootFolder(filePath);
            if (Directory.Exists(nodePath))
            {
                string[] files = Directory.GetFiles(nodePath);
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


        public static FileInfo GetFileInfo(string filePath, string fileName)
        {

            filePath = FileHelper.Decrypt(filePath);
            string nodePath =FileHelper.RootFolder( filePath);
            if (Directory.Exists(nodePath))
            {
                if (File.Exists(nodePath + Path.DirectorySeparatorChar + fileName))
                {
                    FileInfo fi = new FileInfo(nodePath + Path.DirectorySeparatorChar + fileName);
                    return fi;
                }
            }

            return null;
        }


        public static string GetFileLength(long bt)
        {
            string fLength = "";

            if (bt >= 1024 * 1024)
            {
                fLength = string.Format("{0}M", bt / 1024 / 1024);
            }
            else if (bt >= 1024 && bt < 1024 * 1024)
            {
                fLength = string.Format("{0}KB", bt / 1024);
            }
            else if (bt < 1024 && bt > 0)
            {
                fLength = string.Format("{0}B", bt);
            }
            else if (bt == 0)
            {
                fLength = string.Format("{0}", bt);
            }

            return fLength;
        }


        /// <summary>
        /// 计算文件夹的大小  遍历文件夹中所有的文件夹及文件
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static long GetFloderLength(string filePath, string fileName)
        {
            long fLength = 0;
            filePath = FileHelper.Decrypt(filePath);
            string nodePath =FileHelper.RootFolder( filePath);
            string currentPath = nodePath + Path.DirectorySeparatorChar + fileName;
            if (Directory.Exists(currentPath))
            {
                string[] files = Directory.GetFiles(currentPath);
                foreach (string file in files)
                {
                    string filep = currentPath + Path.DirectorySeparatorChar + Path.GetFileName(file);
                    if (File.Exists(filep))
                    {
                        FileInfo fi = new FileInfo(filep);
                        fLength += fi.Length;
                    }
                }
                string[] folders = Directory.GetDirectories(currentPath);
                foreach (string file in folders)
                {
                    GetChildFloderLength(filePath + Path.DirectorySeparatorChar + fileName, Path.GetFileName(file), ref fLength);
                }
            }
            return fLength;
        }

        /// <summary>
        /// 遍历 循环计算文件夹及文件的总和
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="fileName"></param>
        /// <param name="length"></param>
        static void GetChildFloderLength(string filePath, string fileName, ref long length)
        {

            filePath = FileHelper.Decrypt(filePath);
            string nodePath =FileHelper.RootFolder( filePath);
            string currentPath = nodePath + Path.DirectorySeparatorChar + fileName;
            if (Directory.Exists(currentPath))
            {
                string[] files = Directory.GetFiles(currentPath);
                foreach (string file in files)
                {
                    string filep = currentPath + Path.DirectorySeparatorChar + Path.GetFileName(file);
                    if (File.Exists(filep))
                    {
                        FileInfo fi = new FileInfo(filep);
                        length += fi.Length;
                    }
                }
                string[] folders = Directory.GetDirectories(currentPath);
                foreach (string file in folders)
                {
                    GetChildFloderLength(filePath + Path.DirectorySeparatorChar + fileName, Path.GetFileName(file), ref length);
                }
            }

        }


        /// <summary>
        /// 拷贝文件到目标文件夹下
        /// </summary>
        /// <param name="strFromPath"></param>
        /// <param name="strToPath"></param>
        public static void CopyFolder(string strFromPath, string strToPath)
        {
            //如果源文件夹不存在，则创建
            if (!Directory.Exists(strFromPath))
            {
                Directory.CreateDirectory(strFromPath);
            }
            //取得要拷贝的文件夹名
            string strFolderName = strFromPath.Substring(strFromPath.LastIndexOf("\\") + 1, strFromPath.Length - strFromPath.LastIndexOf("\\") - 1);
            //如果目标文件夹中没有源文件夹则在目标文件夹中创建源文件夹
            if (!Directory.Exists(strToPath + "\\" + strFolderName))
            {
                Directory.CreateDirectory(strToPath + "\\" + strFolderName);
            }
            //创建数组保存源文件夹下的文件名
            string[] strFiles = Directory.GetFiles(strFromPath);
            //循环拷贝文件
            for (int i = 0; i < strFiles.Length; i++)
            {
                //取得拷贝的文件名，只取文件名，地址截掉。
                string strFileName = strFiles[i].Substring(strFiles[i].LastIndexOf("\\") + 1, strFiles[i].Length - strFiles[i].LastIndexOf("\\") - 1);
                //开始拷贝文件,true表示覆盖同名文件
                File.Copy(strFiles[i], strToPath + "\\" + strFolderName + "\\" + strFileName, true);
            }

            //创建DirectoryInfo实例
            DirectoryInfo dirInfo = new DirectoryInfo(strFromPath);
            //取得源文件夹下的所有子文件夹名称
            DirectoryInfo[] ZiPath = dirInfo.GetDirectories();
            for (int j = 0; j < ZiPath.Length; j++)
            {
                //获取所有子文件夹名
                string strZiPath = strFromPath + "\\" + ZiPath[j].ToString();
                //把得到的子文件夹当成新的源文件夹，从头开始新一轮的拷贝
                CopyFolder(strZiPath, strToPath + "\\" + strFolderName);
            }
        }
    }
}
