using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// �ֵ��
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysDictionaryModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual string DID
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string ZWMC
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string YZ
			{
				get;
				set;
			}

			/// <summary>
			///��Ӧ����
			/// </summary>
			public virtual string DYMC
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string SSZB
			{
				get;
				set;
			}

        #endregion
    }

}
