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
    /// �ļ���:  BfClsmethodsData.cs
    /// ��������: ���ݲ�-��ɫ��ȡ���������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:51
    /// </summary>
    public class BfClsmethodsData : IBfClsmethodsData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(BfClsmethodsData).ToString();

        //ͬ��
        private static object _synRoot = new Object();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfClsmethodsModel> GetList()
        {
            IList<BfClsmethodsModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<BfClsmethodsModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<BfClsmethodsData> db = new ORMDataAccess<BfClsmethodsData>())
                {
                    list = db.Query<BfClsmethodsModel>("from BfClsmethodsModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                            new CacheItemRefreshAction(typeof(BfClsmethodsData), true);
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
        public bool Execute(BfClsmethodsModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<BfClsmethodsData> db = new ORMDataAccess<BfClsmethodsData>())
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


        /// <summary>
        /// ���ɽ�ɫ��ȡ������ID
        /// </summary>
        /// <returns></returns>
        public string GetClsMethod_ID()
        {
            lock (_synRoot)
            {
                int amount = 0;
                string sql =
                    "select Max(substr(bf_clsid,3,4)) as MaxId from basis_bf_clsmethods";
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
