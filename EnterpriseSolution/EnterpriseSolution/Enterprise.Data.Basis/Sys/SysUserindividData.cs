using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Data.Basis.Sys
{

    /// <summary>
    /// �ļ���:  SysUserindividData.cs
    /// ��������: ���ݲ�-���Ի����ñ����ݷ��ʷ���ʵ����
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-7-3 11:42:29
    /// </summary>
    public class SysUserindividData : ISysUserindividData
    {
        #region ����������
        /// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(SysUserindividData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SysUserindividModel> GetList()
        {
            IList<SysUserindividModel> list = null;
            if (WebKeys.EnableCaching)
            {
                list = (IList<SysUserindividModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            }

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<SysUserindividData> db = new ORMDataAccess<SysUserindividData>())
                {
                    list = db.Query<SysUserindividModel>("from SysUserindividModel");

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(SysUserindividData), false);
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
        /// ��ȡָ��ID������
        /// </summary>
        /// <returns></returns>
        public SysUserindividModel GetModelById(int id)
        {
            SysUserindividModel model = null;
            if (WebKeys.EnableCaching)
            {
                model = (SysUserindividModel)CacheHelper.GetCache(cacheClassKey + "_GetModelById_" + id);
            }
            if (model == null)
            {
                using (ORMDataAccess<SysUserindividData> db = new ORMDataAccess<SysUserindividData>())
                {
                    model = db.Query<SysUserindividModel>(
                        "from SysUserindividModel p where p.USERID='" + id + "'").FirstOrDefault();

                    if (WebKeys.EnableCaching)
                    {
                        //���ݴ��뻺��ϵͳ
                        CacheItemRefreshAction refreshAction =
                        new CacheItemRefreshAction(typeof(SysUserindividData), false);
                        refreshAction.ConstuctParms = null;
                        refreshAction.MethodName = "GetModelById";
                        refreshAction.Parameters = new object[] { id };
                        CacheHelper.Add(cacheClassKey + "_GetModelById_" + id, model, refreshAction);
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysUserindividModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<SysUserindividData> db = new ORMDataAccess<SysUserindividData>())
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
                else if (model.DB_Option_Action == WebKeys.InsertOrUpdateAction)
                {
                    db.InsertOrUpdate(model);
                }
            }

            if (WebKeys.EnableCaching)
            {
                //�����صĻ���
                CacheHelper.RemoveCacheForClassKey(cacheClassKey);
            }

            return isResult;
        }

        #endregion
    }
}
