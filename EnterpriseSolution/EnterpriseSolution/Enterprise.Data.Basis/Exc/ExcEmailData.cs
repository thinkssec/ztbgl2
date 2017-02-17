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
    /// �ļ���:  ExcEmailData.cs
    /// ��������: ���ݲ�-�ʼ����ͱ����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:24
    /// </summary>
    public class ExcEmailData : IExcEmailData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcEmailData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcEmailModel> GetList()
        {
            IList<ExcEmailModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ExcEmailModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcEmailData> db = new ORMDataAccess<ExcEmailData>())
                {
                    list = db.Query<ExcEmailModel>("from ExcEmailModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ExcEmailData), true);
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
        public ExcEmailModel GetModelById(string Id)
        {
            ExcEmailModel emailModel = null;

            using (ORMDataAccess<ExcEmailData> db = new ORMDataAccess<ExcEmailData>())
            {
                emailModel = db.Query<ExcEmailModel>(
                    "from ExcEmailModel p where p.EXC_EMAILID='" + Id + "'").FirstOrDefault();
            }

            return emailModel;
        }
        

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExcEmailModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcEmailData> db = new ORMDataAccess<ExcEmailData>())
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
