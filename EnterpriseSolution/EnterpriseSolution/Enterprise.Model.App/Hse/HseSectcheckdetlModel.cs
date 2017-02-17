using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hse
{
    /// <summary>
    /// 安全检查明细表
	/// 创建人:代码生成器
	/// 创建时间:	2015/5/7 8:12:54
    /// </summary>
    [Serializable]
    public class HseSectcheckdetlModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string CKDID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string CKID
			{
				get;
				set;
			}

			/// <summary>
			///检查地点
			/// </summary>
			public virtual string CWHERE
			{
				get;
				set;
			}

			/// <summary>
			///问题描述
			/// </summary>
			public virtual string DETAIL
			{
				get;
				set;
			}

			/// <summary>
			///负责
			/// </summary>
			public virtual string CHARGE
			{
				get;
				set;
			}

			/// <summary>
			///-2: 当前用户最近保存的没有完成的记录 -1:临时保存 0：已提交安全整改 1：提交验收
			/// </summary>
			public virtual int? STATUS
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
			///整改情况
			/// </summary>
			public virtual string PRESENT
			{
				get;
				set;
			}

			/// <summary>
			///完成时间
			/// </summary>
			public virtual DateTime? COMPLETEDATE
			{
				get;
				set;
			}

			/// <summary>
			///附件文件名称
			/// </summary>
			public virtual string FNAMES
			{
				get;
				set;
			}

			/// <summary>
			///附件保存名称
			/// </summary>
			public virtual string FVIEWNAMES
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SUBMITDATE
			{
				get;
				set;
			}

        #endregion
    }

}
