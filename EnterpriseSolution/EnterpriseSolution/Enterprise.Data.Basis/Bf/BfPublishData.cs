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
    /// �ļ���:  BfPublishData.cs
    /// ��������: ���ݲ�-ҵ�������������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:57
    /// </summary>
    public class BfPublishData : IBfPublishData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfPublishData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfPublishModel> GetList()
        {
            IList<BfPublishModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfPublishModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfPublishData> db = new ORMDataAccess<BfPublishData>())
                {
                    list = db.Query<BfPublishModel>("from BfPublishModel");
                    
                    //���ݴ��뻺��ϵͳ
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BfPublishData), false);
                    refreshAction.ConstuctParms = null;
                    refreshAction.MethodName = "GetList";
                    refreshAction.Parameters = null;//new object[]{};
                    CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfPublishModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfPublishData> db = new ORMDataAccess<BfPublishData>())
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
                else if (model.DB_Option_Action == "DeleteByBF_ID")
                {
                    List<BfPublishModel> delList = GetList().Where(p => p.BF_ID == model.BF_ID).ToList();
                    foreach (BfPublishModel delM in delList)
                    {
                        db.Delete(delM);
                    }
                }
            }

            if (WebKeys.EnableCaching)
            {
                //�����صĻ���
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
                CacheHelper.RemoveCacheForClassKey(BfNodesData.cacheClassKey);
            }

            return isResult;
        }

    }
}
