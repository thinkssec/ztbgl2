using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Meeting;
using Enterprise.Model.Common.Meeting;

namespace Enterprise.Service.Common.Meeting
{
	
    /// <summary>
    /// 文件名:  MeetingInfoService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/1 15:50:38
    /// </summary>
    public class MeetingInfoService
    {
        
        #region 代码生成器
        
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IMeetingInfoData dal = new MeetingInfoData();
        /// <summary>
        /// 会议签收情况--服务类
        /// </summary>
        private static readonly MeetingRecevieService mrService = new MeetingRecevieService();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<MeetingInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<MeetingInfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(MeetingInfoModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 生成会议ID
        /// </summary>
        /// <returns></returns>
        public int GetMeeting_ID()
        {
            return dal.GetMeeting_ID();
        }

        #endregion

        /// <summary>
        ///  会议未签收列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<MeetingRecevieModel> MeetingUnCheck(int UserId)
        {
            List<MeetingRecevieModel> meetingRecieveList = mrService.GetList("from MeetingRecevieModel p where p.MRUSERID='"
               + UserId + "' and p.MRTIME is null").ToList();
            return meetingRecieveList;
        }
    }

}
