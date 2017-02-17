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
    /// �ļ���:  ProjectIncomeData.cs
    /// ��������: ���ݲ�-��Ŀ��ͬ�������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-5 15:48:20
    /// </summary>
    public class ProjectIncomeData : IProjectIncomeData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectIncomeData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectIncomeModel> GetList()
        {
            IList<ProjectIncomeModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectIncomeModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectIncomeData> db = new ORMDataAccess<ProjectIncomeData>())
                {
                    list = db.Query<ProjectIncomeModel>("from ProjectIncomeModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectIncomeData), false);
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
        public IList<ProjectIncomeModel> GetListByHQL(string hql)
        {
            IList<ProjectIncomeModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectIncomeModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectIncomeData> db = new ORMDataAccess<ProjectIncomeData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectIncomeModel>("from ProjectIncomeModel");
                    }
                    else
                    {
                        list = db.Query<ProjectIncomeModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ProjectIncomeData), false);
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
        public bool Execute(ProjectIncomeModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectIncomeData> db = new ORMDataAccess<ProjectIncomeData>())
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
                CacheHelper.RemoveCacheForClassKey(ProjectContractData.CacheClassKey);//��ͬ��Ҳһ�����
                CacheHelper.RemoveCacheForClassKey(ProjectDailyviewData.CacheClassKey);//��ֵͳ��
            }
            return isResult;
        }

        #endregion
    }
}
