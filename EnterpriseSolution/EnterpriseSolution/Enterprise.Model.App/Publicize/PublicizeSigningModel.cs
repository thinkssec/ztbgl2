using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Publicize
{
    /// <summary>
    /// ��������ǩ�ձ�
	/// ������:����������
	/// ����ʱ��:	2014/2/8 10:32:29
    /// </summary>
    [Serializable]
    public class PublicizeSigningModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///ǩ��ID
			/// </summary>
			public virtual string SIGNID
			{
				get;
				set;
			}

			/// <summary>
			///ǩ������
			/// </summary>
			public virtual DateTime? SINGDATE
			{
				get;
				set;
			}

			/// <summary>
			///ǩ����
			/// </summary>
			public virtual int? SIGNUSER
			{
				get;
				set;
			}

			/// <summary>
			///Ͷ��ID
			/// </summary>
			public virtual string PUBID
			{
				get;
				set;
			}

        #endregion
    }

}
