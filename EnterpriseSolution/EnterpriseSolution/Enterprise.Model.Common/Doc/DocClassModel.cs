using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Doc
{
    /// <summary>
    /// ͨ�����·���ģ��
	/// ������:����������
	/// ����ʱ��:	2013/2/26 15:10:23
    /// </summary>
    [Serializable]
    public class DocClassModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			///����ID
			/// </summary>
			public virtual int CLASSID
			{
				get;
				set;
			}

			/// <summary>
			///����Ȩ�� ���Ϊ�������˶��ܷ���
			/// </summary>
			public virtual string CLASSPUBROLES
			{
				get;
				set;
			}

			/// <summary>
			///�ⲿ����URL
			/// </summary>
			public virtual string CLASSURL
			{
				get;
				set;
			}

			/// <summary>
			///����Ȩ�� ���Ϊ�������˶��ܷ���
			/// </summary>
			public virtual string CLASSVIEWROLES
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? CLASSFLAG
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string CLASSNAME
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? CLASSORDERBY
			{
				get;
				set;
			}

        #endregion
    }

}
