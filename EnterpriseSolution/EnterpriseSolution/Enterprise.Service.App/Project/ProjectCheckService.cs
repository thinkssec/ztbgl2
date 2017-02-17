using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Project;
using Enterprise.Model.App.Project;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.App.Project
{

    /// <summary>
    /// 文件名:  ProjectCheckService.cs
    /// 功能描述: 业务逻辑层-审核信息表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2013-11-5 15:48:14
    /// </summary>
    public class ProjectCheckService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IProjectCheckData dal = new ProjectCheckData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCheckModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCheckModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 获取关联ID的审核数据集合
        /// </summary>
        /// <param name="asscId">关联ID</param>
        /// <returns></returns>
        public IList<ProjectCheckModel> GetModelsByAssociateID(string asscId)
        {
            IList<ProjectCheckModel> checkList = dal.GetListByHQL(
                    "from ProjectCheckModel p where p.ASSOCIATEDID='" + asscId + "' order by p.CHECKORDER");
            return checkList;
        }

        /// <summary>
        /// 删除关联ID的审核数据集合
        /// </summary>
        /// <param name="asscId">关联ID</param>
        /// <returns></returns>
        public bool DeleteModelsByAssociateID(string asscId)
        {
            var delList = GetModelsByAssociateID(asscId);
            foreach (var delQ in delList)
            {
                delQ.DB_Option_Action = WebKeys.DeleteAction;
                Execute(delQ);
            }
            return true;
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectCheckModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 执行批量添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteLst(IList<ProjectCheckModel> models)
        {
            return dal.ExecuteLst(models);
        }

        #endregion

        #region 自定义方法

        /// <summary>
        /// 计算质量分 求平均
        /// </summary>
        /// <param name="asscId"></param>
        /// <returns></returns>
        public static double ComputeQualityScore(string asscId)
        {
            //获取该资料的所有得分
            ProjectCheckService service = new ProjectCheckService();
            return service.GetListByHQL("from ProjectCheckModel p where p.ASSOCIATEDID='" + asscId + "'").Average(s => s.CHECKSCORE).ToDouble();
        }

        /// <summary>
        /// 获取关联数据的当前审核进程信息
        /// </summary>
        /// <param name="asscId"></param>
        /// <param name="checkUserIds"></param>
        /// <returns></returns>
        public static string GetCheckProcess(string asscId, int[] checkUserIds)
        {
            StringBuilder pStr = new StringBuilder();
            ProjectCheckService service = new ProjectCheckService();
            IList<ProjectCheckModel> checkList = service.GetModelsByAssociateID(asscId);
            int i = 0;
            foreach (int uId in checkUserIds)
            {
                i++;
                var query = checkList.FirstOrDefault(p => p.CHECKER == uId);
                if (query != null)
                {
                    if (query.CHECKRESULT == 1)
                    {
                        pStr.Append("【" + SysUserService.GetUserName(uId) + "】通过");
                        if (i < checkUserIds.Length) pStr.Append("→");
                    }
                    else if (query.CHECKRESULT == 0)
                    {
                        pStr.Append("【" + SysUserService.GetUserName(uId) + "】不通过");
                        break;
                    }
                }
                else
                {
                    pStr.Append("待【" + SysUserService.GetUserName(uId) + "】审核");
                    break;
                }
            }
            return pStr.ToString();
        }


        /// <summary>
        /// 获取关联数据的当前审核进程信息
        /// </summary>
        /// <param name="asscId"></param>
        /// <returns></returns>
        public static string GetCheckProcess(string asscId)
        {
            StringBuilder pStr = new StringBuilder();
            ProjectCheckService service = new ProjectCheckService();
            IList<ProjectCheckModel> checkList = service.GetModelsByAssociateID(asscId);
            foreach (ProjectCheckModel model in checkList)
            {
                if (model.CHECKSTATUS == 1)
                {
                    if (model.CHECKRESULT == 1)
                    {
                        pStr.Append("【" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "】通过→");
                    }
                    else if (model.CHECKRESULT == 0)
                    {
                        pStr.Append("【" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "】<font color='red'>不通过</font>");
                        break;
                    }
                }
                else
                {
                    pStr.Append("待【" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "】审核");
                    break;
                }
            }
            return pStr.ToString().TrimEnd("→".ToCharArray());
        }

        /// <summary>
        /// 获取关联数据的当前审核结果
        /// </summary>
        /// <param name="asscId"></param>
        /// <returns></returns>
        public static string GetCheckProcessResult(string asscId)
        {
            StringBuilder pStr = new StringBuilder();
            ProjectCheckService service = new ProjectCheckService();
            IList<ProjectCheckModel> checkList = service.GetModelsByAssociateID(asscId);
            foreach (ProjectCheckModel model in checkList)
            {
                if (model.CHECKSTATUS == 1)
                {
                    if (model.CHECKRESULT == 1)
                    {
                        pStr.Append("【" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "】通过,审批时间【" + model.CHECKDATE.ToDateYMDFormat() + "】批复内容【" + model.CHECKOPINION + "】<br/>");
                    }
                    else if (model.CHECKRESULT == 0)
                    {
                        pStr.Append("【" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "】不通过,审批时间【" + model.CHECKDATE.ToDateYMDFormat() + "】批复内容【" + model.CHECKOPINION + "】<br/>");
                        break;
                    }
                }
                else
                {
                    pStr.Append("待【" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "】审核<br/>");
                    break;
                }
            }
            return pStr.ToString();
        }

        /// <summary>
        /// 根据项目id获取项目类型的审核人，即分管经理，目前用于项目计划审核、项目变更审核
        /// </summary>
        /// <param name="proId"></param>
        /// <returns></returns>
        //public static int GetToAUDITOR(string proId)
        //{
        //    ProjectInfoService ser = new ProjectInfoService();
        //    ProjectInfoModel mod = ser.GetModelById(proId);
        //    return mod.SHR.ToInt();
        //}

        #endregion
    }

}
