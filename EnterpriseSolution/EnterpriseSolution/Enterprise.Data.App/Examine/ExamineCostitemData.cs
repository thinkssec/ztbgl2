using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Examine;

namespace Enterprise.Data.App.Examine
{

    /// <summary>
    /// �ļ���:  ExamineCostitemData.cs
    /// ��������: ���ݲ�-�ɱ�������Ŀ�����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-7 14:36:27
    /// </summary>
    public class ExamineCostitemData : IExamineCostitemData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ExamineCostitemData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineCostitemModel> GetList()
        {
            IList<ExamineCostitemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ExamineCostitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExamineCostitemData> db = new ORMDataAccess<ExamineCostitemData>())
                {
                    list = db.Query<ExamineCostitemModel>("from ExamineCostitemModel");

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ExamineCostitemData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
                    //}
                }
            }
            return list;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<ExamineCostitemModel> GetListByHQL(string hql)
        {
            IList<ExamineCostitemModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
            //list = (IList<ExamineCostitemModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ExamineCostitemData> db = new ORMDataAccess<ExamineCostitemData>())
                {
                    if (string.IsNullOrEmpty(hql))
                    {
                        list = db.Query<ExamineCostitemModel>("from ExamineCostitemModel");
                    }
                    else
                    {
                        list = db.Query<ExamineCostitemModel>(hql);
                    }

                    //if (WebKeys.EnableCaching)
                    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                    //new CacheItemRefreshAction(typeof(ExamineCostitemData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = new object[]{ hql };
                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
                    //}
                }
            }
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineCostitemModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ExamineCostitemData> db = new ORMDataAccess<ExamineCostitemData>())
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
                CacheHelper.RemoveCacheForClassKey(CacheClassKey);
            }
            return isResult;
        }

        #endregion
    }
}
