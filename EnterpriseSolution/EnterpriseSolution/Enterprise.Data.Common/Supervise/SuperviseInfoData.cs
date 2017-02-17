using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Supervise;
using System.Data;

namespace Enterprise.Data.Common.Supervise
{

    /// <summary>
    /// �ļ���:  SuperviseInfoData.cs
    /// ��������: ���ݲ�-������������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/13 10:53:09
    /// </summary>
    public class SuperviseInfoData : ISuperviseInfoData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SuperviseInfoData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseInfoModel> GetList()
        {
            IList<SuperviseInfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<SuperviseInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SuperviseInfoData> db = new ORMDataAccess<SuperviseInfoData>())
                {
                    list = db.Query<SuperviseInfoModel>("from SuperviseInfoModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(SuperviseInfoData), false);
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
        public IList<SuperviseInfoModel> GetList(string hql)
        {
            IList<SuperviseInfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<SuperviseInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SuperviseInfoData> db = new ORMDataAccess<SuperviseInfoData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<SuperviseInfoModel>("from SuperviseInfoModel");
			}
			else
			{
				list = db.Query<SuperviseInfoModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(SuperviseInfoData), false);
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
        public bool Execute(SuperviseInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SuperviseInfoData> db = new ORMDataAccess<SuperviseInfoData>())
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
        /// ɾ��һ���������� ��ͬ������ϸ ������Ϣ
        /// </summary>
        /// <param name="dbid"></param>
        public void Delete(string dbid)
        {
            using (ORMDataAccess<SuperviseInfoData> db = new ORMDataAccess<SuperviseInfoData>())
            {
                string sql = "begin delete from common_supervise_info where dbid='"+dbid+"';";
                sql += "delete from basis_bf_unhandledmsg where bf_instanceid='"+dbid+"';";
                sql += "delete from common_supervise_process where dbid='"+dbid+"';end;";
                db.ExecuteNonQuery(sql, null);
            }
        }
    }
}
