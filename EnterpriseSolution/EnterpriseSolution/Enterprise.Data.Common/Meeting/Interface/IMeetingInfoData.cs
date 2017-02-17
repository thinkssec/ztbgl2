using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Meeting;

namespace Enterprise.Data.Common.Meeting
{	

    /// <summary>
    /// �ļ���:  IMeetingInfoData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/3/1 15:50:38
    /// </summary>
    public interface IMeetingInfoData : IDataCommon<MeetingInfoModel>
    {
        #region ����������
        /// <summary>
        /// ���ɻ���ID
        /// </summary>
        /// <returns></returns>
        int GetMeeting_ID();
        #endregion
    }

}
