using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Goods
{
    /// <summary>
    /// �豸���ӵ���
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:11
    /// </summary>
    [Serializable]
    public class GoodsDeviceModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�豸��ID
			/// </summary>
			public virtual string SBID
			{
				get;
				set;
			}

			/// <summary>
			///ԭֵ
			/// </summary>
			public virtual decimal? YZ
			{
				get;
				set;
			}

			/// <summary>
			///��λ
			/// </summary>
			public virtual string DW
			{
				get;
				set;
			}

			/// <summary>
			///�豸����
			/// </summary>
			public virtual string SBMC
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? GZRQ
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string CCBH
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? SL
			{
				get;
				set;
			}

			/// <summary>
			///�豸����
			/// </summary>
			public virtual string SBBM
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string KINDID
			{
				get;
				set;
			}

			/// <summary>
			///���쳧��
			/// </summary>
			public virtual string ZZCJ
			{
				get;
				set;
			}

			/// <summary>
			///����ͺ�
			/// </summary>
			public virtual string GGXH
			{
				get;
				set;
			}

        #endregion
    }

}
