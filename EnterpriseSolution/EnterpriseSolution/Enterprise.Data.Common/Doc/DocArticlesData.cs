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
    /// �ļ���:  DocArticlesData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/26 15:10:22
    /// </summary>
    public class DocArticlesData : IDocArticlesData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(DocArticlesData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocArticlesModel> GetList()
        {
            IList<DocArticlesModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<DocArticlesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocArticlesData> db = new ORMDataAccess<DocArticlesData>())
                {
                    list = db.Query<DocArticlesModel>("from DocArticlesModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(DocArticlesData), true);
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
        public IList<DocArticlesModel> GetList(string hql)
        {
            IList<DocArticlesModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocArticlesData> db = new ORMDataAccess<DocArticlesData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<DocArticlesModel>("from DocArticlesModel");
                    }
                    else
					{
						list = db.Query<DocArticlesModel>(hql);
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
        public bool Execute(DocArticlesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<DocArticlesData> db = new ORMDataAccess<DocArticlesData>())
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

        /// <summary>
        /// ����ID��ȡ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DocArticlesModel GetListById(int id)
        {
            return GetList("from DocArticlesModel c where c.ID=" + id).FirstOrDefault();
        }
    }
}
