using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ���������ϵ��
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:12
    /// </summary>
    [Serializable]
    public class SysCacherelationModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///��ϵID
			/// </summary>
			public virtual string CACHEID
			{
				get;
				set;
			}

			/// <summary>
			///����������
			/// </summary>
			public virtual string CACHENAME
			{
				get;
				set;
			}

			/// <summary>
			///������������
			/// </summary>
			public virtual string INFLCACHENAME
			{
				get;
				set;
			}

			/// <summary>
			///��Ч��־
			/// </summary>
			public virtual string ISVALID
			{
				get;
				set;
			}

        #endregion
    }

}
