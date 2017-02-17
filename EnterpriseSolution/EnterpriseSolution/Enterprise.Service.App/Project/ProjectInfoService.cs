using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Project;
using Enterprise.Model.App.Project;
using System.Data;
using Enterprise.Component.ORM;

namespace Enterprise.Service.App.Project
{
	
    /// <summary>
    /// 文件名:  ProjectInfoService.cs
    /// 功能描述: 业务逻辑层-立项数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2015/6/1 14:34:34
    /// </summary>
    public class ProjectInfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IProjectInfoData dal = new ProjectInfoData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectInfoModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }
        public static string GetProjectName(string projectId)
        {
            string pName = string.Empty;
            ProjectInfoModel model = (new ProjectInfoService()).GetList().Where(w=>w.PROJID==projectId).FirstOrDefault();
            if (model != null)
            {
                pName = model.PROJNAME;
            }
            return pName;
        }
	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectInfoModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectInfoModel model)
        {
            return dal.Execute(model);
        }
        public DataSet getDsBySql(string sql)
        {

            DataSet ds = null;
            using (ORMDataAccess<ProjectInfoData> db = new ORMDataAccess<ProjectInfoData>())
            {
                ds = db.ExecuteDataset(sql, null);
            }
            return ds;
        }
        
        public static string GetAttachmentHTML(string attachId, string attachFiles)
        {
            StringBuilder htmlSB = new StringBuilder();
            if (!string.IsNullOrEmpty(attachFiles))
            {
                //多个文件处理
                string[] afns = attachFiles.TrimEnd('|').Split('|');
                htmlSB.Append("<table border=\"0\" cellspacing=\"2\" class=\"tableborder4\">");
                for (int i = 0; i < afns.Length; i++)
                {
                    string[] fns = afns[i].Split(';');
                    if (fns != null && fns.Length == 2)
                    {
                        string viewFn = fns[0];
                        string factFn = fns[1];
                        if (string.IsNullOrEmpty(viewFn) || string.IsNullOrEmpty(factFn))
                            continue;
                        htmlSB.Append("<tr><td colspan=\"2\" height=\"20\" class=\"tablebody1\"><img title=\"dvubb\" src=\"/Resources/OA/site_skin/images/attach.png\" border=\"0\" alt=\"\"/>");
                        htmlSB.Append(string.Format("&nbsp;&nbsp;附件：<a href=\"/Modules/Common/EntDisk/Content/Ashx/FileDownload.ashx?url={0}\">{1}</a>", FileHelper.Encrypt(factFn), viewFn));
                        //htmlSB.Append("&nbsp;&nbsp;|&nbsp;&nbsp;<img title=\"dvubb\" src=\"/Resources/Common/filetype/anchor.png\" border=\"0\" alt=\"\"/>");
                        //htmlSB.Append(string.Format("<a href=\"/Modules/Common/Article/DownloadFile.aspx?id={0}&fn={1}\" target=\"_blank\">下载{2}次</a>", article.ARTICLEID, viewFn, downloadTimes));
                        htmlSB.Append("</td></tr>");
                    }

                }
                htmlSB.Append("</table>");
            }

            return htmlSB.ToString();
        }
        #endregion
    }

}
