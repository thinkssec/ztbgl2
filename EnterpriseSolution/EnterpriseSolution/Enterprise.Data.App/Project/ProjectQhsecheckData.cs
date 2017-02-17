using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{

    /// <summary>
    /// �ļ���:  ProjectQhsecheckData.cs
    /// ��������: ���ݲ�-������ȫ�������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/11/26 17:18:03
    /// </summary>
    public class ProjectQhsecheckData : IProjectQhsecheckData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectQhsecheckData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectQhsecheckModel> GetList()
        {
            IList<ProjectQhsecheckModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectQhsecheckModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectQhsecheckData> db = new ORMDataAccess<ProjectQhsecheckData>())
                {
                    list = db.Query<ProjectQhsecheckModel>("from ProjectQhsecheckModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectQhsecheckData), false);
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
        public IList<ProjectQhsecheckModel> GetListByHQL(string hql)
        {
            IList<ProjectQhsecheckModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectQhsecheckModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectQhsecheckData> db = new ORMDataAccess<ProjectQhsecheckData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectQhsecheckModel>("from ProjectQhsecheckModel");
			}
			else
			{
				list = db.Query<ProjectQhsecheckModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectQhsecheckData), false);
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
        public IList<ProjectQhsecheckModel> GetListBySQL(string sql)
        {
            IList<ProjectQhsecheckModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectQhsecheckModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectQhsecheckData> db = new ORMDataAccess<ProjectQhsecheckData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectQhsecheckModel>(sql, typeof(ProjectQhsecheckModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectQhsecheckData), false);
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
        public bool Execute(ProjectQhsecheckModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectQhsecheckData> db = new ORMDataAccess<ProjectQhsecheckData>())
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
