using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Goods
{
    /// <summary>
    /// 设备电子档案
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:11
    /// </summary>
    [Serializable]
    public class GoodsDeviceModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///设备表ID
			/// </summary>
			public virtual string SBID
			{
				get;
				set;
			}

			/// <summary>
			///原值
			/// </summary>
			public virtual decimal? YZ
			{
				get;
				set;
			}

			/// <summary>
			///单位
			/// </summary>
			public virtual string DW
			{
				get;
				set;
			}

			/// <summary>
			///设备名称
			/// </summary>
			public virtual string SBMC
			{
				get;
				set;
			}

			/// <summary>
			///购置日期
			/// </summary>
			public virtual DateTime? GZRQ
			{
				get;
				set;
			}

			/// <summary>
			///备注
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///出厂编号
			/// </summary>
			public virtual string CCBH
			{
				get;
				set;
			}

			/// <summary>
			///数量
			/// </summary>
			public virtual int? SL
			{
				get;
				set;
			}

			/// <summary>
			///设备编码
			/// </summary>
			public virtual string SBBM
			{
				get;
				set;
			}

			/// <summary>
			///物资类别
			/// </summary>
			public virtual string KINDID
			{
				get;
				set;
			}

			/// <summary>
			///制造厂家
			/// </summary>
			public virtual string ZZCJ
			{
				get;
				set;
			}

			/// <summary>
			///规格型号
			/// </summary>
			public virtual string GGXH
			{
				get;
				set;
			}

        #endregion
    }

}
