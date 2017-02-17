using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// �û���
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysUserModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///���ű��
			/// </summary>
			public virtual int DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///��¼��
			/// </summary>
			public virtual string ULOGINNAME
			{
				get;
				set;
			}

			/// <summary>
			///��¼����
			/// </summary>
			public virtual string ULOGINPASS
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string UNAME
			{
				get;
				set;
			}

			/// <summary>
			///�Ա�
			/// </summary>
			public virtual string USEX
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime UBIRTHDAY
			{
				get;
				set;
			}

			/// <summary>
			///����绰
			/// </summary>
			public virtual string UHWPHONE
			{
				get;
				set;
			}

			/// <summary>
			///���ڵ绰
			/// </summary>
			public virtual string UGNPHONE
			{
				get;
				set;
			}

			/// <summary>
			///sipc����
			/// </summary>
			public virtual string SIPCEMAIL
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string OTHEREMAIL
			{
				get;
				set;
			}

			/// <summary>
			///ip��ַ
			/// </summary>
			public virtual string UIP
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ��ǹ���Ա
			/// </summary>
			public virtual int? UADMIN
			{
				get;
				set;
			}

			/// <summary>
			///�û�״̬
			/// </summary>
			public virtual int? USTATUS
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? UORDERBY
			{
				get;
				set;
			}

			/// <summary>
			///�û�Ĭ������
			/// </summary>
			public virtual string UDEFAULTLANGUAGE
			{
				get;
				set;
			}

			/// <summary>
			///��ϵ��������
			/// </summary>
			public virtual int UAFFILIATION
			{
				get;
				set;
			}

			/// <summary>
			///����ϵͳ1�û��˺�
			/// </summary>
			public virtual string USYSTEM1
			{
				get;
				set;
			}

			/// <summary>
			///����ϵͳ2�û��˺�
			/// </summary>
			public virtual string USYSTEM2
			{
				get;
				set;
			}

			/// <summary>
			///����ϵͳ3�û��˺�
			/// </summary>
			public virtual string USYSTEM3
			{
				get;
				set;
			}

        #endregion
    }

}
