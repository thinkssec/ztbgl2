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
    /// �ļ���:  SbglTzData.cs
    /// ��������: ���ݲ�-�豸����̨�˱����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2015/4/28 15:01:25
    /// </summary>
    public class SbglTzData : ISbglTzData
    {

        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(SbglTzData).ToString();

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglTzModel GetSingle(string key)
        {
            return null;
        }

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglTzModel> GetList()
        {
            IList<SbglTzModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglTzModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglTzData> db = new ORMDataAccess<SbglTzData>())
                {
                    list = db.Query<SbglTzModel>("from SbglTzModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheHelper.Add(typeof(SbglTzData), false, null, "GetList", null, CacheClassKey + "_GetList", list);
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
        public IList<SbglTzModel> GetListByHQL(string hql)
        {
            IList<SbglTzModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<SbglTzModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglTzData> db = new ORMDataAccess<SbglTzData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<SbglTzModel>("from SbglTzModel");
                    }
                    else
                    {
                        list = db.Query<SbglTzModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheHelper.Add(typeof(SbglTzData), false, null, "GetListByHQL", new object[] { hql }, CacheClassKey + "_GetListByHQL_" + hql, list);
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
        public IList<SbglTzModel> GetListBySQL(string sql)
        {
            IList<SbglTzModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SbglTzModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SbglTzData> db = new ORMDataAccess<SbglTzData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<SbglTzModel>(sql, typeof(SbglTzModel));

                        //if (WebKeys.EnableCaching)
                        //{
                        ////���ݴ��뻺��ϵͳ
                        //CacheHelper.Add(typeof(SbglTzData), false, null, "GetListBySQL", new object[] { sql }, CacheClassKey + "_GetListBySQL_" + sql, list);		
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
        public bool Execute(SbglTzModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SbglTzData> db = new ORMDataAccess<SbglTzData>())
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

            using (ORMDataAccess<SbglTzData> db = new ORMDataAccess<SbglTzData>())
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
