using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Dmgl
{
    /// <summary>
    /// 施工进度
	/// 创建人:代码生成器
	/// 创建时间:	2015/5/17 17:23:42
    /// </summary>
    [Serializable]
    public class DmglSgjdModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string JID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PID
			{
				get;
				set;
			}

			/// <summary>
			///录入时间
			/// </summary>
			public virtual DateTime? JTIME
			{
				get;
				set;
			}

			/// <summary>
			///施工进度
			/// </summary>
			public virtual string DETAIL
			{
				get;
				set;
			}

			/// <summary>
			///-2:临时保存
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

        #endregion
    }

}
