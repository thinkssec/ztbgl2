using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Doc;

namespace Enterprise.Data.Common.Doc
{

    /// <summary>
    /// 文件名:  DocClassData.cs
    /// 功能描述: 数据层-数据访问方法实现类
    /// 创建人：代码生成器
	/// 创建时间 ：2013/2/26 15:10:23
    /// </summary>
    public class DocClassData : IDocClassData
    {
        #region 代码生成器
		/// <summary>
        /// 缓存项名称
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(DocClassData).ToString();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<DocClassModel> GetList()
        {
            IList<DocClassModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<DocClassModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocClassData> db = new ORMDataAccess<DocClassData>())
                {
                    list = db.Query<DocClassModel>("from DocClassModel");
                    
                    //数据存入缓存系统
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(DocClassData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// 根据条件返回数据集合
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<DocClassModel> GetList(string hql)
        {
            IList<DocClassModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocClassData> db = new ORMDataAccess<DocClassData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<DocClassModel>("from DocClassModel");
                    }
                    else
					{
						list = db.Query<DocClassModel>(hql);
					}
                }
            }
            return list;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DocClassModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<DocClassData> db = new ORMDataAccess<DocClassData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(model);
                }
                else if (model.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(model);
                }
                else if (model.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(model);
                }
            }

            //清空相关的缓存
            CacheHelper.RemoveCacheForClassKey(cacheClassKey);

            return isResult;
        }

        #endregion

        #region 扩展方法
        /// <summary>
        /// 根据ID获取数据
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DocClassModel GetListById(int classId)
        {
            return GetList("from DocClassModel c where c.CLASSID=" + classId).FirstOrDefault();
        }        

        /// <summary>
        /// 栏目下是否有文章
        /// </summary>
        /// <param name="_cid"></param>
        /// <returns></returns>
        public bool HasArticle(int classId)
        {
            IDocArticlesData dcd = new DocArticlesData();
            return dcd.GetList("from DocArticlesModel c where C.CLASSID=" + classId).Count>0?true:false;
        }       

        /// <summary>
        /// 用户是否有在栏目中发布文章的权限
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool AllowPubArticleInClass(int classId, int userId)
        {
            bool rbool = false;
            using (ORMDataAccess<DocClassData> db = new ORMDataAccess<DocClassData>())
            {
                System.Data.DataTable dt = db.ExecuteDataset("select t.classid, t.classname, ','||t.classpubroles||',' as rolelist ,'0' as qx from doc_class t ",null).Tables[0];
                System.Data.DataTable dt2 = db.ExecuteDataset("select t.roleid from sys_userrole t where userid=" + userId,null).Tables[0];
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    foreach (System.Data.DataRow dr2 in dt2.Rows)
                    {
                        if (dr["rolelist"].ToString().Contains("," + dr2["roleid"].ToString() + ","))
                        {
                            dr["qx"] = 1;
                            rbool = true;
                        }
                    }
                }
                int t = dt.Select("qx='1' and classid=" + classId).Count();
                if (t > 0)
                    rbool = true;
                else
                    rbool = false;
                return rbool;
            }
        }

        #endregion
    }
}
