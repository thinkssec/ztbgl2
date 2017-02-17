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
    /// �ļ���:  ProjectCarData.cs
    /// ��������: ���ݲ�-��Ŀ���������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/6/19 15:35:13
    /// </summary>
    public class ProjectCarData : IProjectCarData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectCarData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCarModel> GetList()
        {
            IList<ProjectCarModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectCarModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectCarData> db = new ORMDataAccess<ProjectCarData>())
                {
                    list = db.Query<ProjectCarModel>("from ProjectCarModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectCarData), false);
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
        public IList<ProjectCarModel> GetListByHQL(string hql)
        {
            IList<ProjectCarModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectCarModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectCarData> db = new ORMDataAccess<ProjectCarData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectCarModel>("from ProjectCarModel");
                    }
                    else
                    {
                        list = db.Query<ProjectCarModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ProjectCarData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetListByHQL";
                        refreshAction.Parameters = new object[] { hql };
                        CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectCarModel> GetListBySQL(string sql)
        {
            IList<ProjectCarModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectCarModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectCarData> db = new ORMDataAccess<ProjectCarData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectCarModel>(sql, typeof(ProjectCarModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectCarData), false);
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
        public bool Execute(ProjectCarModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectCarData> db = new ORMDataAccess<ProjectCarData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(model);
                }
                else if (model.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(model);
                }
                else if (model.DB_Option_Action == WebKeys.InsertOrUpdateAction)
                {
                    db.InsertOrUpdate(model);
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
