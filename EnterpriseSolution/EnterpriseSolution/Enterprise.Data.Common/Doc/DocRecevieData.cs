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
    /// �ļ���:  DocRecevieData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/2/26 15:10:24
    /// </summary>
    public class DocRecevieData : IDocRecevieData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(DocRecevieData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DocRecevieModel> GetList()
        {
            IList<DocRecevieModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<DocRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocRecevieData> db = new ORMDataAccess<DocRecevieData>())
                {
                    list = db.Query<DocRecevieModel>("from DocRecevieModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(DocRecevieData), true);
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
        public IList<DocRecevieModel> GetList(string hql)
        {
            IList<DocRecevieModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<DocRecevieData> db = new ORMDataAccess<DocRecevieData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<DocRecevieModel>("from DocRecevieModel");
                    }
                    else
					{
						list = db.Query<DocRecevieModel>(hql);
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
        public bool Execute(DocRecevieModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<DocRecevieData> db = new ORMDataAccess<DocRecevieData>())
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
    }
}
