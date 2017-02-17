using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 分包商联系人表
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/11 11:28:04
    /// </summary>
    [Serializable]
    public class CrmFbspersonsModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///分包商联系人ID
			/// </summary>
			public virtual string PERID
			{
				get;
				set;
			}

			/// <summary>
			///职务
			/// </summary>
			public virtual string DUTY
			{
				get;
				set;
			}

			/// <summary>
			///姓名
			/// </summary>
			public virtual string NAME
			{
				get;
				set;
			}

			/// <summary>
			///性别
			/// </summary>
			public virtual string SEX
			{
				get;
				set;
			}

			/// <summary>
			///联系电话
			/// </summary>
			public virtual string PHONE
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

			/// <summary>
			///分包商ID
			/// </summary>
			public virtual string FBSID
			{
				get;
				set;
			}

			/// <summary>
			///其它联系方式
			/// </summary>
			public virtual string OTHER
			{
				get;
				set;
			}

			/// <summary>
			///电子邮件
			/// </summary>
			public virtual string EMAIL
			{
				get;
				set;
			}

        #endregion
    }

}
