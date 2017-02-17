using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// �������
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:12
    /// </summary>
    [Serializable]
    public class SysCacheModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///��������
			/// </summary>
			public virtual string CACHENAME
			{
				get;
				set;
			}

			/// <summary>
			///�û���
			/// </summary>
			public virtual string USERNAME
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string TABLENAME
			{
				get;
				set;
			}

			/// <summary>
			///����˵��
			/// </summary>
			public virtual string CACHEDESCRIBE
			{
				get;
				set;
			}

        #endregion
    }

}
