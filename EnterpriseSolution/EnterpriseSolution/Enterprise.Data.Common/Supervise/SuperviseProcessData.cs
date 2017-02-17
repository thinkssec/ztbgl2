using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Supervise;

namespace Enterprise.Data.Common.Supervise
{

    /// <summary>
    /// �ļ���:  SuperviseProcessData.cs
    /// ��������: ���ݲ�-����������ȼ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/13 10:53:10
    /// </summary>
    public class SuperviseProcessData : ISuperviseProcessData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SuperviseProcessData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseProcessModel> GetList()
        {
            IList<SuperviseProcessModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<SuperviseProcessModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
                {
                    list = db.Query<SuperviseProcessModel>("from SuperviseProcessModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(SuperviseProcessData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
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
        public IList<SuperviseProcessModel> GetList(string hql)
        {
            IList<SuperviseProcessModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SuperviseProcessModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SuperviseProcessModel>("from SuperviseProcessModel");
                    }
                    else
                    {
                        list = db.Query<SuperviseProcessModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(SuperviseProcessData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = new object[]{ hql };
                    //CacheHelper.Add(cacheClassKey + "_GetList_" + hql, list, refreshAction);
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
        public bool Execute(SuperviseProcessModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
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
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
            }

            return isResult;
        }

        #endregion

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="dbId"></param>
        public void DeleteJobs(string dbId)
        {
            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
            {
                db.DeleteByQuery("from SuperviseProcessModel where DBID='" + dbId + "'");
            }
        }

        /// <summary>
        /// ��ȡ�������
        /// </summary>
        /// <param name="dbId"></param>
        public decimal GetProcess(string dbId,string yqsbsj)
        {
            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
            {
                IList<SuperviseProcessModel> list = GetList("from SuperviseProcessModel where DBID='"+dbId+"' and YQSBSJ='"+yqsbsj+"'");
                //ȡ��Ա�ϱ������ֵ��ƽ��ֵ     
                if (list.Count > 0)
                    return list.Select(s => s.DQJD).Average();
                else
                    return 0;
            }
        }

        /// <summary>
        /// ��ȡ�ҵ�ID�嵥
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetMyIdList(int userId)
        {
            List<string> list = new List<string>();
            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
            {
                string sql = "select distinct(t.dbid) as dbid from common_supervise_process t where t.blrid='" + userId+"'";          
                System.Data.DataSet ds =  db.ExecuteDataset(sql, null);
                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr[0].ToString());
                }
            }
            return list;
        }


        public List<string> GetMyChargeList(int userId)
        {
             List<string> list = new List<string>();
            using (ORMDataAccess<SuperviseProcessData> db = new ORMDataAccess<SuperviseProcessData>())
            {
                string sql = "select dbid from common_supervise_info where fzld=" + userId;           
                System.Data.DataSet ds =  db.ExecuteDataset(sql, null);
                foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(dr[0].ToString());
                }
            }
            return list;
            
        }
    }
}
