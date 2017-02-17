using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 专家库
	/// 创建人:代码生成器
	/// 创建时间:	2015/6/22 1:09:39
    /// </summary>
    [Serializable]
    public class CrmPersonModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string PERSONID
			{
				get;
				set;
			}

			/// <summary>
			///信息表ID
			/// </summary>
			public virtual int? DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///联系人
			/// </summary>
			public virtual string PERSONNAME
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
			///手机
			/// </summary>
			public virtual string MOBILEPHONE
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

			/// <summary>
			///
			/// </summary>
			public virtual string SEX
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string HOMETOWN
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? BIRTHDAY
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string DEPTNAME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string DEPTDUTY
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SCHOOL
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string ADDRESS
			{
				get;
				set;
			}

			/// <summary>
			///邮政编码1
			/// </summary>
			public virtual string POSTCODE
			{
				get;
				set;
			}

			/// <summary>
			///优先级
			/// </summary>
			public virtual int MAIN
			{
				get;
				set;
			}

			/// <summary>
			///1:技术评委2经济评委 3需求评委 4不区分
			/// </summary>
			public virtual int LB
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? USRID
			{
				get;
				set;
			}

			/// <summary>
			///1:删除
			/// </summary>
			public virtual int? DEL
			{
				get;
				set;
			}

        #endregion
    }

}
