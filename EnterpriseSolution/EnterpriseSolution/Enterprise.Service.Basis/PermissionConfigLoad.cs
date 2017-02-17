using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Service.Basis
{
    /// <summary>
    ///  权限配置
    /// </summary>
    public class PermissionConfigLoad : IConfigurationSectionHandler
    {

        /// <summary>
        /// 创建配置权限
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="configContext"></param>
        /// <param name="section"></param>
        /// <returns></returns>
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            SysPermissionModel P_Mission = new SysPermissionModel();
            XmlNode AppNode = section.SelectSingleNode("ApplicationID");
            P_Mission.ApplicationId = Convert.ToInt32(AppNode.InnerText);
            P_Mission.ApplicationName = AppNode.Attributes["name"].Value;
            AppNode = section.SelectSingleNode("PageCode");
            P_Mission.PageCode = AppNode.InnerText;
            P_Mission.PageCodeName = AppNode.Attributes["name"].Value;
            //获取当前目录下的所有文件
            List<string> Files = Utility.GetDirFileList("aspx");
            XmlNodeList ItemNodes = section.SelectNodes("Item");
            foreach (XmlNode Node in ItemNodes)
            {
                SysPermissionItemModel Item = new SysPermissionItemModel();
                Item.Item_Name = Node.Attributes["name"].Value;
                Item.Item_Value = Convert.ToInt32(Node.Attributes["value"].Value);
                Item.Item_FileList = Node.InnerText.ToLower();
                P_Mission.ItemList.Add(Item);
                if (Item.Item_FileList.Trim() != "")
                {
                    RemoveFile(Files, Item.Item_FileList.Trim());
                }
            }
            UpdatePermissionConfig(P_Mission, Files);

            return P_Mission;
        }

        /// <summary>
        /// 移除存在文件
        /// </summary>
        /// <param name="Files">所有文件列表</param>
        /// <param name="FileString">要移除的文件名，多个以,号分开如：,1343.aspx,2342.aspx,</param>
        private void RemoveFile(List<string> Files, string FileString)
        {
            string[] FileStringArray = FileString.Split(',');
            for (int i = 0; i < FileStringArray.Length; i++)
            {
                if (FileStringArray[i].Trim() != "")
                {
                    Files.Remove(FileStringArray[i].Trim());
                }
            }
        }

        /// <summary>
        /// 更新权限配置文件表
        /// </summary>
        /// <param name="premission">权限配置</param>
        /// <param name="Files">文件名</param>
        private void UpdatePermissionConfig(SysPermissionModel premission, List<string> Files)
        {
            if (Files.Count > 0)
            {
                SysPermissionItemModel Item = new SysPermissionItemModel();
                Item.Item_Value = 2;
                Item.Item_Name = "Look";
                Item.Item_FileList = "";
                foreach (string var in Files)
                {
                    Item.Item_FileList = string.Format(",{0}{1}", var, Item.Item_FileList);
                }
                Item.Item_FileList = Item.Item_FileList + ",";
                premission.ItemList.Add(Item);

            }
        }

    }
}
