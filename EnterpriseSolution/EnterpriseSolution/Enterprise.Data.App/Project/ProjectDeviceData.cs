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
    /// �ļ���:  ProjectDeviceData.cs
    /// ��������: ���ݲ�-��Ŀ�豸�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/6/19 15:35:20
    /// </summary>
    public class ProjectDeviceData : IProjectDeviceData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectDeviceData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectDeviceModel> GetList()
        {
            IList<ProjectDeviceModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectDeviceModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectDeviceData> db = new ORMDataAccess<ProjectDeviceData>())
                {
                    list = db.Query<ProjectDeviceModel>("from ProjectDeviceModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectDeviceData), false);
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
        public IList<ProjectDeviceModel> GetListByHQL(string hql)
        {
            IList<ProjectDeviceModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectDeviceModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectDeviceData> db = new ORMDataAccess<ProjectDeviceData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectDeviceModel>("from ProjectDeviceModel");
                    }
                    else
                    {
                        list = db.Query<ProjectDeviceModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectDeviceData), false);
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
        public IList<ProjectDeviceModel> GetListBySQL(string sql)
        {
            IList<ProjectDeviceModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectDeviceModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectDeviceData> db = new ORMDataAccess<ProjectDeviceData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectDeviceModel>(sql, typeof(ProjectDeviceModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectDeviceData), false);
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
        public bool Execute(ProjectDeviceModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectDeviceData> db = new ORMDataAccess<ProjectDeviceData>())
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
