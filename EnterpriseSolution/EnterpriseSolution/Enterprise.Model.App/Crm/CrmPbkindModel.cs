using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// �ҷ���λ����
	/// ������:����������
	/// ����ʱ��:	2014/3/31 17:16:03
    /// </summary>
    [Serializable]
    public class CrmPbkindModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�����
			/// </summary>
			public virtual string LBBH
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string LBMC
			{
				get;
				set;
			}

			/// <summary>
			///�ϼ����
			/// </summary>
			public virtual string SJLB
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? LBXH
			{
				get;
				set;
			}

        #endregion
    }

}
