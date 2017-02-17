using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Bf;
using Enterprise.Component.Cache;

namespace Enterprise.Data.Basis.Bf
{

    /// <summary>
    /// �ļ���:  BfUnhandledmsgData.cs
    /// ��������: ���ݲ�-ҵ����δ������Ϣ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:58
    /// </summary>
    public class BfUnhandledmsgData : IBfUnhandledmsgData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfUnhandledmsgData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfUnhandledmsgModel> GetList()
        {
            IList<BfUnhandledmsgModel> list = null;


            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfUnhandledmsgData> db = new ORMDataAccess<BfUnhandledmsgData>())
                {
                    list = db.Query<BfUnhandledmsgModel>("from BfUnhandledmsgModel p where p.BF_ISREAD='0'");
                }
            }
            return list;
        }


        /// <summary>
        /// ��ȡ�����ѯ���������ݼ���
        /// </summary>
        /// <param name="hql">Hibernate��ѯ���</param>
        /// <returns></returns>
        public IList<BfUnhandledmsgModel> GetListByHQL(string hql)
        {
            IList<BfUnhandledmsgModel> list = null;

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfUnhandledmsgData> db = new ORMDataAccess<BfUnhandledmsgData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<BfUnhandledmsgModel>("from BfUnhandledmsgModel p where p.BF_ISREAD='0'");
                    }
                    else
                    {
                        list = db.Query<BfUnhandledmsgModel>(hql);
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
        public bool Execute(BfUnhandledmsgModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfUnhandledmsgData> db = new ORMDataAccess<BfUnhandledmsgData>())
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
                else if (model.DB_Option_Action == "DeleteByInstaceId")
                {
                    var query = GetListByHQL("from BfUnhandledmsgModel p where p.BF_INSTANCEID='" + model.BF_INSTANCEID + "'");
                    foreach (var q in query)
                    {
                        db.Delete(q);
                    }
                }
            }

            if (WebKeys.EnableCaching)
            {
                //�����صĻ���
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
            }

            return isResult;
        }


        /// <summary>
        ///  ����IDֵ��ȡΨһ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BfUnhandledmsgModel GetModelById(string id)
        {
            return GetListByHQL("from BfUnhandledmsgModel p where p.BF_MSGID='" + id + "'").FirstOrDefault();
        }

    }
}
