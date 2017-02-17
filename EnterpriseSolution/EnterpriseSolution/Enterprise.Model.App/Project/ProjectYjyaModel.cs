using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// Ӧ��Ԥ��
	/// ������:����������
	/// ����ʱ��:	2013/11/20 11:34:35
    /// </summary>
    [Serializable]
    public class ProjectYjyaModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///Ԥ��ID
			/// </summary>
			public virtual string ID
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
			///��������
			/// </summary>
			public virtual string YLNR
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? YLSJ
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
			///Ԥ������
			/// </summary>
			public virtual string YAFJ
			{
				get;
				set;
			}

			/// <summary>
			///Ӧ��Ԥ��
			/// </summary>
			public virtual string YJYA
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
			///�����ص�
			/// </summary>
			public virtual string YLDD
			{
				get;
				set;
			}

        #endregion
    }

}
