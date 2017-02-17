using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目变更记录表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:13
    /// </summary>
    [Serializable]
    public class ProjectChangeModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///项目变更ID
			/// </summary>
			public virtual string CHANGEID
			{
				get;
				set;
			}

			/// <summary>
			///变更类型
			/// </summary>
			public virtual int? CHANGETYPE
			{
				get;
				set;
			}

			/// <summary>
			///变更日期
			/// </summary>
			public virtual DateTime? CHANGEDATE
			{
				get;
				set;
			}

			/// <summary>
			///审核状态
			/// </summary>
			public virtual int? AUDITSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///变更说明
			/// </summary>
			public virtual string CHANGEMEMO
			{
				get;
				set;
			}

			/// <summary>
			///变更状态
			/// </summary>
			public virtual int? CHANGESTATUS
			{
				get;
				set;
			}

			/// <summary>
			///申请人
			/// </summary>
			public virtual int? REQUESTOR
			{
				get;
				set;
			}

			/// <summary>
			///原来内容
			/// </summary>
			public virtual string OLDCONTS
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
			///项目ID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///审核日期
			/// </summary>
			public virtual DateTime? AUDITDATE
			{
				get;
				set;
			}

			/// <summary>
			///变更内容
			/// </summary>
			public virtual string NEWCONTS
			{
				get;
				set;
			}

        #endregion
    }

}
