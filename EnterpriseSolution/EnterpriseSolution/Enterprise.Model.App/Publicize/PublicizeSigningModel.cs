using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Publicize
{
    /// <summary>
    /// 宣传报道签收表
	/// 创建人:代码生成器
	/// 创建时间:	2014/2/8 10:32:29
    /// </summary>
    [Serializable]
    public class PublicizeSigningModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///签收ID
			/// </summary>
			public virtual string SIGNID
			{
				get;
				set;
			}

			/// <summary>
			///签收日期
			/// </summary>
			public virtual DateTime? SINGDATE
			{
				get;
				set;
			}

			/// <summary>
			///签收人
			/// </summary>
			public virtual int? SIGNUSER
			{
				get;
				set;
			}

			/// <summary>
			///投稿ID
			/// </summary>
			public virtual string PUBID
			{
				get;
				set;
			}

        #endregion
    }

}
