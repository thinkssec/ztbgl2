using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Supervise;
using Enterprise.Model.Common.Supervise;
using Enterprise.Service.Basis.Bf;
using Enterprise.Service.Basis.Rtx;

namespace Enterprise.Service.Common.Supervise
{
	
    /// <summary>
    /// �ļ���:  SuperviseProcessService.cs
    /// ��������: ҵ���߼���-����������ȼ�����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/13 10:53:10
    /// </summary>
    public class SuperviseProcessService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ISuperviseProcessData dal = new SuperviseProcessData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseProcessModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseProcessModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SuperviseProcessModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="userIds">�û�ID �������û� �ö��ŷָ�</param>
        /// <param name="model">��������</param>
        /// <param name="yqsbsjs">����ʱ���</param>
        public void ProcessJobs(string userIds, SuperviseInfoModel model, List<string> dbsjs, Model.Basis.Sys.SysUserModel userModel)
        {            

            if (model != null)
            {
                BFController bfCtrl = new BFController();
                //��ɾ��������������н��ȵ� 
                DeleteJobs(model.DBID);
                //�����´�
                foreach(var q in userIds.Split(','))
                {
                    if (!string.IsNullOrEmpty(q))
                    {
                        foreach (var sbsj in dbsjs)
                        {
                            SuperviseProcessModel processModel = new SuperviseProcessModel();
                            processModel.DBID = model.DBID;
                            processModel.BLRID = q.ToString();
                            processModel.YQSBSJ = sbsj;
                            processModel.FLAG = 0;
                            processModel.DB_Option_Action = WebKeys.InsertAction;
                            dal.Execute(processModel);
                            
                        }
                        //���ʹ���
                        bfCtrl.SendNotificationMessage(model.DBID,
                            q.ToInt(),
                            userModel,
                            model.DBBT,
                            "/Modules/Common/Supervise/SuperviseProcessDetailsManage.aspx?DBID=" + model.DBID,
                            "MSG", true);
                    }
                }
            }
        }

        /// <summary>
        /// ɾ��������Ա������
        /// </summary>
        /// <param name="dbId"></param>
        public void DeleteJobs(string dbId)
        {
            dal.DeleteJobs(dbId);
        }

        /// <summary>
        /// ��ȡ��ǰ�������
        /// </summary>
        /// <param name="dbId">����ID</param>
        /// <returns></returns>
        public static decimal GetProcess(string dbId,string yqsbsj)
        {
            return dal.GetProcess(dbId,yqsbsj);
        }
        
        /// <summary>
        /// �Ƿ����
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        public static bool GetState(decimal process)
        {
            if (process >= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ��ȡ�ҵ�����ID�б�
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetMyIdList(int userId)
        {
            return dal.GetMyIdList(userId);
        }

        /// <summary>
        /// �Ҹ���������б�
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetMyChargeList(int userId)
        {
            return dal.GetMyChargeList(userId);
        }

        /// <summary>
        /// ������Ϣ��������Ա
        /// </summary>
        public static void SendNoticeToUsers()
        {
            IList<SuperviseProcessModel> list = null;
            //��Ϣδ���ͻ��߽���=0 ����Ϊ0˵����û����д
            list = dal.GetList("from SuperviseProcessModel c where c.FLAG!=1 and c.DQJD=0 ");            
            foreach (var model in list)
            {
                if (model.YQSBSJ == DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"))
                {
                    Enterprise.Service.Common.Supervise.SuperviseInfoService infoServie = new SuperviseInfoService();
                    SuperviseInfoModel info = infoServie.GetList("from SuperviseInfoModel where DBID='" + model.DBID + "'").FirstOrDefault();
                    RtxService.SendRtxMessageByUserId(model.BLRID.ToInt(), "������������", "["+info.DBBT + "]Ҫ����"+model.YQSBSJ+"�ϱ����ȣ���ץ������");
                    model.FLAG = 1;
                    model.DB_Option_Action = WebKeys.UpdateAction;
                    dal.Execute(model);
                }
            }
            
        }
    }

}
