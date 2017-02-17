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
    /// �ļ���:  ExamineProcessService.cs
    /// ��������: ҵ���߼���-������ʩ������������ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-5 15:48:11
    /// </summary>
    public class ExamineProcessService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExamineProcessData dal = new ExamineProcessData();

        /// <summary>
        /// ��ʩ�������ݼ���
        /// </summary>
        private IList<ExamineProcessModel> kindTreeList = null;

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineProcessModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineProcessModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// �������ݼ���
        /// ��˳������򣬲����ݲ㼶��ʾ����
        /// </summary>
        /// <returns></returns>
        public IList<ExamineProcessModel> GetTreeList()
        {
            if (WebKeys.EnableCaching)
            {
                kindTreeList = (IList<ExamineProcessModel>)
                    CacheHelper.GetCache(ExamineProcessData.CacheClassKey + "_GetTreeList");
            }
            if (kindTreeList == null)
            {
                kindTreeList = new List<ExamineProcessModel>();
            }
            if (kindTreeList.Count == 0)
            {
                getListForTree(GetList(), "0");
                if (WebKeys.EnableCaching)
                {
                    CacheHelper.Add(ExamineProcessData.CacheClassKey + "_GetTreeList", kindTreeList);
                }
            }
            return kindTreeList;
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineProcessModel model)
        {
            return dal.Execute(model);
        }

        #endregion


        #region ר�÷���

        /// <summary>
        /// �������Ϳؼ����õ�����
        /// </summary>
        /// <param name="kindLst"></param>
        /// <param name="parentId"></param>
        private void getListForTree(IList<ExamineProcessModel> kindLst, string parentId)
        {
            IList<ExamineProcessModel> subKindLst = kindLst.Where(p => p.SJDM == parentId).OrderBy(p => p.BJDM).ToList();
            foreach (ExamineProcessModel model in subKindLst)
            {
                ExamineProcessModel newModel = (ExamineProcessModel)CommonTool.Clone(model);
                if (!model.SJDM.Equals("0"))
                {
                    int gradeCount = (model.SJDM.Length - 5) / 2 + 1;
                    newModel.BJMC = CommonTool.GenerateBlankSpace(gradeCount) + model.BJMC;
                }
                kindTreeList.Add(newModel);
                getListForTree(kindLst, model.BJDM);
            }
        }

        /// <summary>
        /// ��ȡ��ʩ��������
        /// </summary>
        /// <param name="bjdm"></param>
        /// <returns></returns>
        public static string GetProcessName(string bjdm)
        {
            var q = dal.GetList().FirstOrDefault(p => p.BJDM == bjdm);
            if (q != null)
            {
                return q.BJMC;
            }
            return "";
        }

        /// <summary>
        /// ��ȡ��ʩ��������
        /// </summary>
        /// <param name="bjdm"></param>
        /// <returns></returns>
        public static string GetHierarchyProcessName(string bjdm)
        {
            string processName = string.Empty;
            int len = (bjdm.Length - 5)/2;
            for (int i = 0; i <= len; i++)
            {
                if (i > 0)
                {
                    processName += ">>" + GetProcessName(bjdm.Substring(0, (5 + i * 2)));
                }
                else
                {
                    processName += GetProcessName(bjdm.Substring(0, (5 + i * 2)));
                }
            }
            return processName;
        }

        /// <summary>
        /// ��ȡ�����KEY����
        /// </summary>
        /// <returns></returns>
        public static string GetCacheKey()
        {
            return ExamineProcessData.CacheClassKey;
        }

        #endregion

        public ExamineProcessModel GetSingle(string ID)
        {
            return dal.GetListByHQL("from ExamineProcessModel p where p.BJDM = '" + ID + "'").FirstOrDefault();
        }
    }

}
