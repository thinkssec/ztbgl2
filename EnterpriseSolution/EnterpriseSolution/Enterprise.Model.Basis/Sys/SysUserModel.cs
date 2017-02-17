using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 用户表
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysUserModel : BasisSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///自动编号
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///部门编号
			/// </summary>
			public virtual int DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///登录名
			/// </summary>
			public virtual string ULOGINNAME
			{
				get;
				set;
			}

			/// <summary>
			///登录密码
			/// </summary>
			public virtual string ULOGINPASS
			{
				get;
				set;
			}

			/// <summary>
			///姓名
			/// </summary>
			public virtual string UNAME
			{
				get;
				set;
			}

			/// <summary>
			///性别
			/// </summary>
			public virtual string USEX
			{
				get;
				set;
			}

			/// <summary>
			///出生日期
			/// </summary>
			public virtual DateTime UBIRTHDAY
			{
				get;
				set;
			}

			/// <summary>
			///海外电话
			/// </summary>
			public virtual string UHWPHONE
			{
				get;
				set;
			}

			/// <summary>
			///国内电话
			/// </summary>
			public virtual string UGNPHONE
			{
				get;
				set;
			}

			/// <summary>
			///sipc邮箱
			/// </summary>
			public virtual string SIPCEMAIL
			{
				get;
				set;
			}

			/// <summary>
			///其他邮箱
			/// </summary>
			public virtual string OTHEREMAIL
			{
				get;
				set;
			}

			/// <summary>
			///ip地址
			/// </summary>
			public virtual string UIP
			{
				get;
				set;
			}

			/// <summary>
			///是否是管理员
			/// </summary>
			public virtual int? UADMIN
			{
				get;
				set;
			}

			/// <summary>
			///用户状态
			/// </summary>
			public virtual int? USTATUS
			{
				get;
				set;
			}

			/// <summary>
			///排序
			/// </summary>
			public virtual int? UORDERBY
			{
				get;
				set;
			}

			/// <summary>
			///用户默认语言
			/// </summary>
			public virtual string UDEFAULTLANGUAGE
			{
				get;
				set;
			}

			/// <summary>
			///关系隶属部门
			/// </summary>
			public virtual int UAFFILIATION
			{
				get;
				set;
			}

			/// <summary>
			///关联系统1用户账号
			/// </summary>
			public virtual string USYSTEM1
			{
				get;
				set;
			}

			/// <summary>
			///关联系统2用户账号
			/// </summary>
			public virtual string USYSTEM2
			{
				get;
				set;
			}

			/// <summary>
			///关联系统3用户账号
			/// </summary>
			public virtual string USYSTEM3
			{
				get;
				set;
			}

        #endregion
    }

}
