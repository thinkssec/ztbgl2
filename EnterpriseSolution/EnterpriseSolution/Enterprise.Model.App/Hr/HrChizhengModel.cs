using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hr
{
    /// <summary>
    /// ��Ա��֤��Ϣ��
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:12
    /// </summary>
    [Serializable]
    public class HrChizhengModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��֤��ID
			/// </summary>
			public virtual string CZID
			{
				get;
				set;
			}

			/// <summary>
			///֤������
			/// </summary>
			public virtual string ZSLX
			{
				get;
				set;
			}

			/// <summary>
			///֤����
			/// </summary>
			public virtual string ZSBH
			{
				get;
				set;
			}

			/// <summary>
			///֤����Ч��
			/// </summary>
			public virtual decimal? ZSYXQ
			{
				get;
				set;
			}

			/// <summary>
			///֤�鲹����
			/// </summary>
			public virtual decimal? ZSBTE
			{
				get;
				set;
			}

			/// <summary>
			///֤��Ӱӡ��
			/// </summary>
			public virtual string ZSYYJ
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
			///֤��䷢����
			/// </summary>
			public virtual DateTime? ZSBFRQ
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

        #endregion

            #region �����������

            /// <summary>
            /// ҵ����������--����ʵ��  
            /// </summary>
            public virtual Enterprise.Model.Basis.Sys.SysUserModel HrUser { get; set; }

            #endregion
    }

}
