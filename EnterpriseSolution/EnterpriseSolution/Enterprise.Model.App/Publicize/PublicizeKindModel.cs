using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Publicize
{
    /// <summary>
    /// ������Ŀ��
	/// ������:����������
	/// ����ʱ��:	2014/2/8 10:32:29
    /// </summary>
    [Serializable]
    public class PublicizeKindModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��ĿID
			/// </summary>
			public virtual string LMID
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ��ע
			/// </summary>
			public virtual string LMBZ
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ����
			/// </summary>
			public virtual string LMMC
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ���
			/// </summary>
			public virtual int? LMXH
			{
				get;
				set;
			}

        #endregion
    }

}
