using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 消防设备列表
	/// 创建人:代码生成器
	/// 创建时间:	2013/11/20 11:34:33
    /// </summary>
    [Serializable]
    public class ProjectXfsbModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///规格
			/// </summary>
			public virtual string GG
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
			///启用日期
			/// </summary>
			public virtual DateTime? QYRQ
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
			///备注
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///责任人
			/// </summary>
			public virtual string ZRR
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
