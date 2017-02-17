using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ������־
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:14
    /// </summary>
    [Serializable]
    public class SysVisitLogModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual string VLID
			{
				get;
				set;
			}

			/// <summary>
			///�û����
			/// </summary>
			public virtual int? VLLOGINUSERID
			{
				get;
				set;
			}

			/// <summary>
			///��¼ʱ��
			/// </summary>
			public virtual DateTime? VLLOGINTIME
			{
				get;
				set;
			}

			/// <summary>
			///��¼ip��ַ
			/// </summary>
			public virtual string VLLOGINIP
			{
				get;
				set;
			}

			/// <summary>
			///������url
			/// </summary>
			public virtual string VLURL
			{
				get;
				set;
			}

			/// <summary>
			///ͣ��ʱ��
			/// </summary>
			public virtual int? VLTIMESPAN
			{
				get;
				set;
			}

        #endregion
    }

}
