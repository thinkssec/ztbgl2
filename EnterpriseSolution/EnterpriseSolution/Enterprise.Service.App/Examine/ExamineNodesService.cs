using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Examine;
using Enterprise.Model.App.Examine;
using Enterprise.Component.Cache;

namespace Enterprise.Service.App.Examine
{
	
    /// <summary>
    /// �ļ���:  ExamineNodesService.cs
    /// ��������: ҵ���߼���-�������̽ڵ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:10
    /// </summary>
    public class ExamineNodesService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExamineNodesData dal = new ExamineNodesData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineNodesModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExamineNodesModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ExamineNodesModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        #region �Զ��巽����

        /// <summary>
        /// ���ݼ���������ȡ��Ӧ�Ľڵ����ݼ���
        /// </summary>
        /// <param name="kindId"></param>
        /// <returns></returns>
        public IList<ExamineNodesModel> GetListByKindId(int kindId)
        {
            return GetListByHQL("from ExamineNodesModel p where p.KINDID='" + kindId + "' order by p.NODEBH");
        }

        /// <summary>
        /// ��ȡָ��ҵ�����͵Ľڵ���JSON
        /// </summary>
        /// <param name="kindId">����ID</param>
        /// <returns></returns>
        public string GetNodesTreeJSONById(int kindId)
        {
            string jsonStr = string.Empty;

            if (WebKeys.EnableCaching)
            {
                jsonStr = (string)CacheHelper.GetCache(ExamineNodesData.CacheClassKey + "_GetNodesTreeJSONById_" + kindId);
            }

            if (string.IsNullOrEmpty(jsonStr))
            {
                var list = GetListByKindId(kindId).Where(p => p.NODESTATUS == 1).ToList();
                DataTable dt = new DataTable();
                //NODEBH,NODENAME,NODEPATH,PARENTID,KEYNODE
                dt.Columns.Add("NODEBH", typeof(string));
                dt.Columns.Add("NODENAME", typeof(string));
                dt.Columns.Add("NODEPATH", typeof(string));
                dt.Columns.Add("PARENTID", typeof(string));
                dt.Columns.Add("KEYNODE", typeof(string));
                dt.Columns.Add("RUNSTATUS", typeof(string));
                foreach (var q in list)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = q.NODEBH;
                    dr[1] = q.NODENAME;
                    dr[2] = getNodePath(q);
                    dr[3] = getParentID(q);
                    dr[4] = q.KEYNODE;
                    dr[5] = "1";
                    dt.Rows.Add(dr);
                }
                jsonStr = dt.ToJsonForTree("NODEBH", "NODENAME", "PARENTID", "00", "NODEPATH", "");
                if (WebKeys.EnableCaching)
                {
                    //���ݴ��뻺��ϵͳ
                    CacheHelper.Add(typeof(ExamineNodesData), false, null, "GetNodesTreeJSONById", 
                        null, ExamineNodesData.CacheClassKey + "_GetNodesTreeJSONById_" + kindId, jsonStr);
                }
            }

            return jsonStr;
        }

        #endregion

        #region ˽�з���

        /// <summary>
        /// ��ȡ�ڵ�·��
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string getNodePath(ExamineNodesModel model)
        {
            string url = model.NODEPATH;
            if (!string.IsNullOrEmpty(model.WEBURL))
            {
                url = model.WEBURL + model.WEBPARAM;
            }
            return url;
        }

        /// <summary>
        /// ��ȡ�ϼ��ڵ���
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private string getParentID(ExamineNodesModel model)
        {
            string parentId = "00";
            if (!string.IsNullOrEmpty(model.NODEBH) && model.NODEBH.Length >= 4)
            {
                parentId = model.NODEBH.Substring(0, model.NODEBH.Length - 2);
            }
            return parentId;
        }

        #endregion
    }

}
