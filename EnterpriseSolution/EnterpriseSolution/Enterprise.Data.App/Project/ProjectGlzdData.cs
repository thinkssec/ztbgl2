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
    /// �ļ���:  ProjectGlzdData.cs
    /// ��������: ���ݲ�-��Ŀ�����ƶ����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2014/6/21 17:32:40
    /// </summary>
    public class ProjectGlzdData : IProjectGlzdData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectGlzdData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectGlzdModel> GetList()
        {
            IList<ProjectGlzdModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectGlzdModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectGlzdData> db = new ORMDataAccess<ProjectGlzdData>())
                {
                    list = db.Query<ProjectGlzdModel>("from ProjectGlzdModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectGlzdData), false);
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
        public IList<ProjectGlzdModel> GetListByHQL(string hql)
        {
            IList<ProjectGlzdModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectGlzdModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectGlzdData> db = new ORMDataAccess<ProjectGlzdData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectGlzdModel>("from ProjectGlzdModel");
			}
			else
			{
				list = db.Query<ProjectGlzdModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectGlzdData), false);
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
        public IList<ProjectGlzdModel> GetListBySQL(string sql)
        {
            IList<ProjectGlzdModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectGlzdModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectGlzdData> db = new ORMDataAccess<ProjectGlzdData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectGlzdModel>(sql, typeof(ProjectGlzdModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectGlzdData), false);
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
        public bool Execute(ProjectGlzdModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectGlzdData> db = new ORMDataAccess<ProjectGlzdData>())
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
