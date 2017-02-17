using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目设备表
	/// 创建人:代码生成器
	/// 创建时间:	2014/6/19 15:35:19
    /// </summary>
    [Serializable]
    public class ProjectDeviceModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///设备ID
			/// </summary>
			public virtual string DEVID
			{
				get;
				set;
			}

			/// <summary>
			///保管人
			/// </summary>
			public virtual string BGR
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
			///数量
			/// </summary>
			public virtual int? SBSL
			{
				get;
				set;
			}

			/// <summary>
			///累计运行小时
			/// </summary>
			public virtual int? LJYXSJ
			{
				get;
				set;
			}

			/// <summary>
			///检定周期
			/// </summary>
			public virtual string JDZQ
			{
				get;
				set;
			}

			/// <summary>
			///型号
			/// </summary>
			public virtual string SBXH
			{
				get;
				set;
			}

			/// <summary>
			///运行状态
			/// </summary>
			public virtual string YXZT
			{
				get;
				set;
			}

			/// <summary>
			///运行小时
			/// </summary>
			public virtual int? YXSJ
			{
				get;
				set;
			}

			/// <summary>
            ///设备状态： -1=进场 0=运行 1=调离 2=维修保养 3=闲置
			/// </summary>
			public virtual int? SBZT
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
