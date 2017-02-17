using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{

    /// <summary>
    /// �ļ���:  CrmPbsurveyitemData.cs
    /// ��������: ���ݲ�-�ҷ���λ�������ݱ����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2014/3/31 17:16:11
    /// </summary>
    public class CrmPbsurveyitemData : ICrmPbsurveyitemData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(CrmPbsurveyitemData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmPbsurveyitemModel> GetList()
        {
            IList<CrmPbsurveyitemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<CrmPbsurveyitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmPbsurveyitemData> db = new ORMDataAccess<CrmPbsurveyitemData>())
                {
                    list = db.Query<CrmPbsurveyitemModel>("from CrmPbsurveyitemModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(CrmPbsurveyitemData), false);
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
        public IList<CrmPbsurveyitemModel> GetListByHQL(string hql)
        {
            IList<CrmPbsurveyitemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<CrmPbsurveyitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmPbsurveyitemData> db = new ORMDataAccess<CrmPbsurveyitemData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<CrmPbsurveyitemModel>("from CrmPbsurveyitemModel");
			}
			else
			{
				list = db.Query<CrmPbsurveyitemModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(CrmPbsurveyitemData), false);
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
        public IList<CrmPbsurveyitemModel> GetListBySQL(string sql)
        {
            IList<CrmPbsurveyitemModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<CrmPbsurveyitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmPbsurveyitemData> db = new ORMDataAccess<CrmPbsurveyitemData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<CrmPbsurveyitemModel>(sql, typeof(CrmPbsurveyitemModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(CrmPbsurveyitemData), false);
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
        public bool Execute(CrmPbsurveyitemModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<CrmPbsurveyitemData> db = new ORMDataAccess<CrmPbsurveyitemData>())
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
