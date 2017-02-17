using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��ͼ�߻�
	/// ������:����������
	/// ����ʱ��:	2013/12/1 14:10:57
    /// </summary>
    [Serializable]
    public class ProjectFzstchModel : AppSuperModel
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
			///��ͼ״̬:0=δ��� 1=�����
			/// </summary>
			public virtual int? STZT
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string BJDM
			{
				get;
				set;
			}

			/// <summary>
			///ͼֽ����
			/// </summary>
			public virtual string TZMC
			{
				get;
				set;
			}

			/// <summary>
			///���
			/// </summary>
			public virtual string BC
			{
				get;
				set;
			}

			/// <summary>
			///Ԥ�����ʱ��
			/// </summary>
			public virtual DateTime? YJWCSJ
			{
				get;
				set;
			}

			/// <summary>
			///��ͼ��
			/// </summary>
			public virtual int? STR
			{
				get;
				set;
			}

			/// <summary>
			///�ۺ�1#ͼֽ��
			/// </summary>
            public virtual decimal? ZHTZL
			{
				get;
				set;
			}

			/// <summary>
			///ʵ�����ʱ��
			/// </summary>
			public virtual DateTime? SJWCSJ
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string DAH
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
