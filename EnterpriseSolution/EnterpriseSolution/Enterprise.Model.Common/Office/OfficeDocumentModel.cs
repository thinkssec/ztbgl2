using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Office
{
    /// <summary>
    /// 公文流转表
	/// 创建人:代码生成器
	/// 创建时间:	2013-2-27 21:01:28
    /// </summary>
    [Serializable]
    public class OfficeDocumentModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual string ODID
			{
				get;
				set;
			}

			/// <summary>
			///签收人员
			/// </summary>
			public virtual string ODQSUSERS
			{
				get;
				set;
			}

			/// <summary>
			///发布时间
			/// </summary>
			public virtual DateTime? ODPUBLICTIME
			{
				get;
				set;
			}

			/// <summary>
			///审核人
			/// </summary>
			public virtual string ODCHECKERS
			{
				get;
				set;
			}

			/// <summary>
			///中文摘要说明
			/// </summary>
			public virtual string ODCREMARK
			{
				get;
				set;
			}

			/// <summary>
            ///公文是否发布 0=未发布 1=已发布
			/// </summary>
			public virtual int? ODISPUBLIC
			{
				get;
				set;
			}

			/// <summary>
			///公文类型 0：单位起草 1：其他来文
			/// </summary>
			public virtual int? ODTYPEID
			{
				get;
				set;
			}

			/// <summary>
			///中文标题
			/// </summary>
			public virtual string ODCNAME
			{
				get;
				set;
			}

			/// <summary>
			///来文人
			/// </summary>
			public virtual string ODFROMUSER
			{
				get;
				set;
			}

			/// <summary>
			///来文时间
			/// </summary>
			public virtual string ODFROMTIME
			{
				get;
				set;
			}

			/// <summary>
			///公文编号
			/// </summary>
			public virtual string ODCODE
			{
				get;
				set;
			}

			/// <summary>
			///公文类型
			/// </summary>
			public virtual string ODTYPE
			{
				get;
				set;
			}

			/// <summary>
			///附件
			/// </summary>
			public virtual string ODFILES
			{
				get;
				set;
			}

			/// <summary>
			///部门编号
			/// </summary>
			public virtual int? ODDEPTID
			{
				get;
				set;
			}

			/// <summary>
			///来文编号
			/// </summary>
			public virtual string ODFROMCODE
			{
				get;
				set;
			}

			/// <summary>
			///来文单位
			/// </summary>
			public virtual string ODFROM
			{
				get;
				set;
			}

			/// <summary>
			///俄文摘要说明
			/// </summary>
			public virtual string ODRREMARK
			{
				get;
				set;
			}

			/// <summary>
			///俄文标题
			/// </summary>
			public virtual string ODRNAME
			{
				get;
				set;
			}

			/// <summary>
			///人员编号
			/// </summary>
			public virtual int? ODUSERID
			{
				get;
				set;
			}

			/// <summary>
            ///申请状态 0=未审核 1=已审核 2=审核不通过
			/// </summary>
			public virtual int? ODSTATE
			{
				get;
				set;
			}

			/// <summary>
			///建立日期
			/// </summary>
			public virtual DateTime? ODCREATETIME
			{
				get;
				set;
			}

        #endregion
    }

}
