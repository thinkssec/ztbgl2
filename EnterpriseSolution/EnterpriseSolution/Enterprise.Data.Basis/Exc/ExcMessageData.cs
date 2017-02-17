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
    /// �ļ���:  ExcMessageData.cs
    /// ��������: ���ݲ�-��ʱ��Ϣ���ͱ����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:28
    /// </summary>
    public class ExcMessageData : IExcMessageData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcMessageData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcMessageModel> GetList()
        {
            IList<ExcMessageModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ExcMessageModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcMessageData> db = new ORMDataAccess<ExcMessageData>())
                {
                    list = db.Query<ExcMessageModel>("from ExcMessageModel");

                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ExcMessageData), true);
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
        public ExcMessageModel GetModelById(string Id)
        {
            ExcMessageModel model = null;

            using (ORMDataAccess<ExcMessageData> db = new ORMDataAccess<ExcMessageData>())
            {
                model = db.Query<ExcMessageModel>(
                    "from ExcMessageModel p where p.EXC_MSGID='" + Id + "'").FirstOrDefault();
            }

            return model;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcMessageModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcMessageData> db = new ORMDataAccess<ExcMessageData>())
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
