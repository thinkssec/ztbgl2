using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Hse
{
    /// <summary>
    /// ��ȫ�����ϸ��
	/// ������:����������
	/// ����ʱ��:	2015/5/7 8:12:54
    /// </summary>
    [Serializable]
    public class HseSectcheckdetlModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string CKDID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string CKID
			{
				get;
				set;
			}

			/// <summary>
			///���ص�
			/// </summary>
			public virtual string CWHERE
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string DETAIL
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string CHARGE
			{
				get;
				set;
			}

			/// <summary>
			///-2: ��ǰ�û���������û����ɵļ�¼ -1:��ʱ���� 0�����ύ��ȫ���� 1���ύ����
			/// </summary>
			public virtual int? STATUS
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
			///�������
			/// </summary>
			public virtual string PRESENT
			{
				get;
				set;
			}

			/// <summary>
			///���ʱ��
			/// </summary>
			public virtual DateTime? COMPLETEDATE
			{
				get;
				set;
			}

			/// <summary>
			///�����ļ�����
			/// </summary>
			public virtual string FNAMES
			{
				get;
				set;
			}

			/// <summary>
			///������������
			/// </summary>
			public virtual string FVIEWNAMES
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? SUBMITTER
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual DateTime? SUBMITDATE
			{
				get;
				set;
			}

        #endregion
    }

}
