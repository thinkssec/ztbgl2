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
    /// �ļ���:  BfInstancerolesData.cs
    /// ��������: ���ݲ�-ҵ����ʵ����ɫ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:54
    /// </summary>
    public class BfInstancerolesData : IBfInstancerolesData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfInstancerolesData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfInstancerolesModel> GetList()
        {
            IList<BfInstancerolesModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfInstancerolesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfInstancerolesData> db = new ORMDataAccess<BfInstancerolesData>())
                {
                    list = db.Query<BfInstancerolesModel>("from BfInstancerolesModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfInstancerolesData), true);
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
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfInstancerolesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfInstancerolesData> db = new ORMDataAccess<BfInstancerolesData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    //ͬһ�ڵ��еĽ�ɫӦ�þ���Ψһ��
                    BfInstancerolesModel roleModel = GetListByInstanceId(model.BF_INSTANCEID).
                            Where(p => p.BF_NODEID == model.BF_NODEID &&
                                p.BF_OPERATIONTYPE == model.BF_OPERATIONTYPE &&
                                p.BF_ROLENAME == model.BF_ROLENAME && p.USERIDS == model.USERIDS).FirstOrDefault();
                    if (roleModel == null)
                    {
                        db.Insert(model);
                    }
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

        /// <summary>
        /// ��ȡָ��ҵ����ʵ��ID�µĶ�Ӧ��ɫ���ݼ���
        /// </summary>
        /// <param name="instanceId">ҵ����ʵ��ID</param>
        /// <returns></returns>
        public IList<BfInstancerolesModel> GetListByInstanceId(string instanceId)
        {
            IList<BfInstancerolesModel> list = null;

            using (ORMDataAccess<BfInstancerolesData> db = new ORMDataAccess<BfInstancerolesData>())
            {
                list = db.Query<BfInstancerolesModel>("from BfInstancerolesModel c where c.BF_INSTANCEID='" + instanceId + "'");
            }

            return list;
        }

    }
}
