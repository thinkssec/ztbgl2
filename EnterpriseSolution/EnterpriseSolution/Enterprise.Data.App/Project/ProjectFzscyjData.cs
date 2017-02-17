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
    /// �ļ���:  ProjectFzscyjData.cs
    /// ��������: ���ݲ�-������������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/12/1 14:10:56
    /// </summary>
    public class ProjectFzscyjData : IProjectFzscyjData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectFzscyjData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectFzscyjModel> GetList()
        {
            IList<ProjectFzscyjModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectFzscyjModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFzscyjData> db = new ORMDataAccess<ProjectFzscyjData>())
                {
                    list = db.Query<ProjectFzscyjModel>("from ProjectFzscyjModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectFzscyjData), false);
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
        public IList<ProjectFzscyjModel> GetListByHQL(string hql)
        {
            IList<ProjectFzscyjModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectFzscyjModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFzscyjData> db = new ORMDataAccess<ProjectFzscyjData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectFzscyjModel>("from ProjectFzscyjModel");
			}
			else
			{
				list = db.Query<ProjectFzscyjModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectFzscyjData), false);
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
        public IList<ProjectFzscyjModel> GetListBySQL(string sql)
        {
            IList<ProjectFzscyjModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectFzscyjModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFzscyjData> db = new ORMDataAccess<ProjectFzscyjData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectFzscyjModel>(sql, typeof(ProjectFzscyjModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectFzscyjData), false);
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
        public bool Execute(ProjectFzscyjModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectFzscyjData> db = new ORMDataAccess<ProjectFzscyjData>())
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
