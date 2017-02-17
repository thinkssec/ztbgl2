using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hse
{
    /// <summary>
    /// ��ȫ����
	/// ������:����������
	/// ����ʱ��:	2015/5/8 7:58:50
    /// </summary>
    [Serializable]
    public class HseSectcheckModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string CKID
			{
				get;
				set;
			}

			/// <summary>
			///�ܼ쵥λ
			/// </summary>
			public virtual string CTARGET
			{
				get;
				set;
			}

			/// <summary>
			///��鼶��
			/// </summary>
			public virtual string CLEVEL
			{
				get;
				set;
			}

			/// <summary>
			///�����Ա����ѡ
			/// </summary>
			public virtual string CHECKER
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? CDATE
			{
				get;
				set;
			}

			/// <summary>
			///�޶��������
			/// </summary>
			public virtual DateTime? ENDDATE
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
			///���Ͷ���1����0������
			/// </summary>
			public virtual int? SMSG
			{
				get;
				set;
			}

			/// <summary>
			///-2: ��ǰ�û���������û����ɵļ�¼ -1:��ʱ���� 0�����ύ��ȫ���� 1���ύ��λ����������
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///ʵ�����ʱ��
			/// </summary>
			public virtual DateTime? COMPLETEDATE
			{
				get;
				set;
			}

			/// <summary>
			///��ȫ����������
			/// </summary>
			public virtual int? RECIEVER
			{
				get;
				set;
			}

			/// <summary>
			///���ص�
			/// </summary>
			public virtual string CWHERE
			{
				get;
				set;
			}

			/// <summary>
			///�����˵�λ������
			/// </summary>
			public virtual int? SHR1
			{
				get;
				set;
			}

			/// <summary>
			///�����ύʱ��
			/// </summary>
			public virtual DateTime? SH1SUBMITIME
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? SH1TIME
			{
				get;
				set;
			}

			/// <summary>
			///���
			/// </summary>
			public virtual int? SH1STATUS
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string SH1CONTENT
			{
				get;
				set;
			}

			/// <summary>
			///��λ��ȫԱ
			/// </summary>
			public virtual int? SHR2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SH2SUBMITIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SH2TIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SH2STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SH2CONTENT
			{
				get;
				set;
			}

			/// <summary>
			///��ȫ�а��� 
			/// </summary>
			public virtual int? SHR3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SH3SUBMITIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SH3TIME
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SH3STATUS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SH3CONTENT
			{
				get;
				set;
			}

        #endregion
    }

}
