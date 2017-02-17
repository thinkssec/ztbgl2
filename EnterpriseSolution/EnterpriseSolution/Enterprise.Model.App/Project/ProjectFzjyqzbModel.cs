using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ����ǰ׼��
	/// ������:����������
	/// ����ʱ��:	2013/12/1 14:10:54
    /// </summary>
    [Serializable]
    public class ProjectFzjyqzbModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///���鵥��
			/// </summary>
			public virtual string BYDH
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string JZLX
			{
				get;
				set;
			}

			/// <summary>
			///�����Ա
			/// </summary>
			public virtual int? SCR
			{
				get;
				set;
			}

			/// <summary>
			///��ע
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? JYRQ
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ�����
			/// </summary>
			public virtual int? SFLC
			{
				get;
				set;
			}

			/// <summary>
			///�ļ�����
			/// </summary>
			public virtual string WJLX
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
    }

}
