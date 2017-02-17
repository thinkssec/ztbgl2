using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{

    /// <summary>
    /// �ļ���:  CrmFbcontractData.cs
    /// ��������: ���ݲ�-�ְ���ͬ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013/12/11 11:28:01
    /// </summary>
    public class CrmFbcontractData : ICrmFbcontractData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(CrmFbcontractData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbcontractModel> GetList()
        {
            IList<CrmFbcontractModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<CrmFbcontractModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmFbcontractData> db = new ORMDataAccess<CrmFbcontractData>())
                {
                    list = db.Query<CrmFbcontractModel>("from CrmFbcontractModel");
                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(CrmFbcontractData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetList";
                        refreshAction.Parameters = null;//new object[]{};
                        CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
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
        public IList<CrmFbcontractModel> GetListByHQL(string hql)
        {
            IList<CrmFbcontractModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<CrmFbcontractModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmFbcontractData> db = new ORMDataAccess<CrmFbcontractData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<CrmFbcontractModel>("from CrmFbcontractModel");
                    }
                    else
                    {
                        list = db.Query<CrmFbcontractModel>(hql);
                    }

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(CrmFbcontractData), false);
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
        public IList<CrmFbcontractModel> GetListBySQL(string sql)
        {
            IList<CrmFbcontractModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<CrmFbcontractModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmFbcontractData> db = new ORMDataAccess<CrmFbcontractData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<CrmFbcontractModel>(sql, typeof(CrmFbcontractModel));

                        if (WebKeys.EnableCaching)
                        {
                            //���ݴ��뻺��ϵͳ
                            CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(CrmFbcontractData), false);
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
        public bool Execute(CrmFbcontractModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<CrmFbcontractData> db = new ORMDataAccess<CrmFbcontractData>())
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
