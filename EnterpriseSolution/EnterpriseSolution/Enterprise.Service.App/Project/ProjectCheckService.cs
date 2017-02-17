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
    /// �ļ���:  ProjectCheckService.cs
    /// ��������: ҵ���߼���-�����Ϣ�����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2013-11-5 15:48:14
    /// </summary>
    public class ProjectCheckService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IProjectCheckData dal = new ProjectCheckData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCheckModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectCheckModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ��ȡ����ID��������ݼ���
        /// </summary>
        /// <param name="asscId">����ID</param>
        /// <returns></returns>
        public IList<ProjectCheckModel> GetModelsByAssociateID(string asscId)
        {
            IList<ProjectCheckModel> checkList = dal.GetListByHQL(
                    "from ProjectCheckModel p where p.ASSOCIATEDID='" + asscId + "' order by p.CHECKORDER");
            return checkList;
        }

        /// <summary>
        /// ɾ������ID��������ݼ���
        /// </summary>
        /// <param name="asscId">����ID</param>
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
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectCheckModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ִ��������ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteLst(IList<ProjectCheckModel> models)
        {
            return dal.ExecuteLst(models);
        }

        #endregion

        #region �Զ��巽��

        /// <summary>
        /// ���������� ��ƽ��
        /// </summary>
        /// <param name="asscId"></param>
        /// <returns></returns>
        public static double ComputeQualityScore(string asscId)
        {
            //��ȡ�����ϵ����е÷�
            ProjectCheckService service = new ProjectCheckService();
            return service.GetListByHQL("from ProjectCheckModel p where p.ASSOCIATEDID='" + asscId + "'").Average(s => s.CHECKSCORE).ToDouble();
        }

        /// <summary>
        /// ��ȡ�������ݵĵ�ǰ��˽�����Ϣ
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
                        pStr.Append("��" + SysUserService.GetUserName(uId) + "��ͨ��");
                        if (i < checkUserIds.Length) pStr.Append("��");
                    }
                    else if (query.CHECKRESULT == 0)
                    {
                        pStr.Append("��" + SysUserService.GetUserName(uId) + "����ͨ��");
                        break;
                    }
                }
                else
                {
                    pStr.Append("����" + SysUserService.GetUserName(uId) + "�����");
                    break;
                }
            }
            return pStr.ToString();
        }


        /// <summary>
        /// ��ȡ�������ݵĵ�ǰ��˽�����Ϣ
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
                        pStr.Append("��" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "��ͨ����");
                    }
                    else if (model.CHECKRESULT == 0)
                    {
                        pStr.Append("��" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "��<font color='red'>��ͨ��</font>");
                        break;
                    }
                }
                else
                {
                    pStr.Append("����" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "�����");
                    break;
                }
            }
            return pStr.ToString().TrimEnd("��".ToCharArray());
        }

        /// <summary>
        /// ��ȡ�������ݵĵ�ǰ��˽��
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
                        pStr.Append("��" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "��ͨ��,����ʱ�䡾" + model.CHECKDATE.ToDateYMDFormat() + "���������ݡ�" + model.CHECKOPINION + "��<br/>");
                    }
                    else if (model.CHECKRESULT == 0)
                    {
                        pStr.Append("��" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "����ͨ��,����ʱ�䡾" + model.CHECKDATE.ToDateYMDFormat() + "���������ݡ�" + model.CHECKOPINION + "��<br/>");
                        break;
                    }
                }
                else
                {
                    pStr.Append("����" + SysUserService.GetUserName(model.CHECKER.ToInt()) + "�����<br/>");
                    break;
                }
            }
            return pStr.ToString();
        }

        /// <summary>
        /// ������Ŀid��ȡ��Ŀ���͵�����ˣ����ֹܾ���Ŀǰ������Ŀ�ƻ���ˡ���Ŀ������
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
