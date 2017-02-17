using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Meeting
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/3/1 15:50:38
    /// </summary>
    [Serializable]
    public class MeetingInfoModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
			/// �Զ����
			/// </summary>
			public virtual int MEETINGID
			{
				get;
				set;
			}

			/// <summary>
			///  ����ص�
			/// </summary>
			public virtual string MADDRESS
			{
				get;
				set;
			}

			/// <summary>
			/// ����
			/// </summary>
			public virtual string MCONTENT
			{
				get;
				set;
			}

			/// <summary>
			/// ������
			/// </summary>
			public virtual int? MUSER
			{
				get;
				set;
			}

			/// <summary>
			/// �����ļ�
			/// </summary>
			public virtual string MFILES
			{
				get;
				set;
			}

			/// <summary>
			/// ������
			/// </summary>
			public virtual string MZCR
			{
				get;
				set;
			}

			/// <summary>
			/// ����ʱ��
			/// </summary>
			public virtual DateTime? MCREATETIME
			{
				get;
				set;
			}

			/// <summary>
			/// ������Ա
			/// </summary>
			public virtual string MUSERS
			{
				get;
				set;
			}

			/// <summary>
			/// ��������
			/// </summary>
			public virtual int? MDEPARTMENT
			{
				get;
				set;
			}

			/// <summary>
			///  �������ݶ���
			/// </summary>
			public virtual string MCONTENTRU
			{
				get;
				set;
			}

			/// <summary>
			/// �����������
			/// </summary>
			public virtual string MTITLERU
			{
				get;
				set;
			}

			/// <summary>
			/// ����ʱ��
			/// </summary>
			public virtual DateTime? MTIME
			{
				get;
				set;
			}

			/// <summary>
			/// ��������
			/// </summary>
			public virtual string MTITLE
			{
				get;
				set;
			}

			/// <summary>
			/// ������
			/// </summary>
			public virtual int? MUSERID
			{
				get;
				set;
			}

        #endregion
    }

}
