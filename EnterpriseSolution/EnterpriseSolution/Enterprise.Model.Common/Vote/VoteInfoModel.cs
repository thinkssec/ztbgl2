using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Vote
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/3/1 10:30:48
    /// </summary>
    [Serializable]
    public class VoteInfoModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
           ///  自动编号
			/// </summary>
			public virtual string VID
			{
				get;
				set;
			}

			/// <summary>
			///  最小值
			/// </summary>
			public virtual int? VMIX
			{
				get;
				set;
			}

			/// <summary>
			///  备注
			/// </summary>
			public virtual string VREMARK
			{
				get;
				set;
			}

			/// <summary>
			///  最大值
			/// </summary>
			public virtual int? VMAX
			{
				get;
				set;
			}

			/// <summary>
			///  是否发布
			/// </summary>
			public virtual int? VPUBLIC
			{
				get;
				set;
			}

			/// <summary>
			///  主题
			/// </summary>
			public virtual string VTITLE
			{
				get;
				set;
			}

			/// <summary>
			/// 创建人
			/// </summary>
			public virtual int? VCREATEUSER
			{
				get;
				set;
			}

			/// <summary>
			///  结束时间
			/// </summary>
			public virtual DateTime? VENDTIME
			{
				get;
				set;
			}

			/// <summary>
			///  发布时间
			/// </summary>
			public virtual DateTime? VPUBLICTIME
			{
				get;
				set;
			}

			/// <summary>
			///  范围
			/// </summary>
			public virtual string VRANGE
			{
				get;
				set;
			}

			/// <summary>
			/// 创建时间
			/// </summary>
			public virtual DateTime? VCREATETIME
			{
				get;
				set;
			}

			/// <summary>
			///  类型
			/// </summary>
			public virtual int? VTYPE
			{
				get;
				set;
			}

        #endregion
    }

}
