using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Zygl
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2015/5/28 17:52:44
    /// </summary>
    [Serializable]
    public class ZyglWgqtfyModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string QID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string MC
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual decimal? JE
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string WID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string FJMC
			{
				get;
				set;
			}

        #endregion
    }

}
