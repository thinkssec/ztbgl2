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
    /// �ļ���:  BfInstancesData.cs
    /// ��������: ���ݲ�-ҵ����ʵ�������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:55
    /// </summary>
    public class BfInstancesData : IBfInstancesData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfInstancesData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfInstancesModel> GetList()
        {
            IList<BfInstancesModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfInstancesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfInstancesData> db = new ORMDataAccess<BfInstancesData>())
                {
                    list = db.Query<BfInstancesModel>("from BfInstancesModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfInstancesData), true);
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
        /// ����ID��ȡ��Ӧ����
        /// </summary>
        /// <param name="instanceId"></param>
        /// <returns></returns>
        public BfInstancesModel GetModelById(string instanceId)
        {
            BfInstancesModel model = null;

            using (ORMDataAccess<BfInstancesData> db = new ORMDataAccess<BfInstancesData>())
            {
                model = db.Query<BfInstancesModel>("from BfInstancesModel p where p.BF_INSTANCEID='" 
                    + instanceId + "'").FirstOrDefault();
            }

            return model;
        }


        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfInstancesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfInstancesData> db = new ORMDataAccess<BfInstancesData>())
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

    }
}
