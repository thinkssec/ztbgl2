using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Goods
{
    /// <summary>
    /// ��������
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:11
    /// </summary>
    [Serializable]
    public class GoodsKindModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�������
			/// </summary>
			public virtual string KINDID
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string KINDNAME
			{
				get;
				set;
			}

        #endregion
    }

}
