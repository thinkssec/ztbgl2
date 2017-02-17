using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hse
{
    /// <summary>
    /// 安全检查表
	/// 创建人:代码生成器
	/// 创建时间:	2015/5/8 7:58:50
    /// </summary>
    [Serializable]
    public class HseSectcheckModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string CKID
			{
				get;
				set;
			}

			/// <summary>
			///受检单位
			/// </summary>
			public virtual string CTARGET
			{
				get;
				set;
			}

			/// <summary>
			///检查级别
			/// </summary>
			public virtual string CLEVEL
			{
				get;
				set;
			}

			/// <summary>
			///检查人员，多选
			/// </summary>
			public virtual string CHECKER
			{
				get;
				set;
			}

			/// <summary>
			///检查日期
			/// </summary>
			public virtual DateTime? CDATE
			{
				get;
				set;
			}

			/// <summary>
			///限定完成日期
			/// </summary>
			public virtual DateTime? ENDDATE
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

			/// <summary>
			///发送短信1：发0：不发
			/// </summary>
			public virtual int? SMSG
			{
				get;
				set;
			}

			/// <summary>
			///-2: 当前用户最近保存的没有完成的记录 -1:临时保存 0：已提交安全整改 1：提交单位负责人验收
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///实际完成时间
			/// </summary>
			public virtual DateTime? COMPLETEDATE
			{
				get;
				set;
			}

			/// <summary>
			///安全隐患接受人
			/// </summary>
			public virtual int? RECIEVER
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
			///验收人单位负责人
			/// </summary>
			public virtual int? SHR1
			{
				get;
				set;
			}

			/// <summary>
			///验收提交时间
			/// </summary>
			public virtual DateTime? SH1SUBMITIME
			{
				get;
				set;
			}

			/// <summary>
			///验收时间
			/// </summary>
			public virtual DateTime? SH1TIME
			{
				get;
				set;
			}

			/// <summary>
			///结果
			/// </summary>
			public virtual int? SH1STATUS
			{
				get;
				set;
			}

			/// <summary>
			///内容
			/// </summary>
			public virtual string SH1CONTENT
			{
				get;
				set;
			}

			/// <summary>
			///单位安全员
			/// </summary>
			public virtual int? SHR2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SH2SUBMITIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SH2TIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SH2STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SH2CONTENT
			{
				get;
				set;
			}

			/// <summary>
			///安全承包人 
			/// </summary>
			public virtual int? SHR3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SH3SUBMITIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SH3TIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SH3STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SH3CONTENT
			{
				get;
				set;
			}

        #endregion
    }

}
