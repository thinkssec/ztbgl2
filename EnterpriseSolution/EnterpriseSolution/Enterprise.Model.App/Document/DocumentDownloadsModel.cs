using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// �ĵ���������ؼ�¼��
	/// ������:����������
	/// ����ʱ��:	2014/3/6 8:25:00
    /// </summary>
    [Serializable]
    public class DocumentDownloadsModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��¼ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///�û�����
			/// </summary>
			public virtual string USERNAME
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? DOWNLOADDATE
			{
				get;
				set;
			}

			/// <summary>
			///�û�ID
			/// </summary>
			public virtual int? USERID
			{
				get;
				set;
			}

			/// <summary>
			///���ʱ��
			/// </summary>
			public virtual DateTime? LOOKUPDATE
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ�ID
			/// </summary>
			public virtual string DOCID
			{
				get;
				set;
			}

			/// <summary>
			///IP��ַ
			/// </summary>
			public virtual string IPADDR
			{
				get;
				set;
			}

        #endregion
    }

}
