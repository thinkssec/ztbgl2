using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Doc
{
    /// <summary>
    /// 通用文章模型
	/// 创建人:代码生成器
	/// 创建时间:	2013/2/26 15:10:21
    /// </summary>
    [Serializable]
    public class DocArticlesModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///Id
			/// </summary>
			public virtual int ID
			{
				get;
				set;
			}

			/// <summary>
			///发布时间
			/// </summary>
			public virtual DateTime? PUBDATE
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
			///图片信息
			/// </summary>
			public virtual string APIC
			{
				get;
				set;
			}

			/// <summary>
			///上传附件
			/// </summary>
			public virtual string UPLOADFILES
			{
				get;
				set;
			}

			/// <summary>
			///最后编辑人
			/// </summary>
			public virtual string LASTEDITOR
			{
				get;
				set;
			}

			/// <summary>
			///审批通过
			/// </summary>
			public virtual int? PASSED
			{
				get;
				set;
			}

			/// <summary>
			///点击
			/// </summary>
			public virtual int? HITS
			{
				get;
				set;
			}

			/// <summary>
			///俄语标题
			/// </summary>
			public virtual string TITLERU
			{
				get;
				set;
			}

			/// <summary>
			///分类ID
			/// </summary>
			public virtual int? CLASSID
			{
				get;
				set;
			}

			/// <summary>
			///作者
			/// </summary>
			public virtual string AUTHOR
			{
				get;
				set;
			}

			/// <summary>
			///中文内容
			/// </summary>
			public virtual string CONTENTS
			{
				get;
				set;
			}

			/// <summary>
			///关键字
			/// </summary>
			public virtual string KEYS
			{
				get;
				set;
			}

			/// <summary>
			///俄文内容
			/// </summary>
			public virtual string CONTENTSRU
			{
				get;
				set;
			}

			/// <summary>
			///推荐给领导
			/// </summary>
			public virtual int? ATUIJIAN
			{
				get;
				set;
			}

			/// <summary>
			///接收用户(备用)
			/// </summary>
			public virtual string RCVEDUSERS
			{
				get;
				set;
			}

			/// <summary>
			///置顶
			/// </summary>
			public virtual int? ATOP
			{
				get;
				set;
			}

			/// <summary>
			///发布人
			/// </summary>
			public virtual int? PUBUSER
			{
				get;
				set;
			}

			/// <summary>
			///来源
			/// </summary>
			public virtual string ARTICLEFROM
			{
				get;
				set;
			}

        #endregion
    }

}
