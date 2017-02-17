using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Busitravel;

namespace Enterprise.Data.Common.Busitravel
{	

    /// <summary>
    /// 文件名:  IBusitravelInfoData.cs
    /// 功能描述: 数据层-差旅申请表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-2-23 17:52:26
    /// </summary>
    public interface IBusitravelInfoData : IDataCommon<BusitravelInfoModel>
    {
        #region 代码生成器

        /// <summary>
        /// 获取指定ID的差旅记录
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        BusitravelInfoModel GetModelById(string bid);

        #endregion
    }

}
