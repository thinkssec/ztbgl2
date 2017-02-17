using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// �û�ְ���Ӧ��ϵ
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:14
    /// </summary>
    [Serializable]
    public class SysUserDutyModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual string UDID
			{
				get;
				set;
			}

			/// <summary>
			///�û����
			/// </summary>
			public virtual int? USERID
			{
				get;
				set;
			}

			/// <summary>
			///ְ����
			/// </summary>
			public virtual int? DUTYID
			{
				get;
				set;
			}

        #endregion
    }

}
