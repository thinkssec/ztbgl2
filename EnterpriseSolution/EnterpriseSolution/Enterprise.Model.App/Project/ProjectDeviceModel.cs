using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ�豸��
	/// ������:����������
	/// ����ʱ��:	2014/6/19 15:35:19
    /// </summary>
    [Serializable]
    public class ProjectDeviceModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�豸ID
			/// </summary>
			public virtual string DEVID
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string BGR
			{
				get;
				set;
			}

			/// <summary>
			///��¼����
			/// </summary>
			public virtual DateTime? JLRQ
			{
				get;
				set;
			}

			/// <summary>
			///˵��
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///��¼��
			/// </summary>
			public virtual string JLR
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual int? SBSL
			{
				get;
				set;
			}

			/// <summary>
			///�ۼ�����Сʱ
			/// </summary>
			public virtual int? LJYXSJ
			{
				get;
				set;
			}

			/// <summary>
			///�춨����
			/// </summary>
			public virtual string JDZQ
			{
				get;
				set;
			}

			/// <summary>
			///�ͺ�
			/// </summary>
			public virtual string SBXH
			{
				get;
				set;
			}

			/// <summary>
			///����״̬
			/// </summary>
			public virtual string YXZT
			{
				get;
				set;
			}

			/// <summary>
			///����Сʱ
			/// </summary>
			public virtual int? YXSJ
			{
				get;
				set;
			}

			/// <summary>
            ///�豸״̬�� -1=���� 0=���� 1=���� 2=ά�ޱ��� 3=����
			/// </summary>
			public virtual int? SBZT
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
