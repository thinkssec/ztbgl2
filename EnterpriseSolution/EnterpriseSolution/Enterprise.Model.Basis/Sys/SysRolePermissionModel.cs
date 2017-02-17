using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ��ɫȨ�ޱ�
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysRolePermissionModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual string RPID
			{
				get;
				set;
			}

			/// <summary>
			///ģ�����
			/// </summary>
			public virtual string MCODE
			{
				get;
				set;
			}

			/// <summary>
			///��ɫ���
			/// </summary>
			public virtual int? ROLEID
			{
				get;
				set;
			}

			/// <summary>
			///Ȩ��ֵ
			/// </summary>
			public virtual int? PERMISSIONVALUE
			{
				get;
				set;
			}

        #endregion
    }

}
