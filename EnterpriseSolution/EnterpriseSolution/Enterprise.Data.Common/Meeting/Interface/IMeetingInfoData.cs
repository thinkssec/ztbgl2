using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Meeting;

namespace Enterprise.Data.Common.Meeting
{	

    /// <summary>
    /// 文件名:  IMeetingInfoData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/3/1 15:50:38
    /// </summary>
    public interface IMeetingInfoData : IDataCommon<MeetingInfoModel>
    {
        #region 代码生成器
        /// <summary>
        /// 生成会议ID
        /// </summary>
        /// <returns></returns>
        int GetMeeting_ID();
        #endregion
    }

}
