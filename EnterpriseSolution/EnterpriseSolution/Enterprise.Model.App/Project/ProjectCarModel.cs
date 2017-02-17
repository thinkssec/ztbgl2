using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目车辆表
	/// 创建人:代码生成器
	/// 创建时间:	2014/6/19 15:35:13
    /// </summary>
    [Serializable]
    public class ProjectCarModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///CARID
			/// </summary>
			public virtual string CARID
			{
				get;
				set;
			}

			/// <summary>
			///司机
			/// </summary>
			public virtual string SJ
			{
				get;
				set;
			}

			/// <summary>
			///累计行驶里程
			/// </summary>
			public virtual int? LJXSLC
			{
				get;
				set;
			}

			/// <summary>
			///记录日期
			/// </summary>
			public virtual DateTime? JLRQ
			{
				get;
				set;
			}

			/// <summary>
			///说明
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///记录人
			/// </summary>
			public virtual string JLR
			{
				get;
				set;
			}

			/// <summary>
			///当日是否保养
			/// </summary>
			public virtual int? DRSFBY
			{
				get;
				set;
			}

			/// <summary>
			///里程表读数
			/// </summary>
			public virtual int? LCBDS
			{
				get;
				set;
			}

			/// <summary>
			///车号
			/// </summary>
			public virtual string CH
			{
				get;
				set;
			}

			/// <summary>
			///累计保养次数
			/// </summary>
			public virtual int? LJBYCS
			{
				get;
				set;
			}

			/// <summary>
			///车辆状态： -1=进场 0=运行 1=退场 2=维修保养 3=闲置
			/// </summary>
			public virtual int? CLZT
			{
				get;
				set;
			}

			/// <summary>
			///行驶里程
			/// </summary>
			public virtual int? XSLC
			{
				get;
				set;
			}

			/// <summary>
			///当日加油量
			/// </summary>
			public virtual decimal? DRJYL
			{
				get;
				set;
			}

			/// <summary>
			///车辆型号
			/// </summary>
			public virtual string CLXH
			{
				get;
				set;
			}

			/// <summary>
			///项目ID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

        #endregion
    }

}
