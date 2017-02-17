using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// �ɱ�������Ŀ��
	/// ������:����������
	/// ����ʱ��:	2013-11-7 14:36:26
    /// </summary>
    [Serializable]
    public class ExamineCostitemModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�ɱ������
			/// </summary>
			public virtual string ITEMCODE
			{
				get;
				set;
			}

			/// <summary>
			///�ɱ�������
			/// </summary>
			public virtual string ITEMNAME
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///˳���
			/// </summary>
			public virtual int? ITEMORDER
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string ACCORDINGTO
			{
				get;
				set;
			}

        #endregion
    }

}
