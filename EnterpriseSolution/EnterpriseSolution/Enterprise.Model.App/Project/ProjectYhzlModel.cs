using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ���������
	/// ������:����������
	/// ����ʱ��:	2013/11/20 11:34:34
    /// </summary>
    [Serializable]
    public class ProjectYhzlModel : AppSuperModel
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
			///Ӧ����ʩ
			/// </summary>
			public virtual string YJCS
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? YSSJ
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string ZRY
			{
				get;
				set;
			}

			/// <summary>
			///�������ʱ��
			/// </summary>
			public virtual DateTime? WCZGSJ
			{
				get;
				set;
			}

			/// <summary>
			///��״������
			/// </summary>
			public virtual string XZJWT
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
			///��������
			/// </summary>
			public virtual string YHMC
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ�����ʱ��
			/// </summary>
			public virtual DateTime? JHZGSJ
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
