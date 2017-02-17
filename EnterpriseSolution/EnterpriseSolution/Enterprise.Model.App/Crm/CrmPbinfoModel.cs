using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// 乙方单位信息表
	/// 创建人:代码生成器
	/// 创建时间:	2014/3/31 17:15:59
    /// </summary>
    [Serializable]
    public class CrmPbinfoModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///单位编码
			/// </summary>
			public virtual string PBBM
			{
				get;
				set;
			}

			/// <summary>
			///邮编
			/// </summary>
			public virtual string POSTCODE
			{
				get;
				set;
			}

			/// <summary>
			///通讯地址
			/// </summary>
			public virtual string ADDR
			{
				get;
				set;
			}

			/// <summary>
			///类别编号
			/// </summary>
			public virtual string LBBH
			{
				get;
				set;
			}

			/// <summary>
			///质量管理体系认证证书
			/// </summary>
			public virtual string ZLZS
			{
				get;
				set;
			}

			/// <summary>
			///税务登记号
			/// </summary>
			public virtual string SWDJH
			{
				get;
				set;
			}

			/// <summary>
			///经营范围
			/// </summary>
			public virtual string JYFW
			{
				get;
				set;
			}

			/// <summary>
			///入网证号
			/// </summary>
			public virtual string RWZH
			{
				get;
				set;
			}

			/// <summary>
			///组织机构代码证
			/// </summary>
			public virtual string ZZJGDMZ
			{
				get;
				set;
			}

			/// <summary>
			///资质证
			/// </summary>
			public virtual string ZZZS
			{
				get;
				set;
			}

			/// <summary>
			///许可证
			/// </summary>
			public virtual string XKZS
			{
				get;
				set;
			}

			/// <summary>
			///法定代表人
			/// </summary>
			public virtual string FDDBR
			{
				get;
				set;
			}

			/// <summary>
			///备注
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///营业执照号
			/// </summary>
			public virtual string YYZZH
			{
				get;
				set;
			}

			/// <summary>
			///电话
			/// </summary>
			public virtual string PHONE
			{
				get;
				set;
			}

			/// <summary>
			///单位名称
			/// </summary>
			public virtual string PBMC
			{
				get;
				set;
			}

			/// <summary>
			///联系人
			/// </summary>
			public virtual string CONTACTS
			{
				get;
				set;
			}

			/// <summary>
			///当前状态: 1=有效 0=无效
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

        #endregion
    }

}
