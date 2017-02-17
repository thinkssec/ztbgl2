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
    /// �ļ���:  BfBaseData.cs
    /// ��������: ���ݲ�-ҵ�������������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:50
    /// </summary>
    public class BfBaseData : IBfBaseData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfBaseData).ToString();

        //ͬ��
        private static object _synRoot = new Object();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfBaseModel> GetList()
        {
            IList<BfBaseModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfBaseModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfBaseData> db = new ORMDataAccess<BfBaseData>())
                {
                    list = db.Query<BfBaseModel>("from BfBaseModel");
                    
                    //���ݴ��뻺��ϵͳ
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(BfBaseData), true);
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
        public bool Execute(BfBaseModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfBaseData> db = new ORMDataAccess<BfBaseData>())
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
            CacheHelper.RemoveCacheForClassKey(cacheClassKey);

            return isResult;
        }

        /// <summary>
        /// ����ҵ����ID
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public string GetBF_ID()
        {
            lock (_synRoot)
            {
                int amount = 0;
                string sql =
                    "select Max(substr(bf_id,3,4)) as MaxId from basis_bf_base";
                using (ORMDataAccess<BfBaseData> db = new ORMDataAccess<BfBaseData>())
                {
                    object rr = db.ScalarBySQL(sql);
                    if (rr != null)
                    {
                        int.TryParse(rr.ToString(), out amount);
                    }
                }
                amount++;//����
                return CommonTool.BuZero_4(amount);
            }
        }

    }
}
