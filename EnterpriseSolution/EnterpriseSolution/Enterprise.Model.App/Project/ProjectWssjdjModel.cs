using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// δ���¼��ǼǱ�
	/// ������:����������
	/// ����ʱ��:	2013/11/20 11:34:31
    /// </summary>
    [Serializable]
    public class ProjectWssjdjModel : AppSuperModel
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
			///��������
			/// </summary>
			public virtual DateTime? FSRQ
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string CLJG
			{
				get;
				set;
			}

			/// <summary>
			///�¼�����
			/// </summary>
			public virtual string SJMS
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
			///�¼�����
			/// </summary>
			public virtual string SJMC
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string ZRR
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
