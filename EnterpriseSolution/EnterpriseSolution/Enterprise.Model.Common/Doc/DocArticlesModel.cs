using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Doc
{
    /// <summary>
    /// ͨ������ģ��
	/// ������:����������
	/// ����ʱ��:	2013/2/26 15:10:21
    /// </summary>
    [Serializable]
    public class DocArticlesModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///Id
			/// </summary>
			public virtual int ID
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? PUBDATE
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string TITLE
			{
				get;
				set;
			}

			/// <summary>
			///ͼƬ��Ϣ
			/// </summary>
			public virtual string APIC
			{
				get;
				set;
			}

			/// <summary>
			///�ϴ�����
			/// </summary>
			public virtual string UPLOADFILES
			{
				get;
				set;
			}

			/// <summary>
			///���༭��
			/// </summary>
			public virtual string LASTEDITOR
			{
				get;
				set;
			}

			/// <summary>
			///����ͨ��
			/// </summary>
			public virtual int? PASSED
			{
				get;
				set;
			}

			/// <summary>
			///���
			/// </summary>
			public virtual int? HITS
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string TITLERU
			{
				get;
				set;
			}

			/// <summary>
			///����ID
			/// </summary>
			public virtual int? CLASSID
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string AUTHOR
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string CONTENTS
			{
				get;
				set;
			}

			/// <summary>
			///�ؼ���
			/// </summary>
			public virtual string KEYS
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string CONTENTSRU
			{
				get;
				set;
			}

			/// <summary>
			///�Ƽ����쵼
			/// </summary>
			public virtual int? ATUIJIAN
			{
				get;
				set;
			}

			/// <summary>
			///�����û�(����)
			/// </summary>
			public virtual string RCVEDUSERS
			{
				get;
				set;
			}

			/// <summary>
			///�ö�
			/// </summary>
			public virtual int? ATOP
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? PUBUSER
			{
				get;
				set;
			}

			/// <summary>
			///��Դ
			/// </summary>
			public virtual string ARTICLEFROM
			{
				get;
				set;
			}

        #endregion
    }

}
