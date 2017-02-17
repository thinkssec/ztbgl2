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
    /// �ļ���:  ExcGradeData.cs
    /// ��������: ���ݲ�-�쳣�ȼ������ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:25
    /// </summary>
    public class ExcGradeData : IExcGradeData
    {
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(ExcGradeData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcGradeModel> GetList()
        {
            IList<ExcGradeModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<ExcGradeModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExcGradeData> db = new ORMDataAccess<ExcGradeData>())
                {
                    list = db.Query<ExcGradeModel>("from ExcGradeModel");
                    
                    //���ݴ��뻺��ϵͳ
                    CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(ExcGradeData), true);
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
        public bool Execute(ExcGradeModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExcGradeData> db = new ORMDataAccess<ExcGradeData>())
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
