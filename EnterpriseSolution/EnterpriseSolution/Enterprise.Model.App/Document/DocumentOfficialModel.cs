using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// ���ı�
	/// ������:����������
	/// ����ʱ��:	2015/4/22 16:23:51
    /// </summary>
    [Serializable]
    public class DocumentOfficialModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string DOCID
			{
				get;
				set;
			}
            public virtual string FNAMES
            {
                get;
                set;
            }
            public virtual string FVIEWNAMES
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
			///��������
			/// </summary>
			public virtual DateTime? RELEASETIME
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? CREATEUSER
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? CREATETIME
			{
				get;
				set;
			}
            public virtual DateTime? RESULTDATE
            {
                get;
                set;
            }

			/// <summary>
			///ǩ���쵼
			/// </summary>
			public virtual int? RECEVIEUSER
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string CONTENT
			{
				get;
				set;
			}

			/// <summary>
			///�а�Ҫ��
			/// </summary>
			public virtual string REQUIREMENT
			{
				get;
				set;
			}

			/// <summary>
			///Ҫ���������
			/// </summary>
			public virtual DateTime? COMPLETEDATE
			{
				get;
				set;
			}

			/// <summary>
			///�а���
			/// </summary>
			public virtual int? ORGANIZER
			{
				get;
				set;
			}

			/// <summary>
			///0:���� 1��ǩ�� 2���ύ�а� 3���ύ�а��� 
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

			/// <summary>
			///1:ͨ�� 2������
			/// </summary>
			public virtual int? SHSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///�а���
			/// </summary>
			public virtual string RESULT
			{
				get;
				set;
			}

			/// <summary>
			///����ˣ�Ĭ��Ϊǩ���쵼
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? SHSJ
			{
				get;
				set;
			}

			/// <summary>
			///��ͨ��ԭ��
			/// </summary>
			public virtual string WHY
			{
				get;
				set;
			}

			/// <summary>
			///������λ
			/// </summary>
			public virtual int? CREATEDEPT
			{
				get;
				set;
			}

        #endregion
    }

}
