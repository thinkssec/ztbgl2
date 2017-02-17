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
    /// �ļ���:  CrmFbhtjeData.cs
    /// ��������: ���ݲ�-��Ŀ�ְ���ͬ�������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013/12/11 11:28:02
    /// </summary>
    public class CrmFbhtjeData : ICrmFbhtjeData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(CrmFbhtjeData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbhtjeModel> GetList()
        {
            IList<CrmFbhtjeModel> list = null;

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmFbhtjeData> db = new ORMDataAccess<CrmFbhtjeData>())
                {
                    list = db.Query<CrmFbhtjeModel>("from CrmFbhtjeModel");
                }
            }
            return list;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<CrmFbhtjeModel> GetListByHQL(string hql)
        {
            IList<CrmFbhtjeModel> list = null;

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmFbhtjeData> db = new ORMDataAccess<CrmFbhtjeData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<CrmFbhtjeModel>("from CrmFbhtjeModel");
                    }
                    else
                    {
                        list = db.Query<CrmFbhtjeModel>(hql);
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
        public IList<CrmFbhtjeModel> GetListBySQL(string sql)
        {
            IList<CrmFbhtjeModel> list = (IList<CrmFbhtjeModel>)CacheHelper.GetCache(CacheClassKey + "_GetListBySQL_" + sql);
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<CrmFbhtjeData> db = new ORMDataAccess<CrmFbhtjeData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<CrmFbhtjeModel>(sql, typeof(CrmFbhtjeModel));
                        CacheHelper.Add(typeof(CrmFbhtjeData), false, null, "GetListBySQL",
                            new object[] { sql }, (CacheClassKey + "_GetListBySQL_" + sql), list);
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
        public bool Execute(CrmFbhtjeModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<CrmFbhtjeData> db = new ORMDataAccess<CrmFbhtjeData>())
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

            //�����صĻ���
            CacheHelper.RemoveCacheForClassKey(CacheClassKey);

            return isResult;
        }

        #endregion
    }
}
