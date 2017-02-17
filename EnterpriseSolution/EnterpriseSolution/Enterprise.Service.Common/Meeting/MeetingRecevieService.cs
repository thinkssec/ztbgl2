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
    /// �ļ���:  MeetingRecevieService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/3/1 15:50:39
    /// </summary>
    public class MeetingRecevieService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IMeetingRecevieData dal = new MeetingRecevieData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(MeetingRecevieModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
