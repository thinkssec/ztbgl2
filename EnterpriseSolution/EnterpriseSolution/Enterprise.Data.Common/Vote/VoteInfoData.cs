using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.Common.Vote;

namespace Enterprise.Data.Common.Vote
{

    /// <summary>
    /// �ļ���:  VoteInfoData.cs
    /// ��������: ���ݲ�-���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/1 10:30:49
    /// </summary>
    public class VoteInfoData : IVoteInfoData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        private static readonly string cacheClassKey = WebKeys.CacheItemKey + typeof(VoteInfoData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<VoteInfoModel> GetList()
        {
            IList<VoteInfoModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<VoteInfoModel>)CacheHelper.GetCache(cacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<VoteInfoData> db = new ORMDataAccess<VoteInfoData>())
                {
                    list = db.Query<VoteInfoModel>("from VoteInfoModel");
                    
                    //���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(VoteInfoData), true);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(cacheClassKey + "_GetList", list, refreshAction);
                }
            }
            return list;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<VoteInfoModel> GetList(string hql)
        {
            IList<VoteInfoModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<VoteInfoData> db = new ORMDataAccess<VoteInfoData>())
                {
                     if (hql == "")
                    {
                        list = db.Query<VoteInfoModel>("from VoteInfoModel");
                    }
                    else
					{
						list = db.Query<VoteInfoModel>(hql);
					}
                }
            }
            return list;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(VoteInfoModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<VoteInfoData> db = new ORMDataAccess<VoteInfoData>())
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

        #endregion
    }
}
