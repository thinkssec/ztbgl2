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
    /// �ļ���:  ProjectRwchData.cs
    /// ��������: ���ݲ�-����߻������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-5 15:48:24
    /// </summary>
    public class ProjectRwchData : IProjectRwchData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectRwchData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectRwchModel> GetList()
        {
            IList<ProjectRwchModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectRwchModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRwchData> db = new ORMDataAccess<ProjectRwchData>())
                {
                    list = db.Query<ProjectRwchModel>("from ProjectRwchModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectRwchData), false);
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
        public IList<ProjectRwchModel> GetListByHQL(string hql)
        {
            IList<ProjectRwchModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectRwchModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRwchData> db = new ORMDataAccess<ProjectRwchData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectRwchModel>("from ProjectRwchModel");
                    }
                    else
                    {
                        list = db.Query<ProjectRwchModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectRwchData), false);
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
        public bool Execute(ProjectRwchModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectRwchData> db = new ORMDataAccess<ProjectRwchData>())
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
            }
            return isResult;
        }


        /// <summary>
        /// ִ��������ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteLst(IList<ProjectRwchModel> models)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectRwchData> db = new ORMDataAccess<ProjectRwchData>())
            {
                foreach (ProjectRwchModel model in models)
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
            }

            if (WebKeys.EnableCaching)
            {
                //�����صĻ���
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
                //��������ڵ����б�Ļ���
                CacheHelper.RemoveCacheForClassKey(ProjectRunningData.CacheClassKey);
            }
            return isResult;
        }

        #endregion
    }
}
