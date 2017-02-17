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
    /// �ļ���:  ExcInformData.cs
    /// ��������: ���ݲ�-�쳣֪ͨ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:28
    /// </summary>
    public class ExcInformData : IExcInformData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcInformData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcInformModel> GetList()
        {
            IList<ExcInformModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ExcInformModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcInformData> db = new ORMDataAccess<ExcInformData>())
                {
                    list = db.Query<ExcInformModel>("from ExcInformModel");
                    
                    //���ݴ��뻺��ϵͳ
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ExcInformData), true);
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
        public bool Execute(ExcInformModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcInformData> db = new ORMDataAccess<ExcInformData>())
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
