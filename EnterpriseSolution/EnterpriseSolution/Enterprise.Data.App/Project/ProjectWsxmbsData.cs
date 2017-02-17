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
    /// �ļ���:  ProjectWsxmbsData.cs
    /// ��������: ���ݲ�-��Ŀ��������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:25
    /// </summary>
    public class ProjectWsxmbsData : IProjectWsxmbsData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectWsxmbsData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectWsxmbsModel> GetList()
        {
            IList<ProjectWsxmbsModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectWsxmbsModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectWsxmbsData> db = new ORMDataAccess<ProjectWsxmbsData>())
                {
                    list = db.Query<ProjectWsxmbsModel>("from ProjectWsxmbsModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectWsxmbsData), false);
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
        public IList<ProjectWsxmbsModel> GetListByHQL(string hql)
        {
            IList<ProjectWsxmbsModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectWsxmbsModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectWsxmbsData> db = new ORMDataAccess<ProjectWsxmbsData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectWsxmbsModel>("from ProjectWsxmbsModel");
			}
			else
			{
				list = db.Query<ProjectWsxmbsModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectWsxmbsData), false);
	                    //refreshAction.ConstuctParms = null;
	                    //refreshAction.MethodName = "GetList";
	                    //refreshAction.Parameters = new object[]{ hql };
	                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
			    //}
                }
            }
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectWsxmbsModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectWsxmbsData> db = new ORMDataAccess<ProjectWsxmbsData>())
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
