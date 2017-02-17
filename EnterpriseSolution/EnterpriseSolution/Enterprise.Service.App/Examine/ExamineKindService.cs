using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using Enterprise.Component.Cache;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Examine;
using Enterprise.Model.App.Examine;

namespace Enterprise.Service.App.Examine
{

    /// <summary>
    /// 文件名:  ExamineKindService.cs
    /// 功能描述: 业务逻辑层-检验类型表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2013-11-8 14:53:58
    /// </summary>
    public class ExamineKindService
    {
        #region 代码生成器

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IExamineKindData dal = new ExamineKindData();
        /// <summary>
        /// 检验类型数据集合
        /// </summary>
        private IList<ExamineKindModel> kindTreeList = null;

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ExamineKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ExamineKindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineKindModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 返回数据集合
        /// 按顺序号排序，并根据层级显示名称
        /// </summary>
        /// <returns></returns>
        public IList<ExamineKindModel> GetTreeList()
        {
            if (WebKeys.EnableCaching)
            {
                kindTreeList = (IList<ExamineKindModel>)
                    CacheHelper.GetCache(ExamineKindData.CacheClassKey + "_GetTreeList");
            }
            if (kindTreeList == null)
            {
                kindTreeList = new List<ExamineKindModel>();
            }
            if (kindTreeList.Count == 0)
            {
                getListForTree(GetList(), 0);
                if (WebKeys.EnableCaching)
                {
                    CacheHelper.Add(ExamineKindData.CacheClassKey + "_GetTreeList", kindTreeList);
                }
            }
            return kindTreeList;
        }

        #endregion

        #region 专用方法

        /// <summary>
        /// 生成树型控件调用的数据
        /// </summary>
        /// <param name="kindLst"></param>
        /// <param name="parentId"></param>
        private void getListForTree(IList<ExamineKindModel> kindLst, int parentId)
        {
            IList<ExamineKindModel> subKindLst = kindLst.Where(p => p.PARENTID == parentId).OrderBy(p => p.KINDORDER).ToList();
            foreach (ExamineKindModel model in subKindLst)
            {
                ExamineKindModel newModel = (ExamineKindModel)CommonTool.Clone(model);
                if (model.PARENTID != null && model.PARENTID > 0)
                {
                    newModel.KINDNAME = CommonTool.GenerateBlankSpace(1) + model.KINDNAME;
                }
                kindTreeList.Add(newModel);
                getListForTree(kindLst, model.KINDID);
            }
        }

        /// <summary>
        /// 获取检验类型的名称
        /// </summary>
        /// <param name="KindId"></param>
        public static string GetTypeName(int kindId)
        {
            ExamineKindService Service = new ExamineKindService();
            var q = Service.GetList().Where(p => p.KINDID == kindId).FirstOrDefault();
            if (q != null)
            {
                //if (q.PARENTID != null && q.PARENTID.Value > 0)
                //{
                //    return GetTypeName(q.PARENTID.Value) + "->" + q.KINDNAME;
                //}
                //else
                //{
                    return q.KINDNAME;
                //}
            }
            return "";
        }

        #endregion

        public ExamineKindModel GetSingle(string Id)
        {
            return dal.GetListByHQL("from ExamineKindModel p where p.KINDID = '" + Id + "'").FirstOrDefault();
        }

        /// <summary>
        /// 根据检验类型获取部门ID
        /// </summary>
        /// <param name="KindId"></param>
        /// <returns></returns>
        public int GetDepId(int KindId)
        {
            ExamineKindModel Model = dal.GetList().Where(p => p.KINDID == KindId).FirstOrDefault();
           //var q= dal.GetListByHQL("from ExamineKindModel p where p.KINDID = 'KindId'").FirstOrDefault();
            return Model.DEPTID.ToInt();
        }
    }

}
