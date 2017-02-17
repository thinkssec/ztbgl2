using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ����
	/// ������:����������
	/// ����ʱ��:	2015/9/8 23:25:12
    /// </summary>
    [Serializable]
    public class ProjectTpinfoModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///1:�ۺ� 2������ 3������
			/// </summary>
			public virtual int? KINDID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJNUMBER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJNAME
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ����
			/// </summary>
			public virtual decimal? PROJINCOME
			{
				get;
				set;
			}

			/// <summary>
			///�ʽ���Դ
			/// </summary>
			public virtual string ZJLY
			{
				get;
				set;
			}

			/// <summary>
			///�⿪��ʱ��
			/// </summary>
			public virtual DateTime? NKBSJ
			{
				get;
				set;
			}

			/// <summary>
			///�⿪��ص�
			/// </summary>
			public virtual string NKBDD
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PHONE
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string PROJCONTENT
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
			///�������
			/// </summary>
			public virtual DateTime? CHECKDATE
			{
				get;
				set;
			}

			/// <summary>
			///���״̬ 0=δ��� 1=���ͨ�� 2=��˲�ͨ��
			/// </summary>
			public virtual int? CHECKSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ����״̬: -1=��ʱ���棻0�ύ���  1 �����ͨ�� 2����˲�ͨ�� 3:�б��ļ�ͨ��7:׼������ 8 �������  12���б����
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///�б귽ʽ  1:�����б� 2.�����б�
			/// </summary>
			public virtual int? ZBFS
			{
				get;
				set;
			}

			/// <summary>
			///���������
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///���벿��
			/// </summary>
			public virtual int? DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ��������
			/// </summary>
			public virtual string KINDNAME
			{
				get;
				set;
			}

			/// <summary>
			///��Ӫ��������
			/// </summary>
			public virtual int? SPR
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
			///������
			/// </summary>
			public virtual int? RTN
			{
				get;
				set;
			}

			/// <summary>
			///����״̬
			/// </summary>
			public virtual string RTNSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///�ʽ���Դ��ע
			/// </summary>
			public virtual string ZJBZ
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string SQLY
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string SHYJ
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string SPYJ
			{
				get;
				set;
			}

			/// <summary>
			///רҵ���������
			/// </summary>
			public virtual int? SPR2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ2
			{
				get;
				set;
			}

			/// <summary>
			///����/�ƻ��������
			/// </summary>
			public virtual int? SPR3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ3
			{
				get;
				set;
			}

			/// <summary>
			///��Ͷ�����칫�����
			/// </summary>
			public virtual int? SPR4
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ4
			{
				get;
				set;
			}

			/// <summary>
			///�ֹ��쵼����
			/// </summary>
			public virtual int? SPR5
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ5
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SPR6
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string SPYJ6
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SHS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SPS
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP2
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP3
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP4
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP5
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SP6
			{
				get;
				set;
			}

			/// <summary>
			///ҵ����
			/// </summary>
			public virtual int? YWBM
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string NKBSJSTR
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

        #endregion
    }

}
