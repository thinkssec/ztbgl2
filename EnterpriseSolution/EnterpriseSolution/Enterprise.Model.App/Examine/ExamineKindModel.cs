using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// �������ͱ�
	/// ������:����������
	/// ����ʱ��:	2013-11-8 14:53:57
    /// </summary>
    [Serializable]
    public class ExamineKindModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��������ID
			/// </summary>
			public virtual int KINDID
			{
				get;
				set;
			}

			/// <summary>
			///ҵ���������
			/// </summary>
			public virtual int? DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///�ϼ�����ID
			/// </summary>
			public virtual int? PARENTID
			{
				get;
				set;
			}

			/// <summary>
			///�㼶˳��
			/// </summary>
			public virtual string KINDORDER
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string KINDNAME
			{
				get;
				set;
			}

        #endregion
    }

}
