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
    /// �ļ���:  DocClassData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/26 15:10:23
    /// </summary>
    public class DocClassData : IDocClassData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(DocClassData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
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
                    
                    //���ݴ��뻺��ϵͳ
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
        /// ���������������ݼ���
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
        /// ִ����ӡ��޸ġ�ɾ������
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

            //�����صĻ���
            CacheHelper.RemoveCacheForClassKey(cacheClassKey);

            return isResult;
        }

        #endregion

        #region ��չ����
        /// <summary>
        /// ����ID��ȡ����
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public DocClassModel GetListById(int classId)
        {
            return GetList("from DocClassModel c where c.CLASSID=" + classId).FirstOrDefault();
        }        

        /// <summary>
        /// ��Ŀ���Ƿ�������
        /// </summary>
        /// <param name="_cid"></param>
        /// <returns></returns>
        public bool HasArticle(int classId)
        {
            IDocArticlesData dcd = new DocArticlesData();
            return dcd.GetList("from DocArticlesModel c where C.CLASSID=" + classId).Count>0?true:false;
        }       

        /// <summary>
        /// �û��Ƿ�������Ŀ�з������µ�Ȩ��
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
