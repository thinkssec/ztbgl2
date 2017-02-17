using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Examine;
using Enterprise.Model.App.Examine;
using Enterprise.Component.Cache;

namespace Enterprise.Service.App.Examine
{
	
    /// <summary>
    /// 文件名:  ExamineNodesService.cs
    /// 功能描述: 业务逻辑层-检验流程节点表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013-11-5 15:48:10
    /// </summary>
    public class ExamineNodesService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExamineNodesData dal = new ExamineNodesData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineNodesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineNodesModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineNodesModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        #region 自定义方法区

        /// <summary>
        /// 根据检验类型提取相应的节点数据集合
        /// </summary>
        /// <param name="kindId"></param>
        /// <returns></returns>
        public IList<ExamineNodesModel> GetListByKindId(int kindId)
        {
            return GetListByHQL("from ExamineNodesModel p where p.KINDID='" + kindId + "' order by p.NODEBH");
        }

        /// <summary>
        /// 获取指定业务类型的节点树JSON
        /// </summary>
        /// <param name="kindId">类型ID</param>
        /// <returns></returns>
        public string GetNodesTreeJSONById(int kindId)
        {
            string jsonStr = string.Empty;

            if (WebKeys.EnableCaching)
            {
                jsonStr = (string)CacheHelper.GetCache(ExamineNodesData.CacheClassKey + "_GetNodesTreeJSONById_" + kindId);
            }

            if (string.IsNullOrEmpty(jsonStr))
            {
                var list = GetListByKindId(kindId).Where(p => p.NODESTATUS == 1).ToList();
                DataTable dt = new DataTable();
                //NODEBH,NODENAME,NODEPATH,PARENTID,KEYNODE
                dt.Columns.Add("NODEBH", typeof(string));
                dt.Columns.Add("NODENAME", typeof(string));
                dt.Columns.Add("NODEPATH", typeof(string));
                dt.Columns.Add("PARENTID", typeof(string));
                dt.Columns.Add("KEYNODE", typeof(string));
                dt.Columns.Add("RUNSTATUS", typeof(string));
                foreach (var q in list)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = q.NODEBH;
                    dr[1] = q.NODENAME;
                    dr[2] = getNodePath(q);
                    dr[3] = getParentID(q);
                    dr[4] = q.KEYNODE;
                    dr[5] = "1";
                    dt.Rows.Add(dr);
                }
                jsonStr = dt.ToJsonForTree("NODEBH", "NODENAME", "PARENTID", "00", "NODEPATH", "");
                if (WebKeys.EnableCaching)
                {
                    //数据存入缓存系统
                    CacheHelper.Add(typeof(ExamineNodesData), false, null, "GetNodesTreeJSONById", 
                        null, ExamineNodesData.CacheClassKey + "_GetNodesTreeJSONById_" + kindId, jsonStr);
                }
            }

            return jsonStr;
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 获取节点路径
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string getNodePath(ExamineNodesModel model)
        {
            string url = model.NODEPATH;
            if (!string.IsNullOrEmpty(model.WEBURL))
            {
                url = model.WEBURL + model.WEBPARAM;
            }
            return url;
        }

        /// <summary>
        /// 获取上级节点编号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string getParentID(ExamineNodesModel model)
        {
            string parentId = "00";
            if (!string.IsNullOrEmpty(model.NODEBH) && model.NODEBH.Length >= 4)
            {
                parentId = model.NODEBH.Substring(0, model.NODEBH.Length - 2);
            }
            return parentId;
        }

        #endregion
    }

}
