using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 乙方单位类别表
	/// 创建人:代码生成器
	/// 创建时间:	2014/3/31 17:16:03
    /// </summary>
    [Serializable]
    public class CrmPbkindModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///类别编号
			/// </summary>
			public virtual string LBBH
			{
				get;
				set;
			}

			/// <summary>
			///类别名称
			/// </summary>
			public virtual string LBMC
			{
				get;
				set;
			}

			/// <summary>
			///上级类别
			/// </summary>
			public virtual string SJLB
			{
				get;
				set;
			}

			/// <summary>
			///类别序号
			/// </summary>
			public virtual int? LBXH
			{
				get;
				set;
			}

        #endregion
    }

}
