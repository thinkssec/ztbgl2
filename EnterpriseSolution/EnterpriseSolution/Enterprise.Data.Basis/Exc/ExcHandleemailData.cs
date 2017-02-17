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
    /// �ļ���:  ExcHandleemailData.cs
    /// ��������: ���ݲ�-�ʼ��Ѵ�������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:26
    /// </summary>
    public class ExcHandleemailData : IExcHandleemailData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcHandleemailData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcHandleemailModel> GetList()
        {
            IList<ExcHandleemailModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ExcHandleemailModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcHandleemailData> db = new ORMDataAccess<ExcHandleemailData>())
                {
                    list = db.Query<ExcHandleemailModel>("from ExcHandleemailModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ExcHandleemailData), true);
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
        public bool Execute(ExcHandleemailModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcHandleemailData> db = new ORMDataAccess<ExcHandleemailData>())
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
