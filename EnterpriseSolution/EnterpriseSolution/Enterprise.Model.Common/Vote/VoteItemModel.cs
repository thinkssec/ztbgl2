using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Vote
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/3/1 10:30:49
    /// </summary>
    [Serializable]
    public class VoteItemModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///  �Զ����
			/// </summary>
			public virtual int VITEMID
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string VITEMTITLE
			{
				get;
				set;
			}

			/// <summary>
			///  ���
			/// </summary>
			public virtual string VITEMCODE
			{
				get;
				set;
			}

			/// <summary>
			/// ˵��
			/// </summary>
			public virtual string VITEMREMARK
			{
				get;
				set;
			}

			/// <summary>
			/// ͶƱ���
			/// </summary>
			public virtual string VID
			{
				get;
				set;
			}

        #endregion
    }

}
