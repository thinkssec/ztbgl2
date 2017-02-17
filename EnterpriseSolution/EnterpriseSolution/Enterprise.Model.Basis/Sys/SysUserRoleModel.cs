using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// �û���ɫ��Ӧ��
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:14
    /// </summary>
    [Serializable]
    public class SysUserRoleModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual string RELATIONID
			{
				get;
				set;
			}

			/// <summary>
			///�û����
			/// </summary>
			public virtual int USERID
			{
				get;
				set;
			}

			/// <summary>
			///��ɫ���
			/// </summary>
			public virtual int ROLEID
			{
				get;
				set;
			}

        #endregion
    }

}
