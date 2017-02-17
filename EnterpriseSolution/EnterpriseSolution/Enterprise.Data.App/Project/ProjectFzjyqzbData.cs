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
    /// �ļ���:  ProjectFzjyqzbData.cs
    /// ��������: ���ݲ�-����ǰ׼�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/12/1 14:10:55
    /// </summary>
    public class ProjectFzjyqzbData : IProjectFzjyqzbData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectFzjyqzbData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectFzjyqzbModel> GetList()
        {
            IList<ProjectFzjyqzbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectFzjyqzbModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFzjyqzbData> db = new ORMDataAccess<ProjectFzjyqzbData>())
                {
                    list = db.Query<ProjectFzjyqzbModel>("from ProjectFzjyqzbModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectFzjyqzbData), false);
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
        public IList<ProjectFzjyqzbModel> GetListByHQL(string hql)
        {
            IList<ProjectFzjyqzbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectFzjyqzbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFzjyqzbData> db = new ORMDataAccess<ProjectFzjyqzbData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectFzjyqzbModel>("from ProjectFzjyqzbModel");
			}
			else
			{
				list = db.Query<ProjectFzjyqzbModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectFzjyqzbData), false);
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
        public IList<ProjectFzjyqzbModel> GetListBySQL(string sql)
        {
            IList<ProjectFzjyqzbModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectFzjyqzbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFzjyqzbData> db = new ORMDataAccess<ProjectFzjyqzbData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectFzjyqzbModel>(sql, typeof(ProjectFzjyqzbModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectFzjyqzbData), false);
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
        public bool Execute(ProjectFzjyqzbModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectFzjyqzbData> db = new ORMDataAccess<ProjectFzjyqzbData>())
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
