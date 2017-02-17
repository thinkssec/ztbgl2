using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Webmail
{
    /// <summary>
    /// �ʼ��ռ���
	/// ������:����������
	/// ����ʱ��:	2013/2/18 9:28:01
    /// </summary>
    [Serializable]
    public class WebmailInboxModel : CommonSuperModel
    {
        
			/// <summary>
			/// MessageID
			/// </summary>
			public virtual string MESSAGEID
			{
				get;
				set;
			}

			/// <summary>
			/// �ʼ�����
			/// </summary>
			public virtual string EMAILCONTENT
			{
				get;
				set;
			}

			/// <summary>
			/// ��ʶ
			/// </summary>
			public virtual int FLAGED
			{
				get;
				set;
			}

			/// <summary>
			/// �Ѷ�
			/// </summary>
			public virtual int READED
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAILSUBJECT
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAILFROM
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAILATTACHMENTS
			{
				get;
				set;
			}

			/// <summary>
			/// ��С
			/// </summary>
			public virtual decimal EMAILSIZE
			{
				get;
				set;
			}

			/// <summary>
			/// ��ɾ��
			/// </summary>
			public virtual int? ISDELETE
			{
				get;
				set;
			}

			/// <summary>
			/// ʱ��
			/// </summary>
			public virtual DateTime EMAILDATE
			{
				get;
				set;
			}

			/// <summary>
			/// �ռ��˵�ַ
			/// </summary>
			public virtual string EMAILTO
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string EMAIL
			{
				get;
				set;
			}

    }

}
