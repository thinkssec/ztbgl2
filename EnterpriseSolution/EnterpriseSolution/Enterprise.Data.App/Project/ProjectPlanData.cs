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
    /// �ļ���:  ProjectPlanData.cs
    /// ��������: ���ݲ�-��Ŀ�ƻ������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:22
    /// </summary>
    public class ProjectPlanData : IProjectPlanData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectPlanData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectPlanModel> GetList()
        {
            IList<ProjectPlanModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectPlanModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectPlanData> db = new ORMDataAccess<ProjectPlanData>())
                {
                    list = db.Query<ProjectPlanModel>("from ProjectPlanModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectPlanData), false);
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
        public IList<ProjectPlanModel> GetListByHQL(string hql)
        {
            IList<ProjectPlanModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectPlanModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectPlanData> db = new ORMDataAccess<ProjectPlanData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectPlanModel>("from ProjectPlanModel");
			}
			else
			{
				list = db.Query<ProjectPlanModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectPlanData), false);
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
        public bool Execute(ProjectPlanModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectPlanData> db = new ORMDataAccess<ProjectPlanData>())
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
                

        #region IProjectPlanData ��Ա
        /// <summary>
        /// ����һ���յ���Ŀ�ƻ�
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="ProjectId"></param>
        public void CreatePlan(string planId, string ProjectId)
        {        
            
            using (ORMDataAccess<ProjectPlanData> db = new ORMDataAccess<ProjectPlanData>())
            {
                string sql = "begin ";
                //�����յ���Ŀ�ƻ�
                sql += string.Format("Insert into app_project_plan(PLANID,PROJID,projsurvey) values ('{0}','{1}','{2}');",
                    planId,
                    ProjectId,
                    "��û�мƻ�");
                //�����յĽڵ�ƻ�
                System.Data.DataSet ds = db.ExecuteDataset("select itemcode from app_examine_costitem",null);
                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    sql += string.Format("Insert into app_project_costplan(ITEMCODE,PLANID,Amount)values('{0}','{1}',0);", 
                        dr[0].ToRequestString(), 
                        planId);
                }
                sql += "null;end;";
                using (ORMDataAccess<ProjectPlanData> db2 = new ORMDataAccess<ProjectPlanData>())
                {
                    db2.ExecuteNonQuery(sql, null);
                }
            }
        }

        /// <summary>
        /// �ؽ��ռƻ� ����
        /// </summary>
        /// <param name="planId"></param>
        /// <param name="ProjectId"></param>
        public void RebuildEmptyPlan(string planId, string ProjectId)
        {
            
        }

        #endregion
    }
}
