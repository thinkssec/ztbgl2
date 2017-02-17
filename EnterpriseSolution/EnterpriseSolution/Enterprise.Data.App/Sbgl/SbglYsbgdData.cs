using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Sbgl;
using System.Data;

namespace Enterprise.Data.App.Sbgl
{

    /// <summary>
    /// �ļ���:  SbglYsbgdData.cs
    /// ��������: ���ݲ�-�豸ά����Ŀ���ձ��浥���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2015/4/30 8:22:37
    /// </summary>
    public class SbglYsbgdData : ISbglYsbgdData
    {

        #region ����������

        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(SbglYsbgdData).ToString();

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglYsbgdModel GetSingle(string key)
        {
            return null;
        }

        /// <summary>
        /// ��ȡ��ѯ���ݼ�
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
            {
                DataSet ds = db.ExecuteDataset(sql);
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetList()
        {
            IList<SbglYsbgdModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglYsbgdModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
                {
                    list = db.Query<SbglYsbgdModel>("from SbglYsbgdModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheHelper.Add(typeof(SbglYsbgdData), false, null, "GetList", null, CacheClassKey + "_GetList", list);
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
        public IList<SbglYsbgdModel> GetListByHQL(string hql)
        {
            IList<SbglYsbgdModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglYsbgdModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SbglYsbgdModel>("from SbglYsbgdModel");
                    }
                    else
                    {
                        list = db.Query<SbglYsbgdModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheHelper.Add(typeof(SbglYsbgdData), false, null, "GetListByHQL", new object[] { hql }, CacheClassKey + "_GetListByHQL_" + hql, list);
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
        public IList<SbglYsbgdModel> GetListBySQL(string sql)
        {
            IList<SbglYsbgdModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<SbglYsbgdModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<SbglYsbgdModel>(sql, typeof(SbglYsbgdModel));

                        //if (WebKeys.EnableCaching)
                        //{
                        ////���ݴ��뻺��ϵͳ
                        //CacheHelper.Add(typeof(SbglYsbgdData), false, null, "GetListBySQL", new object[] { sql }, CacheClassKey + "_GetListBySQL_" + sql, list);		
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
        public bool Execute(SbglYsbgdModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
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

            using (ORMDataAccess<SbglYsbgdData> db = new ORMDataAccess<SbglYsbgdData>())
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
