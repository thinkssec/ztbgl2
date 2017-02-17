using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ���������
	/// ������:����������
	/// ����ʱ��:	2014/6/21 17:32:39
    /// </summary>
    [Serializable]
    public class ProjectZlglModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�ϴ���
			/// </summary>
			public virtual int? SCR
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string ZLNAME
			{
				get;
				set;
			}

			/// <summary>
			///��������ID
			/// </summary>
			public virtual string ZLID
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
			///����
			/// </summary>
			public virtual string ATTACHMENT
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

        #endregion
    }

}
