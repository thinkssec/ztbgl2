using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Doc
{
    /// <summary>
    /// ͨ�����²鿴��
	/// ������:����������
	/// ����ʱ��:	2013/2/26 15:10:23
    /// </summary>
    [Serializable]
    public class DocRecevieModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual int RID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? RTIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? RUSERID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? DID
			{
				get;
				set;
			}

        #endregion
    }

}
