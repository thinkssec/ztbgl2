using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hr
{
    /// <summary>
    /// ��Ƹ��Ա��֤��Ϣ��
	/// ������:����������
	/// ����ʱ��:	2014/2/27 17:05:07
    /// </summary>
    [Serializable]
    public class HrChizhengwpModel : AppSuperModel
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
			///��������
			/// </summary>
			public virtual string DEPNAME
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
			///�û�����
			/// </summary>
			public virtual string USERNAME
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
    }

}
