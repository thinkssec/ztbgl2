using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Crm;
using Enterprise.Model.App.Crm;
using Enterprise.Service.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Service.App.Examine;



namespace Enterprise.Service.App.Crm
{
	
    /// <summary>
    /// �ļ���:  CrmFbreqformService.cs
    /// ��������: ҵ���߼���-�ְ����뵥�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/12/11 11:28:03
    /// </summary>
    public class CrmFbreqformService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ICrmFbreqformData dal = new CrmFbreqformData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbreqformModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbreqformModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbreqformModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(CrmFbreqformModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public CrmFbreqformModel GetSingle(string reqId)
        {
            return dal.GetListByHQL("from CrmFbreqformModel p where p.REQID='" + reqId + "'").FirstOrDefault();
        }

        //��һ���������������Ŀ�ļ������ͣ����ҳ���Ӧ����λ�����ҵ�λ�ֹ��� 
        public int GetToAUDITOR(string proId)
        {
            ProjectInfoService ser = new ProjectInfoService();
            ProjectInfoModel mod = ser.GetListByHQL("from ProjectInfoModel p where p.PROJID = '" + proId + "'").FirstOrDefault();
            ExamineKindService kindSrv = new ExamineKindService();
            var kindQ = kindSrv.GetList().FirstOrDefault(p => p.KINDID == mod.KINDID);
            int auditDeptId = (kindQ.DEPTID != null) ? kindQ.DEPTID.Value : 0;
            int auditUserId = getAuditUserId(auditDeptId);
            return auditUserId;
        }

        /// <summary>
        /// ���ݵ�λID��ȡ��Ŀ�Ǽ������ԱID
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        public int getAuditUserId(int deptId)
        {
            int userId = 0;
            string auditUserIds = ConfigurationManager.AppSettings["ProjectAuditUserId"];
            string[] array1 = auditUserIds.Split('|');
            foreach (string s1 in array1)
            {
                string[] array2 = s1.Split('#');
                if (array2 != null && array2.Length == 2)
                {
                    if (array2[0].Equals(deptId.ToString()))
                    {
                        int.TryParse(array2[1], out userId);
                        break;
                    }
                }
            }
            return userId;
        }

        public static string GetFBBH(string REQID)
        {
         var q= dal.GetListByHQL("from CrmFbreqformModel p where p.REQID='" + REQID + "'").FirstOrDefault();
         if (q!=null)
         {
             return q.FBBH;
         }
         return "";
        }

      
    }

}
