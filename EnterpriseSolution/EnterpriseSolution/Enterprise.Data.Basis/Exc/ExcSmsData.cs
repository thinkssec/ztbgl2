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
    /// �ļ���:  ExcSmsData.cs
    /// ��������: ���ݲ�-���ŷ��ͱ����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:29
    /// </summary>
    public class ExcSmsData : IExcSmsData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcSmsData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcSmsModel> GetList()
        {
            IList<ExcSmsModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ExcSmsModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcSmsData> db = new ORMDataAccess<ExcSmsData>())
                {
                    list = db.Query<ExcSmsModel>("from ExcSmsModel");

                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ExcSmsData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }


        /// <summary>
        /// ��ȡָ���ļ�¼
        /// </summary>
        /// <returns></returns>
        public ExcSmsModel GetModelById(string Id)
        {
            ExcSmsModel model = null;

            using (ORMDataAccess<ExcSmsData> db = new ORMDataAccess<ExcSmsData>())
            {
                model = db.Query<ExcSmsModel>(
                    "from ExcSmsModel p where p.EXC_SMSID='" + Id + "'").FirstOrDefault();
            }

            return model;
        }


        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcSmsModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcSmsData> db = new ORMDataAccess<ExcSmsData>())
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
