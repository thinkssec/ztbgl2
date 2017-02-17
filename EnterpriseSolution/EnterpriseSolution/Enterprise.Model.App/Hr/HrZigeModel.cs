using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hr
{
    /// <summary>
    /// ��Ա�ʸ��
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:12
    /// </summary>
    [Serializable]
    public class HrZigeModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string ZGID
			{
				get;
				set;
			}

			/// <summary>
			///���������
			/// </summary>
			public virtual int? BGSHR
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ������
			/// </summary>
			public virtual int? XMFZR
			{
				get;
				set;
			}

			/// <summary>
			///��������1
			/// </summary>
			public virtual int? QTZZ1
			{
				get;
				set;
			}

			/// <summary>
			///�û�ID
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///��������2
			/// </summary>
			public virtual int? QTZZ2
			{
				get;
				set;
			}

			/// <summary>
			///��ͼ������
			/// </summary>
			public virtual int? STFZR
			{
				get;
				set;
			}

			/// <summary>
			///��������ID
			/// </summary>
			public virtual int KINDID
			{
				get;
				set;
			}

			/// <summary>
			///������׼��
			/// </summary>
			public virtual int? BGPZR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SDRQ
			{
				get;
				set;
			}
            /// <summary>
            ///�����д��
            /// </summary>
            public virtual int? BGBXR
            {
                get;
                set;
            }
            /// <summary>
            ///����У����
            /// </summary>
            public virtual int? BGJDR
            {
                get;
                set;
            }
            /// <summary>
            ///��������
            /// </summary>
            public virtual int? SJSCR
            {
                get;
                set;
            }

        #endregion

            public virtual Model.Basis.Sys.SysUserModel SysUserModel { get; set; }
    }

}
