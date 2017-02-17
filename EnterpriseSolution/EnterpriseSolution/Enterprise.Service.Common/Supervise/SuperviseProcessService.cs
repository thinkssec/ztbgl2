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
    /// 文件名:  SuperviseProcessService.cs
    /// 功能描述: 业务逻辑层-督办事务进度检查数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/13 10:53:10
    /// </summary>
    public class SuperviseProcessService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISuperviseProcessData dal = new SuperviseProcessData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseProcessModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SuperviseProcessModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SuperviseProcessModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        /// <summary>
        /// 创建任务
        /// </summary>
        /// <param name="userIds">用户ID 允许多个用户 用逗号分隔</param>
        /// <param name="model">督办事务</param>
        /// <param name="yqsbsjs">督办时间点</param>
        public void ProcessJobs(string userIds, SuperviseInfoModel model, List<string> dbsjs, Model.Basis.Sys.SysUserModel userModel)
        {            

            if (model != null)
            {
                BFController bfCtrl = new BFController();
                //先删除本此任务的所有进度点 
                DeleteJobs(model.DBID);
                //任务下达
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
                        //发送代办
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
        /// 删除所有人员的任务
        /// </summary>
        /// <param name="dbId"></param>
        public void DeleteJobs(string dbId)
        {
            dal.DeleteJobs(dbId);
        }

        /// <summary>
        /// 获取当前任务进度
        /// </summary>
        /// <param name="dbId">督办ID</param>
        /// <returns></returns>
        public static decimal GetProcess(string dbId,string yqsbsj)
        {
            return dal.GetProcess(dbId,yqsbsj);
        }
        
        /// <summary>
        /// 是否完成
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
        /// 获取我的事务ID列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetMyIdList(int userId)
        {
            return dal.GetMyIdList(userId);
        }

        /// <summary>
        /// 我负责的事务列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<string> GetMyChargeList(int userId)
        {
            return dal.GetMyChargeList(userId);
        }

        /// <summary>
        /// 发送消息给代办人员
        /// </summary>
        public static void SendNoticeToUsers()
        {
            IList<SuperviseProcessModel> list = null;
            //消息未发送或者进度=0 进度为0说明还没有填写
            list = dal.GetList("from SuperviseProcessModel c where c.FLAG!=1 and c.DQJD=0 ");            
            foreach (var model in list)
            {
                if (model.YQSBSJ == DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"))
                {
                    Enterprise.Service.Common.Supervise.SuperviseInfoService infoServie = new SuperviseInfoService();
                    SuperviseInfoModel info = infoServie.GetList("from SuperviseInfoModel where DBID='" + model.DBID + "'").FirstOrDefault();
                    RtxService.SendRtxMessageByUserId(model.BLRID.ToInt(), "督办事务提醒", "["+info.DBBT + "]要求在"+model.YQSBSJ+"上报进度，请抓紧办理！");
                    model.FLAG = 1;
                    model.DB_Option_Action = WebKeys.UpdateAction;
                    dal.Execute(model);
                }
            }
            
        }
    }

}
