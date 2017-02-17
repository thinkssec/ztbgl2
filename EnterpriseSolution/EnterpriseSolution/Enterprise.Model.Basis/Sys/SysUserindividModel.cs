using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ���Ի����ñ�
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:14
    /// </summary>
    [Serializable]
    public class SysUserindividModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�û�ID
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///ǩ��ͼƬ·��
			/// </summary>
			public virtual string SIGNPIC
			{
				get;
				set;
			}

			/// <summary>
			///��ҳͼ����
			/// </summary>
			public virtual string INDEXCHART
			{
				get;
				set;
			}

			/// <summary>
			///��ҳͼ��Ȩ��ֵ
			/// </summary>
			public virtual int? CHARTPOWER
			{
				get;
				set;
			}

			/// <summary>
			///���Ի�1
			/// </summary>
			public virtual string SPECIAL1
			{
				get;
				set;
			}

			/// <summary>
			///���Ի�2
			/// </summary>
			public virtual string SPECIAL2
			{
				get;
				set;
			}

			/// <summary>
			///���Ի�3
			/// </summary>
			public virtual string SPECIAL3
			{
				get;
				set;
			}

			/// <summary>
			///���Ի�4
			/// </summary>
			public virtual string SPECIAL4
			{
				get;
				set;
			}

			/// <summary>
			///���Ի�5
			/// </summary>
			public virtual string SPECIAL5
			{
				get;
				set;
			}

        #endregion
    }

}
