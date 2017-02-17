using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Data.Basis.Sys
{

    /// <summary>
    /// �ļ���:  SysCacherelationData.cs
    /// ��������: ���ݲ�-���������ϵ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2015/3/17 14:20:12
    /// </summary>
    public class SysCacherelationData : ISysCacherelationData
    {

        #region ����������

        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(SysCacherelationData).ToString();

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SysCacherelationModel GetSingle(string key)
        {
            return null;
        }

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SysCacherelationModel> GetList()
        {
            IList<SysCacherelationModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysCacherelationModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysCacherelationData> db = new ORMDataAccess<SysCacherelationData>())
                {
                    list = db.Query<SysCacherelationModel>("from SysCacherelationModel p order by p.CACHENAME");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheHelper.Add(typeof(SysCacherelationData), false, null, "GetList", null, CacheClassKey + "_GetList", list);
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
        public IList<SysCacherelationModel> GetListByHQL(string hql)
        {
            IList<SysCacherelationModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SysCacherelationModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysCacherelationData> db = new ORMDataAccess<SysCacherelationData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SysCacherelationModel>("from SysCacherelationModel");
                    }
                    else
                    {
                        list = db.Query<SysCacherelationModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheHelper.Add(typeof(SysCacherelationData), false, null, "GetListByHQL", new object[] { hql }, CacheClassKey + "_GetListByHQL_" + hql, list);
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
        public IList<SysCacherelationModel> GetListBySQL(string sql)
        {
            IList<SysCacherelationModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<SysCacherelationModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysCacherelationData> db = new ORMDataAccess<SysCacherelationData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<SysCacherelationModel>(sql, typeof(SysCacherelationModel));

                        //if (WebKeys.EnableCaching)
                        //{
                        ////���ݴ��뻺��ϵͳ
                        //CacheHelper.Add(typeof(SysCacherelationData), false, null, "GetListBySQL", new object[] { sql }, CacheClassKey + "_GetListBySQL_" + sql, list);		
                        //}
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
        public bool Execute(SysCacherelationModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SysCacherelationData> db = new ORMDataAccess<SysCacherelationData>())
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

        /// <summary>
        /// ִ�л���SQL��ԭ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSQL(string sql)
        {
            bool isResult = true;

            using (ORMDataAccess<SysCacherelationData> db = new ORMDataAccess<SysCacherelationData>())
            {
                isResult = db.ExecuteNonQuery(sql);
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
