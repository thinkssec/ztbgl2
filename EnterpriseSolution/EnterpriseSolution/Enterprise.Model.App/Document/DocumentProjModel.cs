using Enterprise.Model.App.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// ҵ���ĵ���
	/// ������:����������
	/// ����ʱ��:	2014/3/6 8:25:02
    /// </summary>
    [Serializable]
    public class DocumentProjModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�ĵ�ID
			/// </summary>
			public virtual string DOCID
			{
				get;
				set;
			}

			/// <summary>
			///������ID
			/// </summary>
			public virtual string ASSOCIATIONID
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ�·��
			/// </summary>
			public virtual string DOCPATH
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ�״̬: 0=�Ѵ浵 1=��ת��  2=������
			/// </summary>
			public virtual int? DOCSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual string LBBH
			{
				get;
				set;
			}

			/// <summary>
			///���ݱ�����
			/// </summary>
			public virtual string TABLENAME
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ�����
			/// </summary>
			public virtual string DOCQUARRY
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ������
			/// </summary>
			public virtual string DOCADDUSER
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ�����
			/// </summary>
			public virtual string DOCNAME
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ�����
			/// </summary>
			public virtual string DOCWRITER
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ�����
			/// </summary>
			public virtual string DOCOVERVIEW
			{
				get;
				set;
			}

			/// <summary>
			///�浵����
			/// </summary>
			public virtual DateTime? DOCSAVEDATE
			{
				get;
				set;
			}

			/// <summary>
			///��ĿID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

        #endregion

            /// <summary>
            /// ��ĿinfoMODEL
            /// </summary>
            public virtual ProjectInfoModel ProjectInfo
            {
                get;
                set;
            }
    }

}
