using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// �ɱ��ƻ���
	/// ������:����������
	/// ����ʱ��:	2013-11-7 14:36:27
    /// </summary>
    [Serializable]
    public class ProjectCostplanModel : AppSuperModel
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
			///��Ŀ�ƻ���ID
			/// </summary>
			public virtual string PLANID
			{
				get;
				set;
			}

			/// <summary>
			///���
			/// </summary>
			public virtual decimal AMOUNT
			{
				get;
				set;
			}

        #endregion

            #region ��������

            /// <summary>
            /// �ɱ�����
            /// </summary>
            public virtual Examine.ExamineCostitemModel ExamineCostitem
            {
                get;
                set;
            }

            #endregion
    }

}
