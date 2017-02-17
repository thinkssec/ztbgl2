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
    /// �ļ���:  ProjectFztzlviewData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/1/21 8:41:38
    /// </summary>
    public class ProjectFztzlviewData : IProjectFztzlviewData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectFztzlviewData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectFztzlviewModel> GetList()
        {
            IList<ProjectFztzlviewModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectFztzlviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFztzlviewData> db = new ORMDataAccess<ProjectFztzlviewData>())
                {
                    list = db.Query<ProjectFztzlviewModel>("from ProjectFztzlviewModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ProjectFztzlviewData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<ProjectFztzlviewModel> GetListByHQL(string hql)
        {
            IList<ProjectFztzlviewModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectFztzlviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFztzlviewData> db = new ORMDataAccess<ProjectFztzlviewData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectFztzlviewModel>("from ProjectFztzlviewModel");
                    }
                    else
                    {
                        list = db.Query<ProjectFztzlviewModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectFztzlviewData), false);
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
        public IList<ProjectFztzlviewModel> GetListBySQL(string sql)
        {
            IList<ProjectFztzlviewModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectFztzlviewModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectFztzlviewData> db = new ORMDataAccess<ProjectFztzlviewData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectFztzlviewModel>(sql, typeof(ProjectFztzlviewModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectFztzlviewData), false);
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
        public bool Execute(ProjectFztzlviewModel model)
        {
            bool isResult = true;

            //��ͼ����Ҫ
            //using (ORMDataAccess<ProjectFztzlviewData> db = new ORMDataAccess<ProjectFztzlviewData>())
            //{
            //    if (model.DB_Option_Action == WebKeys.InsertAction)
            //    {
            //        db.Insert(model);
            //    }
            //    else if (model.DB_Option_Action == WebKeys.UpdateAction)
            //    {
            //        db.Update(model);
            //    }
            //    else if (model.DB_Option_Action == WebKeys.DeleteAction)
            //    {
            //        db.Delete(model);
            //    }
            //}

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
