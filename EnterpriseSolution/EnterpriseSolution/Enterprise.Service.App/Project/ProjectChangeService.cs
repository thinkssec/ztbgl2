using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Service.App.Examine;

namespace Enterprise.Service.App.Project
{
	
    /// <summary>
    /// �ļ���:  ProjectChangeService.cs
    /// ��������: ҵ���߼���-��Ŀ�����¼�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-11-5 15:48:14
    /// </summary>
    public class ProjectChangeService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IProjectChangeData dal = new ProjectChangeData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectChangeModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectChangeModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectChangeModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        //��һ���������������Ŀ�ļ������ͣ����ҳ���Ӧ����λ�����ҵ�λ�ֹ��� 
        //public int GetToAUDITOR(string proId)
        //{
        //    ProjectInfoService ser = new ProjectInfoService();
        //    ProjectInfoModel mod = ser.GetModelById(proId);
        //    ExamineKindService kindSrv = new ExamineKindService();
        //    var kindQ = kindSrv.GetList().FirstOrDefault(p => p.KINDID == mod.KINDID);
        //    int auditDeptId = (kindQ.DEPTID != null) ? kindQ.DEPTID.Value : 0;
        //    int auditUserId = getAuditUserId(auditDeptId);
        //    return auditUserId;
        //}

        /// <summary>
        /// ���ݵ�λID��ȡ��Ŀ�Ǽ������ԱID
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        //public int getAuditUserId(int deptId)
        //{
        //    int userId = 0;
        //    string auditUserIds = ConfigurationManager.AppSettings["ProjectAuditUserId"];
        //    string[] array1 = auditUserIds.Split('|');
        //    foreach (string s1 in array1)
        //    {
        //        string[] array2 = s1.Split('#');
        //        if (array2 != null && array2.Length == 2)
        //        {
        //            if (array2[0].Equals(deptId.ToString()))
        //            {
        //                int.TryParse(array2[1], out userId);
        //                break;
        //            }
        //        }
        //    }
        //    return userId;
        //}
    }



}
