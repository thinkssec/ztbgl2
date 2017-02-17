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
    /// �ļ���:  ExcHandlesmsData.cs
    /// ��������: ���ݲ�-�����Ѵ�������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:27
    /// </summary>
    public class ExcHandlesmsData : IExcHandlesmsData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcHandlesmsData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcHandlesmsModel> GetList()
        {
            IList<ExcHandlesmsModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ExcHandlesmsModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcHandlesmsData> db = new ORMDataAccess<ExcHandlesmsData>())
                {
                    list = db.Query<ExcHandlesmsModel>("from ExcHandlesmsModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ExcHandlesmsData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcHandlesmsModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcHandlesmsData> db = new ORMDataAccess<ExcHandlesmsData>())
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
