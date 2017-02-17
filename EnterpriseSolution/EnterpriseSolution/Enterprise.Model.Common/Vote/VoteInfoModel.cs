using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Vote
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/3/1 10:30:48
    /// </summary>
    [Serializable]
    public class VoteInfoModel : CommonSuperModel
    {
        #region ����������
        
			/// <summary>
           ///  �Զ����
			/// </summary>
			public virtual string VID
			{
				get;
				set;
			}

			/// <summary>
			///  ��Сֵ
			/// </summary>
			public virtual int? VMIX
			{
				get;
				set;
			}

			/// <summary>
			///  ��ע
			/// </summary>
			public virtual string VREMARK
			{
				get;
				set;
			}

			/// <summary>
			///  ���ֵ
			/// </summary>
			public virtual int? VMAX
			{
				get;
				set;
			}

			/// <summary>
			///  �Ƿ񷢲�
			/// </summary>
			public virtual int? VPUBLIC
			{
				get;
				set;
			}

			/// <summary>
			///  ����
			/// </summary>
			public virtual string VTITLE
			{
				get;
				set;
			}

			/// <summary>
			/// ������
			/// </summary>
			public virtual int? VCREATEUSER
			{
				get;
				set;
			}

			/// <summary>
			///  ����ʱ��
			/// </summary>
			public virtual DateTime? VENDTIME
			{
				get;
				set;
			}

			/// <summary>
			///  ����ʱ��
			/// </summary>
			public virtual DateTime? VPUBLICTIME
			{
				get;
				set;
			}

			/// <summary>
			///  ��Χ
			/// </summary>
			public virtual string VRANGE
			{
				get;
				set;
			}

			/// <summary>
			/// ����ʱ��
			/// </summary>
			public virtual DateTime? VCREATETIME
			{
				get;
				set;
			}

			/// <summary>
			///  ����
			/// </summary>
			public virtual int? VTYPE
			{
				get;
				set;
			}

        #endregion
    }

}
