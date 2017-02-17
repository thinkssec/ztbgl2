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
    /// �ļ���:  BfFlowpathData.cs
    /// ��������: ���ݲ�-�ڵ���ת�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:52
    /// </summary>
    public class BfFlowpathData : IBfFlowpathData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfFlowpathData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfFlowpathModel> GetList()
        {
            IList<BfFlowpathModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfFlowpathModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfFlowpathData> db = new ORMDataAccess<BfFlowpathData>())
                {
                    list = db.Query<BfFlowpathModel>("from BfFlowpathModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfFlowpathData), false);
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
        public bool Execute(BfFlowpathModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfFlowpathData> db = new ORMDataAccess<BfFlowpathData>())
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
                else if (model.DB_Option_Action == "DeleteByBF_ID_VERSION")
                {
                    IList<BfFlowpathModel> deleteList = GetList().
                        Where(p => p.BF_ID == model.BF_ID && p.BF_VERSION == model.BF_VERSION).ToList();
                    foreach (var q in deleteList)
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

    }
}
