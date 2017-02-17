using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Exc;
using Enterprise.Component.Cache;

namespace Enterprise.Data.Basis.Exc
{

    /// <summary>
    /// �ļ���:  ExcChecknodesData.cs
    /// ��������: ���ݲ�-�쳣���ڵ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:22
    /// </summary>
    public class ExcChecknodesData : IExcChecknodesData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcChecknodesData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcChecknodesModel> GetList()
        {
            IList<ExcChecknodesModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ExcChecknodesModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcChecknodesData> db = new ORMDataAccess<ExcChecknodesData>())
                {
                    list = db.Query<ExcChecknodesModel>("from ExcChecknodesModel");
                    
                    //���ݴ��뻺��ϵͳ
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ExcChecknodesData), true);
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
        public bool Execute(ExcChecknodesModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcChecknodesData> db = new ORMDataAccess<ExcChecknodesData>())
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

    }
}
