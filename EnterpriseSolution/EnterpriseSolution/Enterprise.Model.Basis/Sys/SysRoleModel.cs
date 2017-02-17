using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ��ɫ��
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysRoleModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual int RID
			{
				get;
				set;
			}

			/// <summary>
			///��ɫ����
			/// </summary>
			public virtual string RNAME
			{
				get;
				set;
			}

			/// <summary>
			///��ɫ����
			/// </summary>
			public virtual string RTYPE
			{
				get;
				set;
			}

			/// <summary>
			///��ɫ��ע
			/// </summary>
			public virtual string RREMARK
			{
				get;
				set;
			}

        #endregion
    }

}
