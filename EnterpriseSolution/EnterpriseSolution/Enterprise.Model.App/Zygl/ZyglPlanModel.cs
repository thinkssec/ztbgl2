using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Zygl
{
    /// <summary>
    /// ��ҵ����������
	/// ������:����������
	/// ����ʱ��:	2015/5/19 17:09:28
    /// </summary>
    [Serializable]
    public class ZyglPlanModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string ZID
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string JH
			{
				get;
				set;
			}

			/// <summary>
			///��Ԫ����
			/// </summary>
			public virtual string DYQK
			{
				get;
				set;
			}

			/// <summary>
			///��λ
			/// </summary>
			public virtual string CW
			{
				get;
				set;
			}

			/// <summary>
			///�ϴ���ҵʱ��
			/// </summary>
			public virtual DateTime? LASTDATE
			{
				get;
				set;
			}

			/// <summary>
			///�ϴ�ʩ������
			/// </summary>
			public virtual string LSGNR
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual decimal? SCZQ
			{
				get;
				set;
			}

			/// <summary>
			///������ҵԭ��
			/// </summary>
			public virtual string ZYYY
			{
				get;
				set;
			}

			/// <summary>
			///ʩ������
			/// </summary>
			public virtual string SGNR
			{
				get;
				set;
			}

			/// <summary>
			///��ҵ����
			/// </summary>
			public virtual string ZYFL
			{
				get;
				set;
			}

			/// <summary>
			///��ʩ���
			/// </summary>
			public virtual string CSLB
			{
				get;
				set;
			}

			/// <summary>
			///���뿪������
			/// </summary>
			public virtual DateTime? PSTARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ��깤����
			/// </summary>
			public virtual DateTime? PENDDATE
			{
				get;
				set;
			}

			/// <summary>
			///Ԥ���
			/// </summary>
			public virtual decimal? YSE
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
			///
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SUBMITDATE
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SHSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SHTIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SHCONTENT
			{
				get;
				set;
			}

			/// <summary>
			///-1:��ʱ����     0���ύ���  1��ͨ�� 2����ͨ�� 3���깤4���깤���� 5������
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? STARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? ENDDATE
			{
				get;
				set;
			}

        #endregion
    }

}
