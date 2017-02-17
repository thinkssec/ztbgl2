using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Zygl
{
    /// <summary>
    /// �깤����
	/// ������:����������
	/// ����ʱ��:	2015/5/28 17:52:44
    /// </summary>
    [Serializable]
    public class ZyglWgysModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string WID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string ZID
			{
				get;
				set;
			}

			/// <summary>
			///ʩ����λ
			/// </summary>
			public virtual string SGDW
			{
				get;
				set;
			}

			/// <summary>
			///ʩ���ֳ�����
			/// </summary>
			public virtual string SGXCMS
			{
				get;
				set;
			}

			/// <summary>
			///Ԥ�Ʒ����ܼ�
			/// </summary>
			public virtual decimal? YJFYZJ
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual decimal? LWF
			{
				get;
				set;
			}

			/// <summary>
			///�͹�
			/// </summary>
			public virtual decimal? YG
			{
				get;
				set;
			}

			/// <summary>
			///���͸�
			/// </summary>
			public virtual decimal? CYG
			{
				get;
				set;
			}

			/// <summary>
			///��
			/// </summary>
			public virtual decimal? BENG
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual decimal? FGQ
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual decimal? QT
			{
				get;
				set;
			}

			/// <summary>
			///��׷�
			/// </summary>
			public virtual decimal? SKF
			{
				get;
				set;
			}

			/// <summary>
			///��ѹ��
			/// </summary>
			public virtual decimal? CYF
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual decimal? HGL
			{
				get;
				set;
			}

			/// <summary>
			///��ˮ��
			/// </summary>
			public virtual decimal? ZSF
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual decimal? JSFW
			{
				get;
				set;
			}

			/// <summary>
			///�����ļ�����
			/// </summary>
			public virtual string FNAMES
			{
				get;
				set;
			}

			/// <summary>
			///������������
			/// </summary>
			public virtual string FVIEWNAMES
			{
				get;
				set;
			}

			/// <summary>
			///-2:��ʱ����
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

        #endregion
    }

}
