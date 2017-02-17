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
    /// �ļ���:  ProjectCostData.cs
    /// ��������: ���ݲ�-���ü�¼�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-5 15:48:16
    /// </summary>
    public class ProjectCostData : IProjectCostData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectCostData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCostModel> GetList()
        {
            IList<ProjectCostModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectCostModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectCostData> db = new ORMDataAccess<ProjectCostData>())
                {
                    list = db.Query<ProjectCostModel>("from ProjectCostModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectCostData), false);
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
        public IList<ProjectCostModel> GetListByHQL(string hql)
        {
            IList<ProjectCostModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectCostModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectCostData> db = new ORMDataAccess<ProjectCostData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectCostModel>("from ProjectCostModel");
                    }
                    else
                    {
                        list = db.Query<ProjectCostModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ProjectCostData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
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
        public bool Execute(ProjectCostModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectCostData> db = new ORMDataAccess<ProjectCostData>())
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
                CacheHelper.RemoveCacheForClassKey(ProjectDailyviewData.CacheClassKey);
            }
            return isResult;
        }

        #endregion
    }
}
