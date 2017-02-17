using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.Infrastructure;
using Enterprise.Service.Basis.Rtx;
using Enterprise.Data.Common.Notice;
using Enterprise.Model.Common.Notice;
namespace Enterprise.Service.Common.Notice
{
    /// <summary>
    /// 文件名:  NoticeInfoService.cs
    /// 功能描述: 业务逻辑层-个人备忘表数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2013-2-23 17:52:26
    /// </summary>
    public class NoticeInfoService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly INoticeData dal = new NoticeData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<NoticeModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<NoticeModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(NoticeModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 获取指定ID的差旅记录
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public NoticeModel GetModelById(int bid)
        {
            return dal.GetModelById(bid);
        }

        #endregion

        #region 静态方法区


        /// <summary>
        /// 个人备忘表中提取所有达到当前日期的备忘信息
        /// 并通知相关人员
        /// </summary>
        public static void SendNoticeToUsers()
        {
            IList<NoticeModel> noticeList = dal.GetList("from NoticeModel p where p.NISREMIND='1' and p.NREMINDTYPE is null");
            //提醒时间==当前时间（精确到分钟）
            noticeList = noticeList.Where(p => p.NREMINDTIME.ToString("yyyy-MM-dd HH:mm") == 
                DateTime.Now.ToString("yyyy-MM-dd HH:mm")).ToList();
            foreach (NoticeModel notice in noticeList)
            {
                if (!string.IsNullOrEmpty(notice.NREMINDUSERS))
                {
                    RtxService.SendRtxMessageServices(notice.NREMINDUSERS, notice.NTITLE, notice.NREMARK + "【" +
                        ((notice.NREMINDTIME != null) ? notice.NREMINDTIME.ToString("yyyy-MM-dd HH:mm") : "") + "】");
                }
                else
                {
                    RtxService.SendRtxMessageByUserId(notice.NUSERID, notice.NTITLE, notice.NREMARK + "【" +
                        ((notice.NREMINDTIME != null) ? notice.NREMINDTIME.ToString("yyyy-MM-dd HH:mm") : "") + "】");
                }
            }
            if (noticeList.Count > 0)
            {
                //更新提醒标志
                dal.UpdateStatus(noticeList);
            }
        }

        #endregion
    }
}
