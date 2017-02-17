using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 分包商信息表
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/11 11:28:03
    /// </summary>
    [Serializable]
    public class CrmFbsinfoModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///分包商ID
			/// </summary>
			public virtual string FBSID
			{
				get;
				set;
			}

			/// <summary>
			///分包商编号
			/// </summary>
			public virtual string FBSBH
			{
				get;
				set;
			}

			/// <summary>
			///通信地址
			/// </summary>
			public virtual string TXDZ
			{
				get;
				set;
			}

			/// <summary>
			///分包商资质
			/// </summary>
			public virtual string FBSZZ
			{
				get;
				set;
			}

			/// <summary>
			///所属市场区域
			/// </summary>
			public virtual string SCQY
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
			///分包商名称
			/// </summary>
			public virtual string FBSMC
			{
				get;
				set;
			}

			/// <summary>
			///企业简介
			/// </summary>
			public virtual string QYJJ
			{
				get;
				set;
			}

			/// <summary>
			///企业类型
			/// </summary>
			public virtual string QYLX
			{
				get;
				set;
			}

        #endregion
    }

}
