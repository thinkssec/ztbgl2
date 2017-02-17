using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ר������
	/// ������:����������
	/// ����ʱ��:	2013/12/1 14:10:59
    /// </summary>
    [Serializable]
    public class ProjectFzzjpsModel : AppSuperModel
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
			///�ĵ�����
			/// </summary>
			public virtual string WDMC
			{
				get;
				set;
			}

			/// <summary>
			///�μ���Ա
			/// </summary>
			public virtual string CJRY
			{
				get;
				set;
			}

			/// <summary>
			///�Ǽ���
			/// </summary>
			public virtual int? DJR
			{
				get;
				set;
			}

			/// <summary>
			///�ĵ�����
			/// </summary>
			public virtual string WDLX
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///����ص�
			/// </summary>
			public virtual string PSDD
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? PSSJ
			{
				get;
				set;
			}

			/// <summary>
			///�Ǽ�����
			/// </summary>
			public virtual DateTime? DJRQ
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
			///������
			/// </summary>
			public virtual string SHYJ
			{
				get;
				set;
			}

        #endregion
    }

}
