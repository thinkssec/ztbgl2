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
    /// �ļ���:  ProjectRunninganalyzeviewData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013/12/4 17:33:32
    /// </summary>
    public class ProjectRunninganalyzeviewData : IProjectRunninganalyzeviewData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectRunninganalyzeviewData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectRunninganalyzeviewModel> GetList()
        {
            IList<ProjectRunninganalyzeviewModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectRunninganalyzeviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRunninganalyzeviewData> db = new ORMDataAccess<ProjectRunninganalyzeviewData>())
                {
                    list = db.Query<ProjectRunninganalyzeviewModel>("from ProjectRunninganalyzeviewModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectRunninganalyzeviewData), false);
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
        public IList<ProjectRunninganalyzeviewModel> GetListByHQL(string hql)
        {
            IList<ProjectRunninganalyzeviewModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectRunninganalyzeviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRunninganalyzeviewData> db = new ORMDataAccess<ProjectRunninganalyzeviewData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectRunninganalyzeviewModel>("from ProjectRunninganalyzeviewModel");
                    }
                    else
                    {
                        list = db.Query<ProjectRunninganalyzeviewModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectRunninganalyzeviewData), false);
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
        public IList<ProjectRunninganalyzeviewModel> GetListBySQL(string sql)
        {
            IList<ProjectRunninganalyzeviewModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectRunninganalyzeviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRunninganalyzeviewData> db = new ORMDataAccess<ProjectRunninganalyzeviewData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectRunninganalyzeviewModel>(sql, typeof(ProjectRunninganalyzeviewModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectRunninganalyzeviewData), false);
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
        public bool Execute(ProjectRunninganalyzeviewModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectRunninganalyzeviewData> db = new ORMDataAccess<ProjectRunninganalyzeviewData>())
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
