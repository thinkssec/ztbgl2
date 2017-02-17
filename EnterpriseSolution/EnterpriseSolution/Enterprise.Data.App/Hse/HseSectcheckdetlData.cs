using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Hse;

namespace Enterprise.Data.App.Hse
{

    /// <summary>
    /// �ļ���:  HseSectcheckdetlData.cs
    /// ��������: ���ݲ�-��ȫ�����ϸ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/4/29 13:20:45
    /// </summary>
    public class HseSectcheckdetlData : IHseSectcheckdetlData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(HseSectcheckdetlData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetList()
        {
            IList<HseSectcheckdetlModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<HseSectcheckdetlModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<HseSectcheckdetlData> db = new ORMDataAccess<HseSectcheckdetlData>())
                {
                    list = db.Query<HseSectcheckdetlModel>("from HseSectcheckdetlModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(HseSectcheckdetlData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
		    //}
                }
            }
            return list;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetListByHQL(string hql)
        {
            IList<HseSectcheckdetlModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<HseSectcheckdetlModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<HseSectcheckdetlData> db = new ORMDataAccess<HseSectcheckdetlData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<HseSectcheckdetlModel>("from HseSectcheckdetlModel");
			}
			else
			{
				list = db.Query<HseSectcheckdetlModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(HseSectcheckdetlData), false);
	                    //refreshAction.ConstuctParms = null;
	                    //refreshAction.MethodName = "GetListByHQL";
	                    //refreshAction.Parameters = new object[]{ hql };
	                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
			    //}
                }
            }
            return list;
        }


	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HseSectcheckdetlModel> GetListBySQL(string sql)
        {
            IList<HseSectcheckdetlModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<HseSectcheckdetlModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<HseSectcheckdetlData> db = new ORMDataAccess<HseSectcheckdetlData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<HseSectcheckdetlModel>(sql, typeof(HseSectcheckdetlModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(HseSectcheckdetlData), false);
                            refreshAction.ConstuctParms = null;
                            refreshAction.MethodName = "GetListBySQL";
                            refreshAction.Parameters = new object[] { sql };
                            CacheHelper.Add(CacheClassKey + "_GetListBySQL_" + sql, list, refreshAction);
                        }
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
        public bool Execute(HseSectcheckdetlModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<HseSectcheckdetlData> db = new ORMDataAccess<HseSectcheckdetlData>())
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

		if (WebKeys.EnableCaching)
		{
		    //�����صĻ���
		    CacheHelper.RemoveCacheForClassKey(CacheClassKey);
		}
            return isResult;
        }

        #endregion
    }
}
