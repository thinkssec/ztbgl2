using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Hr;

namespace Enterprise.Data.App.Hr
{

    /// <summary>
    /// �ļ���:  HrChizhengwpData.cs
    /// ��������: ���ݲ�-��Ƹ��Ա��֤��Ϣ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2014/2/27 17:05:07
    /// </summary>
    public class HrChizhengwpData : IHrChizhengwpData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(HrChizhengwpData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<HrChizhengwpModel> GetList()
        {
            IList<HrChizhengwpModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<HrChizhengwpModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<HrChizhengwpData> db = new ORMDataAccess<HrChizhengwpData>())
                {
                    list = db.Query<HrChizhengwpModel>("from HrChizhengwpModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(HrChizhengwpData), false);
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
        public IList<HrChizhengwpModel> GetListByHQL(string hql)
        {
            IList<HrChizhengwpModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<HrChizhengwpModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<HrChizhengwpData> db = new ORMDataAccess<HrChizhengwpData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<HrChizhengwpModel>("from HrChizhengwpModel");
                    }
                    else
                    {
                        list = db.Query<HrChizhengwpModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(HrChizhengwpData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetListByHQL";
                    //refreshAction.Parameters = new object[]{ hql };
                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    //}
                }
            }
            return list;
        }


        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<HrChizhengwpModel> GetListBySQL(string sql)
        {
            IList<HrChizhengwpModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<HrChizhengwpModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<HrChizhengwpData> db = new ORMDataAccess<HrChizhengwpData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<HrChizhengwpModel>(sql, typeof(HrChizhengwpModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(HrChizhengwpData), false);
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
        public bool Execute(HrChizhengwpModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<HrChizhengwpData> db = new ORMDataAccess<HrChizhengwpData>())
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
