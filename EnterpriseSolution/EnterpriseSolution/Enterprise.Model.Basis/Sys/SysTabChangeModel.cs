using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ����ļ�¼
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysTabChangeModel : BasisSuperModel
    {
        #region ����������
        
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
			///������
			/// </summary>
			public virtual int CHANGEID
			{
				get;
				set;
			}

			/// <summary>
			///���ʱ��
			/// </summary>
			public virtual DateTime CHANGETIME
			{
				get;
				set;
			}

        #endregion
    }

}
