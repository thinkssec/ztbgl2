using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ�ڵ�ƻ������б�
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:23
    /// </summary>
    [Serializable]
    public class ProjectRunningModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��ĿID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ����
			/// </summary>
			public virtual string NODECODE
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ����ʱ��
			/// </summary>
			public virtual DateTime? PFDATE
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ���
			/// </summary>
			public virtual string NODEBH
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�Ȩֵ
			/// </summary>
			public virtual int? NODEVALUE
			{
				get;
				set;
			}

			/// <summary>
			///�ؼ��ڵ�
			/// </summary>
			public virtual int? KEYNODE
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�����
			/// </summary>
			public virtual string NODENAME
			{
				get;
				set;
			}

			/// <summary>
			///����״̬
            ///Ϊ��=�ڵ�δ�ͷ� 0=δ���� 1=������
			/// </summary>
			public virtual int? RUNSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///ʵ�����ʱ��
			/// </summary>
			public virtual DateTime? AFDATE
			{
				get;
				set;
			}

        #endregion
    }

}
