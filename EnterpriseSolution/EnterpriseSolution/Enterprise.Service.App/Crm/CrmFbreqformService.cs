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
    /// 文件名:  CrmFbreqformService.cs
    /// 功能描述: 业务逻辑层-分包申请单表数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/12/11 11:28:03
    /// </summary>
    public class CrmFbreqformService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ICrmFbreqformData dal = new CrmFbreqformData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbreqformModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<CrmFbreqformModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<CrmFbreqformModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
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

        //第一级，根据申请的项目的检验类型，先找出对应负责单位，再找单位分管人 
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
        /// 根据单位ID获取项目登记审核人员ID
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
