using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hr
{
    /// <summary>
    /// 人员持证信息表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:12
    /// </summary>
    [Serializable]
    public class HrChizhengModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///持证表ID
			/// </summary>
			public virtual string CZID
			{
				get;
				set;
			}

			/// <summary>
			///证书类型
			/// </summary>
			public virtual string ZSLX
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
			///证书有效期
			/// </summary>
			public virtual decimal? ZSYXQ
			{
				get;
				set;
			}

			/// <summary>
			///证书补贴额
			/// </summary>
			public virtual decimal? ZSBTE
			{
				get;
				set;
			}

			/// <summary>
			///证书影印件
			/// </summary>
			public virtual string ZSYYJ
			{
				get;
				set;
			}

			/// <summary>
			///用户ID
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///证书颁发日期
			/// </summary>
			public virtual DateTime? ZSBFRQ
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

        #endregion

            #region 外键关联对象

            /// <summary>
            /// 业务流基础表--对象实例  
            /// </summary>
            public virtual Enterprise.Model.Basis.Sys.SysUserModel HrUser { get; set; }

            #endregion
    }

}
