using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Office
{
    /// <summary>
    /// ������ת��
	/// ������:����������
	/// ����ʱ��:	2013-2-27 21:01:28
    /// </summary>
    [Serializable]
    public class OfficeDocumentModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual string ODID
			{
				get;
				set;
			}

			/// <summary>
			///ǩ����Ա
			/// </summary>
			public virtual string ODQSUSERS
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? ODPUBLICTIME
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual string ODCHECKERS
			{
				get;
				set;
			}

			/// <summary>
			///����ժҪ˵��
			/// </summary>
			public virtual string ODCREMARK
			{
				get;
				set;
			}

			/// <summary>
            ///�����Ƿ񷢲� 0=δ���� 1=�ѷ���
			/// </summary>
			public virtual int? ODISPUBLIC
			{
				get;
				set;
			}

			/// <summary>
			///�������� 0����λ��� 1����������
			/// </summary>
			public virtual int? ODTYPEID
			{
				get;
				set;
			}

			/// <summary>
			///���ı���
			/// </summary>
			public virtual string ODCNAME
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string ODFROMUSER
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual string ODFROMTIME
			{
				get;
				set;
			}

			/// <summary>
			///���ı��
			/// </summary>
			public virtual string ODCODE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string ODTYPE
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string ODFILES
			{
				get;
				set;
			}

			/// <summary>
			///���ű��
			/// </summary>
			public virtual int? ODDEPTID
			{
				get;
				set;
			}

			/// <summary>
			///���ı��
			/// </summary>
			public virtual string ODFROMCODE
			{
				get;
				set;
			}

			/// <summary>
			///���ĵ�λ
			/// </summary>
			public virtual string ODFROM
			{
				get;
				set;
			}

			/// <summary>
			///����ժҪ˵��
			/// </summary>
			public virtual string ODRREMARK
			{
				get;
				set;
			}

			/// <summary>
			///���ı���
			/// </summary>
			public virtual string ODRNAME
			{
				get;
				set;
			}

			/// <summary>
			///��Ա���
			/// </summary>
			public virtual int? ODUSERID
			{
				get;
				set;
			}

			/// <summary>
            ///����״̬ 0=δ��� 1=����� 2=��˲�ͨ��
			/// </summary>
			public virtual int? ODSTATE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? ODCREATETIME
			{
				get;
				set;
			}

        #endregion
    }

}
