using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Dmgl
{
    /// <summary>
    /// ����ά�޼ƻ�����
	/// ������:����������
	/// ����ʱ��:	2015/5/18 9:37:38
    /// </summary>
    [Serializable]
    public class DmglPlanModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string PID
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ���1
			/// </summary>
			public virtual string PKIND1
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ���2
			/// </summary>
			public virtual string PKIND2
			{
				get;
				set;
			}

			/// <summary>
			///��ϸ
			/// </summary>
			public virtual string MX
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string MS
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ�����
			/// </summary>
			public virtual decimal? PDJ
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ�����
			/// </summary>
			public virtual int? PSL
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ���ʼʱ��
			/// </summary>
			public virtual DateTime? PSTARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ�����ʱ��
			/// </summary>
			public virtual DateTime? PENDDATE
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
			///
			/// </summary>
			public virtual int? SPR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SPSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SPTIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPCONTENT
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ��ʼʱ��
			/// </summary>
			public virtual DateTime? CSTARTDATE
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ����ʱ��
			/// </summary>
			public virtual DateTime? CENDDATE
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
			///����ʱ��
			/// </summary>
			public virtual DateTime? CREATETIME
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ����
			/// </summary>
			public virtual decimal? PAMOUNT
			{
				get;
				set;
			}

			/// <summary>
			///ʵ�ʽ���ʱ��
			/// </summary>
			public virtual DateTime? ENDDATE
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
			///��Ҫ�쵼
			/// </summary>
			public virtual int? SPR2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP2STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SP2TIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SP2CONTENT
			{
				get;
				set;
			}

			/// <summary>
			///ʵ�ʿ�ʼʱ��
			/// </summary>
			public virtual DateTime? STARTDATE
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
			///ʩ����������
			/// </summary>
			public virtual string FNAMES2
			{
				get;
				set;
			}

			/// <summary>
			///ʩ�����ȸ�����������
			/// </summary>
			public virtual string FVIEWNAMES2
			{
				get;
				set;
			}

			/// <summary>
			///���̱��
			/// </summary>
			public virtual string GCBH
			{
				get;
				set;
			}

			/// <summary>
			///���̵ص�
			/// </summary>
			public virtual string GCDD
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string GCNR
			{
				get;
				set;
			}

			/// <summary>
			///���̱�ע
			/// </summary>
			public virtual string GCBZ
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string FNAMES3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string FVIEWNAMES3
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual decimal? JSJE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? JSRQ
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? JSR
			{
				get;
				set;
			}

        #endregion
    }

}
