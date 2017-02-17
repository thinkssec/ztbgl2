using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// 公文表
	/// 创建人:代码生成器
	/// 创建时间:	2015/4/22 16:23:51
    /// </summary>
    [Serializable]
    public class DocumentOfficialModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string DOCID
			{
				get;
				set;
			}
            public virtual string FNAMES
            {
                get;
                set;
            }
            public virtual string FVIEWNAMES
            {
                get;
                set;
            }

			/// <summary>
			///标题
			/// </summary>
			public virtual string TITLE
			{
				get;
				set;
			}

			/// <summary>
			///发布日期
			/// </summary>
			public virtual DateTime? RELEASETIME
			{
				get;
				set;
			}

			/// <summary>
			///创建人
			/// </summary>
			public virtual int? CREATEUSER
			{
				get;
				set;
			}

			/// <summary>
			///创建日期
			/// </summary>
			public virtual DateTime? CREATETIME
			{
				get;
				set;
			}
            public virtual DateTime? RESULTDATE
            {
                get;
                set;
            }

			/// <summary>
			///签收领导
			/// </summary>
			public virtual int? RECEVIEUSER
			{
				get;
				set;
			}

			/// <summary>
			///中文内容
			/// </summary>
			public virtual string CONTENT
			{
				get;
				set;
			}

			/// <summary>
			///承办要求
			/// </summary>
			public virtual string REQUIREMENT
			{
				get;
				set;
			}

			/// <summary>
			///要求完成日期
			/// </summary>
			public virtual DateTime? COMPLETEDATE
			{
				get;
				set;
			}

			/// <summary>
			///承办人
			/// </summary>
			public virtual int? ORGANIZER
			{
				get;
				set;
			}

			/// <summary>
			///0:创建 1：签收 2：提交承办 3：提交承办结果 
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///1:通过 2：返回
			/// </summary>
			public virtual int? SHSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///承办结果
			/// </summary>
			public virtual string RESULT
			{
				get;
				set;
			}

			/// <summary>
			///审核人，默认为签收领导
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///审核日期
			/// </summary>
			public virtual DateTime? SHSJ
			{
				get;
				set;
			}

			/// <summary>
			///不通过原因
			/// </summary>
			public virtual string WHY
			{
				get;
				set;
			}

			/// <summary>
			///创建单位
			/// </summary>
			public virtual int? CREATEDEPT
			{
				get;
				set;
			}

        #endregion
    }

}
