using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Meeting;

namespace Enterprise.Data.Common.Meeting
{

    /// <summary>
    /// �ļ���:  MeetingRecevieData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/1 15:50:38
    /// </summary>
    public class MeetingRecevieData : IMeetingRecevieData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(MeetingRecevieData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetList()
        {
            IList<MeetingRecevieModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<MeetingRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<MeetingRecevieData> db = new ORMDataAccess<MeetingRecevieData>())
                {
                    list = db.Query<MeetingRecevieModel>("from MeetingRecevieModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(MeetingRecevieData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                    }
                }
            }
            return list;
        }


        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <param name="hql">Nhibernate HQL,���hqlΪ�� ������������</param>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetListByHQL(string hql)
        {
            IList<MeetingRecevieModel> list = null;

            if (WebKeys.EnableCaching)
            {
                list = (IList<MeetingRecevieModel>)CacheHelper.GetCache(cacheClassKey + "_GetListByHQL_" + hql);
            }
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<MeetingRecevieData> db = new ORMDataAccess<MeetingRecevieData>())
                {
                    if (hql == "")
                    {
                        list = db.Query<MeetingRecevieModel>("from MeetingRecevieModel");
                    }
                    else
                    {
                        list = db.Query<MeetingRecevieModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(MeetingRecevieData), true);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetListByHQL";
                        refreshAction.Parameters = new object[] { hql };
                        CacheHelper.Add(cacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    }
                }
            }

            return list;
        }


        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetList(string hql)
        {
            IList<MeetingRecevieModel> list = GetListByHQL(hql);
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(MeetingRecevieModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<MeetingRecevieData> db = new ORMDataAccess<MeetingRecevieData>())
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
    }
}
