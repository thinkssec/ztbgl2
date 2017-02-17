using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ�������ı�
	/// ������:����������
	/// ����ʱ��:	2014/6/19 15:35:14
    /// </summary>
    [Serializable]
    public class ProjectMaterialModel : AppSuperModel
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
			///�������:1=�����豸�����,2=�������������Ǳ�,3=��������,4=�칫�豸,5=�칫��Ʒ��Ĳ�,6=�칫�Ҿ�,7=�ͱ���Ʒ,8=������������
			/// </summary>
			public virtual string WLLB
			{
				get;
				set;
			}

			/// <summary>
			///�ܽ��
			/// </summary>
			public virtual decimal? ZJE
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string LYR
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? SL
			{
				get;
				set;
			}

			/// <summary>
			///���ϵ�λ
			/// </summary>
			public virtual string WLDW
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual decimal? DJ
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
			public virtual string WLMC
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
			///��������
			/// </summary>
			public virtual DateTime? LYRQ
			{
				get;
				set;
			}

        #endregion
    }

}
