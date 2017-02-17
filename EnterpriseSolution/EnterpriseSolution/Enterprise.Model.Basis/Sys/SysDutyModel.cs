using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ְ���
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysDutyModel : BasisSuperModel
    {
        #region ����������
        
			/// <summary>
			///�Զ����
			/// </summary>
			public virtual int DUTYID
			{
				get;
				set;
			}

			/// <summary>
			///ְ������
			/// </summary>
			public virtual string DNAME
			{
				get;
				set;
			}

			/// <summary>
			///��ע˵��
			/// </summary>
			public virtual string DREMARK
			{
				get;
				set;
			}

        #endregion
    }

}
