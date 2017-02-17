using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 产品认证证书登记


	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:17
    /// </summary>
    [Serializable]
    public class ProjectCprzzsModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///产品认证ID
			/// </summary>
			public virtual string CPRZID
			{
				get;
				set;
			}

			/// <summary>
			///授予单位
			/// </summary>
			public virtual string SYDW
			{
				get;
				set;
			}

			/// <summary>
			///审批人
			/// </summary>
			public virtual int? SPR
			{
				get;
				set;
			}

			/// <summary>
			///证书名称
			/// </summary>
			public virtual string ZSMC
			{
				get;
				set;
			}

			/// <summary>
			///编制人
			/// </summary>
			public virtual int? BZR
			{
				get;
				set;
			}

			/// <summary>
			///审核意见稿
			/// </summary>
			public virtual string SHYJG
			{
				get;
				set;
			}

			/// <summary>
			///颁发日期
			/// </summary>
			public virtual DateTime? BFRQ
			{
				get;
				set;
			}

			/// <summary>
			///校对人
			/// </summary>
			public virtual int? JDR
			{
				get;
				set;
			}

			/// <summary>
			///审核人
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///证书编号
			/// </summary>
			public virtual string ZSBH
			{
				get;
				set;
			}

			/// <summary>
			///附件
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///证书内容
			/// </summary>
			public virtual string ZSNR
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
			///质量得分
			/// </summary>
			public virtual decimal? ZLDF
			{
				get;
				set;
			}

			/// <summary>
			///审核意见
			/// </summary>
			public virtual string SHYJ
			{
				get;
				set;
			}

            /// <summary>
            ///当前状态：0=未审核 1=审核通过  2=审核不通过
            /// </summary>
            public virtual int? PRTSTATUS
            {
                get;
                set;
            }

            /// <summary>
            ///提交人
            /// </summary>
            public virtual int? SUBMITTER
            {
                get;
                set;
            }

        #endregion
    }

}
