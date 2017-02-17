using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Meeting;

namespace Enterprise.Data.Common.Meeting
{	

    /// <summary>
    /// 文件名:  IMeetingRecevieData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/3/1 15:50:39
    /// </summary>
    public interface IMeetingRecevieData : IDataCommon<MeetingRecevieModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="hql">Nhibernate HQL,如果hql为空 返回所有数据</param>
        /// <returns></returns>
        IList<MeetingRecevieModel> GetListByHQL(string hql);

        #endregion
    }

}
