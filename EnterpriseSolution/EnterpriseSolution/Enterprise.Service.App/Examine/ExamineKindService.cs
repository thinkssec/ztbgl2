using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using Enterprise.Component.Cache;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Examine;
using Enterprise.Model.App.Examine;

namespace Enterprise.Service.App.Examine
{

    /// <summary>
    /// �ļ���:  ExamineKindService.cs
    /// ��������: ҵ���߼���-�������ͱ����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-8 14:53:58
    /// </summary>
    public class ExamineKindService
    {
        #region ����������

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExamineKindData dal = new ExamineKindData();
        /// <summary>
        /// �����������ݼ���
        /// </summary>
        private IList<ExamineKindModel> kindTreeList = null;

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineKindModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineKindModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ExamineKindModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineKindModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// �������ݼ���
        /// ��˳������򣬲����ݲ㼶��ʾ����
        /// </summary>
        /// <returns></returns>
        public IList<ExamineKindModel> GetTreeList()
        {
            if (WebKeys.EnableCaching)
            {
                kindTreeList = (IList<ExamineKindModel>)
                    CacheHelper.GetCache(ExamineKindData.CacheClassKey + "_GetTreeList");
            }
            if (kindTreeList == null)
            {
                kindTreeList = new List<ExamineKindModel>();
            }
            if (kindTreeList.Count == 0)
            {
                getListForTree(GetList(), 0);
                if (WebKeys.EnableCaching)
                {
                    CacheHelper.Add(ExamineKindData.CacheClassKey + "_GetTreeList", kindTreeList);
                }
            }
            return kindTreeList;
        }

        #endregion

        #region ר�÷���

        /// <summary>
        /// �������Ϳؼ����õ�����
        /// </summary>
        /// <param name="kindLst"></param>
        /// <param name="parentId"></param>
        private void getListForTree(IList<ExamineKindModel> kindLst, int parentId)
        {
            IList<ExamineKindModel> subKindLst = kindLst.Where(p => p.PARENTID == parentId).OrderBy(p => p.KINDORDER).ToList();
            foreach (ExamineKindModel model in subKindLst)
            {
                ExamineKindModel newModel = (ExamineKindModel)CommonTool.Clone(model);
                if (model.PARENTID != null && model.PARENTID > 0)
                {
                    newModel.KINDNAME = CommonTool.GenerateBlankSpace(1) + model.KINDNAME;
                }
                kindTreeList.Add(newModel);
                getListForTree(kindLst, model.KINDID);
            }
        }

        /// <summary>
        /// ��ȡ�������͵�����
        /// </summary>
        /// <param name="KindId"></param>
        public static string GetTypeName(int kindId)
        {
            ExamineKindService Service = new ExamineKindService();
            var q = Service.GetList().Where(p => p.KINDID == kindId).FirstOrDefault();
            if (q != null)
            {
                //if (q.PARENTID != null && q.PARENTID.Value > 0)
                //{
                //    return GetTypeName(q.PARENTID.Value) + "->" + q.KINDNAME;
                //}
                //else
                //{
                    return q.KINDNAME;
                //}
            }
            return "";
        }

        #endregion

        public ExamineKindModel GetSingle(string Id)
        {
            return dal.GetListByHQL("from ExamineKindModel p where p.KINDID = '" + Id + "'").FirstOrDefault();
        }

        /// <summary>
        /// ���ݼ������ͻ�ȡ����ID
        /// </summary>
        /// <param name="KindId"></param>
        /// <returns></returns>
        public int GetDepId(int KindId)
        {
            ExamineKindModel Model = dal.GetList().Where(p => p.KINDID == KindId).FirstOrDefault();
           //var q= dal.GetListByHQL("from ExamineKindModel p where p.KINDID = 'KindId'").FirstOrDefault();
            return Model.DEPTID.ToInt();
        }
    }

}
