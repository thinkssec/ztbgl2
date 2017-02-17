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
    /// �ļ���:  ProjectMemberData.cs
    /// ��������: ���ݲ�-��Ŀ���Ա�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-5 15:48:21
    /// </summary>
    public class ProjectMemberData : IProjectMemberData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectMemberData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectMemberModel> GetList()
        {
            IList<ProjectMemberModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectMemberModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectMemberData> db = new ORMDataAccess<ProjectMemberData>())
                {
                    list = db.Query<ProjectMemberModel>("from ProjectMemberModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectMemberData), false);
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
        public IList<ProjectMemberModel> GetListByHQL(string hql)
        {
            IList<ProjectMemberModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectMemberModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectMemberData> db = new ORMDataAccess<ProjectMemberData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectMemberModel>("from ProjectMemberModel");
                    }
                    else
                    {
                        list = db.Query<ProjectMemberModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(ProjectMemberData), false);
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
        public bool Execute(ProjectMemberModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectMemberData> db = new ORMDataAccess<ProjectMemberData>())
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
                ///new by zy 2014/5/16�����Ŀ�����˱����ʱ��ҳ�滺������� start
                //�����صĻ���
                CacheHelper.RemoveCacheForClassKey(ProjectMemberData.CacheClassKey);
                CacheHelper.RemoveCacheForClassKey(ProjectOrderData.CacheClassKey);
                CacheHelper.RemoveCacheForClassKey(ProjectInfoData.CacheClassKey);
                
                ///end
            }
            return isResult;
        }

        #endregion
    }
}
