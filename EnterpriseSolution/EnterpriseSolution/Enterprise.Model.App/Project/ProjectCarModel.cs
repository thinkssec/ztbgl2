using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ������
	/// ������:����������
	/// ����ʱ��:	2014/6/19 15:35:13
    /// </summary>
    [Serializable]
    public class ProjectCarModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///CARID
			/// </summary>
			public virtual string CARID
			{
				get;
				set;
			}

			/// <summary>
			///˾��
			/// </summary>
			public virtual string SJ
			{
				get;
				set;
			}

			/// <summary>
			///�ۼ���ʻ���
			/// </summary>
			public virtual int? LJXSLC
			{
				get;
				set;
			}

			/// <summary>
			///��¼����
			/// </summary>
			public virtual DateTime? JLRQ
			{
				get;
				set;
			}

			/// <summary>
			///˵��
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///��¼��
			/// </summary>
			public virtual string JLR
			{
				get;
				set;
			}

			/// <summary>
			///�����Ƿ���
			/// </summary>
			public virtual int? DRSFBY
			{
				get;
				set;
			}

			/// <summary>
			///��̱����
			/// </summary>
			public virtual int? LCBDS
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string CH
			{
				get;
				set;
			}

			/// <summary>
			///�ۼƱ�������
			/// </summary>
			public virtual int? LJBYCS
			{
				get;
				set;
			}

			/// <summary>
			///����״̬�� -1=���� 0=���� 1=�˳� 2=ά�ޱ��� 3=����
			/// </summary>
			public virtual int? CLZT
			{
				get;
				set;
			}

			/// <summary>
			///��ʻ���
			/// </summary>
			public virtual int? XSLC
			{
				get;
				set;
			}

			/// <summary>
			///���ռ�����
			/// </summary>
			public virtual decimal? DRJYL
			{
				get;
				set;
			}

			/// <summary>
			///�����ͺ�
			/// </summary>
			public virtual string CLXH
			{
				get;
				set;
			}

			/// <summary>
			///��ĿID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

        #endregion
    }

}
