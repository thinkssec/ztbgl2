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
    /// �ļ���:  ProjectZbjgspbData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/7/8 22:25:41
    /// </summary>
    public class ProjectZbjgspbData : IProjectZbjgspbData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectZbjgspbData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZbjgspbModel> GetList()
        {
            IList<ProjectZbjgspbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectZbjgspbModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZbjgspbData> db = new ORMDataAccess<ProjectZbjgspbData>())
                {
                    list = db.Query<ProjectZbjgspbModel>("from ProjectZbjgspbModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectZbjgspbData), false);
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
        public IList<ProjectZbjgspbModel> GetListByHQL(string hql)
        {
            IList<ProjectZbjgspbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectZbjgspbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZbjgspbData> db = new ORMDataAccess<ProjectZbjgspbData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectZbjgspbModel>("from ProjectZbjgspbModel");
			}
			else
			{
				list = db.Query<ProjectZbjgspbModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectZbjgspbData), false);
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
        public IList<ProjectZbjgspbModel> GetListBySQL(string sql)
        {
            IList<ProjectZbjgspbModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectZbjgspbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZbjgspbData> db = new ORMDataAccess<ProjectZbjgspbData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectZbjgspbModel>(sql, typeof(ProjectZbjgspbModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectZbjgspbData), false);
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
        public bool Execute(ProjectZbjgspbModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectZbjgspbData> db = new ORMDataAccess<ProjectZbjgspbData>())
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
