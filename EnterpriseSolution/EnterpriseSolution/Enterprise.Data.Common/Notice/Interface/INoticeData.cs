using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Notice;
namespace Enterprise.Data.Common.Notice
{
    /// <summary>
    /// 文件名:  INoticeData.cs
    /// 功能描述: 数据层-个人备忘数据访问接口
    /// 创建人：caitou
    /// 创建日期: 2013.2.27
    /// </summary>
    public interface INoticeData:IDataCommon<NoticeModel>
    {
        /// <summary>
        /// 获取指定ID的记录
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        NoticeModel GetModelById(int bid);

        /// <summary>
        /// 个人备忘操作方法（批量更新状态）
        /// </summary>
        /// <param name="modelLst">对象集合</param>
        /// <returns></returns>
        bool UpdateStatus(IList<NoticeModel> modelLst);
    }
}
