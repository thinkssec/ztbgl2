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
    /// �ļ���:  ProjectRwgzlData.cs
    /// ��������: ���ݲ�-����������������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-5 15:48:24
    /// </summary>
    public class ProjectRwgzlData : IProjectRwgzlData
    {
        #region ����������

        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectRwgzlData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectRwgzlModel> GetList()
        {
            IList<ProjectRwgzlModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectRwgzlModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRwgzlData> db = new ORMDataAccess<ProjectRwgzlData>())
                {
                    list = db.Query<ProjectRwgzlModel>("from ProjectRwgzlModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectRwgzlData), false);
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
        public IList<ProjectRwgzlModel> GetListByHQL(string hql)
        {
            IList<ProjectRwgzlModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectRwgzlModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRwgzlData> db = new ORMDataAccess<ProjectRwgzlData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectRwgzlModel>("from ProjectRwgzlModel");
                    }
                    else
                    {
                        list = db.Query<ProjectRwgzlModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectRwgzlData), false);
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
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectRwgzlModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectRwgzlData> db = new ORMDataAccess<ProjectRwgzlData>())
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
                //��������ڵ����б�Ļ���
                CacheHelper.RemoveCacheForClassKey(ProjectRunningData.CacheClassKey);
                //�������߻��Ļ���
                CacheHelper.RemoveCacheForClassKey(ProjectRwchData.CacheClassKey);
            }
            return isResult;
        }

        #endregion
    }
}
