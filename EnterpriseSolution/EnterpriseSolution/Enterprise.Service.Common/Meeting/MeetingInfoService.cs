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
    /// �ļ���:  MeetingInfoService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/1 15:50:38
    /// </summary>
    public class MeetingInfoService
    {
        
        #region ����������
        
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IMeetingInfoData dal = new MeetingInfoData();
        /// <summary>
        /// ����ǩ�����--������
        /// </summary>
        private static readonly MeetingRecevieService mrService = new MeetingRecevieService();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<MeetingInfoModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<MeetingInfoModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(MeetingInfoModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ���ɻ���ID
        /// </summary>
        /// <returns></returns>
        public int GetMeeting_ID()
        {
            return dal.GetMeeting_ID();
        }

        #endregion

        /// <summary>
        ///  ����δǩ���б�
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
