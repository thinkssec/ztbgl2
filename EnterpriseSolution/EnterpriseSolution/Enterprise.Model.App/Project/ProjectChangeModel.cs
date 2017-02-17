using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ�����¼��
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:13
    /// </summary>
    [Serializable]
    public class ProjectChangeModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��Ŀ���ID
			/// </summary>
			public virtual string CHANGEID
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual int? CHANGETYPE
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? CHANGEDATE
			{
				get;
				set;
			}

			/// <summary>
			///���״̬
			/// </summary>
			public virtual int? AUDITSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///���˵��
			/// </summary>
			public virtual string CHANGEMEMO
			{
				get;
				set;
			}

			/// <summary>
			///���״̬
			/// </summary>
			public virtual int? CHANGESTATUS
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? REQUESTOR
			{
				get;
				set;
			}

			/// <summary>
			///ԭ������
			/// </summary>
			public virtual string OLDCONTS
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string MEMO
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

			/// <summary>
			///�������
			/// </summary>
			public virtual DateTime? AUDITDATE
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string NEWCONTS
			{
				get;
				set;
			}

        #endregion
    }

}
