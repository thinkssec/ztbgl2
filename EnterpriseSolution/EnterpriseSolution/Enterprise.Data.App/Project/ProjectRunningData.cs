using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Project;
using System.Data;

namespace Enterprise.Data.App.Project
{

    /// <summary>
    /// �ļ���:  ProjectRunningData.cs
    /// ��������: ���ݲ�-��Ŀ�ڵ�ƻ������б����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-5 15:48:23
    /// </summary>
    public class ProjectRunningData : IProjectRunningData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectRunningData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectRunningModel> GetList()
        {
            IList<ProjectRunningModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ProjectRunningModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRunningData> db = new ORMDataAccess<ProjectRunningData>())
                {
                    list = db.Query<ProjectRunningModel>("from ProjectRunningModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ProjectRunningData), false);
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
        public IList<ProjectRunningModel> GetListByHQL(string hql)
        {
            IList<ProjectRunningModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ProjectRunningModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectRunningData> db = new ORMDataAccess<ProjectRunningData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ProjectRunningModel>("from ProjectRunningModel");
                    }
                    else
                    {
                        list = db.Query<ProjectRunningModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ProjectRunningData), false);
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
        public bool Execute(ProjectRunningModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectRunningData> db = new ORMDataAccess<ProjectRunningData>())
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
                else if (model.DB_Option_Action == WebKeys.InsertOrUpdateAction)
                {
                    db.InsertOrUpdate(model);
                }
            }

            if (WebKeys.EnableCaching)
            {
                //�����صĻ���
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
            }
            return isResult;
        }


        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteLst(IList<ProjectRunningModel> models)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectRunningData> db = new ORMDataAccess<ProjectRunningData>())
            {
                foreach (ProjectRunningModel model in models)
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
                    else if (model.DB_Option_Action == WebKeys.InsertOrUpdateAction)
                    {
                        db.InsertOrUpdate(model);
                    }
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

        #region IProjectRunningData ��Ա
        
        /// <summary>
        /// ��ȡ�������Ϳؼ��Ľű�
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public string GetRunningEasyuiTreeHtmlById(string projectId)
        {
            string jsonStr = string.Empty;
            
            if (WebKeys.EnableCaching)
            {
                jsonStr = (string)CacheHelper.GetCache(CacheClassKey + "_GetRunningEasyuiTreeHtmlById_" + projectId);
            }

            if (string.IsNullOrEmpty(jsonStr))
            {
                using (ORMDataAccess<ProjectRunningData> db = new ORMDataAccess<ProjectRunningData>())
                {
                    string sql = string.Format(
                        "select t.nodebh,t.nodename,decode(instr(b.nodepath,'?'),0,b.nodepath || '?ProjectId={0}&NodeCode=' || b.nodecode,null,'',b.nodepath || '&ProjectId={0}&NodeCode=' || b.nodecode) as nodepath,"
                        + "nvl(substr(t.nodebh,0,length(t.nodebh)-2),'00') as ParentID,t.keynode,t.runstatus  from app_project_running t ,app_examine_nodes b "
                        + " where t.projid='{0}' and t.nodecode=b.nodecode order by t.nodebh", projectId);
                    DataSet ds = db.ExecuteDataset(sql, null);
                    jsonStr = ds.Tables[0].ToJsonForTree("nodebh", "nodename", "parentid", "00", "nodepath", "");
                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction = new CacheItemRefreshAction(typeof(ProjectRunningData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetRunningEasyuiTreeHtmlById";
                        refreshAction.Parameters = new object[] { projectId };
                        CacheHelper.Add(CacheClassKey + "_GetRunningEasyuiTreeHtmlById_" + projectId, jsonStr, refreshAction);
                    }                    
                }
            }

            return jsonStr;
        }

        #endregion
    }
}
