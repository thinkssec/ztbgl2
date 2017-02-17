using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Sbgl;

namespace Enterprise.Data.App.Sbgl
{

    /// <summary>
    /// �ļ���:  SbglWxjhbData.cs
    /// ��������: ���ݲ�-�豸ά�޼ƻ������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2015/4/30 8:22:37
    /// </summary>
    public class SbglWxjhbData : ISbglWxjhbData
    {

        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(SbglWxjhbData).ToString();

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglWxjhbModel GetSingle(string key)
        {
            return null;
        }

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetList()
        {
            IList<SbglWxjhbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglWxjhbModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
                {
                    list = db.Query<SbglWxjhbModel>("from SbglWxjhbModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheHelper.Add(typeof(SbglWxjhbData), false, null, "GetList", null, CacheClassKey + "_GetList", list);
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
        public IList<SbglWxjhbModel> GetListByHQL(string hql)
        {
            IList<SbglWxjhbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglWxjhbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SbglWxjhbModel>("from SbglWxjhbModel");
                    }
                    else
                    {
                        list = db.Query<SbglWxjhbModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheHelper.Add(typeof(SbglWxjhbData), false, null, "GetListByHQL", new object[] { hql }, CacheClassKey + "_GetListByHQL_" + hql, list);
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
        public IList<SbglWxjhbModel> GetListBySQL(string sql)
        {
            IList<SbglWxjhbModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //    list = (IList<SbglWxjhbModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<SbglWxjhbModel>(sql, typeof(SbglWxjhbModel));

                        //if (WebKeys.EnableCaching)
                        //{
                        ////���ݴ��뻺��ϵͳ
                        //CacheHelper.Add(typeof(SbglWxjhbData), false, null, "GetListBySQL", new object[] { sql }, CacheClassKey + "_GetListBySQL_" + sql, list);		
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
        public bool Execute(SbglWxjhbModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
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

            using (ORMDataAccess<SbglWxjhbData> db = new ORMDataAccess<SbglWxjhbData>())
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
