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
    /// �ļ���:  ProjectZbwjlqdjbData.cs
    /// ��������: ���ݲ�-�б��ļ���ȡ�ǼǱ����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/6/28 0:06:20
    /// </summary>
    public class ProjectZbwjlqdjbData : IProjectZbwjlqdjbData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectZbwjlqdjbData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZbwjlqdjbModel> GetList()
        {
            IList<ProjectZbwjlqdjbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectZbwjlqdjbModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZbwjlqdjbData> db = new ORMDataAccess<ProjectZbwjlqdjbData>())
                {
                    list = db.Query<ProjectZbwjlqdjbModel>("from ProjectZbwjlqdjbModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectZbwjlqdjbData), false);
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
        public IList<ProjectZbwjlqdjbModel> GetListByHQL(string hql)
        {
            IList<ProjectZbwjlqdjbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectZbwjlqdjbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZbwjlqdjbData> db = new ORMDataAccess<ProjectZbwjlqdjbData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectZbwjlqdjbModel>("from ProjectZbwjlqdjbModel");
			}
			else
			{
				list = db.Query<ProjectZbwjlqdjbModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectZbwjlqdjbData), false);
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
        public IList<ProjectZbwjlqdjbModel> GetListBySQL(string sql)
        {
            IList<ProjectZbwjlqdjbModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectZbwjlqdjbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZbwjlqdjbData> db = new ORMDataAccess<ProjectZbwjlqdjbData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectZbwjlqdjbModel>(sql, typeof(ProjectZbwjlqdjbModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectZbwjlqdjbData), false);
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
        public bool Execute(ProjectZbwjlqdjbModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectZbwjlqdjbData> db = new ORMDataAccess<ProjectZbwjlqdjbData>())
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
